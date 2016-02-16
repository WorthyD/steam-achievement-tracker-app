(function () {
    angular.module('app').
        run(init);

    init.$inject = ['$rootScope'];

    function init($rootScope) {
        //Initialize User

        console.log('running');

        $rootScope.$on("$stateChangeError", console.log.bind(console));
        $rootScope.$on('$stateNotFound',
function (event, unfoundState, fromState, fromParams) {
    console.log(unfoundState.to); // "lazy.state"
    console.log(unfoundState.toParams); // {a:1, b:2}
    console.log(unfoundState.options); // {inherit:false} + default options
});

        $rootScope.$on('$stateChangeStart',
function (event, toState, toParams, fromState, fromParams, options) {
    console.log('going somewhere');
    console.log(toState);
    console.log(fromState);
    // transitionTo() promise will be rejected with 
    // a 'transition prevented' error
});

        $rootScope.$on('$stateChangeSuccess', 
function (event, toState, toParams, fromState, fromParams) {

    console.log('going somewhere success');
    console.log(toState);
    console.log(fromState);

})


    }
})();