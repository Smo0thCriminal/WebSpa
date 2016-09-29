(function() {
    angular.module('WebSpaApp').service('loginService', loginService);

    loginService.$inject = ['$http'];

    function loginService($http) {
        var service = {
            savePlayer: savePlayer,
            deletePlayer: deletePlayer,
            init: init
        }
        return service;

        function init() {
            return $http.get('api/PlayerModels');
        }

        function savePlayer(playerModel) {
            return $http.post('api/PlayerModels', playerModel);
        }

        function deletePlayer(playerModel) {
            return $http.delete('api/PlayerModels', {
                params: {
                    id: playerModel.Id
                }
            });
        }
    }


})();