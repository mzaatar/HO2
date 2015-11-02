///<reference path="~/test/CommonReferences.js"/>

'use strict';

describe("Core Module tests : ", function () {

    describe("Http service tests : ", function() {

        var dataservice, httpBackend, matesUrl;

        beforeEach(function () {
            // load the module.
            module('app.core');

            // get your service, also get $httpBackend
            // $httpBackend will be a mock, thanks to angular-mocks.js
            inject(function ($httpBackend, _dataservice_) {
                dataservice = _dataservice_;
                httpBackend = $httpBackend;
                matesUrl = dataservice.matesBaseUrl;
            });
        });

        // make sure no expectations were missed in your tests.
        // (e.g. expectGET or expectPOST)
        afterEach(function () {
            httpBackend.verifyNoOutstandingExpectation();
            httpBackend.verifyNoOutstandingRequest();
        });

        it('should get all mates.', function() {
            var returnData = mockData.getMockMates();

            httpBackend.expectGET(matesUrl).respond(returnData);
            
            var returnedPromise = dataservice.getAllMates();
            var result;
            returnedPromise.then(function (response) {
                result = response;
            });
            httpBackend.flush();
            expect(result).toEqual(returnData);

        });

        it('should send mate Id and return it with details', function () {
            var returnData = mockData.getMockMates()[0];

            httpBackend.expectGET(matesUrl+ '/' + returnData.Id).respond(returnData);

            var returnedPromise = dataservice.getMateById(22);
            var result;
            returnedPromise.then(function (response) {
                result = response;
            });
            httpBackend.flush();
            expect(result).toEqual(returnData);
        });


        it('should add mate and return it', function() {
            var returnData = mockData.getMockMates()[0];

            httpBackend.expectPOST(matesUrl + '/', returnData).respond(returnData);

            var returnedPromise = dataservice.addMateWithDetails(returnData);
            var result;
            returnedPromise.then(function (response) {
                result = response;
            });
            httpBackend.flush();
            expect(result).toEqual(returnData);
        });

        it('should update mate details and save it', function() {
            var returnData = mockData.getMockMates()[0];
            returnData.FirstName = 'Updated Name';

            httpBackend.expectPUT(matesUrl + '/', returnData).respond(returnData);

            var returnedPromise = dataservice.updateMateWithDetails(returnData);
            var result;
            returnedPromise.then(function (response) {
                result = response;
            });
            httpBackend.flush();
            expect(result).toEqual(returnData);
        });

        it('should delete mate by Id and check methdo result', function () {
            var returnData = mockData.getMockMates()[0];

            httpBackend.expectDELETE(matesUrl + '/' + returnData.Id).respond(function (method, data) { return [204, returnData] });

            var returnedPromise = dataservice.deleteMateById(returnData.Id);
            var result;
            returnedPromise.then(function (response) {
                result = response;
            });
            httpBackend.flush();
            expect(result).toEqual(returnData);
        });
    });

    describe("Logger tests : ", function() {
        var fakeloggingprovider;

        beforeEach(function() {
            module('app.core', function() {});

            inject(function(_loggerService_) {
                fakeloggingprovider = _loggerService_;
            });

            spyOn(console, 'log');
        });

        it('should log message and console should recieve it', function() {
            var logText = 'test log';
            fakeloggingprovider.Log(logText);
            expect(console.log).toHaveBeenCalled();
        });

        it('should warn message and console should recieve it', function () {
            var logText = 'test log';
            fakeloggingprovider.Warn(logText);
            expect(console.log).toHaveBeenCalled();
        });

        it('should Error message and console should recieve it', function () {
            var logText = 'test log';
            fakeloggingprovider.Error(logText);
            expect(console.log).toHaveBeenCalled();
        });

        it('should Debug message and console should recieve it', function () {
            var logText = 'test log';
            fakeloggingprovider.Debug(logText);
            expect(console.log).toHaveBeenCalled();
        });
    });
});