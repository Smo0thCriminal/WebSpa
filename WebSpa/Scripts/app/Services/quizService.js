(function() {
    angular.module('WebSpaApp').service('quizService', quizService);

    quizService.$inject = ['$http'];

    function quizService($http) {
        var service = {
            init: init
        }
        return service;

        function init() {
            return $http.get('api/QuizModels/rand');
        }
        //function saveQuiz(quizModel) {
        //    return $http.post('api/QuizModels', quizModel);
        //}

        //function deleteQuiz(quizModel) {
        //    return $http.delete('api/QuizModels', {
        //        params: {
        //            id: quizModel.Id
        //        }
        //    });
        //}
    }
})();