# Dymo

Node.js module for interacting with Dymo LabelWriter printers using the DLS SDK

## Installation

You will need the latest [Dymo LabelWriter software](http://download.dymo.com/dymo/Software/Win/DLS8Setup.8.5.1.exe) installed first.  This provides all of the dependent Dymo libraries.

``` bash
$ npm install dymo --save
```

## TODO

- [x] add package.json
- [x] publish initial module
- [ ] create native bindings for high-level API calls
- [ ] documentation
- [ ] examples
- [ ] add Travis CI

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


## Contributing

Fork, add unit tests for any new or changed functionality.

Lint and test your code.

## Release History

* 0.0.1 Initial release; Module boilerplate
