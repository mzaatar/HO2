
//// logging Provider
//// the implementation is derived from : https://github.com/naorye/angular-ny-logger

//(function () {
//    'use strict';

//    angular
//        .module('app.core')
//        .provider('loggingProvider', loggingProvider);

//    /* @ngInject */

//    function loggingProvider() {
//        var isEnabled = true;
//        this.isEnabled = function(isEnabledFlag) {
//            isEnabled = !!isEnabledFlag;
//        };

//        this.$get = ['$log', function ($log) {

//            var Logging = function(context) {
//                this.context = context;
//            };

//            Logging.getInstance = function (context) {
//                return new Logging(context);
//            };

//            Logging.supplant = function(str, o) {  
//                return str.replace(
//                        /\{([^{}]*)\}/g,
//                        function (a, b) {
//                            var r = o[b];
//                            return typeof r === 'string' || typeof r === 'number' ? r : a;
//                        }
//                    );
//            };

//            Logging.getFormattedTimestamp = function (date) {
//                return Logging.supplant('{0}:{1}:{2}:{3}', [
//                     date.getHours(),
//                     date.getMinutes(),
//                     date.getSeconds(),
//                     date.getMilliseconds()
//                ]);
//            };

//            Logging.prototype = {
//                _log: function(originalFn, args) {
//                    if (!isEnabled) {
//                        return;
//                    }

//                    var now = Logging.getFormattedTimestamp(new Date());
//                    var message = '', supplantData = [];
//                    switch (args.length) {
//                    case 1:
//                        message = Logging.supplant("{0} - {1}: {2}", [now, this.context, args[0]]);
//                        break;
//                    case 3:
//                        supplantData = args[2];
//                        message = Logging.supplant("{0} - {1}::{2}(\'{3}\')", [now, this.context, args[0], args[1]]);
//                        break;
//                    case 2:
//                        if (typeof args[1] === 'string') {
//                            message = Logging.supplant("{0} - {1}::{2}(\'{3}\')", [now, this.context, args[0], args[1]]);
//                        } else {
//                            supplantData = args[1];
//                            message = Logging.supplant("{0} - {1}: {2}", [now, this.context, args[0]]);
//                        }
//                        break;
//                    }

//                    $log[originalFn].call(null, Logging.supplant(message, supplantData));
//                },
//                log: function() {
//                    this._log('log', arguments);
//                },
//                info: function() {
//                    this._log('info', arguments);
//                },
//                warn: function() {
//                    this._log('warn', arguments);
//                },
//                debug: function() {
//                    this._log('debug', arguments);
//                },
//                error: function() {
//                    this._log('error', arguments);
//                }

//            };
//            return Logging;

//        }];
//    }
//})();