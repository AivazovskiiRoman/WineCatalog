angular.module('WineCatalogApp').controller('WineCtrl', [
    '$rootScope', '$scope', '$http', '$uibModal', function ($rootScope, $scope, $http, $uibModal) {

        $rootScope.title = "Wine Catalog";
        $scope.model = {};

        $scope.states = {
            showWineForm: false,
            isAdding: false
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
        $scope.addWine = function () {
            $scope.states.isAdding = true;

            $http({
                method: 'POST',
                url: '/Home/Edit',
                data: $scope.new.Wine
            }).then(function(response) {
                $scope.model.Wines.push(response.data);
                $scope.showWineForm(false);
                $scope.states.isAdding = false;
                $scope.new.Wine = {};
            }, function(error) {
                console.error("Add wine error: ", error);
            });
        }

        // remove wine
        $scope.removeModal = function (id, index) {
            $scope.header = 'Delete record';
            $scope.body = 'Are you sure you want to delete this record?';

            $scope.$uibModalInstance = $uibModal.open({
                scope: $scope,
                templateUrl: '/Home/ModalTemplate',
                controller: 'ModalCtrl',
                size: 'sm'
            });

            $scope.ok = function () {
                $http({
                    method: 'GET',
                    url: 'Home/Delete/?id=' + id
                }).then(function () {
                    $scope.model.Wines.splice(index, 1);
                }, function (error) {
                    console.error("Remove wine error: ", error);
                });

                $scope.$uibModalInstance.close();
            };
        }
    }
]);