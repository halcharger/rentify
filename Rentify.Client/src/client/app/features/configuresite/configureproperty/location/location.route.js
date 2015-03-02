(function () {
    'use strict';

    angular
        .module('app.configuresite')
        .run(appRun);

    appRun.$inject = ['routerHelper'];
    /* @ngInject */
    function appRun(routerHelper) {
        routerHelper.configureStates(getStates());
    }

    function getStates() {
        return [
            {
                state: 'configuresite.configureproperty.location',
                config: {
                    url: '/location',
                    templateUrl: 'app/features/configuresite/configureproperty/location/location.html',
                    controller: 'LocationController',
                    controllerAs: 'vm',
                    title: 'Location',
                    settings: {
                        configurePropertyNav: 2
                    }
                }
            }
        ];
    }
})();
