(function () {
    'use strict';

    angular
        .module('app')
        .factory('locationService', location);

    location.$inject = ['$location'];

    function location($location) {
        var service = {
            goToConfigureSite: function () { $location.path('/configuresite'); },
            goToDeleteSite: function() { $location.path('/configuresite.delete'); }
        };

        return service;

    }
})();