(function() {
    angular.module('WebSpaApp').controller('QuizController', QuizController);

    QuizController.$inject = ['quizService'];

    function QuizController(quizService) {
        var vm = this;
        vm.actions = {
            init: init
        }

        vm.Quiz = {};
        vm.userAnswer = {};

        init();

        function init() {
            quizService.init().then(function (response) {
                vm.Quiz = response.data;
                vm.Quiz.Answer = {};
                vm.userAnswer = response.data;
            });
        }

        function submit() {
            vm.Quiz.forEach(function (item) {
                //item.userAnswer = ;
            });
        }
    }
})();