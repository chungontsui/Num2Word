var main = angular.module('NumToWord', []);

main.controller("ctrl", ['$scope', '$http', function ($scope, $http) {
    $scope.test = "Chung";
    $scope.showError = false;
    $scope.errorMsg = "Number must be between than 0 and 1000";
    $scope.NumberInputClass = "form-group"; 

    $scope.formSubmit = function () {

        $scope.showError = false;
        $scope.NumberInputClass = "form-group";
        $scope.OutputPersonName = "";
        $scope.NumberInWords = "";
        $scope.ErrorMessage = "";

        if ($scope.Number > 999 || $scope.Number < 1)
        {
            $scope.NumberInputClass = "form-group has-error";
            $scope.showError = true;
            return;
        }


        var req = {
            method: 'GET',
            url: "../api/Values/?number=" + $scope.Number,
            headers: {
                'Content-Type': 'application/json'
            }
        };

        $http(req).then(
            function (response) {
                //success
                $scope.OutputPersonName = $scope.PersonName
                $scope.NumberInWords = response.data;
            },
            function (error) {
                //error
                $scope.ErrorMessage = error.data.ExceptionMessage;
            });
    }
}]);