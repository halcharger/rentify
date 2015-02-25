(function () {
    'use strict';

    angular
        .module('app.configuresite')
        .controller('ConfigurePropertyController', Controller);

    Controller.$inject = ['$state', 'routerHelper'];

    function Controller($state, routerHelper) {
        var vm = this;
        var states = routerHelper.getStates();
        vm.isCurrent = isCurrent;

        activate();

        function activate() { getNavRoutes(); }

        function getNavRoutes() {
            vm.navRoutes = states.filter(function (r) {
                return r.settings && r.settings.configurePropertyNav;
            }).sort(function (r1, r2) {
                return r1.settings.configurePropertyNav - r2.settings.configurePropertyNav;
            });
        }

        function isCurrent(route) {
            if (!route.title || !$state.current || !$state.current.title) {
                return '';
            }
            var menuName = route.name;
            return $state.current.name.substr(0, menuName.length) === menuName ? 'active' : '';
        }
    }
})();
