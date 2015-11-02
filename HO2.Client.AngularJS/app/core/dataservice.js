// dataservice factory
(function() {
    'use strict';

    angular
        .module('app.core')
        .factory('dataservice', dataservice);

    /* @ngInject */

    function dataservice($http, loggerService) {

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
            loggerService.Log('XHR Failed. Error is :' + error);
        }

        function getMateById(id) {
            function getMateByIdComplete(response) {
                loggerService.Log("Mate searching for " + id);
                return response.data;
            }

            return $http.get(matesBaseUrl + "/" + id)
                .then(getMateByIdComplete)
                .catch(functionFailed);
        };

        function getAllMates() {
            function getAllMatesComplete(response) {
                loggerService.Log("get All mates");
                return response.data;
            }
            return $http.get(matesBaseUrl)
                .then(getAllMatesComplete)
                .catch(functionFailed);
        }


        function addMateWithDetails(newmate) {
            function addMateWithDetailsComplete(response) {
                loggerService.Log("Addedd successfully");
                return response.data;
            }

            loggerService.Log("inserting a new user with these details : {" + newmate.Email + "} , {" + newmate.FirstName + "} , {" + newmate.LastName + "} !");

            return $http.post(matesBaseUrl + "/", newmate)
                .then(addMateWithDetailsComplete)
                .catch(functionFailed);
        }


        function updateMateWithDetails(mate) {
            function updateMateWithDetailsComplete(response) {
                loggerService.Log("Updated successfully");
                return response.data;
            }

            return $http.put(matesBaseUrl + "/", mate)
                .then(updateMateWithDetailsComplete)
                .catch(functionFailed);
        }


        function deleteMateById(id) {
            function deleteMateByIdComplete(response) {
                loggerService.Log("Mate with : " + id + ' deleted !');
                loggerService.Log(response);
                return response.data;
            }

            return $http.delete(matesBaseUrl + "/" + id)
                .then(deleteMateByIdComplete)
                .catch(functionFailed);
        }
    }
})();