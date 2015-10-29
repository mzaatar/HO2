describe('Mate Controller test', function() {

    beforeEach(module('app'));

    var appController, scope;

    beforeEach(inject(function($rootScope, $controller) {
        scope = $rootScope.$new();

        appController = $controller('appController', {
            $scope: scope
        });
    }));
    it('says hello !', function() {
        expect(scope.greeting).toEqual("Hello, AngularJS. This is Hang Out two project");
    });

});