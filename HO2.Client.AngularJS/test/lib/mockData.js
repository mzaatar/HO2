/*jshint maxlen:120 */
/*jshint -W079 */
var mockData = (function () {
    return {
        getMockMates: getMockMates
    };

    function getMockMates() {
        return [
            {
                'Id': 22,
                'Email': 'mohamed.zaatar@gmail.com',
                'FirstName': 'Mohamed',
                'LastName': 'Zaatar'
            }, {
                'Id': 23,
                'Email': 'Apple.Iphone@gmail.net',
                'FirstName': 'Apple',
                'LastName': 'Iphone'
            }, {
                'Id': 24,
                'Email': 'unit.test@gmail.com',
                'FirstName': 'Unit',
                'LastName': 'Test'
            }, {
                'Id': 25,
                'Email': 'Karma.Jasmine@gmail.com',
                'FirstName': 'Karma',
                'LastName': 'Jasmine'
            }, {
                'Id': 26,
                'Email': 'xyz.abc@gmail.com',
                'FirstName': 'xyz',
                'LastName': 'abc'
            }
        ];
    }
})();
