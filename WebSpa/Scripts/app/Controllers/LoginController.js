'use strict';

angular.controller('LoginController', function($scope, $http) {

    GetAllPlayers();
    $scope.isDisabledupdate = true;
    //get all players
    function GetAllPlayers() {
        $http.get('api/PlayerModels').success(function (data) {
            $scope.Player = data;
        });
    };

    //create player
    $scope.savePlayer = function() {
        $http({
            method: 'POST',
            url: 'api/PlayerModels',
            data: $scope.playerModel
        }).success(function() {
            $scope.playerModel = null;
        }).error(function() {
            alert(data.errors);
        });
        GetAllPlayers();
    };

    //Get player by id to edit
    $scope.getPlayer = function (playerModel) {
        $http.get('api/PlayerModels/' + playerModel.Id)
        .success(function (data, status, headers, config) {
            $scope.QuizModel = data;
            GetAllPlayers();
            $scope.isDisabledsave = true;
            $scope.isDisabledupdate = false;
        })
        .error(function () {
            alert(data.errors);
        });
    };

    //Delete player
    $scope.deletePlayer = function (playerModel) {
        var varIsConf = confirm('Want to delete ' + 'Id: ' + playerModel.Id + ' ' + 'Question: ' + playerModel.LastName + '. Are you sure?');
        if (varIsConf) {
            $http({
                method: 'DELETE',
                url: 'api/PlayerModels/' + playerModel.Id,
                data: $scope.QuizModel
            }).success(function () {
                GetAllPlayers();
                $scope.errors = [];
            }).error(function () {
                alert(data.errors);
            });
        }
    };

    //Update player
    $scope.updatePlayer = function () {
        $http({
            method: 'POST',
            url: 'api/PlayerModels/',
            data: $scope.playerModel
        }).success(function () {
            GetAllPlayers();
            $scope.isDisabledsave = false;
            $scope.isDisabledupdate = true;
            $scope.playerModel = null;
        }).error(function () {
            alert(data.errors);
        });
    };
});