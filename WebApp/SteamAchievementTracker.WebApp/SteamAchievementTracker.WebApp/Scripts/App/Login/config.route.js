(function () {
    'use strict';

    angular
        .module('app.login')
        .run(appRun);

    // appRun.$inject = ['routehelper'];

    /* @ngInject */
    //function appRun(routehelper, $rootScope, $scope,  $location) {
    function appRun(routehelper, $rootScope, $location, logger, AuthService) {
        routehelper.configureRoutes(getRoutes());

        // register listener to watch route changes
        $rootScope.$on("$routeChangeStart", function (event, next, current) {
            logger.info("Is Authenticated", AuthService.isAuthenticated())
            if (AuthService.isAuthenticated() == false) {
                // no logged user, we should be going to #login
                if (next.templateUrl == "scripts/app/login/login.html") {
                    // already going to #login, no redirect needed
                    logger.info('on login page');
                } else {
                    // not going to #login, we should redirect now
                    $location.path("/login");
                }
            }
        });
    }

    function getRoutes() {
        return [
            {
                url: '/login',
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
