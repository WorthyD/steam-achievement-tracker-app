var settings = require('../settings');
module.exports = {
    dist: {
        options: {
            banner: '/*! <%= pkg.name %> - v<%= pkg.version %> - ' +
              '<%= grunt.template.today("yyyy-mm-dd hh:MM:ss tt") %> */'
        },
        files: settings.js.concatfiles
    }
}