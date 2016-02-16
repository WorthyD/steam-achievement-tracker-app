(function() {
    'use strict';

    angular.module('app.core', [
        /*
         * Angular modules
         */
        'ngAnimate',  'ngSanitize',
        /*
         * Our reusable cross app code modules
         */
         'ui.router',
        /*
         * 3rd Party modules
         */
         'blocks.router'
    ]);
})();
