(function () {
    'use strict';

    angular
        .module('app.home')
        .controller('HomeController', HomeController);

    HomeController.$inject = ['$location'];
    console.log('homecontroller');

    function HomeController($location) {
        /* jshint validthis:true */
        var vm = this;
        vm.title = 'home';

            console.log('home');
        activate();

        function activate() {
            console.log('home');
        }
    }
})();
