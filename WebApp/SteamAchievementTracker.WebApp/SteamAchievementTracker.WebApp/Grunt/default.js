module.exports = function (grunt) {
    //grunt.registerTask('dev', ['connect', 'watch']);
    grunt.registerTask('default', ['concat', 'uglify', 'sass', 'imagemin', 'autoprefixer', 'cssmin']);
};