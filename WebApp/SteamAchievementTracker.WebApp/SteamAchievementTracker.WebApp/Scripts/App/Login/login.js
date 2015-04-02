(function () {
    'use strict';

    angular
        .module('app.login')
        .controller('Login', Login);

    Login.$inject = ['$scope', '$q', 'dataservice', 'logger', '$rootScope', 'AuthService'];

    function Login($scope, $q, dataservice, logger, $rootScope, AuthService) {

        /*jshint validthis: true */
        var vm = this;


        vm.avengerCount = 0;
        vm.avengers = [];
        vm.userEvents = [];
        vm.title = 'Dashboard';

        //$scope.credentials = {
        //    username: ''
        //};
        //$scope.login = function (credentials) {
        //    AuthService.login(credentials).then(function (user) {
        //        $rootScope.$broadcast(AUTH_EVENTS.loginSuccess);
        //        $scope.setCurrentUser(user);
        //    }, function () {
        //        $rootScope.$broadcast(AUTH_EVENTS.loginFailed);
        //    });
        //};

        activate();


        //logger.info(AuthService.isAuthenticated());

        function activate() {
            //var promises = [getAvengersCast(), getTokenEvents()];
            var promises = [];
            //            Using a resolver on all routes or dataservice.ready in every controller
            //            return dataservice.ready(promises).then(function(){
            return $q.all(promises).then(function () {
                logger.info('Activated Dashboard View');
                //myInterval = setInterval(getNewEvents, 5000);
                //getNewEvents();
            });
        }

        //function getNewEvents() {
        //    console.log(vm.userEvents);
        //    var eLength = vm.userEvents.length;
        //    var id = vm.userEvents[eLength - 1].EventID;

        //    return dataservice.getNewTokenEvents(id).then(function (data) {
        //        if (data.length > 0) {
        //            logger.info('New Events Found');
        //            for (var i = 0; i < data.length; i++) {
        //                vm.userEvents.push(data[i]);
        //            }
        //        }
        //    });
        //}



        //function getAvengersCast() {
        //    return dataservice.getUsers().then(function (data) {
        //        vm.avengers = data;
        //        return vm.avengers;
        //    });
        //}


        //function getTokenEvents() {
        //    return dataservice.getTokenEvents().then(function (data) {
        //        vm.userEvents = data;
        //        return vm.userEvents;
        //    });
        //}

        //$scope.$on("$destroy", function () {
        //    console.log('destorying');

        //    clearInterval(myInterval);
        //});
        $scope.Login = function () {
            console.log('testing');
            AuthService.login($scope.userid);
        };
    }
})();
