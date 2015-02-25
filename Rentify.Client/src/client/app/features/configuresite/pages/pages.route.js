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
                state: 'configuresite.pages',
                config: {
                    url: '/configuresite.pages',
                    templateUrl: 'app/features/configuresite/pages/pages.html',
                    //controller: 'PagesController',
                    //controllerAs: 'vm',
                    title: 'Pages',
                    settings: {
                        configureSiteNav: 3
                    }
                }
            }
        ];
    }
})();
