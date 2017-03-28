var app = angular.module('app', ['ngTouch', 'ui.grid', 'ui.grid.cellNav', 'ui.grid.edit', 'ui.grid.resizeColumns', 'ui.grid.pinning', 'ui.grid.selection', 'ui.grid.moveColumns', 'ui.grid.exporter', 'ui.grid.importer', 'ui.grid.grouping', 'ui.tinymce', 'ngAnimate', 'angularUtils.directives.dirPagination'])
app.controller("NhaXeController", ['$scope', '$http', '$filter', 'svNhaXe', 'Service', function ($scope, $filter, $http, $svNhaXe, $Service) {
    $scope.allnhaxe = [];
    //$svNhaXe.GetAllNhaXe().success(function (data) {
    //    console.log(data);
    //    $scope.nhaxes = data.d;
    //    $scope.allnhaxe = $scope.nhaxes;
    //    console.log($scope.nhaxes);
    //})
    $Service.Api("POST", "/Admin/Modules/Category/NhaXe.aspx/GetAllNhaXe", "json", {}).success(function (data) {
        console.log(data);
        $scope.nhaxes = data.d;
        $scope.allnhaxe = $scope.nhaxes;
        console.log($scope.nhaxes);
    })
    $scope.action = "";
    $scope.loading = false;
    $scope.selected = {};
    $scope.OpenUpdateForm = function (act) {
        switch (act) {
            case "add":
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
                $("#add-modal").modal({ backdrop: false });
                $scope.Tennhaxe = $scope.selected.Tennhaxe;
                $scope.Soluongxe = $scope.selected.Soluongxe;
                $scope.Trusochinh = $scope.selected.Trusochinh;
                $scope.Sodienthoai = $scope.selected.Sodienthoai;
                $scope.Nguoidaidien = $scope.selected.Nguoidaidien;
                $scope.Gioithieungan = $scope.selected.Gioithieungan;
                $scope.Gioithieuchitiet = $scope.selected.Gioithieuchitiet;
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
            console.log($scope.Gioithieungan);
            $Service.Api(
                "POST",
                "/Admin/Modules/Category/NhaXe.aspx/CreateNhaXe",
                "json",
                { Tennhaxe: $scope.Tennhaxe, Soluongxe: $scope.Soluongxe, Trusochinh: $scope.Trusochinh, Nguoidaidien: $scope.Nguoidaidien, Sodienthoai: $scope.Sodienthoai, Gioithieungan: $scope.Gioithieungan, Gioithieuchitiet: $scope.Gioithieuchitiet }
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
            console.log($scope.selected.ID);
            $Service.Api(
                "POST",
                "/Admin/Modules/Category/NhaXe.aspx/UpdateNhaXe",
                "json",
                { Id: $scope.selected.ID, Tennhaxe: $scope.Tennhaxe, Soluongxe: $scope.Soluongxe, Trusochinh: $scope.Trusochinh, Nguoidaidien: $scope.Nguoidaidien, Sodienthoai: $scope.Sodienthoai, Gioithieungan: $scope.Gioithieungan, Gioithieuchitiet: $scope.Gioithieuchitiet }
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
            $Service.Api("POST", "/Admin/Modules/Category/District.aspx/UpdateDistrict", "json", { MaHuyen: $scope.Huyen.MaHuyen, TenHuyen: $scope.Huyen.TenHuyen, MaTinh: $scope.Huyen.MaTinh }).success(function (data) {
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
        $Service.Api("POST", "/Admin/Modules/Category/District.aspx/CreateDistrict", "json", JSON.stringify($scope.nhaxes)).success(function (data) {
            console.log(data);
        })
    }
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
                $scope.formdata = {};
                $scope.action = "add";
                break;
            case "edit":
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

app.controller('ChuyenXeController', ['$scope', '$http', 'Service', '$timeout', '$interval', 'uiGridConstants', 'uiGridGroupingConstants',
    function ($scope, $http, $Service, $timeout, $interval, uiGridConstants, uiGridGroupingConstants) {
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
            paginationPageSizes: [10, 25, 50, 75],
            paginationPageSize: 10,
            columnDefs: [
                { name: 'Ngaydi', displayName: "Ngày đi", type: 'date', cellFilter: 'date:"dd-MM-yyyy"' },
                { field: 'Giokhoihanh' },
                { field: 'Thoigiandukien' },
                { name: 'Tenxe', displayName: "Tên xe", type: 'text' },
                { name: 'TongSoVeThuong', displayName: "Tổng Vé Thường", type: 'number' },
                { name: 'TongSoVeVIP', displayName: "Tổng Vé VIP", type: 'number' },
                { name: 'VeVipConLai', displayName: "Vé VIP còn lại", type: 'number' },
                { name: 'VeThuongConLai', displayName: "Vé thường còn lại", type: 'number' },
                {
                    name: 'Edit', displayName: "Sửa",
                    width: '5%',
                    cellTemplate: '<button class="btn btn-warning p5" type="button" ng-click="grid.appScope.edit(row)">Sửa</button>'
                },
                {
                    name: 'Xóa', displayName: "Xóa",
                    width: '5%',
                    cellTemplate: '<button class="btn btn-danger p5" type="button" ng-click="grid.appScope.delete(row)">Xóa</button>'
                }
            ],
            enableGridMenu: true,
            enableSelectAll: true,
            enableColumnResizing: true,
            enableGridMenu: true,
            fastWatch: true,
            rowIdentity: function (row) {
                return row.MaChuyenXe;
            },
            getRowIdentity: function (row) {
                return row.MaChuyenXe;
            },
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
            exporterPdfMaxGridWidth: 800,
            exporterCsvLinkElement: angular.element(document.querySelectorAll(".custom-csv-link-location")),
            onRegisterApi: function (gridApi) {
                $scope.gridApi = gridApi;
                gridApi.edit.on.afterCellEdit($scope, function (rowEntity, colDef, newValue, oldValue) {
                    console.log('edited row id:', rowEntity.MaChuyenXe, ' Column:' + colDef.name, ' newValue:', newValue, ' oldValue:', oldValue);
                    $scope.$apply();
                });
                gridApi.rowSelectionChanged == function (rowEntity) {
                    console.log("selected", rowEntity);
                }
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