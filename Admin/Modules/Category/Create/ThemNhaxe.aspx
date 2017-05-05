<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ThemNhaxe.aspx.cs" Inherits="Admin_Modules_Category_Create_ThemNhaxe" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="/resources/css/bootstrap.min.css" rel="stylesheet" />
    <link href="/Admin/Assets/admin-lte/css/AdminLTE.css" rel="stylesheet" />
    <link rel="stylesheet" href="//code.jquery.com/ui/1.12.0/themes/base/jquery-ui.css" />
    <link href="/Admin/js/tinymce/skins/lightgray/skin.min.css" rel="stylesheet" />
    <link href="/resources/plugins/select2/dist/css/select2.min.css" rel="stylesheet" />
    <link href="/Admin/css/Style.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
        <div class="form-group">
            <label>Tên nhà xe</label>
            <asp:TextBox runat="server"  ID="Tennhaxe" CssClass="form-control" required="required" />
        </div>
        <div class="form-group">
            <label>Địa chỉ ở tỉnh?</label>
            <asp:DropDownList runat="server" ID="Tinh" CssClass="select2">
            </asp:DropDownList>
        </div>
        <div class="form-group">
            <label>Địa chỉ trụ sở</label>
            <asp:TextBox runat="server" ID="Trusochinh"  class="form-control" />
        </div>
        <div class="form-group">
            <label class="col-sm-12">Ảnh(*) </label>
            <div class="col-sm-10">
                <div class="row">
                    <asp:TextBox runat="server" ClientIDMode="Static" ng-model="Anh" ID="txtImg" class="form-control" required />
                </div>

            </div>
            <div class="col-sm-2">
                <input id="browseServer" class="btn btn-warning" onclick="BrowseServer('txtImg');" type="button" value="Tải ảnh" />
            </div>
        </div>
        <div class="form-group">
            <br />
            <img class="img-responsive" id="catimg" runat="server" />
        </div>
        <div class="form-group">
            <label>Số điện thoại (*)</label>
            <asp:TextBox runat="server" ID="Sodienthoai"  TextMode="Number" MaxLength="12" CssClass="form-control" required />
        </div>
        <div class="form-group">
            <label>Số lượng xe(*) </label>
            <asp:TextBox runat="server" ID="Soluongxe"  CssClass="form-control" TextMode="Number" MaxLength="3" Text="0" required />
        </div>
        <div class="form-group">
            <label>Tên Người đại diện (*)</label>
            <asp:TextBox runat="server" ID="Nguoidaidien" CssClass="form-control" required />
        </div>
        <div class="form-group">
            <label>Giới thiệu ngắn(*)</label>
            <asp:TextBox runat="server" TextMode="MultiLine" ID="Gioithieungan" CssClass="form-control" />
        </div>
        <div class="form-group">
            <label>Giới thiệu chi tiết(*)</label>
            <asp:TextBox runat="server" TextMode="MultiLine" ID="Gioithieuchitiet" CssClass="form-control editor" />
        </div>


        <input type="reset" class="btn btn-flat btn-warning pull-left" value="Nhập lại" />
        <asp:Button Text="Lưu lại" ID="btnUpdate" OnClick="btnUpdate_Click" CssClass="btn btn-flat btn-success" runat="server" />

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
    <script src="../../../js/site.js"></script>
    <script src="/resources/js/script.js"></script>

    <asp:Literal Text="" ID="ltrScript" runat="server" />
</body>
</html>
