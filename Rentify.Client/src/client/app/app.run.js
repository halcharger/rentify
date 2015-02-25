(function () {
    'use strict';

    angular.module('app')
        .run(['authService', function (authService) {
            authService.fillAuthData();
        }]);

    angular.module('app')
        .run(['$rootScope', '$state', function($rootScope, $state) {
            $rootScope.$on('$stateChangeStart', function(evt, to, params) {
                if (to.redirectTo) {
                    evt.preventDefault();
                    $state.go(to.redirectTo, params);
                }
            });
        }]);

})();
