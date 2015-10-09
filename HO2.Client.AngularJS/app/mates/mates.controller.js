(function() {
    'use strict';

    angular
        .module('app')
        .controller('MatesController', MatesController, ['$scope','$http']);

    //Mates.$inject = ['$q', 'dataservice', 'logger'];

    function MatesController($scope, $http) //($q, dataservice, logger)
    {
        console.log("I'm in MatesController");
        var vm = this;

        var onSearchComplete = function (response) {
            vm.mate = response.data;
        };

        var onGetAllComplete = function (response) {
            vm.mateList = response.data;
        };

        var onAdded = function (response) {
            console.log("addedd successfully");
        };

        var onError = function (reason) {
            vm.error = reason;
            console.log("reason : " + reason);
        };

        vm.search = function(id) {
            console.log("searching for " + id);
            $http.get("http://localhost:49588/api/mates/" + id)
                .then(onSearchComplete, onError);
        };


        vm.getAllMates = function (id) {
            console.log("get All mates ");
            $http.get("http://localhost:49588/api/mates")
                .then(onGetAllComplete, onError);
        };


        vm.addMate = function (newmate) {
            console.log("inserting a new user with these details : {" + newmate.email + "} , {" + newmate.firstname + "} , {" + newmate.lastname + "}");
            $http.post("http://localhost:49588/api/mates/", newmate)
                .then(onAdded, onError);
        };

    };
}
)();