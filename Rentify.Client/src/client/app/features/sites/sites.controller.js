(function () {
    'use strict';

    angular
        .module('app.sites')
        .controller('SitesController', SitesController);

    SitesController.$inject = ['$location', 'authService', 'sitesService'];

    function SitesController($location, authService, sitesService) {
        var vm = this;
        vm.title = 'My Sites';
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
              .success(function (results) {
                  vm.sites = results;
                  vm.loadingSites = false;
              })
              .error(function () {
                  vm.loadingSites = false;
              });
        };

        vm.deleteSite = function (site) {
            sitesService.setSelectedSite(site);
            $location.path('deletesite');
        };

        vm.editSite = function (site) {
            sitesService.setSelectedSite(site);
            $location.path('/configuresite');
        };

        activate();

        function activate() {
            vm.getSites();
        }
    }
})();
