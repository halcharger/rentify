(function () {
    'use strict';

    angular
        .module('app.sites')
        .controller('SitesController', Controller);

    Controller.$inject = ['locationService', 'authService', 'sitesService'];

    function Controller(locationService, authService, sitesService) {
        var vm = this;
        vm.sites = [];

        vm.getSites = function () {
            vm.loadingSites = true;
            sitesService.getMySites()
              .then(function (results) {
                  vm.sites = results;
              });
        };

        vm.refreshSites = function () {
            vm.loadingSites = true;
            return sitesService.refreshMySites()
                .success(function(results) {
                    vm.sites = results;
                });
        };

        vm.deleteSite = function (site) {
            sitesService.setSelectedSite(site);
            locationService.goToDeleteSite(site);
        };

        vm.editSite = function (site) {
            sitesService.setSelectedSite(site);
            locationService.goToConfigureSite(site);
        };

        activate();

        function activate() {
            vm.getSites();
        }
    }
})();
