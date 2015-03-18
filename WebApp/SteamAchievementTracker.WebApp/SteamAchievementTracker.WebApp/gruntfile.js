/// <vs AfterBuild='less' />
module.exports = function (grunt) {

    grunt.initConfig({
        less: {
            style: {
                options: {
                    sourceMap: true,
                    relativeUrls: true
                },
                files: [{
                    expand: true,
                    src: ['content/styles/main.less'],
                    ext: '.css'
                }]
            },
            production: {
                options: {
                    cleancss: true
                },
                files: [{
                    expand: true,
                    src: ['content/styles/main.less'],
                    ext: '.min.css'
                }]
            }

        },
        //imagemin: {
        //    dynamic: {
        //        files: [{
        //            expand: true,                  // Enable dynamic expansion
        //            cwd: 'content/images-src/',   // Actual patterns to match
        //            src: ['**/*.{jpg,png,gif}'],   // Actual patterns to match
        //            dest: 'content/images/'
        //        }]
        //    }
        //},
        watch: {
            css: {
                files: ['content/styles/**/*.less'],
                tasks: ['less:style'],
                options: {
                    livereload: true
                }
            }
            //img: {
            //    files: ['content/images-src/**/*.{jpg,png,gif}'],
            //    tasks: ['imagemin'],
            //    options: {
            //        livereload: true
            //    }
            //}
        }
    });
    
    grunt.loadNpmTasks('grunt-contrib-concat');
    grunt.loadNpmTasks('grunt-contrib-less');
    grunt.loadNpmTasks('grunt-contrib-watch');
    //grunt.loadNpmTasks('grunt-contrib-imagemin');

    grunt.registerTask('default', ['watch']);

};



