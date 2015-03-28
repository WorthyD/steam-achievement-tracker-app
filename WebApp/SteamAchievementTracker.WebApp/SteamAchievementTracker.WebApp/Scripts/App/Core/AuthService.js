(function () {
    'use strict';

    angular
        .module('app.core')
        .factory('AuthService', function ($http, Session) {
            console.log('AuthService');
            var authService = {};

            authService.login = function (credentials) {
                return $http
                  .post('/login', credentials)
                  .then(function (res) {
                      Session.create(res.data.id, res.data.user.id);
                      return res.data.user;
                  });
            };

            authService.isAuthenticated = function () {
                return !!Session.userId;
            };

            authService.isAuthorized = function (authorizedRoles) {
                if (!angular.isArray(authorizedRoles)) {
                    authorizedRoles = [authorizedRoles];
                }
                return (authService.isAuthenticated() &&
                  authorizedRoles.indexOf(Session.userRole) !== -1);
            };

            return authService;
        })
        .service('Session', function () {
            this.create = function (sessionId, userId) {
                this.id = sessionId;
                this.userId = userId;
            };
            this.destroy = function () {
                this.id = null;
                this.userId = null;
            };
        })
})();