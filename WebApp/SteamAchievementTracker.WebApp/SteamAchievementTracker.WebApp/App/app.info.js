(function() {
    "use strict";
    angular.module("app")
        .factory("appInfo",appInfo);

    appInfo.$inject = [];

    function appInfo(){

        var appInfo = {
            "name" : "App"
        } ;

        return {
            getAppInfo : getAppInfo()
        };

        function getAppInfo() {
            return appInfo;
        }
    }


})();