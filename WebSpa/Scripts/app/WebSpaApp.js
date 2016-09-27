(function() {
    'use strict';

    angular
        .module('WebSpaApp')
        .config(config);

    config.$inject = ['$stateProvider'];

    function config($stateProvider) {
        $stateProvider
            .state('home',
            {
                url: '/',
                templateUrl: '/Scripts/app/template/Introduce.html',
                controller: 'LoginController'
            });
    }
})();

//var angular = angular.module('WebSpaApp', ['ngRoute'])
//    .config(function ($routeProvider) {
//        $routeProvider
//            .when('/',
//            {
//                templateUrl: '/Scripts/app/template/Introduce.html',
//                controller: 'LoginController'
//            })

//            .when('/ManageQuiz',
//            {
//             templateUrl: '/Scripts/app/template/ManageData.html',
//             controller: 'ManageController'
//            })
//            .when('/Quiz', 
//            {
//                templateUrl: '/Scripts/app/template/Quiz.html',
//                controller: 'QuizController'
//            })
//            .otherwise({ redirectTo: '/' });
//    });