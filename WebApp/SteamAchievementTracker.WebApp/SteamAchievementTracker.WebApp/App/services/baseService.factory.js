(function () {
    'use strict';

    angular
        .module('app.services')
        .factory('baseService', baseService);

    baseService.$inject = ['$http'];

    function baseService($http) {
        var service = {
            getData: getData
        };

        return service;

        function getData() { }
    }
})();