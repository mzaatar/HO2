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
                'Email': 'Cormac@gmail.net',
                'FirstName': 'Cormac',
                'LastName': 'Cormac'
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
                'Email': 'Ahmed.Helmi@gmail.com',
                'FirstName': 'Ahmed',
                'LastName': 'Helmi'
            }
        ];
    }
})();
