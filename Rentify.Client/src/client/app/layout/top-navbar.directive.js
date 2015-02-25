(function () {
    'use strict';

    angular
        .module('app.layout')
        .directive('topNavBar', topNavBar);

    /* @ngInject */
    function topNavBar() {
        var directive = {
            bindToController: true,
            controller: TopNavController,
            controllerAs: 'vm',
            restrict: 'EA',
            scope: {
                'navline': '='
            },
            templateUrl: 'app/layout/top-navbar.html'
        };

        /* @ngInject */
        TopNavController.$inject = ['$state', '$location', 'routerHelper', 'logger', 'authService'];
        function TopNavController($state, $location, routerHelper, logger, authService) {
            var vm = this;
            var states = routerHelper.getStates();
            vm.isCurrent = isCurrent;
            vm.loggedInUser = authService.authentication.userName;

            activate();

            function activate() { getNavRoutes(); }

            function getNavRoutes() {
                vm.navRoutes = states.filter(function (r) {
                    return r.settings && r.settings.nav;
                }).sort(function (r1, r2) {
                    return r1.settings.nav - r2.settings.nav;
                });
            }

            function isCurrent(route) {
                if (!route.title || !$state.current || !$state.current.title) {
                    return '';
                }
                var menuName = route.title;
                return $state.current.title.substr(0, menuName.length) === menuName ? 'current' : '';
            }

            vm.logOut = function () {
                authService.logOut();
                $location.path('/login');
            };
        }

        return directive;
    }
})();
