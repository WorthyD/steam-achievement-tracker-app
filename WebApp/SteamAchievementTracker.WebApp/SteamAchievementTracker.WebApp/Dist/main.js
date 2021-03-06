/*! BoilerPlate - v0.1.0 - 2016-04-25 12:25:29 pm */
!function() {
    function configure() {}
    var app = angular.module("app");
    app.config(configure), configure.$inject = [];
    var config = {
        appErrorPrefix: "[NG-Modular Error] ",
        appTitle: "Steam Achievement Tracker",
        version: "1.0.0"
    };
    app.value("config", config);
}(), function() {
    "use strict";
    function appInfo() {
        function getAppInfo() {
            return appInfos;
        }
        var appInfos = {
            name: "App"
        };
        return {
            getAppInfo: getAppInfo()
        };
    }
    angular.module("app").factory("appInfo", appInfo), appInfo.$inject = [];
}(), function() {
    function init($rootScope) {}
    angular.module("app").run(init), init.$inject = [ "$rootScope" ];
}(), function() {
    function routerHelperProvider($locationProvider, $stateProvider, $urlRouterProvider) {
        function RouterHelper($state) {
            function configureStates(states, otherwisePath) {
                states.forEach(function(state) {
                    console.log("adding state", state.state, "with config", state.config), $stateProvider.state(state.state, state.config);
                }), otherwisePath && !hasOtherwise && (hasOtherwise = !0, console.log("adding otherwisePath", otherwisePath), 
                $urlRouterProvider.otherwise(otherwisePath));
            }
            function getStates() {
                return $state.get();
            }
            var hasOtherwise = !1, service = {
                configureStates: configureStates,
                getStates: getStates
            };
            return service;
        }
        this.$get = RouterHelper, RouterHelper.$inject = [ "$state" ];
    }
    angular.module("blocks.router", []).provider("routerHelper", routerHelperProvider), 
    routerHelperProvider.$inject = [ "$locationProvider", "$stateProvider", "$urlRouterProvider" ];
}(), function() {
    "use strict";
    function saLoginDialogController() {}
    var componentConfig = {
        bindings: {
            data: "<"
        },
        templateUrl: "app/components/saLoginDialog/saLoginDialog.template.html",
        controller: "saLoginDialogController as vm"
    };
    angular.module("app.components").component("saLoginDialog", componentConfig).controller("saLoginDialogController", saLoginDialogController);
}(), function() {
    "use strict";
    function authenticationWrapper($http) {
        function getData() {}
        var service = {
            getData: getData
        };
        return service;
    }
    angular.module("app").factory("authenticationWrapper", authenticationWrapper), authenticationWrapper.$inject = [ "$http" ];
}(), function() {
    "use strict";
    angular.module("app.core");
}(), function() {
    "use strict";
    function session() {
        this.create = function(sessionId, userId) {
            this.sessionId = sessionId, this.userId = userId;
        }, this.destroy = function() {
            this.sessionId = null, this.userId = null;
        };
    }
    angular.module("app.core").service("Session", session), session.$inject = [];
}(), function() {
    "use strict";
    function HomeController($location) {
        function activate() {}
        var vm = this;
        vm.title = "home", activate();
    }
    angular.module("app.home").controller("HomeController", HomeController), HomeController.$inject = [ "$location" ];
}(), function() {
    function appRun(routerHelper) {
        routerHelper.configureStates(getStates(), "/");
    }
    function getStates() {
        return [ {
            state: "home",
            config: {
                url: "/",
                templateUrl: "app/home/home.html",
                controller: "HomeController as home"
            }
        } ];
    }
    angular.module("app.home").run(appRun), appRun.$inject = [ "routerHelper" ];
}(), function() {
    "use strict";
    function Shell($timeout, config) {
        function activate() {
            hideSplash();
        }
        function hideSplash() {
            $timeout(function() {
                vm.showSplash = !1;
            }, 1e3);
        }
        var vm = this;
        vm.title = config.appTitle, vm.busyMessage = "Please wait ...", vm.isBusy = !0, 
        vm.showSplash = !0, activate();
    }
    angular.module("app.layout").controller("Shell", Shell), Shell.$inject = [ "$timeout", "config" ];
}(), function() {
    "use strict";
    function Sidebar() {
        function activate() {}
        activate();
    }
    angular.module("app.layout").controller("Sidebar", Sidebar), Sidebar.$inject = [];
}(), function() {
    "use strict";
    function authService($http) {
        function getData() {}
        var service = {
            getData: getData
        };
        return service;
    }
    angular.module("app.services").factory("authService", authService), authService.$inject = [ "$http" ];
}(), function() {
    "use strict";
    function baseService($http) {
        function getData() {}
        var service = {
            getData: getData
        };
        return service;
    }
    angular.module("app.services").factory("baseService", baseService), baseService.$inject = [ "$http" ];
}();
//# sourceMappingURL=main.js.map