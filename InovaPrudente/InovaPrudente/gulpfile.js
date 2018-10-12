/// <binding ProjectOpened='watchBabel, watchSass' />
/// <vs SolutionOpened='watchBabel, watchSass' />
/// <binding ProjectOpened='watchBabel, watchSass' />
/// <vs SolutionOpened='watchSass, watchBabel' />
/// <binding ProjectOpened='watchSass, watchBabel' />

var gulp = require('gulp');
var util = require('gulp-util');
var sass = require('gulp-sass');
var cssmin = require('gulp-cssmin');
var rename = require('gulp-rename');
var babel = require("gulp-babel");
var pump = require('pump');
var uglify = require("gulp-uglify");

var config = {
    assetsDir: './Content',
    scriptsDir: './Scripts',
    production: !!util.env.production
};

//Adicionar scripts que usam ES6 na lista para compilação do Babel
var scripts = [
    config.scriptsDir + '/app/*.js',
    '!' + config.scriptsDir + 'app/*.min.js'
];


/* Minify CSS e JS */
/*=============================*/
gulp.task('minifyCSS', function (done) {

    if (config.production) {

        console.log('Configuração release selecionada, minificando CSS');

        return gulp.src([config.assetsDir + '/CSS/*.css', "!" + config.assetsDir + '/CSS/*.min.css'])
        .pipe(cssmin())
        .pipe(rename({ suffix: '.min' }))
        .pipe(gulp.dest(function (f) {
            return f.base;
        }));

    }
    else {

        console.log('Configuração debug selecionada, ignorando etapa de minificação de CSS');
        done();
    }

});

gulp.task("minifyJS", function (done) {

    if (config.production) {

        console.log('Configuração release selecionada, minificando JS');

        //Minifica javascripts do sistema
        return pump([gulp.src([config.scriptsDir + "/app/dist/*.js", "!" + config.scriptsDir + "/app/dist/*.min.js"]),
                uglify().on('error', function (uglify) {

                    console.error(uglify);
                    console.error(uglify.message);

                    this.emit('end');

                }),
                rename({ suffix: '.min' }),
                gulp.dest(config.scriptsDir + "/app/dist/")]);

    }
    else {
        console.log('Configuração debug selecionada, ignorando etapa de minificação de JS');
        done();
    }

});

/* SASS e Babel  */
/*==============================*/
gulp.task('sass', function () {

    console.log("Compilando SASS");

    return gulp.src(config.assetsDir + '/CSS/*.scss')
        .pipe(sass())
        .pipe(gulp.dest(function (f) {
            return f.base;
        }));
});

gulp.task('babel', function () {

    console.log('Executando babel');

    return gulp.src(scripts)
            .pipe(babel().on('error', function (e) {
                console.log(e);
            }))
            .pipe(gulp.dest(config.scriptsDir + '/app/dist'));

});

/* Watches */
/*================================================*/
var watchSass = function () {

    console.log("watching sass");
    return gulp.watch(config.assetsDir + '/css/*.scss', gulp.series('sass'));

}

var watchBabel = function () {

    console.log("watching babel");
    return gulp.watch(scripts, gulp.series('babel'));

}

gulp.task('watchSass', watchSass);
gulp.task('watchBabel', watchBabel);

/* Default */
/* ================================================== */
var watch = function (done) {

    if (util.env.watch) {
        watchSass();
        watchBabel();
    }

    done();
}

gulp.task('default', gulp.series('sass', 'minifyCSS', 'babel', 'minifyJS', watch));