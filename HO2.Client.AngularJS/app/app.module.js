(function () {
    'use strict';

    var app = angular.module('app', [
        //'ngAnimate', 'ngRoute', 'ngSanitize'

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

    //app.config(function($routeProvider) {
    //    $routeProvider
    //        .when("/api/mates", {
    //            templateUrl: "mates.html",
    //            controller: "MatesController"
    //        })
    //        //.when("/api/mates/:id", {
    //        //    templateUrl: "votes.html",
    //        //    controller: "matesController"
    //        //})
    //        .otherwise({ redirectTo: "index.html" });
    //});
})();