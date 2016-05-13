(function () {

    var appName = "app";

    angular.module(appName, [
        /* shared modules */
        appName + ".core",
        appName + ".components",
        //appName + ".widgets",
        appName + ".layout",
        appName + ".services",


        appName + ".home",

    ]);  
})();        