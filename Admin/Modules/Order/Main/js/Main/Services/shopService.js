var app = angular.module("shopApp");
app.factory("shopService", ["$http", function ($http) {
    return {
        Get: function () {
            return $http({
                method: "POST",
                url: "/WebService.asmx/getAllEmployee",
                dataType: 'JSON',
                data: {},
                headers: {
                    "Content-Type": "application/json"
                }
            });
        },
        //    Get: function () {
        //        return $http({
        //            method: "POST",
        //            url: "/Shop/Default.aspx/GetCart",
        //            dataType: 'json',
        //            data: {},      //use if want send parameter ::  data: {id:1},
        //            headers: {
        //                "Content-Type": "application/json"
        //            }
        //        });
        //    },
        Add: function (firstName, lastName, gender, salary) {
            return $http({
                method: "POST",
                url: "/WebService.asmx/insertEmployee",
                dataType: 'json',
                data: { firstName: FirstName, lastName: LastName, gender: Gender, salary: Salary },      //use if want send parameter ::  data: {id:1},
                headers: {
                    "Content-Type": "application/json"
                }
            });
        },
        //    Update: function (pid, quan) {
        //        return $http({
        //            method: "POST",
        //            url: "/Shop/Default.aspx/UpdateQuantity",
        //            dataType: 'json',
        //            data: { pid: pid, quan: quan },      //use if want send parameter ::  data: {id:1},
        //            headers: {
        //                "Content-Type": "application/json"
        //            }
        //        });
        //    },
        Delete: function (product) {
            return $http({
                method: "POST",
                url: "/WebService.asmx/deleteEmployeeById",
                dataType: 'json',
                data: { id: product.ID },      //use if want send parameter ::  data: {id:1},
                headers: {
                    "Content-Type": "application/json"
                }
            });
        }
    }
}])