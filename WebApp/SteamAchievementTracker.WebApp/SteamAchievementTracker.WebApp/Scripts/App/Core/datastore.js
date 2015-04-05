(function () {
    'use strict';
    //angular
      //  .module('app.core', ['indexedDB']).config(datastore);
        //.factory('datastore', datastore)

    /* @ngInject */
    function datastore() {
        console.log('buidling datastore')
        $indexedDBProvider
      .connection('myIndexedDB')
      .upgradeDatabase(1, function (event, db, tx) {
          var objStore = db.createObjectStore('people', { keyPath: 'ssn' });
          objStore.createIndex('name_idx', 'name', { unique: false });
          objStore.createIndex('age_idx', 'age', { unique: false });
      });
    };


})