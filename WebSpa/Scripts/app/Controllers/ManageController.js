angular.module('WebSpaApp').controller('ManageController', ManageController);

ManageController.$inject = ['manageService', '$http'];

function ManageController(manageService, $http) {
    var vm = this;
    vm.actions = {
        saveQuiz: saveQuiz,
        deleteQuiz: deleteQuiz
    }

    vm.QuizModel = {};
    vm.Quiz = {};

    init();

    function init() {
        $http.get('api/QuizModels').then(function (response) {
            vm.Quiz = response.data;
        });
    }
    
    function saveQuiz() {
        manageService.saveQuiz(vm.QuizModel).then(function () {
            init();
        });
        vm.QuizModel = null;
    }

    function deleteQuiz(quiz) {
        init();
        var varIsConf = confirm('Want to delete ' + 'Id: ' + quiz.Id + ' ' + 'MaxPoints: ' + quiz.MaxPoints + '. Are you sure?');
        if (varIsConf) {
            manageService.deleteQuiz(quiz).then(function () {
                init();
            });
        }
        init();
    }
}

//angular.module('WebSpaApp').controller('ManageController', ManageController);

//ManageController.$inject = ['loginService'];

//function ManageController(loginService) {
//    var vm = this;
//    vm.data = [];

//    vm.actions = {
        
//    }
//}


////angular.controller('ManageController', function ($scope, $http) {

////    GetAllData();
////    $scope.isDisabledupdate = true;

////    function GetAllData() {
////        $http.get('api/QuizModels').success(function (data) {
////            $scope.Quiz = data;
////        });
////    };


////    $scope.saveQuiz = function () {
////        $http({
////            method: 'POST',
////            url: 'api/QuizModels',
////            data: $scope.QuizModel
////        }).success(function () {
////            GetAllData();
////            $scope.QuizModel = null;
////        }).error(function () {
////            alert(data.errors);
////        });
////        GetAllData();
////    };

////    $scope.deleteQuiz = function (QuizModel) {

////        var varIsConf = confirm('Want to delete ' + 'Id: '  + QuizModel.Id + ' ' + 'Question: ' + QuizModel.Question + '. Are you sure?');
////        if (varIsConf) {
////            $http({
////                method: 'DELETE',
////                url: 'api/QuizModels/' + QuizModel.Id,
////                data: $scope.QuizModel
////            }).success(function () {
////                GetAllData();
////                $scope.errors = [];
////            }).error(function () {
////                alert(data.errors);
////            });
////        }
////    };


////    $scope.getQuiz = function (QuizModel) {
////        $http.get('api/QuizModels/' + QuizModel.Id)
////        .success(function (data, status, headers, config) {
////            $scope.QuizModel = data;
////            GetAllData();
////            $scope.isDisabledsave = true;
////            $scope.isDisabledupdate = false;
////        })
////        .error(function () {
////            alert(data.errors);
////        });
////    };


////    $scope.updateQuiz = function () {
////        $http({
////            method: 'POST',
////            url: 'api/QuizModels/',
////            data: $scope.QuizModel
////        }).success(function () {
////            GetAllData();
////            $scope.isDisabledsave = false;
////            $scope.isDisabledupdate = true;
////            $scope.QuizModel = null;
////        }).error(function () {
////            alert(data.errors);
////        });
////    };

////});