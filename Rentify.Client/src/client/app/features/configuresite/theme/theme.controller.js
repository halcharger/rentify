(function () {
    'use strict';

    angular
        .module('app.configuresite')
        .controller('ThemeController', theme);

    theme.$inject = [
        'siteUniqueId', 'sitesService', 'logger'];

    function theme(siteUniqueId, sitesService, logger) {
        /* jshint validthis:true */
        var vm = this;
        vm.site = {};
        vm.themes = ['lavilla', 'some other theme'];

        activate();

        function activate() {
            sitesService.getSite(siteUniqueId).then(function (result) {
                vm.site = result;
            });
        }

        vm.save = function () {
            return sitesService.updateTheme(vm.site.uniqueId, vm.site.themeId)
                .success(function () {
                    logger.success('Successfully updated Theme & Styling for ' + vm.site.name + '.');
                });
        };

    }
})();
