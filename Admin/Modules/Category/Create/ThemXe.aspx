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
            <h2 class="modal-title text-bold">Thêm mới XE</h2>
        </div>
        <div class="modal-body">
            <div class="form-group">
                <asp:Literal Text="" ID="ltrError" runat="server" />
            </div>
            <div class="form-group">
                <label>Biển số</label>
                <asp:TextBox runat="server" ID="txtBienSo" CssClass="form-control" placeholder="Nhập biển số" required></asp:TextBox>
            </div>
            <div class="form-group">
                <label>Tên hiển thị</label>
                <asp:TextBox runat="server" ID="txtTenXe" CssClass="form-control" placeholder="Nhập tên hiển thị" required></asp:TextBox>
            </div>
            <div class="form-group">
                <label>Nhà xe</label>
                <asp:DropDownList runat="server" ID="ddlNhaxe" CssClass="form-control select2"></asp:DropDownList>
            </div>
            <div class="form-group">
                <label>Loại xe</label>
                <asp:DropDownList runat="server" ID="ddlHangXe" CssClass="form-control select2"></asp:DropDownList>
            </div>
            <div class="form-group">
                <label>Số chỗ</label>
                <asp:TextBox runat="server" ID="txtSoGhe" CssClass="form-control" TextMode="Number" MaxLength="3" />
            </div>
            <div class="form-group">
                <label>Ảnh</label>
                <div class="row">
                    <div class="col-sm-10 col-md-10 col-xs-10">
                        <asp:TextBox runat="server" ClientIDMode="Static" CssClass="form-control" ID="txtAvartar" MaxLength="512" />
                    </div>
                    <div class="col-sm-2 col-md-2 col-xs-2">
                        <div class="input-group">
                            <button class="btn btn-success btn-flat" onclick="BrowseServer('txtAvartar');">Chọn ảnh</button>
                        </div>
                    </div>
                </div>
            </div>
            <div class="form-group">
                <div class="col-sm-6 col-sm-offset-3">
                    <img id="catimg" width="200" height="200" class="img-responsive" />
                </div>
            </div>
            <div class="form-group">
                <label>Giới thiệu</label>
                <asp:TextBox runat="server" ID="txtGioiThieu" CssClass="form-control" TextMode="MultiLine" />
            </div>
            <div class="form-group">
                <label>Mô tả chi tiết</label>
                <asp:TextBox runat="server" ID="txtChiTiet" CssClass="form-control editor" TextMode="MultiLine" />
            </div>

            <div class="form-group">
                <asp:CheckBox Text="Kích hoạt" ID="ckDel" CssClass="icheck ui-icon-arrowthick-1-w" runat="server" />
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
    <script src="../../../Assets/app/bower_components/bootstrap-timepicker/js/bootstrap-timepicker.js"></script>
    <script src="/resources/js/script.js"></script>
    <script src="../../../js/site.js"></script>
    <asp:Literal Text="" ID="ltrScript" runat="server" />
</body>
</html>
