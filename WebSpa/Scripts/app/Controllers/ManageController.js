(function() {
    angular.module('WebSpaApp').controller('ManageController', ManageController);

    ManageController.$inject = ['manageService', '$http'];

    function ManageController(manageService, $http) {
        var vm = this;
        vm.actions = {
            saveQuiz: saveQuiz,
            deleteQuiz: deleteQuiz,
            init: init
        }

        vm.QuizModel = {};
        vm.Quiz = {};

        init();

        function init() {
            manageService.init().then(function(response) {
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