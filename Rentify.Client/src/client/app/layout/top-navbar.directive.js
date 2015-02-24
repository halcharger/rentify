(function () {
    'use strict';

    angular
        .module('app.layout')
        .directive('topNavBar', topNavBar);

    /* @ngInject */
    function topNavBar() {
        var directive = {
            bindToController: true,
            controller: TopNavController,
            controllerAs: 'vm',
            restrict: 'EA',
            scope: {
                'navline': '='
            },
            templateUrl: 'app/layout/top-navbar.html'
        };

        /* @ngInject */
        TopNavController.$inject = ['$location', 'logger', 'authService'];
        function TopNavController($location, logger, authService) {
            var vm = this;

            vm.logOut = function () {
                authService.logOut();
                $location.path('/login');
            };
        }

        return directive;
    }
})();
