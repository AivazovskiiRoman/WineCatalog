angular.module('WineCatalogApp').controller('WineCtrl', ['$rootScope', '$scope', '$uibModal', 'apiSrv',
    function ($rootScope, $scope, $uibModal, apiSrv) {

        $rootScope.title = "Wine Catalog";
        $scope.wines = {};

        $scope.states = {
            showWineForm: false,
            isAdding: false
        };

        $scope.new = {
            wine: {}
        }

        // list of wines
        apiSrv.wines.get().then(function (data) {
            $scope.wines = data;
        }, function (error) {
            console.error("Get wines error: ", error);
        });

        $scope.showWineForm = function (show) {
            $scope.states.showWineForm = show;
        }

        // add new wine
        $scope.addWine = function () {
            apiSrv.wines.add($scope.new.wine).then(function (data) {
                $scope.wines.push(data);
                $scope.showWineForm(false);
                $scope.states.isAdding = false;
                $scope.new.wine = {};
            });
        }

        // edit wine
        $scope.editModal = function (id, data) {
            data.Id = id;
            apiSrv.wines.edit(data).then(function () {
                console.log("The record was updated.");
            }, function (error) {
                console.error("Edit wine error: ", error);
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
                size: 'sm',
                resolve: {
                    function () {
                        $scope.message = 'The record was deleted.';
                    }
                }
            });

            $scope.ok = function () {

                apiSrv.wines.remove(id).then(function() {
                    $scope.wines.splice(index, 1);
                }, function(error) {
                    console.error("Remove wine error: ", error);
                });

                $scope.$uibModalInstance.close();
            };
        }
    }
]);