(function () {
    'use strict';

    angular
        .module('app.configuresite')
        .controller('ConfigureSiteController', Controller);

    Controller.$inject = ['$state', '$stateParams', 'routerHelper', 'sitesService'];

    function Controller($state, $stateParams, routerHelper, sitesService) {
        var states = routerHelper.getStates();
        var siteUniqueId = $stateParams.siteUniqueId;

        var vm = this;
        vm.isCurrent = isCurrent;
        vm.site = {};

        activate();

        function activate() {
            getNavRoutes();
            sitesService.getSite(siteUniqueId).then(function(result) {
                vm.site = result;
            });
        }

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
