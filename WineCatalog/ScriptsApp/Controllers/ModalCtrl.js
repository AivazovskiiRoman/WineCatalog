angular.module('WineCatalogApp').controller('ModalCtrl', [
    '$scope', '$uibModalInstance', function ($scope, $uibModalInstance) {
        
        $scope.cancel = function() {
            $uibModalInstance.dismiss();
        };

        $uibModalInstance.result.then(function () {
            console.log('Success!');
        }, function() {
            console.log('Modal dismissed at: ' + new Date());
        });
    }
]);
