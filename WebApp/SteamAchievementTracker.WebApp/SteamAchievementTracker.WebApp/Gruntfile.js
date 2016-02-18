
module.exports = function(grunt) {

    // Utility to load the different option files
    // based on their names
    function loadConfig(path) {
        var glob = require('glob');
        var object = {};
        var key;

        glob.sync('*', {cwd: path}).forEach(function(option) {
            key = option.replace(/\.js$/,'');
            object[key] = require(path + option);
        });

        return object;
    }

    // Initial config
    var config = {
        pkg: grunt.file.readJSON('package.json'),
        settings: grunt.file.readJSON('grunt.settings.json')
    }

    // Load tasks from the tasks folder
    grunt.loadTasks('grunt');

    // Load all the tasks options in tasks/options base on the name:
    // watch.js => watch{}
    grunt.util._.extend(config, loadConfig('./grunt/options/'));

    grunt.initConfig(config);

    require('load-grunt-tasks')(grunt);
    console.log('testing');
    console.log(config.settings);
    console.log('------------------------');
    console.log('<%= config.settings %>');

    // Default Task is basically a rebuild
    //grunt.registerTask('default', ['concat', 'uglify', 'sass', 'imagemin', 'autoprefixer', 'cssmin']);

    // Moved to the tasks folder:
    // grunt.registerTask('dev', ['connect', 'watch']);

};

//var grunt = require('grunt')
//module.exports = grunt.file.readJSON('grunt.settings.json');