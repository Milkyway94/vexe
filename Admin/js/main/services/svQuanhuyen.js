var app = angular.module("app");
app.factory("svQuanhuyen", ["$http", function ($http) {
    return {
        GetAllDistrict: function () {
            return $http({
                method: "POST",
                url: "/Admin/Modules/Category/District.aspx/GetAllDistrict",
                dataType: 'json',
                data: {},      //use if want send parameter ::  data: {id:1},
                headers: {
                    "Content-Type": "application/json"
                }
            });
        },
        GetAllProvince: function () {
            return $http({
                method: "POST",
                url: "/Admin/Modules/Category/Province.aspx/GetAllProvince",
                dataType: 'json',
                data: {},      //use if want send parameter ::  data: {id:1},
                headers: {
                    "Content-Type": "application/json"
                }
            });
        },
        GetProvinceById: function (matinh) {
            return $http({
                method: "POST",
                url: "/Admin/Modules/Category/Province.aspx/GetProvinceById",
                dataType: 'json',
                data: { matinh : matinh},      //use if want send parameter ::  data: {id:1},
                headers: {
                    "Content-Type": "application/json"
                }
            });
        },
        AddDistrict: function (district) {
            return $http({
                method: "POST",
                url: "/Admin/Modules/Category/District.aspx/CreateDistrict",
                dataType: 'json',
                data: district,      //use if want send parameter ::  data: {id:1},
                headers: {
                    "Content-Type": "application/json"
                }
            });
        },
        DeleteDistrict: function (Id) {
            return $http({
                method: "POST",
                url: "/Admin/Modules/Category/District.aspx/DeleteDistrict",
                dataType: 'json',
                data: { Id: Id },      //use if want send parameter ::  data: {id:1},
                headers: {
                    "Content-Type": "application/json"
                }
            });
        },
        UpdateDistrict: function (district) {
            return $http({
                method: "POST",
                url: "/Admin/Modules/Category/District.aspx/UpdateDistrict",
                dataType: 'json',
                data: district,
                headers: {
                    "Content-Type": "application/json"
                }
            });
        },
        ExportToExcel: function (nhaxes) {
            return $http({
                method: "POST",
                url: "/Admin/Modules/Category/District.aspx/ExportToExcel",
                dataType: 'json',
                data: { nhaxes: nhaxes },      //use if want send parameter ::  data: {id:1},
                headers: {
                    "Content-Type": "application/json"
                }
            });
        },
    }
}])
