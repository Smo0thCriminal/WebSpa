(function() {
    angular.module('WebSpaApp').controller('LoginController', LoginController);

    LoginController.$inject = ['loginService', '$http', '$state'];

    function LoginController(loginService, $http, $state) {
        var vm = this;
        vm.actions = {
            savePlayer: savePlayer,
            deletePlayer: deletePlayer,
            createAndLoginPlayer: createAndLoginPlayer,
            init: init
        }

        vm.playerModel = {};
        vm.allPlayers = {};

        init();

        function init() {
            loginService.init().then(function(response) {
                vm.allPlayers = response.data;
            });
        }

        function createAndLoginPlayer() {
            loginService.savePlayer(vm.playerModel).then(function() {
                $state.go('Quiz');
            });
            vm.playerModel = null;
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