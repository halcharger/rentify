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
                state: 'configuresite.configureproperty.reviews',
                config: {
                    url: '/reviews',
                    templateUrl: 'app/features/configuresite/configureproperty/reviews/reviews.html',
                    //controller: 'ReviewsController',
                    //controllerAs: 'vm',
                    title: 'Reviews',
                    settings: {
                        configurePropertyNav: 6
                    }
                }
            }
        ];
    }
})();
