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
                state: 'configuresite',
                config: {
                    url: '/configuresite/{siteUniqueId}',
                    templateUrl: 'app/features/configuresite/configuresite.html',
                    controller: 'ConfigureSiteController',
                    controllerAs: 'vm',
                    redirectTo: 'configuresite.theme',
                    resolve: {
                        siteUniqueId: ['$stateParams', function ($stateParams) {
                            return $stateParams.siteUniqueId;
                        }]
                    }
                }
            }
        ];
    }
})();
