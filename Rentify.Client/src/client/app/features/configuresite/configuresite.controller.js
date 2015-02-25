(function () {
    'use strict';

    angular
        .module('app.configuresite')
        .controller('ConfigureSiteController', ConfigureSiteController);

    ConfigureSiteController.$inject = ['$state', 'routerHelper'];

    function ConfigureSiteController($state, routerHelper) {
        var vm = this;
        var states = routerHelper.getStates();
        vm.isCurrent = isCurrent;

        activate();

        function activate() { getNavRoutes(); }

        function getNavRoutes() {
            vm.navRoutes = states.filter(function (r) {
                return r.settings && r.settings.configureSiteNav;
            }).sort(function (r1, r2) {
                return r1.settings.configureSiteNav - r2.settings.configureSiteNav;
            });
            console.log('navRoutes: ', vm.navRoutes);
        }

        function isCurrent(route) {
            if (!route.title || !$state.current || !$state.current.title) {
                return '';
            }
            var menuName = route.title;
            return $state.current.title.substr(0, menuName.length) === menuName ? 'active' : '';
        }
    }
})();
