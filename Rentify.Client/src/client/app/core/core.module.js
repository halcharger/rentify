(function () {
    'use strict';

    angular
        .module('app.core', [
            //core ng modules
            'ngAnimate',
            'ngCookies',
            'ngResource',
            'ngRoute',
            'ngSanitize',
            'ngTouch',

            //our custom modules
            'blocks.exception', 'blocks.logger', 'blocks.router',

            //3rd party modules
            'ui.router',
            'ngplus',
            'LocalStorageModule',
            'angular-data.DSCacheFactory',
            'ui.bootstrap',
            'flow',
            'angular-images-loaded'
        ]);
})();
