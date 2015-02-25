(function () {
    'use strict';

    angular
        .module('app')
        .factory('locationService', locationService);

    locationService.$inject = ['$location'];

    function locationService
        ($location) {
        var service = {
            goToConfigureSite: function (site) {
                $location.path('/configuresite/' + site.uniqueId);
            },
            goToDeleteSite: function () { $location.path('/configuresite.delete'); }
        };

        return service;

    }
})();
