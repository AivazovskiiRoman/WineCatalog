angular.module('WineCatalogApp').controller('WineCtrl', [
    '$rootScope', '$scope', '$http', function ($rootScope, $scope, $http) {

        $rootScope.title = "Wine Catalog";

        $scope.model = {};
        $scope.states = {
            showWineForm: false
        };
        $scope.new = {
            Wine: {}
        }

        // list of wines
        $http({
            method: 'GET',
            url: '/Home/WineVM'
        }).then(function (response) {
            $scope.model = response.data;
        }, function (error) {
            console.error("Get wines error: ", error);
        });

        $scope.showWineForm = function(show) {
            $scope.states.showWineForm = show;
        }

        // add new wine
        $scope.addWine = function() {
            $http({
                method: 'POST',
                url: '/Home/Edit',
                data: $scope.new.Wine
            }).then(function (response) {
                $scope.model.Wines.push(response.data);
                $scope.showWineForm(false);
                $scope.new.Wine = {};
            }, function(error) {
                console.error("Add wine error: ", error);
            });
        }
    }
]);