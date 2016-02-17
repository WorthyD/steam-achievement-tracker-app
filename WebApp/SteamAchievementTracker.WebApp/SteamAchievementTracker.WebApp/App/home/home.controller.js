(function () {
    'use strict';

    angular
        .module('app.home')
        .controller('HomeController', HomeController);

    HomeController.$inject = ['$location'];

    function HomeController($location) {
        /* jshint validthis:true */
        var vm = this;
        vm.title = 'home';

        activate();

        function activate() {
        }
    }
})();
