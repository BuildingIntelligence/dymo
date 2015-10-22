var path = require('path');
var fs = require('fs');
var edge = require('edge');

var libDir = path.join(__dirname, 'lib');
var nodeDymoLib = path.join(libDir, 'NodeDymoLib.dll');
var dymoLibPath = path.join('C:', 'Program Files (x86)', 'DYMO', 'DYMO Label Software', 'Framework', '.net4');
dymoAssemblies = [ 'DYMO.Label.Framework.dll', 'DYMO.DLS.Runtime.dll', 'DYMO.Common.dll' ];

var called = 0;

var initDymoLib = function() {
	if (++called < dymoAssemblies.length) return false;

	var printers = module.exports.printers = edge.func({
		assemblyFile: nodeDymoLib,
		typeName: 'NodeDymoLib.Dymo',
		methodName: 'Printers'
	});

	var print = module.exports.print = edge.func({
		assemblyFile: nodeDymoLib,
		typeName: 'NodeDymoLib.Dymo',
		methodName: 'Print'
	});
}

for (var f of dymoAssemblies) {
	var source = path.join(dymoLibPath, f), target = path.join(libDir, f);
	var readStream = fs.createReadStream(source);
	var writeStream = fs.createWriteStream(target);
	readStream.on('error', function(err) { throw err });
	writeStream.on('error', function(err) { throw err });
	writeStream.on('finish', initDymoLib);
	readStream.pipe(writeStream);
}


