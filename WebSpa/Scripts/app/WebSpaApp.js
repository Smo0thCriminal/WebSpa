(function() {
    angular.module('WebSpaApp', ['ui.router', 'ngCookies'])
        .config(function($stateProvider, $urlRouterProvider) {
            $urlRouterProvider.otherwise("/");
            $stateProvider
                .state('Introduce', {
                    url: '/',
                    templateUrl: '/Scripts/app/template/Introduce.html',
                    controller: 'LoginController as vm'
                })
                .state('ManagePlayer', {
                    url: '/ManagePlayer',
                    templateUrl: '/Scripts/app/template/ManagePlayers.html',
                    controller: 'LoginController as vm'
                })
                .state('ManageQuiz', {
                    url: '/ManageQuiz',
                    templateUrl: '/Scripts/app/template/ManageQuiz.html',
                    controller: 'ManageController as vm'
                })
                .state('Quiz', {
                    url: '/Quiz',
                    templateUrl: '/Scripts/app/template/Quiz.html',
                    controller: 'QuizController as vm'
                });
        });
})();