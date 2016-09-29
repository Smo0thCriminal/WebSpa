angular.module('WebSpaApp').service('loginService', loginService);

loginService.$inject = ['$http'];

function loginService($http) {
    var service = {
        savePlayer: savePlayer,
        deletePlayer: deletePlayer
    }
    return service;

    function savePlayer(playerModel) {
        return $http.post('api/PlayerModels', playerModel);
    }

    function deletePlayer(playerModel) {
        return $http.delete('api/PlayerModels', {
            params: {
                id: playerModel.Id
            }
        });
        //$http({
        //    method: 'DELETE',
        //    url: 'api/PlayerModels/' + playerModel.Id,
        //    data: playerModel.Id
        //});
    }
}

