(function () {
    'use strict';

    angular
        .module('app')
        .factory('authenticationWrapper', authenticationWrapper);

    authenticationWrapper.$inject = ['$http'];

    function authenticationWrapper($http) {
        var service = {
            getData: getData
        };

        return service;

        function getData() { }
    }
})();