var app = angular.module("app");
app.factory("svNhaXe", ["$http", function ($http) {
    return {
        GetAllNhaXe: function () {
            return $http({
                method: "POST",
                url: "/Admin/Modules/Category/NhaXe.aspx/GetAllNhaXe",
                dataType: 'json',
                data: {},      //use if want send parameter ::  data: {id:1},
                headers: {
                    "Content-Type": "application/json"
                }
            });
        },
        AddNhaXe: function (Tennhaxe, Soluongxe, Trusochinh, Sodienthoai, Nguoidaidien, Gioithieungan, Gioithieuchitiet) {
            return $http({
                method: "POST",
                url: "/Admin/Modules/Category/NhaXe.aspx/CreateNhaXe",
                dataType: 'json',
                data: { Tennhaxe: Tennhaxe, Soluongxe: Soluongxe, Trusochinh: Trusochinh, Nguoidaidien: Nguoidaidien, Sodienthoai: Sodienthoai, Gioithieungan: Gioithieungan, Gioithieuchitiet: Gioithieuchitiet },      //use if want send parameter ::  data: {id:1},
                headers: {
                    "Content-Type": "application/json"
                }
            });
        },
        DeleteNhaXe: function(Id){
            return $http({
                method: "POST",
                url: "/Admin/Modules/Category/NhaXe.aspx/DeleteNhaXe",
                dataType: 'json',
                data: { Id:Id },      //use if want send parameter ::  data: {id:1},
                headers: {
                    "Content-Type": "application/json"
                }
            });
        },
        UpdateNhaXe: function (Id, Tennhaxe, Soluongxe, Trusochinh, Sodienthoai, Nguoidaidien, Gioithieungan, Gioithieuchitiet) {
            return $http({
                method: "POST",
                url: "/Admin/Modules/Category/NhaXe.aspx/UpdateNhaXe",
                dataType: 'json',
                data: { Id: Id, Tennhaxe: Tennhaxe, Soluongxe: Soluongxe, Trusochinh: Trusochinh, Nguoidaidien: Nguoidaidien, Sodienthoai: Sodienthoai, Gioithieungan: Gioithieungan, Gioithieuchitiet: Gioithieuchitiet },      //use if want send parameter ::  data: {id:1},
                headers: {
                    "Content-Type": "application/json"
                }
            });
        },
        ExportToExcel: function (nhaxes) {
            return $http({
                method: "POST",
                url: "/Admin/Modules/Category/NhaXe.aspx/ExportToExcel",
                dataType: 'json',
                data: { nhaxes: nhaxes },      //use if want send parameter ::  data: {id:1},
                headers: {
                    "Content-Type": "application/json"
                }
            });
        },
    }
}])
