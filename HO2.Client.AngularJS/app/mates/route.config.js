(function () {
    'use strict';

    angular
        .module('app.mates')
        .condig(config);

    function config($routeProvider) {
        $routeProvider
            .when('/mates', {
                templateUrl: 'app/mates/mates.html',
                controller: 'MatesController',
                controllerAs: 'vm',
                title: 'mates',
                settings: {
                    nav: 2,
                    content: '<i class="fa fa-lock"></i> Avengers'
                }
            });
    }
})();