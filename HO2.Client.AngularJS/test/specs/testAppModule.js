///<reference path="~/test/CommonReferences.js"/>

describe('Main Module tests : ', function () {

    var scope;
    var ctrl;

    beforeEach(module('app'));

    beforeEach(inject(function ($rootScope, $controller) {
        scope = $rootScope.$new();
        ctrl = $controller('appController', { $scope: scope });
    }));


    it('Match $scope.message', function () {
        expect(scope.message).toEqual('Hello, AngularJS. This is Hang Out two project');
    });
});