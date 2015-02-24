(function () {
    'use strict';

    angular
        .module('app.sites')
        .controller('SitesController', SitesController);

    SitesController.$inject = ['$location', 'authService', 'sitesService', 'logger'];

    function SitesController($location, authService, sitesService, logger) {
        var vm = this;
        vm.title = 'My Sites';
        vm.sites = [];

        vm.getSites = function () {
            vm.loadingSites = true;
            sitesService.getMySites()
              .then(function (results) {
                  logger.info('got sites results', results);
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
            $location.path('editsite-theme');
        };

        activate();

        function activate() {
            vm.getSites();
            logger.info('Activated Sites View');
        }
    }
})();
