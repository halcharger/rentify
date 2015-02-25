(function () {
    'use strict';

    angular
        .module('app.services')
        .factory('sitesService', factory);

    factory.$inject = ['$http', '$q', 'authService', 'config', 'DSCacheFactory', 'logger'];

    function factory($http, $q, authService, config, DSCacheFactory, logger) {
        authService.redirectToLoginIfNotAuthenticated();

        var sitesCacheKey = 'mysites';
        var baseUri = config.serverBaseUri;
        var selectedSite;

        var cache = new DSCacheFactory(sitesCacheKey, {
            maxAge: 90000, // Items added to this cache expire after 15 minutes.
            cacheFlushInterval: 600000, // This cache will clear itself every hour.
            deleteOnExpire: 'aggressive' // Items will be deleted from this cache right when they expire.
        });

        var service = {};

        service.getMySites = function () {
            var deferred = $q.defer(),
              start = new Date().getTime(),
              mySitesCache = DSCacheFactory.get(sitesCacheKey);

            if (mySitesCache.get(sitesCacheKey)) {
                deferred.resolve(mySitesCache.get(sitesCacheKey));
            } else {
                $http.get(baseUri + 'api/mysites')
                  .success(function (results) {
                      console.log('time taken for mysites request: ' +
                          (new Date().getTime() - start) + 'ms');
                      mySitesCache.put(sitesCacheKey, results);
                      deferred.resolve(results);
                  });
            }
            return deferred.promise;
        };

        service.getSite = function(siteUniqueId) {
            return service.getMySites()
                .then(function(results) {
                    for (var i = 0; i < results.length; i++) {
                        if (results[i].uniqueId === siteUniqueId) {
                            return results[i];
                        }
                    }
            });
        };


        service.refreshMySites = function () {
            return $http.get(baseUri + 'api/mysites')
              .success(function (results) {
                  var mySitesCache = DSCacheFactory.get(sitesCacheKey);
                  mySitesCache.put(sitesCacheKey, results);
                  return results;
              });
        };

        service.addSite = function (site) {
            return $http.post(baseUri + 'api/mysites/add', site)
              .success(function () {
                  var mySitesCache = DSCacheFactory.get(sitesCacheKey);
                  var mysites = mySitesCache.get(sitesCacheKey);
                  mysites.push(site);
                  mySitesCache.put(sitesCacheKey, mysites);
              });
        };

        service.updateTheme = function (uniqueId, themeId) {
            return $http.post(baseUri + 'api/site/updatetheme',
                { uniqueId: uniqueId, themeId: themeId })
              .success(function () {
                  service.refreshMySites();
              });
        };

        service.deleteSite = function (siteUniqueId) {
            return $http.delete(baseUri + 'api/mysites/delete?uniqueId=' + siteUniqueId)
              .success(function () {
                  var mySitesCache = DSCacheFactory.get(sitesCacheKey);
                  var mysites = mySitesCache.get(sitesCacheKey);
                  for (var i = mysites.length - 1; i >= 0; i--) {
                      if (mysites[i].uniqueId === siteUniqueId) {
                          mysites.splice(i, 1);
                      }
                  }
                  mySitesCache.put(sitesCacheKey, mysites);
              });
        };

        service.removeGalleryImage = function (siteUniqueId, galleryId, imageUrl) {
            return $http.post(baseUri + 'api/site/removegalleryimage',
                { siteUniqueId: siteUniqueId, galleryId: galleryId, imageUrl: imageUrl });
        };

        service.getPropertyOverview = function (siteUniqueId) {
            return $http.get(baseUri + 'api/site/propertyoverview?siteUniqueId=' + siteUniqueId);
        };

        service.updatePropertyOverview = function (propertyOverview) {
            return $http.post(baseUri + 'api/site/updatepropertyoverview', propertyOverview);
        };

        service.getLocation = function (siteUniqueId) {
            return $http.get(baseUri + 'api/site/location?siteUniqueId=' + siteUniqueId);
        };

        service.updateLocation = function (location) {
            return $http.post(baseUri + 'api/site/updatelocation', location);
        };

        service.getGallery = function (siteUniqueId) {
            return $http.get(baseUri + 'api/site/gallery?siteUniqueId=' + siteUniqueId);
        };

        service.updateGallery = function (gallery) {
            return $http.post(baseUri + 'api/site/updategallery', gallery);
        };

        service.getCustomMapImageUploadUrl = function (siteUniqueId) {
            return baseUri + 'api/site/mapimage/upload?siteUniqueId=' + siteUniqueId;
        };

        service.getGalleryImageUploadUrl = function (siteUniqueId, galleryId) {
            return baseUri + 'api/site/gallery/upload?siteUniqueId=' +
                siteUniqueId + '&galleryId=' + galleryId;
        };

        service.setSelectedSite = function (site) {
            selectedSite = site;
        };
        service.getSelectedSite = function () {
            return selectedSite;
        };
        service.clearSelectedSite = function () {
            selectedSite = {};
        };

        return service;
    }
})();
