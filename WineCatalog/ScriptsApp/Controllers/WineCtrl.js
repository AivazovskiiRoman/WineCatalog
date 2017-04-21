angular.module('WineCatalogApp').controller('WineCtrl', [
    '$rootScope', '$scope', '$http', function ($rootScope, $scope, $http) {

        $rootScope.title = "Wine Catalog";

        $scope.model = {};

        // list of wines
        $http({
            method: 'GET',
            url: '/Home/WineVM'
        }).then(function(data) {
            $scope.model = data;
        }, function(error) {
            console.error("Get wines error: ", error);
        });
    }
]);