(function() {
    'use strict';

    angular
        .module('app.core')
        .service('loggerService', loggerService);

    /* @ngInject */

    function loggerService() {

        function getFormattedDate() {

            var today = new Date();
            var dd = today.getDate();
            var mm = today.getMonth()+1; //January is 0!
            var yyyy = today.getFullYear();
            var currentTime = today.getHours() + ':' +
                today.getMinutes() + ':' +
                today.getSeconds() + ':' +
                today.getMilliseconds();

            if(dd<10) {
                dd='0'+dd
            } 

            if(mm<10) {
                mm='0'+mm
            } 

            today = dd+'/'+mm+'/'+yyyy;

            return currentTime + ' ' + today;
        };
        this.Log = function(message) {
            console.log(getFormattedDate() + ' - Log : ' + message);
        };

        this.Warn = function (message) {
            console.log(getFormattedDate() + 'Warn : ' + message);
        };

        this.Debug = function (message) {
            console.log(getFormattedDate() + 'Debug : ' + message);
        };

        this.Error = function (message) {
            console.log(getFormattedDate() + 'Error : ' + message);
        };
    }
})();