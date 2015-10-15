(function() {
    'use strict';

        angular
            .module('app.mates')
            .controller('MatesController', MatesController);

    /* @ngInject */

    function MatesController($scope, $q, dataservice)
    {
        console.log("I'm in MatesController");
        var vm = this;

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
})();