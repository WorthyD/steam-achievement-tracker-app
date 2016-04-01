
module.exports = function (grunt) {

    // Utility to load the different option files
    // based on their names
    function loadConfig(path) {
        var glob = require('glob');
        var object = {};
        var key;

        glob.sync('*', { cwd: path }).forEach(function (option) {
            key = option.replace(/\.js$/, '');
            object[key] = require(path + option);
        });

        return object;
    }

    // Initial config
    var config = {
        pkg: grunt.file.readJSON('package.json'),
        settings: grunt.file.readJSON('grunt.settings.json'), //Loads settings so they may be used in string <%= settings.css %>
        concurrent: {
            concurrentbuild: ['build-styles', 'build-scripts'],
            concurrentjsbuild: ['newer:uglify:development', 'newer:uglify:production'],
        }
    }

    // Load all the tasks options in tasks/options base on the name:
    // watch.js => watch{}
    grunt.util._.extend(config, loadConfig('./grunt/options/'));

    grunt.initConfig(config);

    require('load-grunt-tasks')(grunt);

    //Default tasks and builds
    grunt.registerTask('default', ['build', 'watch']);
    grunt.registerTask('build', ['concurrent:concurrentbuild']);

    //JS Specific Tasks
    grunt.registerTask('build-scripts', ['jshint:strict', 'jshint:warn', 'concurrent:concurrentjsbuild']);
    grunt.registerTask('build-scripts-notify', ['build-scripts', 'notify:js']);

    //CSS Specific Tasks
    grunt.registerTask('build-styles', ['newer:sass', 'cssmin']);
    grunt.registerTask('build-styles-notify', ['build-styles', 'notify:css']);

    //Watch Specific Tasks
    grunt.registerTask('watchcss', ['build-styles-notify']);
    grunt.registerTask('watchjs', ['build-script-notify']);

};
