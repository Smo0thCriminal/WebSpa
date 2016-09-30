(function() {
    angular.module('WebSpaApp').service('manageService', manageService);

    manageService.$inject = ['$http'];

    function manageService($http) {
        var service = {
            saveQuiz: saveQuiz,
            deleteQuiz: deleteQuiz,
            init: init
        }
        return service;

        function init() {
            return $http.get('api/QuizModels');
        }

        function saveQuiz(quizModel) {
            return $http.post('api/QuizModels', quizModel);
        }

        function deleteQuiz(quizModel) {
            return $http.delete('api/QuizModels', {
                params: {
                    id: quizModel.Id
                }
            });
        }
    }
})();
