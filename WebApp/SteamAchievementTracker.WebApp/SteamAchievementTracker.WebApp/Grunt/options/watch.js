module.exports = {
  options: {
    livereload: true,
  },
  //scripts: {
  //  files: ['js/*.js'],
  //  tasks: ['jshint', 'concat', 'uglify'],
  //  options: {
  //    spawn: false,
  //  }
  //},
  css: {
    files: ['content/sass/*.scss'],
    //tasks: ['sass',  'cssmin'],
    tasks: ['sass'],
    options: {
      spawn: false,
    }
  }
}