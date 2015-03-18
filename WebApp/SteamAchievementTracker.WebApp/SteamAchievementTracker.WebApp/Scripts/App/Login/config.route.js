(function () {
    'use strict';

    angular
        .module('app.login')
        .run(appRun);

    // appRun.$inject = ['routehelper'];

    /* @ngInject */
    function appRun(routehelper, $rootScope, AuthService) {
        routehelper.configureRoutes(getRoutes());

    }

    function getRoutes() {
        return [
            {
                url: '/',
                config: {
                    templateUrl: 'scripts/app/login/login.html',
                    controller: 'Login',
                    controllerAs: 'vm',
                    title: 'login',
                    settings: {
                        nav: 1,
                        content: '<i class="fa fa-dashboard"></i> Dashboard'
                    }
                }
            }
        ];
    }
})();
