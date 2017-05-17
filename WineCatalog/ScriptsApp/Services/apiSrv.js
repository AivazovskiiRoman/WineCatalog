angular.module('WineCatalogApp').factory('apiSrv', ['$rootScope', 'Restangular', function($rootScope, Restangular) {

        Restangular
            .setBaseUrl('/api');
            //.setRestangularFields({ id: 'Id' });

        return {
            wines: {
                get: function() {
                    return Restangular.all('Wines').getList();
                },
                add: function(model) {
                    return Restangular.all('Wines').post(model);
                },
                edit: function(model) {
                    return Restangular.one('Wines', model.Id).customPUT(model);
                },
                remove: function(id) {
                    return Restangular.one('Wines', id).remove();
                }
            }
        }
    }
]);