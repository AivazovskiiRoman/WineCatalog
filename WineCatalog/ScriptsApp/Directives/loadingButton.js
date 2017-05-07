/*
* Ladda - buttons with loading indicators.
* https://github.com/hakimel/Ladda
*/

angular.module('WineCatalogApp').directive('loadingButton', function () {
    return {
        restrict: 'A',
        scope: {
            spin: "="
        },
        link: function(scope, element, attrs) {

            // Ladda.bind('.ladda-button');

            var l = Ladda.create(document.querySelector('.ladda-button'));

            scope.$watch('spin', function(newValue, oldValue) {
                if (newValue) {
                    l.start();
                } else {
                    l.stop();
                }
            });

        }
    }
});