// dataservice factory


angular
    .module('app')
    .factory('dataservice', dataservice, ['$http']);

//dataservice.$inject = ['$http'];

function dataservice($http) {

    var baseUrl = 'http://localhost:49588/api/mates';

 
    function getMateById(id) {
        return $http.get(baseUrl + "/" + id);
    };

    function getAllMates() {
        return $http.get(baseUrl)
            .then(function(response) {
                return response.data;
            })
            .catch(function(error) {
                return error;
            });
    }

    function addMateWithDetails(newmate) {
        $http.post(baseUrl + "/", newmate)
            .then(function(response) {
                return response;
            });
    }

    function updateMateWithDetails(mate) {
        $http.put(baseUrl + "/", mate)
            .then(function(response) {
                return response;
            });
    }

    return {
        getMateById: getMateById,
        getAllMates: getAllMates,
        addMateWithDetails: addMateWithDetails,
        updateMateWithDetails: updateMateWithDetails
    };
}