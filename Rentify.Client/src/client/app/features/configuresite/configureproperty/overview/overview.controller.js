(function () {
    'use strict';

    angular
        .module('app.configuresite')
        .controller('OverviewController', overview);

    overview.$inject = ['$q', 'siteUniqueId', 'sitesService', 'logger'];

    function overview($q, siteUniqueId, sitesService, logger) {
        /* jshint validthis:true */
        var vm = this;
        vm.propertyOverview = {};
        vm.site = {};
        vm.memento = {};

        vm.save = function () {
            vm.propertyOverview.uniqueId = vm.site.uniqueId;
            return sitesService.updatePropertyOverview(vm.propertyOverview)
              .success(function () {
                  logger.success(vm.site.name + ' Property Overview successfully saved.');
              });
        };

        vm.cancel = function () {
            return $q.when((function () { vm.propertyOverview = JSON.parse(vm.memento); }()));
        };

        activate();

        function activate() {
            sitesService.getSite(siteUniqueId).then(function (result) {
                vm.site = result;
                vm.propertyOverview = vm.site.property.overview;
                vm.memento = JSON.stringify(vm.propertyOverview);
            });
        }
    }
})();
