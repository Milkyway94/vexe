var app = angular.module("app");
app.factory("Service", ["$http", function ($http) {
    return {
        Api: function (method, url, dataType, data) {
            return $http({
                method: method,
                url: url,
                dataType: dataType,
                data: data,      //use if want send parameter ::  data: {id:1},
                headers: {
                    "Content-Type": "application/json"
                }
            });
        },
        Post: function (url, data) {
            return $http({
                method: "POST",
                url: url,
                dataType: "json",
                data: data,      //use if want send parameter ::  data: {id:1},
                headers: {
                    "Content-Type": "application/json"
                }
            });
        }
    }
}])