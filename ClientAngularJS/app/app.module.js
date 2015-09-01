(function () {
    'use strict';

    var app = angular.module('app', [
        'ngAnimate', 'ngRoute', 'ngSanitize'

        //'app.core',
        //'app.dashboard',
        //'app.mates'
    ]);

    app.config(function($routeProvider) {
        $routeProvider
            .when("/api/mates", {
                templateUrl: "mates.html",
                controller: "MatesController"
            })
            //.when("/api/mates/:id", {
            //    templateUrl: "votes.html",
            //    controller: "matesController"
            //})
            .otherwise({ redirectTo: "index.html" });
    });
})();