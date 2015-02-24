(function () {
    'use strict';

    angular
        .module('app.login')
        .controller('LoginController', LoginController);

    LoginController.$inject = ['$location', 'authService', 'logger'];

    function LoginController($location, authService, logger) {
        var vm = this;

        vm.loginData = {
            userName: '',
            password: '',
            useRefreshTokens: false
        };

        vm.login = function () {
            return authService.login(vm.loginData)
              .success(function () {
                  $location.path('/sites');
              });
        };

        activate();

        function activate() {
            logger.info('Activated Login View');
        }
    }
})();
