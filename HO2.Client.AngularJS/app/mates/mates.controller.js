(function() {
    'use strict';

    angular
        .module('app')
        .controller('MatesController', MatesController, ['dataservice', '$scope', '$http']);


    function MatesController($scope, $q, dataservice)
    {
        console.log("I'm in MatesController");
        var vm = this;

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
            return dataservice.getMateById(id)
                .then(function(data) {
                    vm.mate = data;
                    return vm.mate;
                });
        };

        vm.getAllMates = function () {
            return dataservice.getAllMates()
                .then(function (data) {
                    vm.mateList = data;
                    return vm.mateList;
                });
        };

        vm.addMate = function(newmate) {
            return dataservice.addMateWithDetails(newmate);
        };

        vm.updateMate = function (mate) {
            return dataservice.updateMateWithDetails(mate);
        };

        vm.delete = function(id) {
            return dataservice.deleteMateById(id);
        };

    };
}
)();