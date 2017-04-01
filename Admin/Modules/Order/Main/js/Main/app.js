var app = angular.module("myApp", []);
app.controller("baoCaoController", ['$scope', '$http', 'shopService', 'Service', '$filter', function ($scope, $http, $shopService, $Service, $filter) {
    //$Service.Api("POST", "/WebService.asmx/getAllEmployee", "json", {}).success(function (data) {
    //    //console.log(data);
    //    $scope.products = data.d;
    //    angular.forEach($scope.products, function (p) {
    //        $Service.Api("POST", "/WebService.asmx/getDepartmentByid", "json", { did: 1 }).success(function (res) {
    //            p.Congty = res.d;
    //            console.log(p.Congty);
    //        })
    //    })
    //})
   
    //// select options department
    //$Service.Api("POST", "/WebService.asmx/getAllDepartment", "json", {}).success(function (data) {
    //    console.log(data);
    //    $scope.Deps = data.d;
    //})
}]);