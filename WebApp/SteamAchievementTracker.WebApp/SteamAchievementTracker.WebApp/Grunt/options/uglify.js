var settings = require('../settings');
module.exports = {
    options: {
        banner: '/*! <%= pkg.name %> - v<%= pkg.version %> - ' +
          '<%= grunt.template.today("yyyy-mm-dd hh:MM:ss tt") %> */'
    },
    development: {
        options:{
            sourceMap: true,
            beautify: true,
            mangle: false,
        },
        files: settings.js.developmentmap
    },
    production: {
        files: settings.js.productionmap
    }
}