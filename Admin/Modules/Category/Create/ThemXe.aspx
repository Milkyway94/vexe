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
                <asp:TextBox runat="server" ClientIDMode="Static" ID="txtBienSo" CssClass="form-control" placeholder="Nhập biển số" required></asp:TextBox>
                <asp:RegularExpressionValidator runat="server"
                    ControlToValidate="txtBienSo"
                    ErrorMessage="Biển số không hợp lệ."
                    ValidationExpression="[a-zA-Z0-9 -]{1,20}"
                    SetFocusOnError="true" />
            </div>
            <div class="form-group">
                <label>Tên hiển thị</label>
                <asp:TextBox runat="server" ID="txtTenXe" CssClass="form-control" MaxLength="50" placeholder="Nhập tên hiển thị" required></asp:TextBox>
                <asp:RegularExpressionValidator runat="server" Display="Dynamic"
                    ControlToValidate="txtTenXe"
                    ErrorMessage="Tên hiển thị chỉ tử 3-50 ký tự."
                    ValidationExpression="[\s\S]{3,50}" />
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
                <asp:TextBox runat="server" ID="txtSoGhe" Text="0" CssClass="form-control" TextMode="Number" MaxLength="3" />
                <asp:RangeValidator runat="server" Type="Integer"
                    MinimumValue="1" MaximumValue="999" ControlToValidate="txtSoGhe"
                    ErrorMessage="Số chỗ chỉ từ 1-999" />
            </div>
            <div class="form-group">
                <label>Ảnh(*)</label>
                <table class="table">
                    <tr>
                        <td>
                            <asp:TextBox runat="server" ClientIDMode="Static" ID="txtAvartar" class="form-control" required /></td>
                        <td>
                            <input id="browseServer" class="btn btn-warning" onclick="BrowseServer('txtAvartar');" type="button" value="Tải ảnh" /></td>
                    </tr>
                </table>
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
