(function() {
    angular.module('WebSpaApp').controller('QuizController', QuizController);

    QuizController.$inject = ['quizService', '$http'];

    function QuizController(quizService, $http) {
        var vm = this;
        vm.actions = {
        
        }

        vm.QuizModel = {};
        vm.Quiz = {};

        init();

        function init() {
            $http.get('api/QuizModels').then(function(response) {
                vm.Quiz = response.data;
            });
        }

        function saveQuiz() {
            manageService.saveQuiz(vm.QuizModel).then(function() {
                init();
            });
            vm.QuizModel = null;
        }

        function deleteQuiz(quiz) {
            init();
            var varIsConf = confirm('Want to delete ' + 'Id: ' + quiz.Id + ' ' + 'MaxPoints: ' + quiz.MaxPoints + '. Are you sure?');
            if (varIsConf) {
                manageService.deleteQuiz(quiz).then(function() {
                    init();
                });
            }
            init();
        }
    }
})();