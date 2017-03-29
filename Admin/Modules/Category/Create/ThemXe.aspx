<%@ Page Language="C#" AutoEventWireup="true" EnableEventValidation="true" CodeFile="ThemXe.aspx.cs" Inherits="Admin_Modules_Category_Create_ThemXe" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Thêm chuyến xe</title>
    <link href="/resources/css/bootstrap.min.css" rel="stylesheet" />
    <link href="/Admin/Assets/admin-lte/css/AdminLTE.css" rel="stylesheet" />
    <link rel="stylesheet" href="//code.jquery.com/ui/1.12.0/themes/base/jquery-ui.css" />
    <link href="/Admin/js/tinymce/skins/lightgray/skin.min.css" rel="stylesheet" />
    <link href="/resources/plugins/select2/dist/css/select2.min.css" rel="stylesheet" />
    <link href="/Admin/css/Style.css" rel="stylesheet" />
    <link href="../../../Assets/app/bower_components/bootstrap-timepicker/css/timepicker.less" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server" EnablePartialRendering="true"></asp:ScriptManager>
        <div class="modal-header">
            <h2 class="modal-title text-bold">Thêm mới CHUYẾN XE</h2>
        </div>
        <div class="modal-body">
            <div class="form-group">
                <asp:Literal Text="" ID="ltrError" runat="server" />
            </div>
            <div class="form-group">
                <label>Chọn xe</label>
                <asp:DropDownList runat="server" ID="ddlXe" CssClass="form-control select2"></asp:DropDownList>
            </div>
            <div class="form-group">
                <label>Chọn ngày đi</label>
                <div class="input-group bootstrap-timepicker timepicker">
                    <asp:TextBox runat="server" ID="txtNgaydi" CssClass="form-control datepicker" placeholder="Chọn ngày đi" required></asp:TextBox>
                    <span class="input-group-addon"><i class="glyphicon glyphicon-calendar"></i></span>
                </div>
                <asp:RequiredFieldValidator ErrorMessage="Bạn phải nhập trường này" ControlToValidate="txtNgaydi" runat="server" />
            </div>
            <div class="form-group">
                <label>Chọn giờ đi</label>
                <div class="input-group bootstrap-timepicker timepicker">
                    <asp:TextBox runat="server" ID="txtGiodi" ClientIDMode="Static" CssClass="form-control input-small" placeholder="Chọn giờ đi" required></asp:TextBox>
                    <span class="input-group-addon"><i class="glyphicon glyphicon-time"></i></span>
                </div>
                <asp:RequiredFieldValidator ErrorMessage="Bạn phải nhập trường này" ControlToValidate="txtGiodi" runat="server" />
            </div>
            <div class="form-group">
                <label>Nhập thời gian đi</label>
                <div class="row">
                    <div class="col-sm-6 col-md-6 col-xs-6">
                        <div class="input-group">
                            <asp:TextBox runat="server" ID="txtThoigiandiG" TextMode="Number" MaxLength="3" CssClass="form-control" placeholder="Nhập số Giờ" required></asp:TextBox>
                            <span class="input-group-addon">Giờ</span>
                        </div>
                        <asp:RequiredFieldValidator ErrorMessage="Bạn phải nhập trường này" ControlToValidate="txtThoigiandiG" runat="server" />
                        <br />
                        <asp:RangeValidator ForeColor="Red" ErrorMessage="Giá trị chỉ nhận từ 00 đến 999 giờ" ControlToValidate="txtThoigiandiG" MaximumValue="999" MinimumValue="0" runat="server" />
                    </div>
                    <div class="col-sm-6 col-md-6 col-xs-6">
                        <div class="input-group">
                            <asp:TextBox runat="server" ID="txtThoigiandiP" TextMode="Number" MaxLength="2" CssClass="form-control" placeholder="Nhập số phút" required></asp:TextBox>
                            <span class="input-group-addon">Phút</span>
                        </div>
                        <asp:RequiredFieldValidator ErrorMessage="Bạn phải nhập trường này" ControlToValidate="txtThoigiandiP" runat="server" />
                        <br />
                        <asp:RangeValidator ErrorMessage="Giá trị chỉ nhận từ 0 đến 59 phút" MinimumValue="0" MaximumValue="59" ControlToValidate="txtThoigiandiP" runat="server" />
                    </div>
                </div>

            </div>
            <div class="form-group">
                <label>Chọn điểm đi</label>
                <div class="row">
                    <div class="col-sm-6 col-md-6 col-xs-6">
                        <div class="input-group">
                            <asp:DropDownList runat="server" ID="ddlDiTinh" AutoPostBack="true" OnSelectedIndexChanged="ddlDiTinh_SelectedIndexChanged" ClientIDMode="Static" CssClass="form-control select2"></asp:DropDownList>
                            <span class="input-group-addon">Tỉnh</span>
                        </div>
                    </div>
                    <div class="col-sm-6 col-md-6 col-xs-6">
                        <div class="input-group">
                            <asp:DropDownList runat="server" ID="ddlDiHuyen" CssClass="form-control select2"></asp:DropDownList>
                            <span class="input-group-addon">Huyện</span>
                        </div>
                    </div>
                </div>
            </div>
            <div class="form-group">
                <label>Chọn điểm đến</label>
                <div class="row">

                    <div class="col-sm-6 col-md-6 col-xs-6">
                        <div class="input-group">
                            <asp:DropDownList runat="server" ID="ddlDenTinh" AutoPostBack="true" OnSelectedIndexChanged="ddlDenTinh_SelectedIndexChanged" ClientIDMode="Static" CssClass="form-control select2"></asp:DropDownList>
                            <span class="input-group-addon">Tỉnh</span>
                        </div>
                    </div>
                    <div class="col-sm-6 col-md-6 col-xs-6">
                        <div class="input-group">
                            <asp:DropDownList runat="server" ID="ddlDenHuyen" CssClass="form-control select2"></asp:DropDownList>
                            <span class="input-group-addon">Huyện</span>
                        </div>
                    </div>

                </div>
                <div class="form-group">
                    <label>Tổng số vé</label>
                    <asp:TextBox runat="server" ID="txtTongsove" TextMode="Number" CssClass="form-control" placeholder="Nhập tổng số vé" required></asp:TextBox>
                </div>
                <div class="form-group">
                    <label>Số vé thường</label>
                    <asp:TextBox runat="server" ID="txtVethuong" TextMode="Number" CssClass="form-control" placeholder="Nhập số vé thường" required></asp:TextBox>
                </div>
                <div class="form-group">
                    <label>Số vé VIP</label>
                    <asp:TextBox runat="server" ID="txtVeVip" TextMode="Number" CssClass="form-control" placeholder="Nhập số vé Vip" required></asp:TextBox>
                </div>
                <div class="form-group">
                    <label>Giá vé VIP</label>
                    <asp:TextBox runat="server" ID="txtGiaVip" TextMode="Number" CssClass="form-control" placeholder="Nhập giá vé Vip" required></asp:TextBox>
                </div>
                <div class="form-group">
                    <label>Giá vé Thường</label>
                    <asp:TextBox runat="server" ID="txtGiaThuong" TextMode="Number" CssClass="form-control" placeholder="Nhập giá vé thường" required></asp:TextBox>
                </div>
                <div class="form-group">
                    <label>Khuyến Mãi(%)</label>
                    <asp:TextBox runat="server" ID="txtKhuyenMai" TextMode="Number" CssClass="form-control" placeholder="Nhập giá khuyến mãi"></asp:TextBox>
                </div>
                <div class="form-group">
                    <label>Lộ trình chuyến</label>
                    <asp:TextBox runat="server" ID="txtLotrinh" CssClass="form-control" placeholder="Nhập giá lộ trình" required></asp:TextBox>
                </div>
            </div>
        </div>
        <div class="modal-footer">
            <div class="form-group">
                <asp:Button Text="Lưu lại" CssClass="btn btn-success btn-flat" ID="btnSave" OnClick="btnSave_Click" runat="server" />
                <input type="reset" class="btn btn-warning btn-flat" value="Nhập lại" />
            </div>
        </div>
    </form>
    <script src="/resources/js/jquery-2.2.4.min.js"></script>
    <script src="/resources/js/bootstrap.min.js"></script>
    <script src="/Admin/Assets/admin-lte/js/app.min.js"></script>
    <script src="/Admin/js/tinymce/jquery.tinymce.min.js"></script>
    <script src="/Admin/js/tinymce/tinymce.min.js"></script>
    <script src="/Scripts/ckfinder/ckfinder.js"></script>
    <script src="/Admin/Assets/admin-lte/select2/select2.full.min.js"></script>
    <script src="/Admin/Assets/admin-lte/iCheck/icheck.min.js"></script>
    <script src="/resources/js/jquery-ui.js"></script>
    <script src="/resources/js/script.js"></script>
    <script src="../../../Assets/app/bower_components/bootstrap-timepicker/js/bootstrap-timepicker.js"></script>

    <script>
        tinymce.init({
            selector: '#CKTeaser, #CKContent',
            height: 300,
            theme: 'modern',
            plugins: [
              'advlist autolink lists link image charmap print preview hr anchor pagebreak',
              'searchreplace wordcount visualblocks visualchars code fullscreen',
              'insertdatetime media nonbreaking save table contextmenu directionality',
              'emoticons template paste textcolor colorpicker textpattern imagetools codesample'
            ],
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
            ],
        });
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
        function BrowseServer(field) {
            var finder = new CKFinder();
            finder.selectActionFunction = function (fileUrl) {
                document.getElementById(field).value = fileUrl;
                document.getElementById("catimg").src = fileUrl;
            };
            finder.popup();
        }
    </script>
    <script>
        $("#txtGiodi").timepicker();
        //$("#ddlDiTinh").change(function () {
        //    var data = {
        //        matinh: $(this).val()
        //    }
        //    $.ajax({
        //        url: "ThemChuyenXe.aspx/GetHuyenByTinh",
        //        method: "POST",
        //        contentType: "application/json",
        //        data: JSON.stringify(data)
        //    })
        //    .success(function (data) {
        //        var res = JSON.parse(data.d);
        //        var str = "";
        //        for (var i = 0; i < res.length; i++) {
        //            str += "<option value='" + res[i].id + "'>" + res[i].text + "</option>";
        //        }
        //        $("#ddlDiHuyen").html(str);
        //        $("#ddlDiHuyen").select2();
        //    })
        //     .error(function (data) {
        //         console.log(data);
        //     })
        //})
        //$("#ddlDenTinh").change(function () {
        //    var data = {
        //        matinh: $(this).val()
        //    }
        //    $.ajax({
        //        url: "ThemChuyenXe.aspx/GetHuyenByTinh",
        //        method: "POST",
        //        contentType: "application/json",
        //        data: JSON.stringify(data)
        //    })
        //    .success(function (data) {
        //        var res = JSON.parse(data.d);
        //        var str = "";
        //        for (var i = 0; i < res.length; i++) {
        //            str += "<option value='" + res[i].id + "'>" + res[i].text + "</option>";
        //        }
        //        $("#ddlDenHuyen").html(str);
        //        $("#ddlDenHuyen").select2();
        //    })
        //     .error(function (data) {
        //         console.log(data);
        //     })
        //})
        $(document).ready(function () {
            $(".datepicker").datepicker();
            $(".nav-tabs li a").click(function () {
                $(this).tab('show');
            });
            $('.nav-tabs a').on('shown.bs.tab', function (event) {
                var x = $(event.target).text();         // active tab
                var y = $(event.relatedTarget).text();  // previous tab
                $(".act span").text(x);
                $(".prev span").text(y);
            });
            $('input[type="checkbox"].flat-red, input[type="radio"].flat-red').iCheck({
                checkboxClass: 'icheckbox_flat-green',
                radioClass: 'iradio_flat-green'
            });
        });
        function ChangeToSlug() {
            // Chuyển hết sang chữ thường
            var title = document.getElementById("ctl02_txtName").value;
            var str = title.toLowerCase();
            // xóa dấu
            str = str.replace(/(à|á|ạ|ả|ã|â|ầ|ấ|ậ|ẩ|ẫ|ă|ằ|ắ|ặ|ẳ|ẵ)/g, 'a');
            str = str.replace(/(è|é|ẹ|ẻ|ẽ|ê|ề|ế|ệ|ể|ễ)/g, 'e');
            str = str.replace(/(ì|í|ị|ỉ|ĩ)/g, 'i');
            str = str.replace(/(ò|ó|ọ|ỏ|õ|ô|ồ|ố|ộ|ổ|ỗ|ơ|ờ|ớ|ợ|ở|ỡ)/g, 'o');
            str = str.replace(/(ù|ú|ụ|ủ|ũ|ư|ừ|ứ|ự|ử|ữ)/g, 'u');
            str = str.replace(/(ỳ|ý|ỵ|ỷ|ỹ)/g, 'y');
            str = str.replace(/(đ)/g, 'd');
            // Xóa ký tự đặc biệt
            str = str.replace(/([^0-9a-z-\s])/g, '');
            // Xóa khoảng trắng thay bằng ký tự -
            str = str.replace(/(\s+)/g, '-');
            // xóa phần dự - ở đầu
            str = str.replace(/^-+/g, '');
            // xóa phần dư - ở cuối
            str = str.replace(/-+$/g, '');
            // return 
            document.getElementById('ctl02_txtCode').value = str;
            return str;
        }
        function HideModal() {
            $('#add-modal').modal('hide');
        }
    </script>
    <asp:Literal Text="" ID="ltrScript" runat="server" />
</body>
</html>
