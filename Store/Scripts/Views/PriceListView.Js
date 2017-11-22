// Script View/Price

    today = new Date($.now())

    debugger;
    var teste = DateToString(today);
    var app = angular.module("myApp", []);

    app.controller("myCtrl", function ($scope, $http, $filter) {

        //$scope.date = $filter("date")(Date.now(), "yyyy-MM-dd");
        $scope.date = new Date(today);
  
    $scope.LoadPrice = function (DateChanged) {
            debugger;
            $http({
        method: "get",
                url: "../api/PriceList/GetPriceList?date=" + DateToString(DateChanged),
                isArray: true,
            }).then(function (response) {
        $scope.Price = response.data;
    }, function () {})
        };

    });


    app.filter('percentage', ['$filter', function ($filter) {
        return function (input, decimals) {
            return $filter('number')(input, decimals) + '%';
        };
    }]);

    function DateToString(dateToString) {

        var data = dateToString.getFullYear() + "-" + ((dateToString.getMonth() + 1) > 9 ? (dateToString.getMonth() + 1) : "0" + (dateToString.getMonth() + 1)) + "-" + (dateToString.getDate() > 9 ? dateToString.getDate() : "0" + dateToString.getDate());
        return data;
    }






