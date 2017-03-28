var app = angular.module("App");
app.factory("service", ["$http", function ($http) {
    return {
        Post: function (url, data) {
            return $http({
                method: "POST",
                url: url,
                dataType: 'json',
                data: data,      //use if want send parameter ::  data: {id:1},
                headers: {
                    "Content-Type": "application/json"
                }
            });
        }
    }
}])