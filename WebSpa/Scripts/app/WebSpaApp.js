angular.module('WebSpaApp', ['ui.router'])
    .config(function($stateProvider, $urlRouterProvider) {
        $urlRouterProvider.otherwise("/");
        $stateProvider
            .state('Introduce', {
                url: '/',
                templateUrl: '/Scripts/app/template/Introduce.html',
                controller: 'LoginController as vm'
            })
            .state('ManageQuiz', {
                url: '/ManageQuiz',
                templateUrl: '/Scripts/app/template/ManageData.html',
                controller: 'LoginController as vm'
            })
            .state('Quiz', {
                url: '/Quiz',
                templateUrl: '/Scripts/app/template/Quiz.html',
                controller: 'QuizController as vm'
            });
    });