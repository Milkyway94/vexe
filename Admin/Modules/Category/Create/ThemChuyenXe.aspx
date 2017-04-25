<%@ Page Language="C#" AutoEventWireup="true" EnableEventValidation="true" CodeFile="ThemChuyenXe.aspx.cs" Inherits="Admin_Modules_Category_Create_ThemChuyenXe" %>

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
    <%--<link href="../../../Assets/app/bower_components/bootstrap-timepicker/css/timepicker.less" rel="stylesheet" />--%>
</head>
<body>
    <form id="form1" runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server" EnablePartialRendering="true"></asp:ScriptManager>
        <div class="modal-header">
            <h2 class="modal-title text-bold"><asp:Label runat="server" ID="lbTitle"></asp:Label></h2>
        </div>
        <div class="modal-body">
            <div class="form-group">
                <asp:Literal Text="" ID="ltrError" runat="server" />
            </div>
            <asp:UpdatePanel runat="server">
                <ContentTemplate>
                    <div class="form-group">
                        <label runat="server" id="lbNhaxe">Chọn nhà xe</label>
                        <asp:DropDownList runat="server" ID="ddlNhaxe" OnSelectedIndexChanged="ddlNhaxe_SelectedIndexChanged" AutoPostBack="true" CssClass="form-control select2"></asp:DropDownList>
                    </div>
                    <div class="form-group">
                        <label>Chọn xe</label>
                        <asp:DropDownList runat="server" ID="ddlXe" CssClass="form-control select2"></asp:DropDownList>
                    </div>
                </ContentTemplate>
            </asp:UpdatePanel>
            <div class="form-group">
                <label>Chọn ngày đi</label>
                <div class="input-group bootstrap-timepicker">
                    <asp:TextBox runat="server" ID="txtNgaydi" ClientIDMode="Static" TextMode="Date" CssClass="form-control" placeholder="Chọn ngày đi" required></asp:TextBox>
                    <span class="input-group-addon" onclick="$('#txtNgaydi').focus().click()"><i class="glyphicon glyphicon-calendar"></i></span>
                </div>
                <asp:RequiredFieldValidator ErrorMessage="Bạn phải nhập trường này" ControlToValidate="txtNgaydi" runat="server" />
            </div>
            <div class="form-group">
                <label>Chọn giờ đi</label>
                <div class="input-group bootstrap-timepicker timepicker">
                    <asp:TextBox runat="server" TextMode="Time" ID="txtGiodi" ClientIDMode="Static" CssClass="form-control input-small" placeholder="Chọn giờ đi" required></asp:TextBox>
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
            <asp:UpdatePanel runat="server">
                <ContentTemplate>
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
                </ContentTemplate>
            </asp:UpdatePanel>
            <asp:UpdatePanel runat="server">
                <ContentTemplate>
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
                </ContentTemplate>
            </asp:UpdatePanel>

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
    <script src="../../../js/site.js"></script>
    <script src="/resources/js/script.js"></script>
    <script> 
        function pageLoad() { $(".select2").select2(); }
    </script>
    <asp:Literal Text="" ID="ltrScript" runat="server" />
</body>
</html>
