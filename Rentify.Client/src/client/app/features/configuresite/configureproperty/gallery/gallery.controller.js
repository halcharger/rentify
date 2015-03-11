(function () {
    'use strict';

    angular
        .module('app.configuresite')
        .controller('GalleryController', Controller);

    Controller.$inject = ['$q', 'siteUniqueId', 'sitesService', 'logger', 'localStorageService'];

    function Controller($q, siteUniqueId, sitesService, logger, localStorageService) {
        /* jshint validthis:true */
        var vm = this;
        vm.gallery = {};
        vm.site = {};
        vm.memento = {};

        vm.save = function () {
            vm.gallery.uniqueId = vm.site.uniqueId;
            return sitesService.updateGallery(vm.gallery)
              .success(function () {
                  logger.success(vm.site.name + ' Property Gallery successfully saved.');
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
            return sitesService.getGalleryImageUploadUrl(siteUniqueId);
        };

        vm.onFileUploadSuccess = function (file) {
            console.log('file upload success...');
            file.cancel();
        };

        activate();

        function activate() {
            sitesService.getSite(siteUniqueId).then(function (result) {
                vm.site = result;
                vm.gallery = vm.site.property.gallery;
                vm.memento = JSON.stringify(vm.gallery);
                console.log('gallery memento: ', vm.memento);
            });
        }
    }
})();
