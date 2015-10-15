(function() {
    'use strict';

    angular
        .module('app')
        .controller('MatesController', MatesController, ['dataservice', '$scope', '$http']);


    function MatesController($scope, $q, dataservice)
    {
        console.log("I'm in MatesController");
        var vm = this;

        var onGetAllComplete = function (response) {
            vm.mateList = response.data;
        };

        var onAdded = function (response) {
            console.log("Addedd successfully");
        };

        var onUpdated = function (response) {
            console.log("Updated successfully");
        };

        var onError = function (reason) {
            vm.error = reason;
            console.log("reason : " + reason);
        };


        vm.search = function (id) {
            console.log("searching for " + id);

            dataservice.getMateById(id)
             .success(function (data) {
                vm.mate = data;
            })
            .error(function (error) {
                console.log('Unable to load customer data: ' + error.message);
          });
        };


        vm.getAllMates = function () {
            console.log("get All mates ");
            $http.get("http://localhost:49588/api/mates")
                .then(onGetAllComplete, onError);
        };


        vm.addMate = function (newmate) {
            console.log("inserting a new user with these details : {" + newmate.email + "} , {" + newmate.firstname + "} , {" + newmate.lastname + "}");
            $http.post("http://localhost:49588/api/mates/", newmate)
                .then(onAdded, onError);
        };

        vm.updateMate = function (mate) {
            console.log("inserting a new user with these details : {" + mate.Id + "} , {" + mate.Email + "} , {" + mate.Firstname + "} , {" + mate.Lastname + "}");
            $http.put("http://localhost:49588/api/mates/", mate)
                .then(onUpdated, onError);
        };

    };
}
)();