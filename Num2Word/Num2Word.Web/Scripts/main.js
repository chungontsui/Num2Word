var main = angular.module('NumToWord', []);

main.controller("ctrl", ['$scope', '$http', function ($scope, $http) {
    $scope.test = "Chung";

    $scope.formSubmit = function () {

        $scope.showError = false;

        var req = {
            method: 'POST',
            url: "../api/Values/GetNumWord",
            headers: {
                'Content-Type': 'application/json'
            },
            data: {
                number: $scope.Number
            }
        };

        $http(req).then(
            function (response) {
                //success
                $scope.NumberInWords = response;
            },
            function (error) {
                //error
                $scope.returnedMessage = error.data;
                $scope.showError = true;
            });
    }
}]);