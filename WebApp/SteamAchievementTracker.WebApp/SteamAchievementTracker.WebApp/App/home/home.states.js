(function () {
    angular
        .module("app.home")
        .run(appRun);

    appRun.$inject = ["routerHelper"];

    function appRun(routerHelper) {
        routerHelper.configureStates(getStates(), "/");
    }

    function getStates() {
        return [{
            state: "home",
            config: {
                url: "/",
                templateUrl: "app/home/home.html",
                controller: "HomeController as home"
            }
        }];
    }
})();
