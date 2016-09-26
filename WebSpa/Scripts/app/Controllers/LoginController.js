'use strict';

angular.controller('LoginController', function($scope, $http, $window) {

    GetAllPlayers();
    $scope.isDisabledupdate = true;

    function GetAllPlayers() {
        $http.get('api/PlayerModels').success(function (data) {
            $scope.Player = data;
        });
    };

    $scope.loginRedirectPlayer = function () {
        $http({
            method: 'POST',
            url: 'api/PlayerModels',
            data: $scope.PlayerModel
        }).success(function () {
            $window.location.href = '/Quiz';
            GetAllPlayers();
            $scope.PlayerModel = null;
        }).error(function () {
            alert(data.errors);
        });
        GetAllPlayers();
    };

    $scope.savePlayer = function () {
        $http({
            method: 'POST',
            url: 'api/PlayerModels',
            data: $scope.PlayerModel
        }).success(function () {
            GetAllPlayers();
            $scope.PlayerModel = null;
        }).error(function () {
            alert(data.errors);
        });
        GetAllPlayers();
    };

    $scope.getPlayer = function (PlayerModel) {
        $http.get('api/PlayerModels/' + PlayerModel.Id)
        .success(function (data, status, headers, config) {
            $scope.PlayerModel = data;
            GetAllPlayers();
            $scope.isDisabledsave = true;
            $scope.isDisabledupdate = false;
        })
        .error(function () {
            alert(data.errors);
        });
    };

    $scope.deletePlayer = function (PlayerModel) {
        var varIsConf = confirm('Want to delete ' + 'Id: ' + PlayerModel.Id + ' ' + 'LastName: ' + PlayerModel.LastName + '. Are you sure?');
        if (varIsConf) {
            $http({
                method: 'DELETE',
                url: 'api/PlayerModels/' + PlayerModel.Id,
                data: $scope.PlayerModel
            }).success(function () {
                GetAllPlayers();
                $scope.errors = [];
            }).error(function () {
                alert(data.errors);
            });
        }
    };

    $scope.updatePlayer = function () {
        $http({
            method: 'POST',
            url: 'api/PlayerModels/',
            data: $scope.PlayerModel
        }).success(function () {
            GetAllPlayers();
            $scope.isDisabledsave = false;
            $scope.isDisabledupdate = true;
            $scope.PlayerModel = null;
        }).error(function () {
            alert(data.errors);
        });
    };
});