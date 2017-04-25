var app = angular.module('app', ['ngTouch', 'ui.bootstrap', 'ui.grid', 'ui.grid.cellNav', 'ui.grid.edit', 'ui.grid.resizeColumns', 'ui.grid.pinning', 'ui.grid.moveColumns', 'ui.grid.exporter', 'ui.grid.importer', 'ui.grid.pagination', 'ui.grid.grouping', 'ui.tinymce', 'ngAnimate', 'angularUtils.directives.dirPagination'])
app.controller("NhaXeController", ['$scope', '$http', '$filter', 'svNhaXe', 'Service', function ($scope, $filter, $http, $svNhaXe, $Service) {
    $scope.allnhaxe = [];
    //$svNhaXe.GetAllNhaXe().success(function (data) {
    //    console.log(data);
    //    $scope.nhaxes = data.d;
    //    $scope.allnhaxe = $scope.nhaxes;
    //    console.log($scope.nhaxes);
    //})
    $(".selecte2").select2();
    $scope.tinymceOptions = {
        plugins: 'link image code',
        toolbar: 'undo redo | bold italic | alignleft aligncenter alignright | code',
        file_browser_callback: openKCFinder,
        file_browser_callback_types: 'file image media'
    };
    $Service.Api("POST", "/Admin/Modules/Category/NhaXe.aspx/GetAllNhaXe", "json", {}).success(function (data) {
        console.log(data);
        $scope.nhaxes = JSON.parse(data.d);
        $scope.allnhaxe = JSON.parse(data.d);
        console.log($scope.nhaxes);
    })
    $scope.action = "";
    $scope.loading = false;
    $scope.selected = {};
    $scope.OpenUpdateForm = function (act) {
        switch (act) {
            case "add":
                $Service.Api("POST", "/Admin/Default.aspx/Execute", "json", { sp: "SP_GETALLTINH", param: "" }).success(function (data) {
                    $scope.Tinhs = JSON.parse(data.d);
                })
                $scope.Tennhaxe = "";
                $scope.Soluongxe = "";
                $scope.Trusochinh = "";
                $scope.Sodienthoai = "";
                $scope.Gioithieunga = "";
                $scope.Gioithieuchitiet = "";
                $("#add-modal").modal({ backdrop: false });
                $scope.action = "add";
                break;
            case "edit":
                $Service.Api("POST", "/Admin/Default.aspx/Execute", "json", { sp: "SP_GETALLTINH", param: "" }).success(function (data) {
                    $scope.Tinhs = JSON.parse(data.d);
                })
                $("#add-modal").modal({ backdrop: false });
                $scope.Tennhaxe = $scope.selected.Tennhaxe;
                $scope.Soluongxe = $scope.selected.Soluongxe;
                $scope.Trusochinh = $scope.selected.Trusochinh;
                $scope.Sodienthoai = $scope.selected.Sodienthoai;
                $scope.Nguoidaidien = $scope.selected.Nguoidaidien;
                $scope.Gioithieungan = $scope.selected.Gioithieungan;
                $scope.Gioithieuchitiet = $scope.selected.Gioithieuchitiet;
                $scope.Anh = $scope.selected.Anh;
                $scope.action = "edit";
                break;
            default:
                break;
        }

    }
    $scope.OpenDetail = function () {
        $("#detail-modal").modal({ backdrop: false });
    }
    $scope.Select = function (item) {
        $scope.selected = item;
    }
    $scope.Save = function () {
        $scope.loading = true;
        if ($scope.action == "add") {
            console.log($scope.Anh);
            $Service.Api(
                "POST",
                "/Admin/Modules/Category/NhaXe.aspx/CreateNhaXe",
                "json",
                { Tennhaxe: $scope.Tennhaxe, Anh: $scope.Anh, Soluongxe: $scope.Soluongxe, Trusochinh: $scope.Trusochinh, Nguoidaidien: $scope.Nguoidaidien, Sodienthoai: $scope.Sodienthoai, Gioithieungan: $scope.Gioithieungan, Gioithieuchitiet: $scope.Gioithieuchitiet, Tinh: $scope.Tinh }
            ).success(function (data) {
                var rs = data.d;
                $scope.nhaxes.push({
                    Tennhaxe: rs.Tennhaxe,
                    Soluongxe: rs.Soluongxe,
                    Trusochinh: rs.Trusochinh,
                    Sodienthoai: rs.Sodienthoai,
                    Nguoidaidien: $scope.Nguoidaidien,
                    Gioithieungan: rs.Gioithieungan,
                    Gioithieuchitiet: rs.Gioithieuchitiet
                });
                $("#add-modal").modal('hide');
                swal(
                    'Thêm nhà xe thành công!',
                    '',
                    'success'
                )
                $scope.Tennhaxe = "";
                $scope.Soluongxe = "";
                $scope.Trusochinh = "";
                $scope.Sodienthoai = "";
                $scope.Nguoidaidien = "";
                $scope.Gioithieunga = "";
                $scope.Gioithieuchitiet = "";
            })
        }
        if ($scope.action == "edit") {
            console.log($scope.Anh);
            $Service.Api(
                "POST",
                "/Admin/Modules/Category/NhaXe.aspx/UpdateNhaXe",
                "json",
                { Id: $scope.selected.ID, Anh: $scope.Anh, Tennhaxe: $scope.Tennhaxe, Soluongxe: $scope.Soluongxe, Trusochinh: $scope.Trusochinh, Nguoidaidien: $scope.Nguoidaidien, Sodienthoai: $scope.Sodienthoai, Gioithieungan: $scope.Gioithieungan, Gioithieuchitiet: $scope.Gioithieuchitiet, Tinh: $scope.Tinh }
            ).success(function (data) {
                console.log(data.d);
                var index = $scope.nhaxes.indexOf($scope.selected);
                $scope.nhaxes.splice(index, 1);
                $scope.nhaxes.push(data.d);
                swal(
                    'Thành công!',
                    'Nhà xe bạn sửa đã được lưu lại.',
                    'success'
                )
                $("#add-modal").modal('hide');
            })
        }

    }
    $scope.Delete = function (item) {
        swal({
            title: 'Bạn có chắc chắn xóa nhà xe này không?',
            text: "Nếu đồng ý, bạn sẽ không thể thấy nhà xe này nữa.",
            type: 'warning',
            showCancelButton: true,
            confirmButtonColor: '#3085d6',
            cancelButtonColor: '#d33',
            confirmButtonText: 'Đồng ý',
            cancelButtonText: 'Hủy bỏ',
            confirmButtonClass: 'btn btn-success',
            cancelButtonClass: 'btn btn-danger',
            buttonsStyling: false
        }).then(function () {
            $Service.Api(
                "POST",
                "/Admin/Modules/Category/NhaXe.aspx/DeleteNhaXe",
                "json",
                { Id: $scope.selected.ID, Tennhaxe: $scope.Tennhaxe, Soluongxe: $scope.Soluongxe, Trusochinh: $scope.Trusochinh, Nguoidaidien: $scope.Nguoidaidien, Sodienthoai: $scope.Sodienthoai, Gioithieungan: $scope.Gioithieungan, Gioithieuchitiet: $scope.Gioithieuchitiet }
            ).success(function (data) {
                console.log(data);
                var index = $scope.nhaxes.indexOf(item);
                $scope.nhaxes.splice(index, 1);
                swal(
                    'Đã xóa!',
                    'Nhà xe bạn chọn đã bị xóa.',
                    'success'
                )
            })

        }, function (dismiss) {
            // dismiss can be 'cancel', 'overlay',
            // 'close', and 'timer'
            if (dismiss === 'cancel') {
                swal(
                    'Hủy bỏ',
                    'Nhà xe bạn chọn chưa bị xóa',
                    'error'
                )
            }
        })
    }
    $scope.ExportToExcel = function () {
        $svNhaXe.ExportToExcel(JSON.stringify($scope.nhaxes)).success(function (data) {
            console.log(data);
        })
    }
}])
app.controller("QuanHuyenController", ['$scope', '$http', '$filter', 'Service', function ($scope, $filter, $http, $Service) {
    $scope.alldistricts = [];
    $scope.pageSize = "10";
    $scope.sortType = 'TenHuyen'; // set the default sort type
    $scope.sortReverse = false;
    $scope.Huyen = {};
    $Service.Api("POST", "/Admin/Modules/Category/District.aspx/GetAllDistrict", "json", {}).success(function (data) {
        $scope.districts = data.d;
        angular.forEach($scope.districts, function (item) {
            $Service.Api("POST", "/Admin/Modules/Category/Province.aspx/GetProvinceById", "json", { matinh: item.MaTinh }).success(function (rs) {
                item.TinhThanh = rs.d;
            })
        });
        $scope.alldistricts = $scope.districts;
    })
    $Service.Api("POST", "/Admin/Modules/Category/Province.aspx/GetAllProvince", "json", {}).success(function (data) {
        console.log(data);
        $scope.Tinhs = data.d;
    })
    $scope.action = "";
    $scope.loading = false;
    $scope.selected = {};
    $scope.OpenUpdateForm = function (act) {
        switch (act) {
            case "add":
                $scope.Huyen = {};
                $("#add-modal").modal({ backdrop: false });
                $scope.action = "add";
                break;
            case "edit":
                $("#add-modal").modal({ backdrop: false });
                $(".select2").select2();
                $scope.Huyen = $scope.selected;
                $scope.action = "edit";
                break;
            default:
                break;
        }

    }
    $scope.Select = function (item) {
        $scope.selected = item;
    }
    $scope.Save = function () {
        $scope.loading = true;
        if ($scope.action == "add") {
            $Service.Api("POST", "/Admin/Modules/Category/District.aspx/CreateDistrict", "json", $scope.Huyen).success(function (data) {
                var res = data.d;
                $Service.Api("POST", "/Admin/Modules/Category/Province.aspx/GetProvinceById", "json", { matinh: res.MaTinh }).success(function (rs) {
                    res.TinhThanh = rs.d;
                })
                $scope.districts.push(res);
                $("#add-modal").modal('hide');
                swal(
                    'Thêm quận/huyện thành công!',
                    '',
                    'success'
                )
                $scope.Huyen = {};
            })
        }
        if ($scope.action == "edit") {
            console.log($scope.selected);
            $scope.Huyen.MaHuyen = $scope.selected.MaHuyen;
            console.log("ma huyen", $scope.Huyen);
            $Service.Api("POST", "/Admin/Modules/Category/District.aspx/UpdateDistrict", "json", { MaHuyen: $scope.Huyen.MaHuyen, TenHuyen: $scope.Huyen.TenHuyen, MaTinh: $scope.Huyen.MaTinh, GiaShip: $scope.Huyen.GiaShip }).success(function (data) {
                var res = data.d;
                var index = $scope.districts.indexOf($scope.selected);
                $scope.districts.splice(index, 1);
                $Service.Api("POST", "/Admin/Modules/Category/Province.aspx/GetProvinceById", "json", { matinh: res.MaTinh })
                    .success(function (data) {
                        res.TinhThanh = data.d;
                    })
                $scope.districts.push(res);
                swal(
                    'Thành công!',
                    'Quận/Huyện bạn sửa đã được lưu lại.',
                    'success'
                )
                $("#add-modal").modal('hide');
            })
        }

    }
    $scope.Delete = function (item) {
        swal({
            title: 'Bạn có chắc chắn xóa nhà xe này không?',
            text: "Nếu đồng ý, bạn sẽ không thể thấy nhà xe này nữa.",
            type: 'warning',
            showCancelButton: true,
            confirmButtonColor: '#3085d6',
            cancelButtonColor: '#d33',
            confirmButtonText: 'Đồng ý',
            cancelButtonText: 'Hủy bỏ',
            confirmButtonClass: 'btn btn-success',
            cancelButtonClass: 'btn btn-danger',
            buttonsStyling: false
        }).then(function () {
            $Service.Api("POST", "/Admin/Modules/Category/District.aspx/DeleteDistrict", "json", { Id: item.MaHuyen }).success(function (data) {
                console.log(data);
                var index = $scope.districts.indexOf(item);
                $scope.districts.splice(index, 1);
                swal(
                    'Đã xóa!',
                    'Nhà xe bạn chọn đã bị xóa.',
                    'success'
                )
            })

        }, function (dismiss) {
            // dismiss can be 'cancel', 'overlay',
            // 'close', and 'timer'
            if (dismiss === 'cancel') {
                swal(
                    'Hủy bỏ',
                    'Nhà xe bạn chọn chưa bị xóa',
                    'error'
                )
            }
        })
    }
    $scope.ExportToExcel = function () {
        var blob = new Blob([document.getElementById('exportData').innerHTML], {
            type: "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet;charset=utf-8"
        });
        var currentDate = new Date();
        var datetime = currentDate.getDate() + "-" + (currentDate.getMonth() + 1) + "-" + currentDate.getFullYear();
        saveAs(blob, "Danhmucquanhuyen .xls");
    };
}])
app.controller("XeController", ['$scope', '$http', '$filter', 'Service', function ($scope, $filter, $http, $Service) {
    var url = "/Admin/Modules/Category/Vehicle.aspx";
    var rootUrl = "/Admin/Default.aspx";
    $scope.tinymceOptions = {
        resize: false,
        height: 300,
        plugins: [
            'advlist autolink lists link image charmap print preview hr anchor pagebreak',
            'searchreplace wordcount visualblocks visualchars code fullscreen',
            'insertdatetime media nonbreaking save table contextmenu directionality',
            'emoticons template paste textcolor colorpicker textpattern imagetools codesample'
        ],
        toolbar: "undo redo styleselect bold italic print forecolor backcolor",
        toolbar1: 'insertfile undo redo | styleselect | bold italic | alignleft aligncenter alignright alignjustify | bullist numlist outdent indent | link image',
        toolbar2: 'print preview media | forecolor backcolor emoticons | codesample',
        image_advtab: true,
        relative_urls: false,
        remove_script_host: false,
        file_browser_callback: openKCFinder,
        file_browser_callback_types: 'file image media',
        style_formats: [
            { title: 'Open Sans', inline: 'span', styles: { 'font-family': 'Open Sans' } },
            { title: 'Arial', inline: 'span', styles: { 'font-family': 'arial' } },
            { title: 'Book Antiqua', inline: 'span', styles: { 'font-family': 'book antiqua' } },
            { title: 'Comic Sans MS', inline: 'span', styles: { 'font-family': 'comic sans ms,sans-serif' } },
            { title: 'Courier New', inline: 'span', styles: { 'font-family': 'courier new,courier' } },
            { title: 'Georgia', inline: 'span', styles: { 'font-family': 'georgia,palatino' } },
            { title: 'Helvetica', inline: 'span', styles: { 'font-family': 'helvetica' } },
            { title: 'Impact', inline: 'span', styles: { 'font-family': 'impact,chicago' } },
            { title: 'Symbol', inline: 'span', styles: { 'font-family': 'symbol' } },
            { title: 'Tahoma', inline: 'span', styles: { 'font-family': 'tahoma' } },
            { title: 'Terminal', inline: 'span', styles: { 'font-family': 'terminal,monaco' } },
            { title: 'Times New Roman', inline: 'span', styles: { 'font-family': 'times new roman,times' } },
            { title: 'Verdana', inline: 'span', styles: { 'font-family': 'Verdana' } }
        ]
    };
    function openKCFinder(field_name, url, type, win) {
        BrowseServerInEditor(field_name);
        return false;
    }
    function BrowseServerInEditor(field) {
        var finder = new CKFinder();
        finder.selectActionFunction = function (fileUrl) {
            document.getElementById(field).value = fileUrl;
        };
        finder.popup();
    }
    $scope.all = [];
    $scope.pageSize = "10";
    $scope.sortReverse = false;
    $scope.action = "";
    $scope.loading = false;
    $scope.selected = {};
    $scope.list = [];
    $scope.formdata = {};
    $scope.Mod = {};
    $scope.grvs = [];
    $scope.updates = [];
    $scope.btnUpdates = [];
    $scope.btnExec = [];
    $scope.gio = "01";
    $scope.phut = "00";
    var path = window.location.hash.replace('#', '');
    if (path) {
        var mid = path;
    }
    else {
        mid = 29;
    }

    $Service.Post(rootUrl + "/GetModFromId", { mid: mid }).success(function (data) {
        $scope.Mod = JSON.parse(data.d)[0];
        console.log($scope.Mod);
        $Service.Post(rootUrl + "/Execute", { sp: $scope.Mod.Onload, param: "" })
            .success(function (data) {
                $scope.list = JSON.parse(data.d);
                console.log($scope.list);
            })
    })
    $Service.Post(rootUrl + "/GetBtnFromMod", { mid: mid }).success(function (data) {
        var res = JSON.parse(data.d);
        angular.forEach(res, function (item) {
            if (item.Btn_Type == 1) {
                $scope.btnUpdates.push(item);
            }
            else {
                $scope.btnExec.push(item);
            }
        })
        console.log($scope.btns);
    })
    $Service.Post(rootUrl + "/GetFldFromMod", { modid: mid }).success(function (data) {
        $scope.flds = data.d;
        $scope.sortType = $scope.flds[0].FldName;
        $scope.grvs = [];
        angular.forEach($scope.flds, function (item) {
            if (item.FldSource) {
                var s = item.FldSource;
                $Service.Post(rootUrl + "/Execute", { sp: s, param: "" })
                    .success(function (data) {
                        item.FldSource = JSON.parse(data.d);
                    })
            }
            if (item.GRW == true) {
                $scope.grvs.push(item);
            }
            if (item.Show == 1) {
                $scope.updates.push(item);
            }
        })
        console.log($scope.grvs);
    })
    $scope.today = function (td) {
        console.log($scope.formdata[td]);
        if (!$scope.formdata[td]) {
            var gettoday = new Date();
            var dd = gettoday.getDate();
            var mm = gettoday.getMonth() + 1; //January is 0!
            var yyyy = gettoday.getFullYear();

            if (dd < 10) {
                dd = '0' + dd
            }

            if (mm < 10) {
                mm = '0' + mm
            }

            gettoday = mm + '/' + dd + '/' + yyyy;
            $scope.formdata[td] = gettoday;
        }
    };
    function Load() {
        $scope.loadData = true;
        $Service.Post(rootUrl + "/Execute", { sp: $scope.Mod.Onload, param: "" })
            .success(function (data) {
                $scope.list = JSON.parse(data.d);
                console.log($scope.list);
                $scope.loadData = false;
            })
    }

    $scope.OpenUpdateForm = function (act) {
        switch (act) {
            case "add":
                $("#add-modal").modal({ backdrop: false });
                $scope.updateFormTitle = "Thêm mới "+$scope.Mod.ModAdmin_Name;
                $scope.formdata = {};
                $scope.action = "add";
                break;
            case "edit":
                $scope.updateFormTitle = "Cập nhật thông tin " + $scope.Mod.ModAdmin_Name;
                $("#add-modal").modal({ backdrop: false });
                $scope.formdata = $scope.selected;
                console.log($scope.formdata);
                $scope.action = "edit";
                break;
            default:
                break;
        }

    }

    $scope.Select = function (item) {
        $scope.selectedRow = item;
        $Service.Post(rootUrl + "/Execute", { sp: $scope.Mod.OnSelect, param: item[$scope.flds[0].FldName] })
            .success(function (data) {
                $scope.selected = JSON.parse(data.d)[0];

            })
    }

    $scope.Exec = function (sp) {
        $scope.loading = true;
        if (sp.isConfirm == true) {
            swal({
                title: sp.ConfirmContent,
                text: "",
                type: 'warning',
                showCancelButton: true,
                confirmButtonColor: '#3085d6',
                cancelButtonColor: '#d33',
                confirmButtonText: 'Đồng ý',
                cancelButtonText: 'Hủy bỏ',
                confirmButtonClass: 'btn btn-success',
                cancelButtonClass: 'btn btn-danger',
                buttonsStyling: false
            })
                .then(function () {
                    var param = {};
                    if (sp.Btn_Type == 1) {
                        param = JSON.stringify($scope.formdata);
                    }
                    else {
                        angular.forEach($scope.flds, function (item) {
                            if (item.FldType == 'PK') {
                                console.log("selected pk", $scope.selected[item.FldName]);
                                param = "{\"" + item.FldName + "\":" + $scope.selected[item.FldName] + "}";
                            }
                        })
                    }
                    console.log(param);
                    $Service.Post(rootUrl + "/ExecuteScalar", { mid: mid, sp: sp.Btn_ExecuteSP, param: param, fldcount: 0 })
                        .success(function (data) {
                            //var rs = JSON.parse(data.d);
                            console.log(data.d);
                            Load();
                            $("#add-modal").modal('hide');
                            if (sp.isConfirm == true) {
                                swal(
                                    sp.AlertContent,
                                    '',
                                    'success'
                                )
                            }

                            $scope.formdata = {};
                        })

                }, function (dismiss) {
                    // dismiss can be 'cancel', 'overlay',
                    // 'close', and 'timer'
                    if (dismiss === 'cancel') {
                        swal(
                            'Hủy bỏ',
                            'Đã hủy',
                            'error'
                        )
                    }
                })
        }
        else {
            var param = $scope.formdata;
            console.log(param);
            $Service.Post(rootUrl + "/ExecuteScalar", { mid: mid, sp: sp.Btn_ExecuteSP, param: JSON.stringify(param), fldcount: $scope.updates.length })
                .success(function (data) {
                    //var rs = JSON.parse(data.d);
                    console.log(data.d);
                    Load();
                    $("#add-modal").modal('hide');
                    if (sp.AlertAfterExec == true) {
                        swal(
                            sp.AlertContent,
                            '',
                            'success'
                        )
                    }
                })
        }
    }
}])
app.controller("BenXeController", ['$scope', '$http', '$filter', 'svBenXe', function ($scope, $filter, $http, $svBenXe) {
    $scope.alldistricts = [];
    $scope.pageSize = "5";
    $scope.sortType = 'TenHuyen'; // set the default sort type
    $scope.sortReverse = false;
    $scope.Huyen = {};
    $svQuanhuyen.GetAllDistrict().success(function (data) {
        $scope.districts = data.d;
        angular.forEach($scope.districts, function (item) {
            $svQuanhuyen.GetProvinceById(item.MaTinh).success(function (rs) {
                item.TinhThanh = rs.d;
                console.log(item.TinhThanh);
            })
        });
        $scope.alldistricts = $scope.districts;
    })
    $svQuanhuyen.GetAllProvince().success(function (data) {
        console.log(data);
        $scope.Tinhs = data.d;
    })
    $scope.action = "";
    $scope.loading = false;
    $scope.selected = {};
    $scope.OpenUpdateForm = function (act) {
        switch (act) {
            case "add":
                $scope.Huyen = {};
                $("#add-modal").modal({ backdrop: false });
                $scope.action = "add";
                break;
            case "edit":
                $("#add-modal").modal({ backdrop: false });
                $scope.Huyen = $scope.selected;
                $scope.action = "edit";
                break;
            default:
                break;
        }

    }
    $scope.Select = function (item) {
        $scope.selected = item;
    }
    $scope.Save = function () {
        $scope.loading = true;
        if ($scope.action == "add") {
            $svQuanhuyen.AddDistrict($scope.Huyen)
                .success(function (data) {
                    var res = data.d;
                    $svQuanhuyen.GetProvinceById(res.MaTinh).success(function (rs) {
                        res.TinhThanh = rs.d;
                    })
                    $scope.districts.push(res);
                    $("#add-modal").modal('hide');
                    swal(
                        'Thêm quận/huyện thành công!',
                        '',
                        'success'
                    )
                    $scope.Huyen = {};
                })
        }
        if ($scope.action == "edit") {
            console.log($scope.selected);
            $scope.Huyen.MaHuyen = $scope.selected.MaHuyen;
            $svQuanhuyen.UpdateDistrict($scope.Huyen)
                .success(function (data) {
                    console.log(data.d);
                    var index = $scope.districts.indexOf($scope.selected);
                    $scope.districts.splice(index, 1);
                    $scope.districts.push(data.d);
                    swal(
                        'Thành công!',
                        'Quận/Huyện bạn sửa đã được lưu lại.',
                        'success'
                    )
                    $("#add-modal").modal('hide');
                })
        }

    }
    $scope.Delete = function (item) {
        swal({
            title: 'Bạn có chắc chắn xóa nhà xe này không?',
            text: "Nếu đồng ý, bạn sẽ không thể thấy nhà xe này nữa.",
            type: 'warning',
            showCancelButton: true,
            confirmButtonColor: '#3085d6',
            cancelButtonColor: '#d33',
            confirmButtonText: 'Đồng ý',
            cancelButtonText: 'Hủy bỏ',
            confirmButtonClass: 'btn btn-success',
            cancelButtonClass: 'btn btn-danger',
            buttonsStyling: false
        }).then(function () {
            $svQuanhuyen.DeleteDistrict(item.MaHuyen).success(function (data) {
                console.log(data);
                var index = $scope.nhaxes.indexOf(item);
                $scope.districts.splice(index, 1);
                swal(
                    'Đã xóa!',
                    'Nhà xe bạn chọn đã bị xóa.',
                    'success'
                )
            })

        }, function (dismiss) {
            // dismiss can be 'cancel', 'overlay',
            // 'close', and 'timer'
            if (dismiss === 'cancel') {
                swal(
                    'Hủy bỏ',
                    'Nhà xe bạn chọn chưa bị xóa',
                    'error'
                )
            }
        })
    }
    $scope.ExportToExcel = function () {
        $svQuanhuyen.ExportToExcel(JSON.stringify($scope.nhaxes)).success(function (data) {
            console.log(data);
        })
    }
}])
app.controller("QLXeController", ['$scope', '$http', 'Service', '$timeout', '$interval', 'uiGridConstants', 'uiGridGroupingConstants', function ($scope, $http, $Service, $timeout, $interval, uiGridConstants, uiGridGroupingConstants) {
    var today = new Date();
    var url = "/Admin/Modules/Category/Xe.aspx";
    var rootUrl = "/Admin/Default.aspx";
    $scope.columns = [];

    var nextWeek = new Date();
    nextWeek.setDate(nextWeek.getDate() + 7);
    $scope.highlightFilteredHeader = function (row, rowRenderIndex, col, colRenderIndex) {
        if (col.filters[0].term) {
            return 'header-filtered';
        } else {
            return '';
        }
    };
    $scope.edit = function (row) {
        $("#updateframe").prop("src", "Create/ThemXe.aspx?id=" + row.entity.MaXe);
        $("#add-modal").modal({ backdrop: 'static' });
    };
    $scope.delete = function (row) {
        swal({
            title: 'Bạn có chắc chắn?',
            text: "Xóa chuyến xe này!",
            type: 'warning',
            showCancelButton: true,
            confirmButtonColor: '#3085d6',
            cancelButtonColor: '#d33',
            confirmButtonText: 'Có, tôi muốn!',
            cancelButtonText: 'Không, hủy!',
            confirmButtonClass: 'btn btn-success',
            cancelButtonClass: 'btn btn-danger',
            buttonsStyling: false
        }).then(function () {
            console.log(row.entity.MaXe);
            $Service.Post(rootUrl + "/Execute", { sp: "SP_DELXE", param: row.entity.MaXe })
                .success(function (data) {
                    console.log(data.d);
                    LoadData();
                    swal(
                        'Đã xóa!',
                        'Xe bạn chọn đã bị xóa khỏi hệ thống.',
                        'success'
                    )
                })
        }, function (dismiss) {
            // dismiss can be 'cancel', 'overlay',
            // 'close', and 'timer'
            if (dismiss === 'cancel') {
                swal(
                    'Hủy bỏ',
                    'Chuyến xe của bạn vẫn chưa bị xóa',
                    'error'
                )
            }
        })
    };


    $scope.gridOptions = {
        enableFiltering: true,
        paginationPageSizes: [10, 25, 50, 75],
        paginationPageSize: 10,
        columnDefs: [
            {
                name: 'E', enableFiltering: false, enableSorting: false, width: 50, enableCellEdit: false, allowCellFocus: false,
                cellTemplate: '<div class="dropdown tbl-option" style="position: absolute;top: 15 %;left: 1 %;"><button class="btn btn-primary dropdown-toggle" type="button" data-toggle="dropdown"><span class="caret" ></span></button> <ul class="dropdown-menu"><li><a href="#" ng-click="grid.appScope.edit(row)"><i class="glyphicon glyphicon-edit"></i> Sửa</a></li><li><a href="#" ng-click="grid.appScope.delete(row)"><i class="glyphicon glyphicon-trash"></i> Xóa</a></li></u></div>'
            },
            { name: "Nhaxe", displayName: "Nhà xe", width: 150, enableCellEdit: false, allowCellFocus: false },
            { name: "Bienso", displayName: "Biển số", width: 150, enableCellEdit: false, allowCellFocus: false },
            { name: "Tenxe", displayName: "Tên xe", width: 150, enableCellEdit: false, allowCellFocus: false },
            { name: "TongSoGhe", displayName: "Tổng số ghế", width: 150, enableCellEdit: false, allowCellFocus: false },
            { name: "Hangxe", displayName: "Tổng số ghế", width: 150, enableCellEdit: false, allowCellFocus: false },
            { name: "Daxoa", displayName: "Trạng thái", width: 120, enableCellEdit: false, allowCellFocus: false }
        ],
        enableGridMenu: true,
        enableColumnResizing: true,
        rowIdentity: function (row) {
            return row.MaChuyenXe;
        },
        getRowIdentity: function (row) {
            return row.MaChuyenXe;
        },
        exporterOlderExcelCompatibility: true,
        exporterCsvFilename: 'xe.csv',
        exporterPdfDefaultStyle: { fontSize: 9 },
        exporterPdfTableStyle: { margin: [30, 30, 30, 30] },
        exporterPdfTableHeaderStyle: { fontSize: 10, bold: true, italics: true, color: 'red' },
        exporterPdfHeader: { text: "Danh sách xe", style: 'headerStyle' },
        exporterPdfFooter: function (currentPage, pageCount) {
            return { text: currentPage.toString() + ' of ' + pageCount.toString(), style: 'footerStyle' };
        },
        exporterPdfCustomFormatter: function (docDefinition) {
            docDefinition.styles.headerStyle = { fontSize: 22, bold: true };
            docDefinition.styles.footerStyle = { fontSize: 10, bold: true };
            return docDefinition;
        },
        exporterPdfOrientation: 'landscape',
        exporterPdfPageSize: 'A4',
        exporterPdfMaxGridWidth: 800,
        exporterCsvLinkElement: angular.element(document.querySelectorAll(".custom-csv-link-location")),
        onRegisterApi: function (gridApi) {
            $scope.gridApi = gridApi;
        }
    };
    $scope.toggleFiltering = function () {
        $scope.gridOptions.enableFiltering = !$scope.gridOptions.enableFiltering;
        $scope.gridApi.core.notifyDataChange(uiGridConstants.dataChange.COLUMN);
    };
    var LoadData = function () {
        $Service.Post(rootUrl + "/GetAllXe", {})
            .success(function (data) {
                $scope.gridOptions.data = JSON.parse(data.d);
                console.log($scope.gridOptions.data);
                return true;
            });
    }
    $scope.LoadData = function () {
        $Service.Post(rootUrl + "/GetAllXe", {})
            .success(function (data) {
                $scope.gridOptions.data = JSON.parse(data.d);
                console.log($scope.gridOptions.data);
                return true;
            });
    }
    LoadData();
}])
app.controller('ChuyenXeController', ['$scope', '$http', 'Service', '$timeout', '$interval', 'uiGridConstants', 'uiGridGroupingConstants',function ($scope, $http, $Service, $timeout, $interval, uiGridConstants, uiGridGroupingConstants) {
        var today = new Date();
        var url = "/Admin/Modules/Category/Vehicle.aspx";
        var rootUrl = "/Admin/Default.aspx";
        var nextWeek = new Date();
        nextWeek.setDate(nextWeek.getDate() + 7);
        $scope.highlightFilteredHeader = function (row, rowRenderIndex, col, colRenderIndex) {
            if (col.filters[0].term) {
                return 'header-filtered';
            } else {
                return '';
            }
        };
        $scope.edit = function (row) {
            console.log(row.entity.MaChuyenXe);
            $("#updateframe").prop("src", "Create/ThemChuyenXe.aspx?id=" + row.entity.MaChuyenXe);
            $("#add-modal").modal({ backdrop: 'static' });
        };
        $scope.delete = function (row) {
            swal({
                title: 'Bạn có chắc chắn?',
                text: "Xóa chuyến xe này!",
                type: 'warning',
                showCancelButton: true,
                confirmButtonColor: '#3085d6',
                cancelButtonColor: '#d33',
                confirmButtonText: 'Có, tôi muốn!',
                cancelButtonText: 'Không, hủy!',
                confirmButtonClass: 'btn btn-success',
                cancelButtonClass: 'btn btn-danger',
                buttonsStyling: false
            }).then(function () {
                $Service.Post(rootUrl + "/DELCHUYENXE", { machuyenxe: row.entity.MaChuyenXe })
                    .success(function (data) {
                        LoadData();
                        swal(
                            'Đã xóa!',
                            'Chuyến xe bạn chọn đã bị xóa khỏi hệ thống.',
                            'success'
                        )
                    })
            }, function (dismiss) {
                // dismiss can be 'cancel', 'overlay',
                // 'close', and 'timer'
                if (dismiss === 'cancel') {
                    swal(
                        'Hủy bỏ',
                        'Chuyến xe của bạn vẫn chưa bị xóa',
                        'error'
                    )
                }
            })
        };

        $scope.gridOptions = {
            enableFiltering: true,
            paginationPageSizes: [25, 50, 75],
            paginationPageSize: 25,
            columnDefs: [
                {
                    name: 'E', enableFiltering: false, width: 50, enableCellEdit: false, allowCellFocus: false,
                    cellTemplate: '<div class="dropdown tbl-option" style="position: absolute;top: 15 %;left: 1 %;"><button class="btn btn-primary dropdown-toggle" type="button" data-toggle="dropdown"><span class="caret" ></span></button> <ul class="dropdown-menu"><li><a href="#" ng-click="grid.appScope.edit(row)"><i class="glyphicon glyphicon-edit"></i> Sửa</a></li><li><a href="#" ng-click="grid.appScope.delete(row)"><i class="glyphicon glyphicon-trash"></i> Xóa</a></li></u></div>'
                },
                { name: 'Tennhaxe', displayName: "Nhà xe", type: 'text' },
                { name: 'Tenxe', displayName: "Tên xe", type: 'text' },
                { name: 'Ngaydi', displayName: "Ngày đi", type: 'date'},
                { field: 'Giokhoihanh' },
                { field: 'Thoigiandukien' },
                { name: 'TongSoVeThuong', displayName: "Tổng Vé Thường", type: 'number' },
                { name: 'TongSoVeVIP', displayName: "Tổng Vé VIP", type: 'number' },
                { name: 'VeVipConLai', displayName: "Vé VIP còn lại", type: 'number' },
                { name: 'VeThuongConLai', displayName: "Vé thường còn lại", type: 'number' }
            ],
            enableGridMenu: true,
            enableSelectAll: true,
            enableColumnResizing: true,
            enableGridMenu: true,
            rowIdentity: function (row) {
                return row.MaChuyenXe;
            },
            getRowIdentity: function (row) {
                return row.MaChuyenXe;
            },
            exporterOlderExcelCompatibility: true,
            exporterCsvFilename: 'chuyenxe.csv',
            exporterPdfDefaultStyle: { fontSize: 9 },
            exporterPdfTableStyle: { margin: [30, 30, 30, 30] },
            exporterPdfTableHeaderStyle: { fontSize: 10, bold: true, italics: true, color: 'red' },
            exporterPdfHeader: { text: "Danh sách chuyến xe", style: 'headerStyle' },
            exporterPdfFooter: function (currentPage, pageCount) {
                return { text: currentPage.toString() + ' of ' + pageCount.toString(), style: 'footerStyle' };
            },
            exporterPdfCustomFormatter: function (docDefinition) {
                docDefinition.styles.headerStyle = { fontSize: 22, bold: true };
                docDefinition.styles.footerStyle = { fontSize: 10, bold: true };
                return docDefinition;
            },
            exporterPdfOrientation: 'landscape',
            exporterPdfPageSize: 'A4',
            exporterPdfMaxGridWidth: 600,
            exporterCsvLinkElement: angular.element(document.querySelectorAll(".custom-csv-link-location")),
            onRegisterApi: function (gridApi) {
                $scope.gridApi = gridApi;
            }
        };
        $scope.toggleFiltering = function () {
            $scope.gridOptions.enableFiltering = !$scope.gridOptions.enableFiltering;
            $scope.gridApi.core.notifyDataChange(uiGridConstants.dataChange.COLUMN);
        };
        var LoadData = function () {
            $Service.Post(rootUrl + "/SELECTALLCHUYENXE", {})
                .success(function (data) {
                    $scope.gridOptions.data = JSON.parse(data.d);
                    console.log($scope.gridOptions.data);
                });
        }
        $scope.LoadData = function () {
            $Service.Post(rootUrl + "/SELECTALLCHUYENXE", {})
                .success(function (data) {
                    $scope.gridOptions.data = JSON.parse(data.d);
                    console.log($scope.gridOptions.data);
                    return true;
                });
        }
        LoadData();
    }])
