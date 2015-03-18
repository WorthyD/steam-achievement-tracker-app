(function () {
    'use strict';

    angular
        .module('app.core')
        .factory('dataservice', dataservice);

    /* @ngInject */
    function dataservice($http, $location, $q, exception, logger) {
        var isPrimed = false;
        var primePromise;

        var service = {
            getTokenEvents: getTokenEvents,
            getNewTokenEvents: getNewTokenEvents,
            getUsers: getUsers,
            getUserById: getUserById,
            ready: ready
        };

        return service;

        function getTokenEvents() {
            return $http.get('/api/values')
                .then(getTokenEventsComplete)
                .catch(function (message) {
                    exception.catcher('XHR Failed for Events')(message);
                    //$location.url('/');
                });

            function getTokenEventsComplete(data, status, headers, config) {
                return data.data.Events
            }
        }
        function getNewTokenEvents(id) {
            return $http.get('/api/values/' + id)
                .then(getAvengersComplete)
                .catch(function (message) {
                    exception.catcher('XHR Failed for getAvengers')(message);
                });

            function getAvengersComplete(data, status, headers, config) {
                return data.data.Events
            }
 
        }

        function getAvengerCount() {
            var count = 0;
            return getAvengersCast()
                .then(getAvengersCastComplete)
                .catch(exception.catcher('XHR Failed for getAvengerCount'));

            function getAvengersCastComplete(data) {
                count = data.length;
                return $q.when(count);
            }
        }

        function getUsers() {
            return $http.get('/api/users')
                  .then(getAvengersComplete)
                  .catch(function (message) {
                      exception.catcher('XHR Failed for getAvengers')(message);
                  });

            function getAvengersComplete(data, status, headers, config) {
                return data.data.Users
            }
        }

        function getUserById(id) {
            return getUsers().then(getByIdComplete);

            function getByIdComplete(data) {
                var a = data;
                var retVar = null
                for (var i = 0; i < a.length; i++) {
                    if (a[i].UserID  == id) {
                        retVar = a[i];
                    }
                }
                return $q.when(retVar);
            }

        }

        function prime() {
            // This function can only be called once.
            if (primePromise) {
                return primePromise;
            }

            primePromise = $q.when(true).then(success);
            return primePromise;

            function success() {
                isPrimed = true;
                logger.info('Primed data');
            }
        }

        function ready(nextPromises) {
            var readyPromise = primePromise || prime();

            return readyPromise
                .then(function () { return $q.all(nextPromises); })
                .catch(exception.catcher('"ready" function failed'));
        }

    }
})();
