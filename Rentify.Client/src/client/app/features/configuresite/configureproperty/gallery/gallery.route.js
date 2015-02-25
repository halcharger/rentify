(function () {
    'use strict';

    angular
        .module('app.configuresite')
        .run(appRun);

    appRun.$inject = ['routerHelper'];
    /* @ngInject */
    function appRun(routerHelper) {
        routerHelper.configureStates(getStates());
    }

    function getStates() {
        return [
            {
                state: 'configuresite.configureproperty.gallery',
                config: {
                    url: '/gallery',
                    templateUrl: 'app/features/configuresite/configureproperty/gallery/gallery.html',
                    //controller: 'GalleryController',
                    //controllerAs: 'vm',
                    title: 'Gallery',
                    settings: {
                        configurePropertyNav: 3
                    }
                }
            }
        ];
    }
})();
