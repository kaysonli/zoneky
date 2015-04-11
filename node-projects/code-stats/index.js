var fs = require('fs'),
    path = require('path');

exports.sloc = function() {
    var argv = process.argv;
    var dir = '',
        fileTypes = ['.js', '.html', '.htm', '.css'],
        ignoredFolders = [];
    if (argv.length <= 2) {
        dir = path.resolve('.');
    } else {
        dir = path.normalize(argv[2]);
        dir = path.resolve(dir);
        fileTypes = argv[3] ? argv[3].split(',') : fileTypes;
        ignoredFolders = argv[4] ? argv[4].split(',') : [];
    }
    hanlder(dir, fileTypes, ignoredFolders);
}

function hanlder(dir, fileTypes, ignoredFolders) {
    var loc = {};
    for (var i = 0; i < fileTypes.length; i++) {
        loc[fileTypes[i]] = 0;
    }

    var defers = [],
        actions = 0;
    setTimeout(function() {
        scan(dir, fileTypes);
        for (var i = 0, ln = defers.length; i < ln; i++) {
            var args = defers[i];
            countLines(args[0], args[1], args[2]);
        }
    }, 0);


    function scan(dir) {
        var stats = fs.statSync(dir);
        if (stats.isDirectory()) {
            if (~ignoredFolders.indexOf(dir)) {
                return;
            }
            var files = fs.readdirSync(dir);
            for (var i = 0; i < files.length; i++) {
                scan(path.join(dir, files[i]));
            }
        } else if (stats.isFile()) {
            for (var i = 0; i < fileTypes.length; i++) {
                var reg = new RegExp(fileTypes[i] + '$', 'i');
                if (dir.match(reg)) {
                    defers.push([dir, loc, fileTypes[i]]);
                    // countLines(dir, loc, fileTypes[i]);
                }
            }
        }
    }

    function countLines(filePath, loc, fileType) {
        var stream = fs.createReadStream(filePath);
        var count = 1;
        stream.on('data', function(chunk) {
            var buffer = new Buffer(chunk);
            var lineBreaks = buffer.toString().match(/[\n]/g);
            if (lineBreaks) {
                count += lineBreaks.length;
            }
        });

        stream.on('end', function() {
            loc[fileType] += count;
            if (++actions === defers.length) {
                display(loc);
            }

        });
    }

    function display(loc) {
        for (var ext in loc) {
            console.log(loc[ext] + ' Lines of code in ' + ext + ' files.');
        }
    }
}