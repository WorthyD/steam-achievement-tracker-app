(function() {
    var app =     angular
            .module("app");
        app.config(configure);

    configure.$inject = [];

    var config = {
        appErrorPrefix: '[NG-Modular Error] ', //Configure the exceptionHandler decorator
        appTitle: 'Angular Modular Demo',
        version: '1.0.0'
    };

    app.value('config', config);

    function configure() {

    }

})();