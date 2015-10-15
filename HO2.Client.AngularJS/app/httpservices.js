// dataservice factory
(function() {
    'use strict';

    angular
        .module('app')
        .factory('dataservice', dataservice, ['$http']);

    /* @ngInject */

    function dataservice($http) {

        var baseUrl = 'http://localhost:49588/api/mates';

        function functionFailed(error) {
            console.log('XHR Failed. Error is :' + error);
        }


        function getMateById(id) {
            function getMateByIdComplete(response) {
                console.log("Mate searching for " + id);
                return response.data;
            }

            return $http.get(baseUrl + "/" + id)
                .then(getMateByIdComplete)
                .catch(functionFailed);
        };

        function getAllMates() {
            function getAllMatesComplete(response) {
                console.log("get All mates");
                return response.data;
            }
            return $http.get(baseUrl)
                .then(getAllMatesComplete)
                .catch(functionFailed);
        }


        function addMateWithDetails(newmate) {
            function addMateWithDetailsComplete(response) {
                console.log("Addedd successfully");
                return response.data;
            }

            console.log("inserting a new user with these details : {" + newmate.email + "} , {" + newmate.firstname + "} , {" + newmate.lastname + "}");

            return $http.post(baseUrl + "/", newmate)
                .then(addMateWithDetailsComplete)
                .catch(functionFailed);
        }


        function updateMateWithDetails(mate) {
            function updateMateWithDetailsComplete(response) {
                console.log("Udpated successfully");
                return response.data;
            }

            return $http.put(baseUrl + "/", mate)
                .then(updateMateWithDetailsComplete)
                .catch(functionFailed);
        }

        var service = {
            getMateById: getMateById,
            getAllMates: getAllMates,
            addMateWithDetails: addMateWithDetails,
            updateMateWithDetails: updateMateWithDetails
        };

        return service;
    }
})();