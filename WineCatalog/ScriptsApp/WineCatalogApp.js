angular.module('WineCatalogApp', ['ui.router', 'ui.bootstrap'])
    .config([
        '$stateProvider', '$urlRouterProvider', '$locationProvider', function ($stateProvider, $urlRouterProvider, $locationProvider) {

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