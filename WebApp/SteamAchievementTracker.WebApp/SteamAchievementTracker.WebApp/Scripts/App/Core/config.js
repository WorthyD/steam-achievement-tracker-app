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
        console.log('config');
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
      .connection('myIndexedDB')
      .upgradeDatabase(1, function (event, db, tx) {
          console.log('building');
          var objStore = db.createObjectStore('people', { keyPath: 'ssn' });
          objStore.createIndex('name_idx', 'name', { unique: false });
          objStore.createIndex('age_idx', 'age', { unique: false });
      });
    }
})();
