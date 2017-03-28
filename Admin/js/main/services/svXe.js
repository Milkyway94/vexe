var app = angular.module("app");
app.factory("svXe", ["$http", function ($http) {
    return {
        GetAllXe: function () {
            return $http({
                method: "POST",
                url: "/Admin/Modules/Category/Vehicle.aspx/GetAllXe",
                dataType: 'json',
                data: {},      //use if want send parameter ::  data: {id:1},
                headers: {
                    "Content-Type": "application/json"
                }
            });
        },
        AddXe: function (xe) {
            return $http({
                method: "POST",
                url: "/Admin/Modules/Category/Vehicle.aspx/CreateXe",
                dataType: 'json',
                data: xe,
                headers: {
                    "Content-Type": "application/json"
                }
            });
        },
        DeleteXe: function(Id){
            return $http({
                method: "POST",
                url: "/Admin/Modules/Category/Vehicle.aspx/DeleteXe",
                dataType: 'json',
                data: { Id:Id },      //use if want send parameter ::  data: {id:1},
                headers: {
                    "Content-Type": "application/json"
                }
            });
        },
        UpdateXe: function (xe) {
            return $http({
                method: "POST",
                url: "/Admin/Modules/Category/Vehicle.aspx/UpdateNhaXe",
                dataType: 'json',
                data: xe,
                headers: {
                    "Content-Type": "application/json"
                }
            });
        },
        ExportToExcel: function (xes) {
            return $http({
                method: "POST",
                url: "/Admin/Modules/Category/Vehicle.aspx/ExportToExcel",
                dataType: 'json',
                data: { xes: xes },      //use if want send parameter ::  data: {id:1},
                headers: {
                    "Content-Type": "application/json"
                }
            });
        },
    }
}])
