// gulpfile.js
var gulp = require("gulp"),
    sass = require("gulp-sass")(require('sass'));

var paths = {
    src: {
        node_modules: 'node_modules',
        scss: 'wwwroot/scss/'
    },
    dest: {
        css: 'wwwroot/css/'
    }
};

// Style task
gulp.task("sass", function () {
    return gulp.src(paths.src.scss + 'site.scss')
        .pipe(sass({ includePaths: [paths.src.node_modules] }))
        .pipe(gulp.dest(paths.dest.css));
});

gulp.task("default", gulp.series("sass"));