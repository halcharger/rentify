(function () {
    'use strict';

    angular
        .module('app.configuresite')
        .run(appRun);

    appRun.$inject = ['routerHelper'];

    function appRun(routerHelper) {
        routerHelper.configureStates(getStates());
    }

    function getStates() {
        return [
            {
                state: 'configuresite.configureproperty',
                config: {
                    url: '/configureproperty',
                    templateUrl: 'app/features/configuresite/configureproperty/configureproperty.html',
                    controller: 'ConfigurePropertyController',
                    controllerAs: 'vm',
                    redirectTo: 'configuresite.configureproperty.overview',
                    title: 'Property Details',
                    settings: {
                        configureSiteNav: 2
                    }
                }
            }
        ];
    }
})();