app.controller("BaoCaoController", ['$scope', '$http', '$filter', 'Service', function ($scope, $filter, $http, $Service) {
    //Export Excel
    $scope.exportData = function () {
        var blob = new Blob([document.getElementById('exportData').innerHTML], {
            type: "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet;charset=utf-8"
        });
        var currentDate = new Date();
        var datetime = currentDate.getDate() + "-" + (currentDate.getMonth() + 1) + "-" + currentDate.getFullYear();
        saveAs(blob, "BaoCao" + datetime + ".xls");
    };
    $scope.exportPDF = function () {
        var blob = new Blob([document.getElementById('exportPDF').innerHTML], {
            type: "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet;charset=utf-8"
        });
        //var date = new Date().toJSON().slice(0, 10);
        var currentDate = new Date();
        var datetime = currentDate.getDate() + "-" + (currentDate.getMonth() + 1) + "-" + currentDate.getFullYear();
        console.log(datetime)
        saveAs(blob, "Baocaochitiet" + datetime + ".xls");
    };
    //Get all tbl_Order
    $Service.Api("POST", "/Admin/Modules/Order/Default.aspx/getAllOrderBySql", "json", {}).success(function (data) {
        $scope.orders = JSON.parse(data.d);
        angular.forEach($scope.orders, function (item) {
            $Service.Api("POST", "/Admin/Modules/Order/Default.aspx/getMemberByOrderAcc", "json", { accId: item.Order_Account }).success(function (data) {
                item.tbl_Member = JSON.parse(data.d);
                $scope.Order_Name = item.Order_Account == null ? item.Order_Ten : item.tbl_Member[0].Member_Name;
                $scope.Mail = item.Order_Account == null ? item.Order_Email : item.tbl_Member[0].Member_Email
            })
        })
        //$scope.Tongtien += $scope.orders.Order_Tongtien;
        $scope.TongTienThanhToan = getTotal($scope.orders);
    })
    $scope.loading = false;
    $scope.nodata = false;
    $scope.Loc = function (o) {
        if ($scope.startDate != null && $scope.endDate != null && $scope.tenNhaXe != null) {
            $scope.loading = true;
            $Service.Api("POST", "/Admin/Modules/Order/Default.aspx/getOrderByDate", "json", { tenNhaXe: $scope.tenNhaXe, startDate: $scope.startDate, endDate: $scope.endDate }).success(function (data) {
                $scope.orders = JSON.parse(data.d);
                angular.forEach($scope.orders, function (item) {
                    $Service.Api("POST", "/Admin/Modules/Order/Default.aspx/getMemberByOrderAcc", "json", { accId: item.Order_Account }).success(function (data) {
                        item.tbl_Member = JSON.parse(data.d);
                    })
                })
                $scope.forDate = "Từ ngày " + $scope.startDate + " Đến ngày" + $scope.endDate + "";
                $scope.loading = false;
                $scope.totalItems = $scope.orders.length;
                //-	Báo cáo doanh thu theo khoảng thời gian
                $scope.TongTienThanhToan = getTotal($scope.orders);
            })
        }
        else {
            alert("Bạn chưa nhập đủ thông tin tìm kiếm");
        }
    }
    $scope.view = function (o) {
        console.log(o.Order_ID);
        var index = $scope.orders.indexOf(o.Order_ID);
        //console.log(o.Order_ID);
        $("#myModal").modal({ backdrop: false });
        $Service.Api("POST", "/Admin/Modules/Order/Default.aspx/getOrderDetailByOID", "json", { oid: o.Order_ID }).success(function (data) {
            $scope.orderDetail = JSON.parse(data.d);
            console.log($scope.orderDetail);

        })
        //var index = $scope.orders.indexOf(o) + 1;
        $scope.HoTen = o.Order_Account == null ? o.Order_Ten : o.tbl_Member[0].Member_Name;
        $scope.DiaChi = o.Order_ShipAddress;
        $scope.NgayTao = o.Order_CreatedDate;
        $scope.NhaXe = o.Tennhaxe;
        $scope.TongTien = o.Order_Tongtien ? o.Order_Tongtien:0 ;
        $scope.GiamGia = o.Order_KhuyenMai ? o.Order_KhuyenMai: 0;
        $scope.PhiVanChuyen = o.Order_ShipValue ? o.Order_ShipValue:0;
        $scope.Phone = o.Order_Account == null ? o.Sodienthoai : o.tbl_Member[0].Member_Phone;
        $scope.TongThanhToan = o.Order_TongThanhToan ? o.Order_TongThanhToan:0;
        $scope.MaDonHang = o.Order_Code;
    }
    $scope.Delete = function (o) {
        if (confirm('Are you sure?')) {
            $Service.Api("POST", "/Admin/Modules/Order/Default.aspx/DeleteOrderByID", "json", { oid: o.Order_ID })
                .success(function (data) {
                    console.log(data.d);
                })
        }
    };
    //Tổng doanh thu từ ngày -> đến ngày
    var getTotal = function (o) {
        var total = 0;
        angular.forEach(o, function (item) {
            total += item.Order_TongThanhToan;
        })
        return total;
    }
    // Sort Data
    $scope.sortColumn = "Order_CreatedDate";
    $scope.reverseSort = false;
    $scope.sortData = function (column) {
        $scope.reverseSort = ($scope.sortColumn == column) ? !$scope.reverseSort : false;
        $scope.sortColumn = column;
    }
    $scope.getSortClass = function (column) {
        if ($scope.sortColumn == column) {
            return $scope.reverseSort
              ? 'arrow-down'
              : 'arrow-up';
        }
        return;
    }
    //Phân trang
    $scope.viewby = 10;
    //$scope.totalItems = 2;
    $scope.currentPage = 4;
    $scope.itemsPerPage = $scope.viewby;
    $scope.maxSize = 5; //Number of pager buttons to show
    $scope.setPage = function (pageNo) {
        $scope.currentPage = pageNo;
    };
    $scope.pageChanged = function () {
        console.log('Page changed to: ' + $scope.currentPage);
    };
    $scope.setItemsPerPage = function (num) {
        $scope.itemsPerPage = num;
        $scope.currentPage = 1; //reset to first paghe
    }
}])
app.controller("CommentController", ['$scope', '$http', '$filter', 'Service', function ($scope, $filter, $http, $Service) {
    //Export Excel
    function getParameterByName(name, url) {
        if (!url) url = window.location.href;
        name = name.replace(/[\[\]]/g, "\\$&");
        var regex = new RegExp("[?&]" + name + "(=([^&#]*)|&|#|$)"),
            results = regex.exec(url);
        if (!results) return null;
        if (!results[2]) return '';
        return decodeURIComponent(results[2].replace(/\+/g, " "));
    }
    $scope.exportData = function () {
        var blob = new Blob([document.getElementById('exportData').innerHTML], {
            type: "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet;charset=utf-8"
        });
        var currentDate = new Date();
        var datetime = currentDate.getDate() + "-" + (currentDate.getMonth() + 1) + "-" + currentDate.getFullYear();
        saveAs(blob, "BaoCao" + datetime + ".xls");
    };
    $scope.exportPDF = function () {
        var blob = new Blob([document.getElementById('exportPDF').innerHTML], {
            type: "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet;charset=utf-8"
        });
        //var date = new Date().toJSON().slice(0, 10);
        var currentDate = new Date();
        var datetime = currentDate.getDate() + "-" + (currentDate.getMonth() + 1) + "-" + currentDate.getFullYear();
        console.log(datetime)
        saveAs(blob, "Baocaochitiet" + datetime + ".xls");
    };
    //Get all
    function LoadData() {
        $Service.Api("POST", "/Admin/Modules/Content/CommentList.aspx/getAllCommentList", "json", { nhaxe: getParameterByName("nx", window.location.href) }).success(function (data) {
            $scope.orders = JSON.parse(data.d);
            console.log($scope.orders);
            $scope.fields = Object.keys($scope.orders[0]);
        })
    }
    $Service.Api("POST", "/Admin/Default.aspx/Execute", "json", { sp:"SP_GETNHAXEBYID", param: getParameterByName("nx", window.location.href) }).success(function (data) {
        $scope.Nhaxe = JSON.parse(data.d);
        console.log($scope.Nhaxe);
    })
    LoadData();
    $scope.loading = false;
    $scope.nodata = false;
    $scope.Loc = function (o) {
        if ($scope.startDate != null && $scope.endDate != null && $scope.tenNhaXe != null) {
            $scope.loading = true;
            $Service.Api("POST", "/Admin/Modules/Order/Default.aspx/getOrderByDate", "json", { tenNhaXe: $scope.tenNhaXe, startDate: $scope.startDate, endDate: $scope.endDate }).success(function (data) {
                $scope.orders = JSON.parse(data.d);
                angular.forEach($scope.orders, function (item) {
                    $Service.Api("POST", "/Admin/Modules/Order/Default.aspx/getMemberByOrderAcc", "json", { accId: item.Order_Account }).success(function (data) {
                        item.tbl_Member = JSON.parse(data.d);
                    })
                })
                $scope.forDate = "Từ ngày " + $scope.startDate + " Đến ngày" + $scope.endDate + "";
                $scope.loading = false;
                $scope.totalItems = $scope.orders.length;
                //-	Báo cáo doanh thu theo khoảng thời gian
                $scope.TongTienThanhToan = getTotal($scope.orders);
            })
        }
        else {
            alert("Bạn chưa nhập đủ thông tin tìm kiếm");
        }
    }
    $scope.view = function (o) {
        console.log(o.Order_ID);
        var index = $scope.orders.indexOf(o.Order_ID);
        //console.log(o.Order_ID);
        $("#myModal").modal({ backdrop: false });
        $Service.Api("POST", "/Admin/Modules/Order/Default.aspx/getOrderDetailByOID", "json", { oid: o.Order_ID }).success(function (data) {
            $scope.orderDetail = JSON.parse(data.d);
            console.log($scope.orderDetail);

        })
        //var index = $scope.orders.indexOf(o) + 1;
        $scope.HoTen = o.Order_Account == null ? o.Order_Ten : o.tbl_Member[0].Member_Name;
        $scope.DiaChi = o.Order_ShipAddress;
        $scope.NgayTao = o.Order_CreatedDate;
        $scope.NhaXe = o.Tennhaxe;
        $scope.TongTien = o.Order_Tongtien ? o.Order_Tongtien : 0;
        $scope.GiamGia = o.Order_KhuyenMai ? o.Order_KhuyenMai : 0;
        $scope.PhiVanChuyen = o.Order_ShipValue ? o.Order_ShipValue : 0;
        $scope.Phone = o.Order_Account == null ? o.Sodienthoai : o.tbl_Member[0].Member_Phone;
        $scope.TongThanhToan = o.Order_TongThanhToan ? o.Order_TongThanhToan : 0;
        $scope.MaDonHang = o.Order_Code;
    }
    $scope.Approve = function (o) {
        if (confirm('Bạn có chắc chắn muốn thay đổi nội dung này?')) {
            $Service.Api("POST", "/Admin/Modules/Content/CommentList.aspx/ApproveComment", "json", { cmtID: o['Mã'] })
                .success(function (data) {
                    LoadData();
                })
        }
    };
    //Tổng doanh thu từ ngày -> đến ngày
    var getTotal = function (o) {
        var total = 0;
        console.log(o);
        angular.forEach(o, function (item) {
            total += item.Order_TongThanhToan;
        })
        return total;
    }
    // Sort Data
    $scope.sortColumn = "'Ngày bình luận'";
    $scope.reverseSort = false;
    $scope.sortData = function (column) {
        $scope.reverseSort = ($scope.sortColumn == column) ? !$scope.reverseSort : false;
        $scope.sortColumn = column;
    }
    $scope.getSortClass = function (column) {
        if ($scope.sortColumn == column) {
            return $scope.reverseSort
                ? 'arrow-down'
                : 'arrow-up';
        }
        return;
    }
    //Phân trang
    $scope.viewby = 10;
    //$scope.totalItems = 2;
    $scope.currentPage = 4;
    $scope.itemsPerPage = $scope.viewby;
    $scope.maxSize = 5; //Number of pager buttons to show
    $scope.setPage = function (pageNo) {
        $scope.currentPage = pageNo;
    };
    $scope.pageChanged = function () {
        console.log('Page changed to: ' + $scope.currentPage);
    };
    $scope.setItemsPerPage = function (num) {
        $scope.itemsPerPage = num;
        $scope.currentPage = 1; //reset to first paghe
    }
}])
.filter('mapGender', function () {
    var genderHash = {
        1: 'male',
        2: 'female'
    };

    return function (input) {
        if (!input) {
            return '';
        } else {
            return genderHash[input];
        }
    };
});