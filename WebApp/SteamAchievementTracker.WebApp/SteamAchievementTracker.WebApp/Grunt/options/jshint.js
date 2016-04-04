var settings = require('../settings');
module.exports = {
    strict: {
        files: { src: settings.js.workingdirectory },
        options: {
            jshintrc: '.jshintrc'
        }
    },
    warn: {
        files: { src: settings.js.workingdirectory },
        options: {
            force: true,
            indent: 4,
            quotmark: true,
            maxlen: 800
        }
    }


}