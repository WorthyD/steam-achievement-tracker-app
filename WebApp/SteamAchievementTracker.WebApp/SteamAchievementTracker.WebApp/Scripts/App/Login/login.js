(function () {
    'use strict';

    angular
        .module('app.login')
        .controller('Login', Login);

    Login.$inject = ['$scope', 'logger', '$rootScope', 'AuthService'];

    function Login($scope, logger, $rootScope, AuthService) {

        /*jshint validthis: true */
        var vm = this;

        activate();

        function activate() {
            //var promises = [getAvengersCast(), getTokenEvents()];
            var promises = [];
        
        }

    
        $scope.Login = function () {
            AuthService.login($scope.userid);
        };
    }
})();
