(function () {
    'use strict';

    angular
        .module('app.dashboard')
        .controller('Dashboard', Dashboard);

    Dashboard.$inject = [ '$q', 'dataservice', 'logger', 'profileservice', 'Session'];

    function Dashboard( $q, dataservice, logger, profileservice, Session) {

        logger.info('dashboard');

        /*jshint validthis: true */
        var vm = this;


        vm.avengerCount = 0;
        vm.User = null;
        vm.userEvents = [];
        vm.title = 'Dashboard';

        var myInterval = null;

        activate();

        function activate() {
            var promises = [GetUserByID()];
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



        function GetUserByID() {
            console.log(Session);
            return profileservice.getUserById(Session.userId).then(function (data) {
                vm.User = data;
                //validate login
                return vm.User;
            });
        }


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
    }
})();
