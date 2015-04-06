(function() {
    'use strict';

    var core = angular.module('app.core');

    //core.config(toastrConfig);

    /* @ngInject */
    //function toastrConfig(toastr) {
        //toastr.options.timeOut = 4000;
        //toastr.options.positionClass = 'toast-bottom-right';
    //}

    var config = {
        appErrorPrefix: '[NG-Modular Error] ', //Configure the exceptionHandler decorator
        appTitle: 'Steam Achievement Tracker',
        version: '1.0.0'
    };

    core.value('config', config);

    core.config(configure);

    /* @ngInject */
    function configure ($logProvider, $routeProvider, routehelperConfigProvider, exceptionHandlerProvider, $indexedDBProvider) {
        // turn debugging off/on (no info or warn)
        if ($logProvider.debugEnabled) {
            $logProvider.debugEnabled(true);
        }

        // Configure the common route provider
        routehelperConfigProvider.config.$routeProvider = $routeProvider;
        routehelperConfigProvider.config.docTitle = 'NG-Modular: ';
        var resolveAlways = { /* @ngInject */
            ready: function(dataservice) {
                return dataservice.ready();
            }
            // ready: ['dataservice', function (dataservice) {
            //    return dataservice.ready();
            // }]
        };
        routehelperConfigProvider.config.resolveAlways = resolveAlways;

        // Configure the common exception handler
        exceptionHandlerProvider.configure(config.appErrorPrefix);


        console.log('buidling datastore')
        $indexedDBProvider
      .connection('SteamAPI')
      .upgradeDatabase(1, function (event, db, tx) {
          var objStore = db.createObjectStore('PlayerProfile', { keyPath: 'SteamID64' });

          var objStore2 = db.createObjectStore('PlayerRecentGames', { keyPath: 'ID64-GameLink' });
          objStore2.createIndex("SteamID64", "SteamID64", { unique: false });

          var objStore3 = db.createObjectStore('Game', { keyPath: 'GameID-SteamID' });
          objStore3.createIndex("SteamID64", "SteamID64", { unique: false });
          objStore3.createIndex("GameID", "GameID", { unique: false });

          var objStore4 = db.createObjectStore('GameAchievement', { });
          objStore4.createIndex("StatsURL", "StatsURL", { unique: false });
      });
    }
})();
