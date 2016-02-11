/**
 * Created by m1thang on 6/2/15.
 */
(function() {
    "use strict";
    angular.module("mfeApp")
        .factory("appInfo",appInfo);

    appInfo.$inject = [];

    function appInfo(){

        var appInfo = {
            "name" : "mfeApp",
            "icon" : "style/img/app_logo.svg",
            "busUnitIcon" : "style/img/spark.svg"
        } ;

        return {
            getAppInfo : getAppInfo()
        };

        function getAppInfo() {
            return appInfo;
        }
    }


})();