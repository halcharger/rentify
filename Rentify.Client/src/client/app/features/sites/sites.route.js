(function () {
    'use strict';

    angular
        .module('app.sites')
        .run(appRun);

    appRun.$inject = ['routerHelper'];
    /* @ngInject */
    function appRun(routerHelper) {
        routerHelper.configureStates(getStates());
    }

    function getStates() {
        return [
            {
                state: 'default',
                config: {
                    url: '/',
                    templateUrl: 'app/features/sites/sites.html',
                    controller: 'SitesController',
                    controllerAs: 'vm',
                    title: 'My Sites'
                }
            },
            {
                state: 'sites',
                config: {
                    url: '/sites',
                    templateUrl: 'app/features/sites/sites.html',
                    controller: 'SitesController',
                    controllerAs: 'vm',
                    title: 'My Sites',
                    settings: {
                        nav: 1,
                        content: '<i class="fa fa-globe"></i> Sites'
                    }
                }
            }
        ];
    }
})();
