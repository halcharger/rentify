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
                state: 'configuresite.settings',
                config: {
                    url: '/configuresite.settings',
                    templateUrl: 'app/features/configuresite/settings/settings.html',
                    //controller: 'SettingsController',
                    //controllerAs: 'vm',
                    title: 'Settings',
                    settings: {
                        configureSiteNav: 4
                    }
                }
            }
        ];
    }
})();
