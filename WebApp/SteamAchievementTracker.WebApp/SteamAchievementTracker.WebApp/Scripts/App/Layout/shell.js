(function() {
    'use strict';

    angular
        .module('app.layout')
        .controller('Shell', Shell);

    Shell.$inject = ['$rootScope', '$timeout', 'config', 'logger', 'AuthService'];

    function Shell($rootScope, $timeout, config, logger, AuthService) {
        /*jshint validthis: true */
        var vm = this;

        vm.title = config.appTitle;
        vm.busyMessage = 'Please wait ...';
        vm.isBusy = false;
        vm.showSplash = false;


        logger.info('init shell');

        $rootScope.currentUser = null;
        $rootScope.userRoles = USER_ROLES;
        $rootScope.isAuthorized = AuthService.isAuthorized;

        $rootScope.setCurrentUser = function (user) {
            $scope.currentUser = user;
        };

        activate();

        function activate() {
            logger.success(config.appTitle + ' loaded!', null);
//            Using a resolver on all routes or dataservice.ready in every controller
//            dataservice.ready().then(function(){
//                hideSplash();
//            });
            hideSplash();
        }

        function hideSplash() {
            //Force a 1 second delay so we can see the splash.
            $timeout(function() {
                vm.showSplash = false;
            }, 100);
        }
    }
})();
