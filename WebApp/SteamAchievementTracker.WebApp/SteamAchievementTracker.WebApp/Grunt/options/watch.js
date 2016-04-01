var settings = require('../settings');
module.exports = {
    options: {
        livereload: true,
    },
    css: {
        files: settings.css.workingdirectory,
        tasks: ['watchcss'],  //Task in watchtasks.js
        options: {
            spawn: false,
        }
    }
    ,
    js: {
        files: settings.js.workingdirectory,
        tasks: ['watchjs'],   //Task in watchtasks.js
        options: {
            spawn: false,
        }
    }

}