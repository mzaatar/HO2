(function () {

    var httpservices = function ($http) {

        var getMateDetails = function (id) {
            return $http.get("http://localhost:49588/api/mates/" + id)
                .then(function(response) {
                    return reponse.data;
                });
        };

        var getMates = function() {
            return $http.get("http://localhost:49588/api/mates")
                .then(function(response) {
                    return response.data;
                });
        };

        return {
            getMateDetails: getMateDetails,
            getMates: getMates
       };
    };

    var module = angular.module("app");
    module.factory("httpservices", httpservices);

})();