describe('appController test', function() {

    var scope;
    var ctrl;

    beforeEach(module('app'));

    beforeEach(inject(function ($rootScope, $controller) {
        scope = $rootScope.$new();
        ctrl = $controller('appController', { $scope: scope });
    }));


    it('should have an initial documentSaved state', function () {
        expect(scope.message).toEqual('Hello, AngularJS. This is Hang Out two project');
    });
});