(function () {
    'use strict';

    angular
        .module('app.core')
        .service('Session', session);

    session.$inject = [];

    function session() {
        this.create = function (sessionId, userId) {
            this.sessionId = sessionId;
            this.userId = userId;
        };

        this.destroy = function () {
            this.sessionId = null;
            this.userId = null;
        };

    }
})();