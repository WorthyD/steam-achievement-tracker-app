(function () {
    'use strict';

    angular
        .module('app.services')
        .factory('authService', authService);

    authService.$inject = ['$http'];

    function authService($http) {
        var service = {
            getData: getData
        };

        return service;

        function getData() { }
    }
})();