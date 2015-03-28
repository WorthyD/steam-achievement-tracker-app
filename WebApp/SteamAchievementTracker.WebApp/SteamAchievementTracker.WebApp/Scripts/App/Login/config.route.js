(function () {
    'use strict';

    angular
        .module('app.login')
        .run(appRun);

    // appRun.$inject = ['routehelper'];

    /* @ngInject */
    function appRun(routehelper, $rootScope,$scope,  $location) {
        routehelper.configureRoutes(getRoutes());

        // register listener to watch route changes
        $rootScope.$on("$routeChangeStart", function (event, next, current) {
            console.log("rout change start");
            console.log($scope)
            console.log(next.templateUrl)
            if ($rootScope.loggedUser == null) {
                // no logged user, we should be going to #login
                if (next.templateUrl == "scripts/app/login/login.html") {
                    // already going to #login, no redirect needed
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
