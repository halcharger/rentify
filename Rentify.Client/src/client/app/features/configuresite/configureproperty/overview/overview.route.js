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
                state: 'configuresite.configureproperty.overview',
                config: {
                    url: '/overview',
                    templateUrl: 'app/features/configuresite/configureproperty/overview/overview.html',
                    controller: 'OverviewController',
                    controllerAs: 'vm',
                    title: 'Overview',
                    settings: {
                        configurePropertyNav: 1
                    }
                }
            }
        ];
    }
})();
