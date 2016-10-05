(function () {
    angular.module('WebSpaApp').controller('QuizController', QuizController);

    QuizController.$inject = ['quizService', '$cookies'];

    function QuizController(quizService, $cookies) {
        var vm = this;
        vm.actions = {
            init: init,
            getPlayerScore: getPlayerScore
        }

        vm.Quiz = {};
        vm.currentPlayer = {};

        init();

        function init() {
            quizService.init().then(function (response) {
                vm.Quiz = response.data;
                vm.Quiz.forEach(function(item) {    
                    item.Answer = null;
                });
                vm.currentPlayer = $cookies.get('currentPlayer');
            });
        }

        function getPlayerScore() {
            debugger;
            quizService.getPlayerScore(vm.Quiz).then(function () {
            });
            //vm.Quiz.forEach(function (item) {
            //            alert(item);
            //});
        }
    }
})();