(function () {
    'use strict';

    var app = angular.module('app', [
        /*
         * Everybody has access to these.
         * We could place these under every feature area,
         * but this is easier to maintain.
         */
        'app.core',
        

        /*
         * Feature areas
         */
         'app.mates'
    ]);
})();