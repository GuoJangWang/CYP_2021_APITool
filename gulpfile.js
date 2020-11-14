
/// <binding BeforeBuild='copy-libs, copy-asset, clean:libs' />
"use strict";

var _ = require("lodash"),
    gulp = require("gulp");


var libs = [
    { name: "@arduino/arduino-iot-client", value: "D:\VS\CYP_2021_APITool-ANC\CYP_2021_APITool\node_modules\@arduino\arduino-iot-client" },
    { name: "razor-partial-views-webpack-plugin", value: "D:\VS\CYP_2021_APITool-ANC\CYP_2021_APITool\node_modules\razor-partial-views-webpack-plugin" }
];


gulp.task("copy-libs", function () {
    libs.forEach(function (item) {
        gulp.src(item.value)
            .pipe(gulp.dest("D:\VS\CYP_2021_APITool-ANC\CYP_2021_APITool\wwwroot\lib" + item.name));
    });
});

/*gulp.task("clean:libs", function (cb) {
    rimraf("./wwwroot/lib/", cb);
});

gulp.task("copy-asset", ["clean:libs", "copy-libs"]);*/