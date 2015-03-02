(function () {
    'use strict';

    angular
        .module('app.configuresite')
        .controller('LocationController', Controller);

    Controller.$inject = ['$q', 'siteUniqueId', 'sitesService', 'logger', 'localStorageService'];

    function Controller($q, siteUniqueId, sitesService, logger, localStorageService) {
        /* jshint validthis:true */
        var vm = this;
        vm.location = {};
        vm.site = {};
        vm.memento = {};

        vm.save = function () {
            vm.location.uniqueId = vm.site.uniqueId;
            return sitesService.updateLocation(vm.location)
              .success(function () {
                  logger.success(vm.site.name + ' Property Location successfully saved.');
              });
        };

        vm.cancel = function () {
            return $q.when((function () { vm.location = JSON.parse(vm.memento); }()));
        };

        vm.getSecurityHeaders = function () {
            var authData = localStorageService.get('authorizationData');
            if (authData) {
                return { Authorization: 'Bearer ' + authData.token };
            }
        };

        vm.getFlowJsUploadTarget = function () {
            return sitesService.getCustomMapImageUploadUrl(siteUniqueId);
        };

        vm.onFileUploadSuccess = function (file) {
            console.log('file upload success...');
            file.cancel();
        };

        activate();

        function activate() {
            sitesService.getSite(siteUniqueId).then(function (result) {
                vm.site = result;
                console.log('site: ', vm.site);
                vm.location = vm.site.property.location;
                vm.memento = JSON.stringify(vm.location);
                console.log('location memento: ', vm.memento);
            });
        }
    }
})();
