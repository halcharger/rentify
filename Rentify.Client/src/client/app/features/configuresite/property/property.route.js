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
                state: 'configuresite.property',
                config: {
                    url: '/configuresite.property',
                    templateUrl: 'app/features/configuresite/property/property.html',
                    //controller: 'PropertyController',
                    //controllerAs: 'vm',
                    title: 'Property Details',
                    settings: {
                        configureSiteNav: 2
                    }
                }
            }
        ];
    }
})();
