(function () {
    // borrowed from John Papa's angular style guide
    angular
        .module('blocks.router', [])
        .provider('routerHelper', routerHelperProvider);

    routerHelperProvider.$inject = ['$locationProvider', '$stateProvider', '$urlRouterProvider'];
    /* @ngInject */
    function routerHelperProvider($locationProvider, $stateProvider, $urlRouterProvider) {
        /* jshint validthis:true */
        this.$get = RouterHelper;

        //$locationProvider.html5Mode(true);

        RouterHelper.$inject = ['$state'];
        /* @ngInject */
        function RouterHelper($state) {
            var hasOtherwise = false;

            var service = {
                configureStates: configureStates,
                getStates: getStates
            };

            return service;

            function configureStates(states, otherwisePath) {
                states.forEach(function (state) {
                    console.log('adding state', state.state, 'with config', state.config);
                    $stateProvider.state(state.state, state.config);
                });
                if (otherwisePath && !hasOtherwise) {
                    hasOtherwise = true;
                    console.log('adding otherwisePath', otherwisePath);
                    $urlRouterProvider.otherwise(otherwisePath);
                }

                //$urlRouterProvider.otherwise({ redirectTo: '/' });
            }

            function getStates() { return $state.get(); }
        }
    }
})();