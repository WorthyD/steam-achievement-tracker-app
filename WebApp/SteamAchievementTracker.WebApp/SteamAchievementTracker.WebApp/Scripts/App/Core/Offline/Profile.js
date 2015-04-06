(function () {
    'use strict';

    angular
        .module('app.core')
        .factory('profilestore', profilestore);


    function profilestore($q, profileservice) {
        var isPrimed = false;
        var primePromise;

        var service = {
            getUserById: getUserById,
            ready: ready
        };

        return service;


        function getUserById(id) {
            //get from store
            //return $http.get('/api/userprofile/' + id)
            //      .then(getUserByIdComplete)
            //      .catch(function (message) {
            //          exception.catcher('XHR Failed for GetUserById')(message);
            //      });

            //function getUserByIdComplete(data, status, headers, config) {
            //    console.log(data.data);
            //    //Add to store
            //    return data.data
            //}


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
