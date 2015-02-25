(function() {
    'use strict';

    angular
        .module('app.layout')
        .controller('ShellController', Controller);

    Controller.$inject = ['$state', '$location', 'routerHelper', 'logger', 'authService', 'environment'];

    function Controller($state, $location, routerHelper, logger, authService, environment) {
        var vm = this;
        var states = routerHelper.getStates();
        vm.isCurrent = isCurrent;
        vm.loggedInUser = authService.authentication.userName;
        vm.environment = environment;

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
            var menuName = route.name;
            var cssClass = $state.current.name.substr(0, menuName.length) === menuName ? 'current' : '';
            return cssClass;
        }

        vm.logOut = function () {
            authService.logOut();
            $location.path('/login');
        };
    }
})();
