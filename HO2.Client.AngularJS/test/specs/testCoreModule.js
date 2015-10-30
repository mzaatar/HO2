'use strict';

describe("Core Module unit testing", function () {


    describe("Http service unit testing", function() {
       
        var dataservice, httpBackend;

        beforeEach(function () {
            // load the module.
            module('app.core');

            // get your service, also get $httpBackend
            // $httpBackend will be a mock, thanks to angular-mocks.js
            inject(function ($httpBackend, _dataservice_) {
                dataservice = _dataservice_;
                httpBackend = $httpBackend;
            });
        });

        // make sure no expectations were missed in your tests.
        // (e.g. expectGET or expectPOST)
        afterEach(function () {
            httpBackend.verifyNoOutstandingExpectation();
            httpBackend.verifyNoOutstandingRequest();
        });

        it('should send name and return the response.', function () {
            var name = 'Mohamed';

            // set up some data for the http call to return and test later.
            var returnData = 'Im HttpServices and I feel Ok !';

            // expectGET to make sure this is called once.
            httpBackend.expectGET('somthing.json?name='+name).respond(returnData);

            // make the call.
            var returnedPromise = dataservice.getSomething(name);

            // set up a handler for the response, that will put the result
            // into a variable in this scope for you to test.
            var result;
            returnedPromise.then(function (response) {
                result = response;
            });

            // flush the backend to "execute" the request to do the expectedGET assertion.
            httpBackend.flush();

            // check the result. 
            // (after Angular 1.2.5: be sure to use `toEqual` and not `toBe`
            // as the object will be a copy and not the same instance.)
            expect(result).toEqual(returnData);
        });

        it('should get all mates.', function() {
            var returnData = mockData.getMockMates();

            httpBackend.expectGET().respond(returnData);

            var returnedPromise = dataservice.getAllMates();
            var result;
            returnedPromise.then(function (response) {
                result = response;
            });
            httpBackend.flush();
            expect(result).toEqual(returnData);

        });


        it('should send mateId and return it with details', function () {
            var returnData = mockData.getMockMates();// get the ID ?

            httpBackend.expectGET().respond(returnData);

            var returnedPromise = dataservice.getMateById(22);
            var result;
            returnedPromise.then(function (response) {
                result = response;
            });
            httpBackend.flush();
            expect(result).toEqual(returnData);

        });
    });
});