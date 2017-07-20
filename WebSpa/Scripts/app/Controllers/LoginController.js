(function() {
    angular.module('WebSpaApp').controller('LoginController', LoginController);

    LoginController.$inject = ['loginService', '$state', '$cookies'];

    function LoginController(loginService, $state, $cookies) {
        var vm = this;
        vm.actions = {
            savePlayer: savePlayer,
            deletePlayer: deletePlayer,
            createAndLoginPlayer: createAndLoginPlayer,
            init: init
        }

        vm.playerModel = {};
        vm.allPlayers = {};
        vm.currentPlayer = {};

        init();

        function init() {
            loginService.init().then(function(response) {
                vm.allPlayers = response.data;
                vm.currentPlayer = $cookies.get('currentPlayer');
            });
        }

        function createAndLoginPlayer() {
            loginService.savePlayer(vm.playerModel).then(function () {
                $cookies.put('currentPlayer', vm.playerModel.FirstName + ' ' + vm.playerModel.LastName);
                $state.go('Quiz');
            });
        }

        function savePlayer() {
            loginService.savePlayer(vm.playerModel).then(function() {
                init();
            });
            vm.playerModel = null;
        }

        function deletePlayer(player) {
            init();
            var varIsConf = confirm('Want to delete ' + 'Id: ' + player.Id + ' ' + 'LastName: ' + player.LastName + '. Are you sure?');
            if (varIsConf) {
                loginService.deletePlayer(player).then(function() {
                    init();
                });
            }
            init();
        }
    }

})();