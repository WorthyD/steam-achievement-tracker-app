(function() {
    'use strict';


    var componentConfig = {
        bindings: {
            data: '<'
        },
        templateUrl: 'app/components/saLoginDialog/saLoginDialog.template.html',
        controller: 'saLoginDialogController as vm'
    };


    angular
        .module('app.components')
        .component('saLoginDialog', componentConfig)
        .controller('saLoginDialogController', saLoginDialogController);


    function saLoginDialogController(){

    };
  

})();
