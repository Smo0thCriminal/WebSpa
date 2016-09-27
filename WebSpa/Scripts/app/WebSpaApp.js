var angular = angular.module('WebSpaApp', ['ui.router']).config($stateProvider)
    $stateProvider
        .state('Introduce', {
            url: '/Introduce',
            templateUrl: '/Scripts/app/template/Introduce.html',
            controller: 'LoginController as vm'
        });
        //.state('ManageQuiz', {
        //    url: '/ManageQuiz',
        //    templateUrl: '/Scripts/app/template/ManageData.html',
        //    controller: 'ManageController as vm'
        //});
}
    //.config(function ($routeProvider) {
    //    $routeProvider
    //        .when('/',
    //        {
    //            templateUrl: '/Scripts/app/template/Introduce.html',
    //            controller: 'LoginController'
    //        })
    //        .when('/ManageQuiz',
    //        {
    //         templateUrl: '/Scripts/app/template/ManageData.html',
    //         controller: 'ManageController'
    //        })
    //        .when('/Quiz', 
    //        {
    //            templateUrl: '/Scripts/app/template/Quiz.html',
    //            controller: 'QuizController'
    //        })
    //        .otherwise({ redirectTo: '/' });