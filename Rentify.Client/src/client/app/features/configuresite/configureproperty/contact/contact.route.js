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
                state: 'configuresite.configureproperty.contact',
                config: {
                    url: '/contact',
                    templateUrl: 'app/features/configuresite/configureproperty/contact/contact.html',
                    controller: 'ContactController',
                    controllerAs: 'vm',
                    title: 'Contact',
                    settings: {
                        configurePropertyNav: 5
                    }
                }
            }
        ];
    }
})();
