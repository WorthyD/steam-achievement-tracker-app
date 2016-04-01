module.exports = {
    options: {
        csslintrc: '.csslintrc'
    },
    src: ['<%= settings.css.dist%><%=settings.css.distfilename%>.css']
}