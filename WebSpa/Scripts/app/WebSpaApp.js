var angular = angular.module('WebSpaApp', ['ngRoute'])
    .config(function ($routeProvider) {
        $routeProvider
            .when('/ManageQuiz',
            {
             templateUrl: '/Scripts/app/template/ManageData.html',
             controller: 'ManageController'
        })
        .when('/',
            {
                templateUrl: '/Scripts/app/template/Introduce.html',
                controller: 'LoginController'
            })
        .otherwise({ redirectTo: '/Scripts/app/template/Introduce.html' });
    });