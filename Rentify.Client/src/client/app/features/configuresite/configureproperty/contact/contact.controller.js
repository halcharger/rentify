(function () {
    'use strict';

    angular
        .module('app.configuresite')
        .controller('ContactController', controller);

    controller.$inject = ['$q', 'siteUniqueId', 'sitesService', 'logger'];

    function controller($q, siteUniqueId, sitesService, logger) {
        /* jshint validthis:true */
        var vm = this;
        vm.contact = {};
        vm.site = {};
        vm.memento = {};

        vm.save = function () {
            vm.contact.uniqueId = vm.site.uniqueId;
            return sitesService.updateContact(vm.contact)
              .success(function () {
                  logger.success(vm.site.name + ' Contact Info successfully saved.');
              });
        };

        vm.cancel = function () {
            return $q.when((function () { vm.contact = JSON.parse(vm.memento); }()));
        };

        activate();

        function activate() {
            sitesService.getSite(siteUniqueId).then(function (result) {
                vm.site = result;
                vm.contact = vm.site.property.contact;
                vm.memento = JSON.stringify(vm.contact);
            });
        }
    }
})();
