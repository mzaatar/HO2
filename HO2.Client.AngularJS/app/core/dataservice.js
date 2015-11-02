// dataservice factory
(function() {
    'use strict';

    angular
        .module('app.core')
        .factory('dataservice', dataservice);

    /* @ngInject */

    function dataservice($http) {

        var baseUrl = 'http://localhost:49588/api';
        var matesBaseUrl = baseUrl+'/mates';

        return {
            matesBaseUrl: matesBaseUrl,
            getMateById: getMateById,
            getAllMates: getAllMates,
            addMateWithDetails: addMateWithDetails,
            updateMateWithDetails: updateMateWithDetails,
            deleteMateById: deleteMateById
        };

        function functionFailed(error) {
            console.log('XHR Failed. Error is :' + error);
        }

        function getMateById(id) {
            function getMateByIdComplete(response) {
                console.log("Mate searching for " + id);
                return response.data;
            }

            return $http.get(matesBaseUrl + "/" + id)
                .then(getMateByIdComplete)
                .catch(functionFailed);
        };

        function getAllMates() {
            function getAllMatesComplete(response) {
                console.log("get All mates");
                return response.data;
            }
            return $http.get(matesBaseUrl)
                .then(getAllMatesComplete)
                .catch(functionFailed);
        }


        function addMateWithDetails(newmate) {
            function addMateWithDetailsComplete(response) {
                console.log("Addedd successfully");
                return response.data;
            }

            console.log("inserting a new user with these details : {" + newmate.Email + "} , {" + newmate.FirstName + "} , {" + newmate.LastName + "} !");

            return $http.post(matesBaseUrl + "/", newmate)
                .then(addMateWithDetailsComplete)
                .catch(functionFailed);
        }


        function updateMateWithDetails(mate) {
            function updateMateWithDetailsComplete(response) {
                console.log("Updated successfully");
                return response.data;
            }

            return $http.put(matesBaseUrl + "/", mate)
                .then(updateMateWithDetailsComplete)
                .catch(functionFailed);
        }


        function deleteMateById(id) {
            function deleteMateByIdComplete(response) {
                console.log("Mate with : " + id + ' deleted !');
                console.log(response);
                return response.data;
            }

            return $http.delete(matesBaseUrl + "/" + id)
                .then(deleteMateByIdComplete)
                .catch(functionFailed);
        }
    }
})();