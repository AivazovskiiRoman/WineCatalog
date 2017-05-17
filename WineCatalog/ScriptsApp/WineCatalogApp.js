angular.module('WineCatalogApp', ['ui.router', 'ngAnimate', 'ui.bootstrap', 'xeditable', 'restangular'])
    .config([
        '$stateProvider', '$urlRouterProvider', '$locationProvider', function($stateProvider, $urlRouterProvider, $locationProvider) {
            // Route
            $locationProvider.hashPrefix('');
            $urlRouterProvider.otherwise('/');

            $stateProvider
                .state('wine',
                {
                    url: '',
                    templateUrl: 'Wines',
                    controller: 'WineCtrl'
                });
        }
    ])
    .run(['editableOptions', 'editableThemes', function (editableOptions, editableThemes) {
        editableThemes.bs3.inputClass = 'input-sm';
        editableThemes.bs3.buttonsClass = 'btn-sm';
        editableOptions.theme = 'bs3';
    }]);