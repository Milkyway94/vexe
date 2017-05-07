var app = angular.module("App", ['angular.filter']);
app.controller("SearchController", ['$scope', '$http', '$location', 'service', function ($scope, $http, $location, $service) {
    var url = "/Default.aspx";
    $scope.alltinh = {};
    $scope.loading = false;
    $scope.tinh = {};
    $scope.showResult = false;
    $scope.showSearch = false;
    $scope.Selected = {};
    $scope.sSelected = [];
    $scope.AllResult = [];
    $scope.YcGiodi = {};
    $service.Post(url + "/LayTatCaDiaDiem", {})
        .success(function (data) {
            $scope.Diemdies = JSON.parse(data.d);
            autocomplete($scope.Diemdies);
        })
    $scope.Diemdi = getQueryString("di-tu");
    $scope.Diemden = getQueryString("den");
    $scope.Ngaydi = getQueryString("ngay");
    $scope.Giodi = getQueryString("luc");
    if ($scope.Diemdi && $scope.Diemden) {
        $scope.showResult = true;
        $scope.showSearch = false;
    }
    else {
        $scope.showResult = false;
        $scope.showSearch = true;
    }
    $scope.DaoTuyen = function () {
        var tg = $scope.Diemdi;
        $scope.Diemdi = $scope.Diemden;
        $scope.Diemden = tg;
    }
    var Code = [];
    $scope.SearchResult = [];
    $scope.options2 = {
        country: 'vn',
        types: 'geocode'
    };
    $scope.details2 = '';
    $service.Post(url + "/SearchTravel", { Diemdi: $scope.Diemdi, Diemden: $scope.Diemden, Ngaydi: $scope.Ngaydi, Giodi: $scope.Giodi }).success(function (data) {
        $scope.loading = false;
        $scope.Nhaxes = []; $scope.Giodi = []; $scope.Hangxes = [];
        $scope.SearchResult = data.d;
        $scope.AllResult = data.d;
        angular.forEach($scope.SearchResult, function (item) {
            if (item.Xe.NhaXe1)
                $scope.Nhaxes.push(item.Xe.NhaXe1);
            if (item.Xe.NhaXe1)
                $scope.Hangxes.push(item.Xe.Hangxe);
        });
        $scope.Nhaxes = Unique($scope.Nhaxes, "Tennhaxe");
        $scope.Giodies = Unique($scope.SearchResult, "Giokhoihanh");
        $scope.Hangxes = Unique($scope.Hangxes, "Hangxe");
        console.log($scope.SearchResult);
    })
        .error(function (data) {
            console.log("Error: ", data);
        });
    $scope.Search = function () {
        $scope.loading = true;
        $scope.showSearch = true;
        if ($scope.frmSearch.Ngaydi) {
            var ngaydi = convertToDateTime('#ngaydi');
            if (isPastDate(ngaydi)) {
                alert("Bạn không thể chọn ngày quá khứ.");
                $scope.loading = false;
                $('#ngaydi').focus();
                $('#ngaydi').css("border", "1px solid red");
            }
            else {
                window.location.href = "/ket-qua-tim-kiem-ve-xe.htm?di-tu=" + $scope.frmSearch.Diemdi + "&den=" + $scope.frmSearch.Diemden + "&ngay=" + $scope.frmSearch.Ngaydi;
            }
        }
    }
    $scope.Detail = function (item) {
        console.log(item);
        $scope.Selected = item;
        $("#row-" + item.MaChuyenXe).toggle(200);
        $(".tp").attr('tabindex', 1);
        $(".tp").focus();
    }
    $scope.DatVe = function (item) {
        $scope.Selected = item;

        window.location.href = "/thanh-toan/" + item.url + ".htm";
    }
    $scope.SortByNhaXe = function (item) {
        if (item != 0) {
            $("#btnNhaxe").html(item.Tennhaxe);

        }
        else
            $("#btnNhaxe").html("Tất cả nhà xe");
        $scope.sSelected.Nhaxe = item.Tennhaxe;
    }
    $scope.SortByHangXe = function (item) {
        if (item != 0) {
            $("#btnHangxe").html(item);
            $scope.sSelected.Hangxe = item;
        }
        else {
            $("#btnHangxe").html("Tất cả loại xe");
        }

    }
    $scope.SortByGiodi = function (item) {
        if (item != 0) {
            $("#btnGiodi").html(item.Giokhoihanh);

        }
        else
            $("#btnGiodi").html("Tất cả các giờ");
        $scope.sSelected.Giodi = item.Giokhoihanh;
    }
    $scope.lower_price_bound = 0;
    $scope.upper_price_bound = 50;
    $scope.items = $scope.SearchResult;
    $scope.SaveYC = function () {
        $scope.loading = true;
        if ($scope.YcNgaydi) {
            var ngaydi = convertToDateTime('#ycNgaydi');
            if (isPastDate(ngaydi)) {
                alert("Bạn không thể chọn ngày quá khứ.");
                $scope.loading = false;
            }
            else if (!validatePhone($scope.YcSdt)) {
                $scope.showError = true;
                $scope.sdtError = "Sai định dạng số điện thoại";
                $scope.loading = false; 
            }
            else {
                $scope.showError = false;
                $scope.sdtError = "";
                var dataRequest = {
                    from: setNotNull($scope.YcDiemDi),
                    to: setNotNull($scope.YcDiemDen),
                    startdate: setNotNull($scope.YcNgaydi),
                    starttime: setNotNull($scope.YcGiodi),
                    more: setNotNull($scope.YcMore),
                    sdt: setNotNull($scope.YcSdt)
                }
                console.log(dataRequest);
                $service.Post(url + "/SaveYc", dataRequest)
                    .success(function (data) {
                        console.log(data.d);
                        $scope.loading = false;
                        $scope.showError = true;
                        $scope.message = data.d.message;
                    })
                    .error(function (err) {
                        console.log(err);
                    })
            }
        }

    }
    $scope.HuyYC = function () {
        $service.Post(url + "/HuyYC", {})
            .success(function (data) {
                console.log(data.d);
                alert(data.d.message);
                window.location.reload();
            })
    }
    //function
    function Unique(collection, keyname) {
        var output = [],
            keys = [];

        angular.forEach(collection, function (item) {
            var key = item[keyname];
            if (keys.indexOf(key) === -1) {
                keys.push(key);
                output.push(item);
            }
        });

        return output;
    }
    function getQueryString(name) {
        var url = window.location.href;
        name = name.replace(/[\[\]]/g, "\\$&");
        var regex = new RegExp("[?&]" + name + "(=([^&#]*)|&|#|$)"),
            results = regex.exec(url);
        if (!results) return null;
        if (!results[2]) return '';
        return decodeURIComponent(results[2].replace(/\+/g, " "));
    }
    function setNotNull(str) {
        if (str) {
            return str;
        }
        else {
            return "";
        }
    }
}]);
app.controller("HomeController", ['$scope', '$http', 'service', function ($scope, $http, $service) {
    var url = "/Default.aspx";
    $service.Post(url + "/LayTatCaDiaDiem", {})
        .success(function (data) {
            console.log(data.d);
            $scope.Diemdies = JSON.parse(data.d);
            autocomplete($scope.Diemdies);
        })
    $scope.TimVeXe = function () {
        $scope.loadding = true;
        if ($scope.frmSearch.Ngaydi) {
            var ngaydi = convertToDateTime('.datepicker');
            if (isPastDate(ngaydi)) {
                alert("Bạn không thể chọn ngày quá khứ.");
                $scope.loadding = false;
            }
            else {
                window.location.href = "/ket-qua-tim-kiem-ve-xe.htm?di-tu=" + $scope.frmSearch.Diemdi + "&den=" + $scope.frmSearch.Diemden + "&ngay=" + $scope.frmSearch.Ngaydi + "&luc=" + $scope.frmSearch.Giodi;
            }
        }
    }
    //$scope.updateDiemdi = function (typed) {
    //    $service.Post(url + "/Timxe", { key: type })
    //    .success(function (data) {
    //        $scope.Diemdi = data;
    //    })
    //}
    $scope.Diemden = '';
    $scope.options2 = {
        country: 'vn',
        types: 'geocode'
    };
    $scope.details2 = '';

}])
app.controller("CheckOutController", ['$scope', '$http', 'service', function ($scope, $http, $service) {
    var url = "/Default.aspx";
    var path = window.location.pathname;
    var strArr = path.split('/');
    var nurl = strArr[strArr.length - 1].replace('.htm', '');
    $scope.TongTien = 0;
    $scope.KhuyenMai = 0;
    $scope.GiaTriVeCu = 0;
    $scope.showerror = false;
    //Lay Chuyen Xe
    $service.Post(url + "/GetChuyenXeByUrl", { url: nurl }).success(function (data) {
        $scope.Chuyenxe = data.d;
        $scope.TongTien = ($scope.selectedTicket.VIP * $scope.Chuyenxe.GiaVIP + $scope.selectedTicket.THUONG * $scope.Chuyenxe.GiaThuong);
        console.log($scope.Chuyenxe);
    })
    $service.Post(url + "/ExecProc", { proc: "SP_CCB_Tinh", param: "" }).success(function (data) {
        console.log(data.d);
        $scope.Tinhs = JSON.parse(data.d);
    })
    $scope.SelectDistrict = function () {
        console.log($scope.Province);
        $service.Post(url + "/ExecProc", { proc: "SP_CCB_Huyen_FROM_Tinh", param: $scope.Province ? $scope.Province.id : "" }).success(function (data) {
            console.log(data.d);
            $scope.Huyens = JSON.parse(data.d);
        })
    }
    //So luong ve da chon
    $scope.selectedTicket = {
        VIP: 1,
        THUONG: 1
    }

    //Chọn phương thức thanh toán
    $scope.Method = 1;
    $scope.selectedMethod = function (method) {
        $scope.Method = method;
    }
    //Chọn vé
    $scope.updateTicket = function () {
        if ($scope.selectedTicket.VIP > $scope.Chuyenxe.VeVipConLai) {
            $scope.showerror = true;
            $scope.message = "Số vé bạn chọn đã vượt quá số vé còn lại";
            $scope.selectedTicket.VIP = 30;
        }
        else {
            if ($scope.selectedTicket.THUONG > $scope.Chuyenxe.VeThuongConLai) {
                $scope.showerror = true;
                $scope.message = "Số vé bạn chọn đã vượt quá số vé còn lại";
                $scope.selectedTicket.THUONG = 30;
            }
            else {
                $scope.TongTien = ($scope.selectedTicket.VIP * $scope.Chuyenxe.GiaVIP + $scope.selectedTicket.THUONG * $scope.Chuyenxe.GiaThuong);
            }
        }
    }
    //$(".tbl-car tr td").not("#laixe").click(function () {
    //    var type = $(this).attr('data-type');
    //    var status = $(this).attr('data-status');
    //    if (status == "true") {
    //        $(this).attr('data-status', "false");
    //        $scope.selectedTicket[type] = $scope.selectedTicket[type] - 1;
    //    }
    //    if (status == "false") {
    //        $(this).attr('data-status', "true");
    //        $scope.selectedTicket[type] = $scope.selectedTicket[type] + 1;
    //    }
    //    $(this).find('img').toggle();
    //    $scope.TongTien = ($scope.selectedTicket.VIP * $scope.Chuyenxe.GiaVIP + $scope.selectedTicket.THUONG * $scope.Chuyenxe.GiaThuong);
    //    console.log($scope.TongTien);
    //})
    $scope.loadding = false;
    //Đổi vé
    $scope.isExchage = false;
    $scope.DoiVe = function () {
        $scope.loadding = true;
        $service.Post(url + "/DoiVe", { Mave: $scope.Mavedoi, Tongtien: $scope.TongTien })
            .success(function (data) {
                console.log(data.d);
                $scope.message = data.d.message;
                $scope.showerror = true;

                if (data.d.data > $scope.TongTien) {
                    $scope.GiaTriVeCu = $scope.TongTien;
                }
                else {
                    $scope.GiaTriVeCu = data.d.data;
                }
                $scope.loadding = false;
            })
    }
    //Login
    $scope.Login = function () {
        $("#LoginModal").modal({ backdrop: 'static' });
    }
    $scope.doLogin = function () {
        $scope.loadding = true;
        $service.Post(url + "/doLogin", $scope.login)
            .success(function (data) {
                $scope.loginMsg = data.d.message;
                $scope.loadding = false;
                $("#LoginModal").modal('hide');
            })
    }
    //Thanh toán
    $scope.ThanhToan = function () {
        $scope.loadding = true;
        switch ($scope.Method) {
            case 4:
                var dataRequest = {
                    method: $scope.Method,
                    vip: $scope.selectedTicket.VIP,
                    thuong: $scope.selectedTicket.THUONG,
                    machuyenxe: $scope.Chuyenxe.MaChuyenXe,
                    khuyenmai: $scope.KhuyenMai,
                    giatridoive: $scope.GiaTriVeCu,
                    tinh: $scope.Province.id,
                    huyen: $scope.District.id,
                    diachinhanve: $scope.Address,
                    tongtien: $scope.TongTien
                };
                break;
            default:
                $scope.showAlert = true;
                $scope.alertMsg = "Phương thức thanh toán này chưa được áp dụng";
                $scope.loadding = false;
                break;
        }
        if (!$scope.Address) {
            $("#address").focus();
            $scope.loadding = false;
        }
        if (!$scope.Province) {
            $("#province").focus();
            $scope.loadding = false;
        }
        if (!$scope.District) {
            $("#district").focus();
            $scope.loadding = false;
        }
        else {
            $service.Post(url + "/ThanhToan", dataRequest)
                .success(function (data) {
                    console.log(data.d);
                    switch (data.d.data) {
                        case -1:
                            $scope.showAlert = true;
                            $scope.alertMsg = data.d.message;
                            $scope.loadding = false;
                            $("#LoginModal").modal({ backdrop: 'static' });
                            break;
                        case 0:
                            $scope.showAlert = true;
                            $scope.alertMsg = data.d.message;
                            $scope.loadding = false;
                            location.href = "/giao-dich.htm";
                            break;
                        case 1:
                            $scope.showAlert = true;
                            $scope.alertMsg = data.d.message;
                            $scope.loadding = false;
                            location.href = "/xac-thuc-dat-ve.htm";
                        default:
                            $scope.showAlert = true;
                            $scope.alertMsg = data.d.message;
                            $scope.loadding = false;
                    }
                })
                .error(function (data) {
                    $scope.loadding = false;
                })
        }
    }
    $scope.CheckPromote = function () {
        $scope.loaddingKM = true;
        $service.Post(url + "/CheckPromote", { makhuyenmai: $scope.MaKhuyenMai, Tongtien: $scope.TongTien })
            .success(function (data) {
                if (data.d.data != null) {
                    console.log(data.d);
                    $scope.alertType = "success";
                    $scope.KhuyenMai = data.d.data.ValueCast;
                }
                else {
                    $scope.alertType = "danger";
                }
                $scope.message = data.d.message;
                $scope.showErrorKM = true;
                $scope.loaddingKM = false;
            })
    }
}])
app.controller("VertifyController", ['$scope', '$http', 'service', function ($scope, $http, $service) {
    var url = "/Default.aspx";
    $scope.loadding = false;
    $scope.Vertify = function () {
        $scope.loadding = true;
        $service.Post(url + "/VertifyTicket", { magiaodich: $scope.magiaodich })
            .success(function (data) {
                console.log(data.d);
                $scope.showerror = true;
                $scope.message = data.d.message;
                if (data.d.data) {
                    $scope.alertType = "success";
                    window.location.href = "/nhan-ve/" + $scope.magiaodich + ".htm";
                }
                else {
                    $scope.alertType = "danger";
                }

                $scope.loadding = false;
            })
    }
}])
app.controller("TransactionController", ['$scope', '$http', 'service', function ($scope, $http, $service) {
    $scope.loadding = false;
    var url = "/Default.aspx";
    $scope.CreateTransaction = function () {
        $service.Post(url + "/CreateTransaction", { Mathe: $scope.Mathe })
            .success(function (data) {
                $scope.showerror = true;
                $scope.message = data.d.message;
                if (data.d.data) {
                    $scope.alertType = "success";
                    window.location.href = "/xac-thuc-dat-ve.htm";
                }
                else {
                    $scope.alertType = "danger";
                }

                $scope.loadding = false;
            })
    }
}])
app.controller("CheckTicketController", ['$scope', '$http', 'service', function ($scope, $http, $service) {
    $scope.loadding = false;
    $scope.showResult = false;
    var url = "/Default.aspx";
    $scope.CheckTicket = function () {
        $scope.loadding = true;
        if (!$scope.mave && !$scope.sdt) {
            $scope.showerror = true;
            $scope.msgAlert = "Bạn phải nhập ít nhất 1 trường để tra cứu vé."
            $scope.loadding = false;
        }
        else {
            if (!$scope.mave) {
                $scope.mave = '';
            }
            if (!$scope.sdt) {
                $scope.sdt = '';
            }
            $service.Post(url + "/CheckTicket", { mave: $scope.mave, sdt: $scope.sdt })
                .success(function (data) {
                    var res = JSON.parse(data.d);
                    $scope.Result = res;
                    console.log($scope.Result);
                    $scope.loadding = false;
                    $scope.showResult = true;
                    $scope.showerror = false;
                })
        }
    }
}])
app.controller("DoSearchController", ['$scope', '$http', '$location', 'service', function ($scope, $http, $location, $service) {
    var url = "/Default.aspx";
    $scope.alltinh = {};
    $scope.loading = false;
    $scope.tinh = {};
    $scope.showResult = false;
    $scope.showSearch = false;
    $scope.Selected = {};
    $scope.sSelected = [];
    $scope.AllResult = [];
    $scope.YcGiodi = {};
    $service.Post(url + "/LayTatCaDiaDiem", {})
        .success(function (data) {
            $scope.Diemdies = JSON.parse(data.d);
            autocomplete($scope.Diemdies);
        })
    $scope.Diemdi = getQueryString("di-tu");
    $scope.Diemden = getQueryString("den");
    $scope.Ngaydi = getQueryString("ngay");
    $scope.Giodi = getQueryString("luc");
    if ($scope.Diemdi && $scope.Diemden) {
        $scope.showResult = true;
        $scope.showSearch = false;
    }
    else {
        $scope.showResult = false;
        $scope.showSearch = true;
    }
    $scope.DaoTuyen = function () {
        var tg = $scope.Diemdi;
        $scope.Diemdi = $scope.Diemden;
        $scope.Diemden = tg;
    }
    var Code = [];
    $scope.SearchResult = [];
    $scope.options2 = {
        country: 'vn',
        types: 'geocode'
    };
    $scope.details2 = '';
    $service.Post(url + "/SearchTravel", { Diemdi: $scope.Diemdi, Diemden: $scope.Diemden, Ngaydi: $scope.Ngaydi, Giodi: $scope.Giodi }).success(function (data) {
        $scope.loading = false;
        $scope.Nhaxes = []; $scope.Giodi = []; $scope.Hangxes = [];
        $scope.SearchResult = data.d;
        $scope.AllResult = data.d;
        angular.forEach($scope.SearchResult, function (item) {
            if (item.Xe.NhaXe1)
                $scope.Nhaxes.push(item.Xe.NhaXe1);
            if (item.Xe.NhaXe1)
                $scope.Hangxes.push(item.Xe.Hangxe);
        });
        $scope.Nhaxes = Unique($scope.Nhaxes, "Tennhaxe");
        $scope.Giodies = Unique($scope.SearchResult, "Giokhoihanh");
        $scope.Hangxes = Unique($scope.Hangxes, "Hangxe");
        console.log($scope.SearchResult);
    })
        .error(function (data) {
            console.log("Error: ", data);
        });
    $scope.Search = function () {
        $scope.loading = true;
        $scope.showSearch = true;
        if ($scope.frmSearch.Ngaydi) {
            var ngaydi = convertToDateTime('#ngaydi');
            if (isPastDate(ngaydi)) {
                alert("Bạn không thể chọn ngày quá khứ.");
                $scope.loading = false;
                $('#ngaydi').focus();
                $('#ngaydi').css("border", "1px solid red");
            }
            else {
                window.location.href = "/ket-qua-tim-kiem-ve-xe.htm?di-tu=" + $scope.frmSearch.Diemdi + "&den=" + $scope.frmSearch.Diemden + "&ngay=" + $scope.frmSearch.Ngaydi;
            }
        }
    }
    $scope.Detail = function (item) {
        console.log(item);
        $scope.Selected = item;
        $("#row-" + item.MaChuyenXe).toggle(200);
        $(".tp").attr('tabindex', 1);
        $(".tp").focus();
    }
    $scope.DatVe = function (item) {
        $scope.Selected = item;

        window.location.href = "/thanh-toan/" + item.url + ".htm";
    }
    $scope.SortByNhaXe = function (item) {
        if (item != 0) {
            $("#btnNhaxe").html(item.Tennhaxe);

        }
        else
            $("#btnNhaxe").html("Tất cả nhà xe");
        $scope.sSelected.Nhaxe = item.Tennhaxe;
    }
    $scope.SortByHangXe = function (item) {
        if (item != 0) {
            $("#btnHangxe").html(item);
            $scope.sSelected.Hangxe = item;
        }
        else {
            $("#btnHangxe").html("Tất cả loại xe");
        }

    }
    $scope.SortByGiodi = function (item) {
        if (item != 0) {
            $("#btnGiodi").html(item.Giokhoihanh);

        }
        else
            $("#btnGiodi").html("Tất cả các giờ");
        $scope.sSelected.Giodi = item.Giokhoihanh;
    }
    $scope.lower_price_bound = 0;
    $scope.upper_price_bound = 50;
    $scope.items = $scope.SearchResult;
    $scope.SaveYC = function () {
        $scope.loading = true;
        if ($scope.YcNgaydi) {
            var ngaydi = convertToDateTime('#ycNgaydi');
            if (isPastDate(ngaydi)) {
                alert("Bạn không thể chọn ngày quá khứ.");
                $scope.loading = false;
            }
            else if (!validatePhone($scope.YcSdt)) {
                $scope.showError = true;
                $scope.sdtError = "Sai định dạng số điện thoại";
                $scope.loading = false;
            }
            else {
                $scope.showError = false;
                $scope.sdtError = "";
                var dataRequest = {
                    from: setNotNull($scope.YcDiemDi),
                    to: setNotNull($scope.YcDiemDen),
                    startdate: setNotNull($scope.YcNgaydi),
                    starttime: setNotNull($scope.YcGiodi),
                    more: setNotNull($scope.YcMore),
                    sdt: setNotNull($scope.YcSdt)
                }
                console.log(dataRequest);
                $service.Post(url + "/SaveYc", dataRequest)
                    .success(function (data) {
                        console.log(data.d);
                        $scope.loading = false;
                        $scope.showError = true;
                        $scope.message = data.d.message;
                    })
                    .error(function (err) {
                        console.log(err);
                    })
            }
        }

    }
    $scope.HuyYC = function () {
        $service.Post(url + "/HuyYC", {})
            .success(function (data) {
                console.log(data.d);
                alert(data.d.message);
                window.location.reload();
            })
    }
    //function
    function Unique(collection, keyname) {
        var output = [],
            keys = [];

        angular.forEach(collection, function (item) {
            var key = item[keyname];
            if (keys.indexOf(key) === -1) {
                keys.push(key);
                output.push(item);
            }
        });

        return output;
    }
    function getQueryString(name) {
        var url = window.location.href;
        name = name.replace(/[\[\]]/g, "\\$&");
        var regex = new RegExp("[?&]" + name + "(=([^&#]*)|&|#|$)"),
            results = regex.exec(url);
        if (!results) return null;
        if (!results[2]) return '';
        return decodeURIComponent(results[2].replace(/\+/g, " "));
    }
    function setNotNull(str) {
        if (str) {
            return str;
        }
        else {
            return "";
        }
    }
}]);