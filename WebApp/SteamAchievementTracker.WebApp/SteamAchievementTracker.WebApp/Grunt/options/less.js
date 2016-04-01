var settings = require('../settings');
module.exports = {
    dist: {
        options: {
            // cssmin will minify later
            compress: false 
        },
        files: {
            '<%= settings.css.dist%><%=settings.css.distfilename%>.css': '<%= settings.css.src %>'
        }
    }
}