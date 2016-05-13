/*! BoilerPlate - v0.1.0 - 2016-04-25 12:21:04 pm */
!function() {
    var appName = "app";
    angular.module(appName, [ appName + ".core", appName + ".components", appName + ".layout", appName + ".services", appName + ".home" ]);
}(), function() {
    "use strict";
    angular.module("app.components", []);
}(), function() {
    "use strict";
    angular.module("app.core", [ "ngAnimate", "ngSanitize", "ui.router", "blocks.router", "ui.bootstrap" ]);
}(), function() {
    "use strict";
    angular.module("app.home", []);
}(), function() {
    "use strict";
    angular.module("app.layout", []);
}(), function() {
    "use strict";
    angular.module("app.services", []);
}();
//# sourceMappingURL=modules.js.map