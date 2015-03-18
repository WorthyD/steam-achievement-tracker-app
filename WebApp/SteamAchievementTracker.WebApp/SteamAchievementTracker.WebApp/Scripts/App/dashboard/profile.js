(function () {
    'use strict';

    angular
        .module('app.dashboard')
        .controller('Profile', Profile);

    Profile.$inject = ['$q', 'dataservice', 'logger', '$routeParams'];

    function Profile($q, dataservice, logger, $routeParams) {
        /*jshint validthis: true */
        var vm = this;

        //vm.avengerCount = 0;
        vm.profile = null;
        vm.title = 'Profile';

        activate();

        function activate() {
            var promises = [getAvengersCast()];
            return $q.all(promises).then(function () {
                logger.info('Activated profile View');
            });
        }

        function getAvengersCast() {
            return dataservice.getUserById($routeParams.profileid).then(function (data) {
                vm.profile = data;
                return vm.profile;
            });
        }
    }
})();
