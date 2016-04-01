module.exports = {
    combine: {
        options: {
            banner: '/*! <%= pkg.name %> - v<%= pkg.version %> - ' +
              '<%= grunt.template.today("yyyy-mm-dd hh:MM:ss tt") %> */'
        },

        files: {
            '<%= settings.css.dist%><%=settings.css.distfilename%>.min.css': ['<%= settings.css.dist%><%=settings.css.distfilename%>.css']
        }
    }
}