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
                state: 'configuresite.theme',
                config: {
                    url: '/configuresite.theme',
                    templateUrl: 'app/features/configuresite/theme/theme.html',
                    //controller: 'ThemeController',
                    //controllerAs: 'vm',
                    title: 'Theme & Styling',
                    settings: {
                        configureSiteNav: 1
                    }
                }
            }
        ];
    }
})();
