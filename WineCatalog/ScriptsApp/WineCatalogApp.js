angular.module('WineCatalogApp', ['ui.router', 'ngAnimate', 'ui.bootstrap'])
    .config([
        '$stateProvider', '$urlRouterProvider', '$locationProvider', function ($stateProvider, $urlRouterProvider, $locationProvider) {
            // Route
            $locationProvider.hashPrefix('');
            $urlRouterProvider.otherwise('');

            $stateProvider
                .state('wine',
                {
                    url: '',
                    templateUrl: '/Home/Wine',
                    controller: 'WineCtrl'
                });
        }
    ]);