/*! BoilerPlate - v0.1.0 - 2016-04-04 12:04:51 pm */
!function() {
    var appName = "app";
    angular.module(appName, [ appName + ".core", appName + ".layout", appName + ".home" ]);
}(), function() {
    "use strict";
    angular.module("app.core", [ "ngAnimate", "ngSanitize", "ui.router", "blocks.router", "ui.bootstrap" ]);
}(), function() {
    "use strict";
    angular.module("app.home", []);
}(), function() {
    "use strict";
    angular.module("app.layout", []);
}();
//# sourceMappingURL=modules.js.map