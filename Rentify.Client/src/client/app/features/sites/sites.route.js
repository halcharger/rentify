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
                state: 'sites',
                config: {
                    url: '/sites',
                    templateUrl: 'app/features/sites/sites.html',
                    controller: 'SitesController',
                    controllerAs: 'vm',
                    title: 'My Sites',
                    settings: {
                        nav: 2,
                        content: '<i class="fa fa-lock"></i> Sites'
                    }
                }
            }
        ];
    }
})();
