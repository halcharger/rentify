(function () {
    'use strict';

    angular
        .module('app.configuresite')
        .controller('ConfigureSiteController', Controller);

    Controller.$inject = ['$state', '$stateParams', 'routerHelper'];

    function Controller($state, $stateParams, routerHelper) {
        var states = routerHelper.getStates();
        console.log('configuresite param siteUniqueId: ' + $stateParams.siteUniqueId);

        var vm = this;
        vm.isCurrent = isCurrent;

        activate();

        function activate() { getNavRoutes(); }

        function getNavRoutes() {
            vm.navRoutes = states.filter(function (r) {
                return r.settings && r.settings.configureSiteNav;
            }).sort(function (r1, r2) {
                return r1.settings.configureSiteNav - r2.settings.configureSiteNav;
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
