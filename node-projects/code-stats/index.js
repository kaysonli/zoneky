var fs = require('fs'),
    path = require('path');

var dir = 'D:\\MyProjects\\Roc\\assetallocation.client\\Roc';
// dir = 'D:\\MyProjects\\Roc\\assetallocation.client\\Roc\\ext'
var file = path.join(dir, 'ext-all.js');

var lines = 0;
debugger;
// scan(dir);
countLines(file);

function scan(dir) {
    var stats = fs.statSync(dir);
    if (stats.isDirectory()) {
        if (dir.match(/ext$/)) {
            return;
        }
        var files = fs.readdirSync(dir);
        for (var i = 0; i < files.length; i++) {
            scan(path.join(dir, files[i]));
        }
    } else if (stats.isFile()) {
        if (dir.match(/[.]js$/)) {
            countLines(dir);
        }
    }
}


function countLines(filePath) {
    var stream = fs.createReadStream(filePath);
    var count = 0;
    stream.on('data', function(chunk) {
        var buffer = new Buffer(chunk);
        var lineBreaks = buffer.toString().match(/[\n]/g);
        if (lineBreaks) {
            count += lineBreaks.length;
        }
    });

    stream.on('end', function() {
        lines += count;
        console.log('Total lines in ', filePath, ': ', count);
    });
}
