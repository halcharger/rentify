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
                state: 'configuresite.configureproperty.rates',
                config: {
                    url: '/rates',
                    templateUrl: 'app/features/configuresite/configureproperty/rates/rates.html',
                    //controller: 'RatesController',
                    //controllerAs: 'vm',
                    title: 'Rates',
                    settings: {
                        configurePropertyNav: 4
                    }
                }
            }
        ];
    }
})();
