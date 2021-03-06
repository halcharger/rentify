﻿(function () {
    'use strict';

    angular
        .module('app.services')
        .factory('authInterceptorService', auth);

    auth.$inject = ['$rootScope', '$q', '$location', '$injector', 'localStorageService'];

    function auth($rootScope, $q, $location, $injector, localStorageService) {
        var authInterceptorServiceFactory = {};
        var $http;

        function broadcastFriendlyErrorMessage(rejection) {
            /*jshint maxcomplexity:false */
            console.log('global generic error handler: rejection:', rejection);
            var msg = '<p>We are sorry but you experienced an unexpected error. ' +
                'We have done all we can to notify the right people so all you can do right now is try again.</p>';

            //the case where the client cannot connect to the server
            if (!rejection.data && rejection.status === 0 && rejection.statusText === '') {
                msg = 'Unable to connect to the server, please try again in a couple of seconds.';
            }
            else if (rejection.status === 400) {
                //the case where we push a custom error description down the wire
                if (rejection.data && rejection.data.error_description) {// jshint ignore:line
                    msg = rejection.data.error_description;// jshint ignore:line
                }
                    //the case where asp.net modelstate errors come down the wire
                else if (rejection.data && rejection.data.message === 'The request is invalid.' &&
                            rejection.data.modelState) {
                    var errors = [];
                    for (var key in rejection.data.modelState) {
                        if (rejection.data.modelState.hasOwnProperty(key)) {
                            for (var i = 0; i < rejection.data.modelState[key].length; i++) {
                                errors.push(rejection.data.modelState[key][i]);
                            }
                        }
                    }
                    msg = '<strong>Failed to save changes due to:</strong><BR/>' + errors.join('<br/>');
                }
                else if (rejection.data && rejection.data.message) {
                    msg = rejection.data.message;
                }
            }
            else if (rejection.status === 500) {
                if (rejection.data.exceptionMessage) {
                    msg = msg + '<p><strong>Exception Type:</strong></p><p>' + rejection.data.exceptionType + '</p>';
                }
            }

            $rootScope.$broadcast('globalErrorEvent', msg);
        }

        var _request = function (config) {
            config = config || {};
            config.headers = config.headers || {};

            var authData = localStorageService.get('authorizationData');
            if (authData) {
                config.headers.Authorization = 'Bearer ' + authData.token;
            }

            $rootScope.$broadcast('globalClearErrorEvent');

            return config;
        };

        var _responseError = function (rejection) {
            var deferred = $q.defer();
            if (rejection.status === 401) {
                var authService = $injector.get('authService');
                authService.refreshToken().then(function () {
                    _retryHttpRequest(rejection.config, deferred);
                }, function (httpData) {
                    console.log('failed to refresh token: ', httpData);
                    authService.logOut();
                    $location.path('/login');
                    deferred.reject(rejection);
                });
            }
            else {
                //generic error handling logic goes here
                broadcastFriendlyErrorMessage(rejection);
                deferred.reject(rejection);
            }
            return deferred.promise;
        };

        var _retryHttpRequest = function (config, deferred) {
            $http = $http || $injector.get('$http');
            $http(config).then(function (response) {
                deferred.resolve(response);
            }, function (response) {
                deferred.reject(response);
            });
        };

        authInterceptorServiceFactory.request = _request;
        authInterceptorServiceFactory.responseError = _responseError;

        return authInterceptorServiceFactory;
    }
})();
