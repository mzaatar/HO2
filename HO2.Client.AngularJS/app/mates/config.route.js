(function () {
    'use strict';

    angular
        .module('app.mates')
        .run(appRun);

    // appRun.$inject = ['routehelper']

    /* @ngInject */
    function appRun(routehelper) {
        routehelper.configureRoutes(getRoutes());
    }

    function getRoutes() {
        return [
            {
                url: '/mates',
                config: {
                    templateUrl: 'app/mates/mates.html',
                    controller: 'MatesController',
                    controllerAs: 'vm',
                    title: 'mates',
                    settings: {
                        nav: 2,
                        content: '<i class="fa fa-lock"></i> Avengers'
                    }
                }
            }
        ];
    }
})();