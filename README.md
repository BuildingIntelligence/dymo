# Dymo

Node.js module for interacting with Dymo LabelWriter printers using the DLS SDK

[![Code Climate](https://codeclimate.com/github/BuildingIntelligence/dymo/badges/gpa.svg)](https://codeclimate.com/github/BuildingIntelligence/dymo)

## Installation

You will need the latest [Dymo LabelWriter software](http://download.dymo.com/dymo/Software/Win/DLS8Setup.8.5.1.exe) installed first.  This provides all of the dependent Dymo libraries.

``` bash
$ npm install dymo --save
```

## Use

This impementation is still very immature and experimental.  Not production ready. YMMV.

```
var dymo = require('dymo');
var fs = require('fs');

// It takes a second or two for initialization to complete.
setTimeout(function(){

	// Gets an array of IPrinter objects (Dymo printers on the current system)
	dymo.printers(null, function(err, printers){
		if (err) throw err;
		console.log(printers);
	});

	// A print object;
	var printArgs = {
		printer: 'DYMO LabelWriter 450 (Copy 1)',	//name of printer
		label: 'test.label',						//path to label
		fields: {
			name: 'Timmy',
			barcode: '100360931'
		},
		images: {
			photo: fs.readFileSync('face.png')
		}
	};

	dymo.print(printArgs, function(err, res){
		if (err) throw err;
		console.log("Print job created.");
	});

}, 2000);

```

## TODO

- [ ] Test coverage
- [ ] Build instructions
- [ ] Make use of EventEmitter and fire Ready event after initialization
- [ ] Improve API
- [ ] Travis CI

## Building

Prerequisits:

Install [Node.js](https://nodejs.org/en/download/).  Then install gyp:

``` bash
$ npm install -g node-gyp
```

For gyp you will also need:

* On Windows:
  * [Python 2.7.x](https://www.python.org/getit/windows)
  * Microsoft Visual Studio C++ 2013
  * [Windows 64-bit SDK](https://msdn.microsoft.com/en-us/windows/desktop/bg162891.aspx)
  * [Dymo LabelWriter v8.5.1](http://download.dymo.com/dymo/Software/Win/DLS8Setup.8.5.1.exe)


## Publishing

``` bash
npm pack
npm publish

```

## Contributing

Fork, add unit tests for any new or changed functionality.

Lint and test your code.

## Release History

* 0.0.1 Initial release; Module boilerplate
