(function () {

    var appName = "app";

    angular.module(appName, [
        /* shared modules */
        appName + ".core",
        appName + ".widgets",
        appName + ".layout",
        appName + ".services",

    ]);
})();