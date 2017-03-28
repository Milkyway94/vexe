 var app= angular.module("app");
 app.factory("svPromote", ["$http", function($http){
     return {
         GetAllPromote: function () {
             return $http({
                 method: "POST",
                 url: "/Admin/Modules/Promotion/Default.aspx/GetAllPromote",
                 dataType: 'json',
                 data: {},      //use if want send parameter ::  data: {id:1},
                 headers: {
                     "Content-Type": "application/json"
                 }
             });
         },
         AddPromote: function (Code, Value, Start, End, OrderFrom, OrderTo) {
             return $http({
                 method: "POST",
                 url: "/Admin/Modules/Promotion/Default.aspx/AddPromote",
                 dataType: 'json',
                 data: { Code: Code, Value: Value, Start: Start, End: End, OrderFrom: OrderFrom, OrderTo: OrderTo },      //use if want send parameter ::  data: {id:1},
                 headers: {
                     "Content-Type": "application/json"
                 }
             });
         },
         CheckPromoteCode: function (Code) {
             return $http({
                 method: "POST",
                 url: "/Admin/Modules/Promotion/Default.aspx/CheckPromoteCode",
                 dataType: 'json',
                 data: { Code: Code },      //use if want send parameter ::  data: {id:1},
                 headers: {
                     "Content-Type": "application/json"
                 }
             });
         },
         Active: function (id) {
             return $http({
                 method: "POST",
                 url: "/Admin/Modules/Promotion/Default.aspx/Active",
                 dataType: 'json',
                 data: { id: id },      //use if want send parameter ::  data: {id:1},
                 headers: {
                     "Content-Type": "application/json"
                 }
             });
         }
     }
 }])
