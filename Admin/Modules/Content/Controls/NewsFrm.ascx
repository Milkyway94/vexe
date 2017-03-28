<%@ Control Language="C#" AutoEventWireup="true" CodeFile="NewsFrm.ascx.cs" Inherits="Admin_Modules_Content_Controls_NewsFrm" %>
<link href="/resources/css/bootstrap.min.css" rel="stylesheet" />
<link href="/Admin/Assets/admin-lte/css/AdminLTE.min.css" rel="stylesheet" />

<link rel="stylesheet" href="//code.jquery.com/ui/1.12.0/themes/base/jquery-ui.css">
<link rel="stylesheet" href="https://jqueryui.com/resources/demos/style.css">
<link href="/Admin/js/tinymce/skins/lightgray/skin.min.css" rel="stylesheet" />
<div class="container">
    <form>
        <h2 class="text-center">Cập nhật tin tức</h2>
        <hr />
        <div class="form-group row">
            <label for="inputEmail3" class="col-sm-3 col-form-label">Tiêu đề</label>
            <div class="col-sm-9">
                <asp:TextBox type="text" ID="txtName" runat="server" CssClass="w100 form-control"></asp:TextBox>
            </div>
        </div>
        <div class="form-group row">
            <label for="inputEmail3" class="col-sm-3 col-form-label">Đề mục</label>
            <div class="col-sm-9">
                <asp:DropDownList CssClass="form-control select2" ID="ddlModID" runat="server"></asp:DropDownList>
            </div>
        </div>
        <div class="form-group row">
            <label for="inputEmail3" class="col-sm-3 col-form-label">Ngày đăng</label>
            <div class="col-sm-9">
                <asp:TextBox ID="txtDate" CssClass="form-control datepicker" runat="server"></asp:TextBox>
            </div>
        </div>
        <div class="form-group row">
            <label for="inputEmail3" class="col-sm-3 col-form-label">Đường dẫn</label>
            <div class="col-sm-9">
                <asp:TextBox ID="txtCode" CssClass="form-control" runat="server"></asp:TextBox>
            </div>
        </div>
        <div class="form-group row">
            <label for="inputEmail3" class="col-sm-3 col-form-label">Ảnh</label>
            <div class="col-sm-7">
                <asp:TextBox ID="txtImg" CssClass="form-control" ClientIDMode="Static" runat="server"></asp:TextBox>
            </div>
            <div class="col-sm-2">
                <input id="browseServer" class="btn btn-warning" onclick="BrowseServer('txtImg');" type="button" value="Tải ảnh" />
            </div>
        </div>
        <div class="form-group row">
            <div class="col-sm-6 col-sm-offset-3">
                <img id="catimg" class="img-responsive"/>
            </div>
        </div>
        <div class="form-group row">
            <label for="inputEmail3" class="col-sm-3 col-form-label">Vị trí</label>
            <div class="col-sm-9">
                <asp:TextBox ID="txtPos" Width="200" CssClass="form-control" runat="server"></asp:TextBox>
            </div>
        </div>
        <div class="form-group row">
            <label for="inputEmail3" class="col-sm-3 col-form-label">Trạng thái: </label>
            <div class="col-sm-9">
                <asp:CheckBox ID="cbIsUse" runat="server"></asp:CheckBox>
                Kích hoạt
		&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
		<asp:CheckBox ID="cbIsHot" runat="server"></asp:CheckBox>
                Tin nổi bật
		&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
		<asp:CheckBox ID="cbIsHome" runat="server"></asp:CheckBox>
                Hiện lên trang chủ
            </div>
        </div>
        <div class="form-group row">
            <ul class="nav nav-tabs">
                <li class="active"><a data-toggle="tab" href="#home">Mô tả</a></li>
                <li><a data-toggle="tab" href="#menu1">Chi tiết</a></li>
                <li><a data-toggle="tab" href="#menu2">SEO</a></li>
            </ul>
            <div class="tab-content">
                <div id="home" class="tab-pane fade in active">
                    <asp:TextBox ID="CKTeaser" ClientIDMode="Static" TextMode="MultiLine"  Height="300" CssClass="form-control" runat="server"></asp:TextBox>
                </div>
                <div id="menu1" class="tab-pane fade">
                    <asp:TextBox ID="CKContent" ClientIDMode="Static" TextMode="MultiLine" Height="300" CssClass="form-control" runat="server"></asp:TextBox>
                </div>
                <div id="menu2" class="tab-pane fade">
                    <div class="form-group row">
                        <label for="inputEmail3" class="col-sm-3 col-form-label">Title page</label>
                        <div class="col-sm-9">
                            <asp:TextBox ID="txtTitle" CssClass="form-control" runat="server"></asp:TextBox>
                        </div>
                    </div>

                    <div class="form-group row">
                        <label for="inputEmail3" class="col-sm-3 col-form-label">Keywords</label>
                        <div class="col-sm-9">
                            <asp:TextBox ID="txtKey" CssClass="form-control" runat="server"></asp:TextBox>
                        </div>
                    </div>
                    <div class="form-group row">
                        <label for="inputEmail3" class="col-sm-3 col-form-label">Meta Description</label>
                        <div class="col-sm-9">
                            <asp:TextBox ID="txtMeta" TextMode="MultiLine" CssClass="form-control" runat="server"></asp:TextBox>
                        </div>
                    </div>
                    <div class="form-group row">
                        <label for="inputEmail3" class="col-sm-3 col-form-label">Tags</label>
                        <div class="col-sm-9">
                            <asp:TextBox ID="txtTag" CssClass="form-control" runat="server"></asp:TextBox>
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <div class="form-inline row">
            <div class="form-group col-sm-offset-4">
                <asp:LinkButton ID="lbtUpdate" CssClass="btn btn-success btn-flat" runat="server" OnClick="lbtUpdate_Click"><i class="fa fa-check"></i>Cập nhật</asp:LinkButton>
            </div>
            <div class="form-group">
                <asp:LinkButton ID="lbtBack" CssClass="btn btn-warning btn-flat" runat="server" OnClick="lbtBack_Click"><i class="fa fa-check"></i>Trở về danh sách</asp:LinkButton>
            </div>
        </div>
        <br /><br />
</form>
</div>
<script src="/resources/js/jquery-2.2.4.min.js"></script>
<script src="/resources/js/bootstrap.min.js"></script>
<script src="/Admin/Assets/admin-lte/js/app.min.js"></script>
<script src="/Admin/js/tinymce/jquery.tinymce.min.js"></script>
<script src="/Admin/js/tinymce/tinymce.min.js"></script>
<script src="/Scripts/ckfinder/ckfinder.js"></script>
<script src="/Admin/Assets/admin-lte/select2/select2.full.min.js"></script>
<script src="/Admin/Assets/admin-lte/iCheck/icheck.min.js"></script>
<script src="/resources/js/jquery-ui.js"></script>
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
    document.getElementById("catimg").src = document.getElementById("txtPath").value;
</script>
<script>
   
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
</script>