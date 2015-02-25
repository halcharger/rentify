(function () {
    'use strict';

    angular
      .module('app.layout')
      .directive('pageContentContainer', function () {
          return {
              restrict: 'E',
              transclude: true,
              replace: true,
              scope: {
                  pageHeading: '@',
                  faIcon: '@'
              },
              template: '<div class="page-container">' +
                        '<div class="page-head">' +
                        '<div class="container"><div class="page-title">' +
                        '<i class="pull-left fa {{faIcon}} fa-2x"></i>' +
                        '<h1 class="pull-left">{{pageHeading}}</h1>' +
                        '</div></div></div>' +
                        '<div class="page-content"><div class="container">' +
                        '<ng-transclude></ng-transclude>' +
                        '</div></div></div>'
          };
      });

}());
