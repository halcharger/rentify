﻿(function () {
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
                state: 'configuresite',
                config: {
                    url: '/configuresite',
                    templateUrl: 'app/features/configuresite/configuresite.html',
                    controller: 'ConfigureSiteController',
                    controllerAs: 'vm',
                    redirectTo: 'configuresite.theme'
                }
            }
        ];
    }
})();
