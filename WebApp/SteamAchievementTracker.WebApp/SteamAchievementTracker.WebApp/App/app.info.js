(function() {
    "use strict";
    angular.module("app")
        .factory("appInfo",appInfo);

    appInfo.$inject = [];

    function appInfo(){

        var appInfos = {
            "name" : "App"
        } ;

        return {
            getAppInfo : getAppInfo()
        };

        function getAppInfo() {
            return appInfos;
        }
    }


})();