(function() {
    'use strict';

    function appController($scope) {
        $scope.message = "Hello, AngularJS. This is Hang Out two project";

        console.log("I'm in app.controller");
    }

    angular
        .module('app')
        .controller('appController', appController);
})();