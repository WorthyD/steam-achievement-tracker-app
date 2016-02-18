module.exports = {
  dist: {
    options: {
      // cssmin will minify later
      style: 'expanded'
    },
    files: {
      '<%= settings.sass.dist%>': '<%= settings.sass.src %>'
    }
  }
}