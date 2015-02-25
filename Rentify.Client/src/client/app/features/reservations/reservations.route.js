(function () {
    'use strict';

    angular
        .module('app.reservations')
        .run(appRun);

    appRun.$inject = ['routerHelper'];
    /* @ngInject */
    function appRun(routerHelper) {
        routerHelper.configureStates(getStates());
    }

    function getStates() {
        return [
            {
                state: 'reservations',
                config: {
                    url: '/reservations',
                    templateUrl: 'app/features/reservations/reservations.html',
                    //controller: 'ReservationsController',
                    //controllerAs: 'vm',
                    title: 'Reservations',
                    settings: {
                        nav: 2,
                        content: '<i class="fa fa-calendar"></i> Reservations'
                    }
                }
            }
        ];
    }
})();
