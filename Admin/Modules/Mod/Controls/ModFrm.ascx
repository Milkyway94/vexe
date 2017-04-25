<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ModFrm.ascx.cs" Inherits="Admin_Modules_Mod_Controls_ModFrm" %>
<link href="/Admin/Assets/admin-lte/css/AdminLTE.min.css" rel="stylesheet" />

<link rel="stylesheet" href="//code.jquery.com/ui/1.12.0/themes/base/jquery-ui.css">
<link rel="stylesheet" href="https://jqueryui.com/resources/demos/style.css">
<link href="/Admin/js/tinymce/skins/lightgray/skin.min.css" rel="stylesheet" />
<table id="toolbar" cellspacing="0">
<tr> 
	<td style="width:149px"> 
		<table cellspacing="0">
			<tr> 
				<td class="toolBarButton" id="btnCreate"><img src="<%=sRootAppPath %>Themes/save.png" align="absmiddle">&nbsp;<asp:LinkButton
                        ID="lbtUpdate" runat="server" OnClick="lbtUpdate_Click">Cập nhật</asp:LinkButton></td>
				<td class="toolBarButton" id="btnCancel" onclick="javascript:window.close();"><img src="<%=sRootAppPath %>Themes/cancel.gif" align="absmiddle">&nbsp;Huỷ bỏ</td>
			</tr>
		</table>
	</td>
</tr>
</table>
<table class="controlbox" width="100%">	
<tr> 
	<td valign="top">
		<table class="fieldbox" width="100%" cellspacing="2">
			<tr>
    			<td>Nhóm Module</td>
				<td><asp:DropDownList ID="ddlGroup" Width="200" runat="server" CssClass="form-control"></asp:DropDownList></td>
				<td>Định dạng</td>
				<td><asp:DropDownList ID="ddlModtype" runat="server" CssClass="form-control" ClientIDMode="Static"></asp:DropDownList></td>				
			</tr>
            <tr id="dMtypePt" style="display:none">
                <td>Danh mục sản phẩm : </td>
				<td><asp:DropDownList ID="ddlModtypePt" Width="200" CssClass="form-control" runat="server"></asp:DropDownList></td>
            </tr>
            
			    <tr class="typeNM">
    			    <td>Tên mục</td>
				    <td><asp:textbox id="txtName" CssClass="name form-control"  Width="193" runat="server"></asp:textbox></td>
    			    <td>Mã mục</td>
				    <td><asp:textbox id="txtCode" Width="150" CssClass="code form-control" runat="server"></asp:textbox></td>						
			    </tr>
                <tr class="typeNM">
    			    <td>URL</td>
				    <td colspan="3"><asp:textbox CssClass="form-control url" id="txtURL" Width="460" runat="server"></asp:textbox></td>
			    </tr>			
			    <tr class="typeNM">
    			    <td>Keywords</td>
				    <td colspan="3"><asp:textbox CssClass="form-control" id="txtKey" Width="460" runat="server"></asp:textbox></td>
			    </tr>
			    <tr class="typeNM">
    			    <td>Title page</td>
				    <td colspan="3"><asp:textbox CssClass="form-control" id="txtTitle" Width="460" runat="server"></asp:textbox></td>
			    </tr>
			    <tr class="typeNM">
    			    <td>Descripton</td>
				    <td colspan="3"><asp:textbox id="txtDes" CssClass="form-control" Width="460" runat="server"></asp:textbox></td>
			    </tr>
			    <tr class="typeNM"> 		                        			
		            <td>Ảnh</td>
		            <td colspan="3">
                        <asp:textbox id="txtImg" ClientIDMode="Static" CssClass="form-control" Width="420" runat="server"></asp:textbox>
                        <input id="browseServer" onclick="BrowseServer('txtImg');"  type="button" value="Tải ảnh" />
		            </td>									
	            </tr>
          
            <tr>
    			<td colspan="4">
    			    Số thứ tự <asp:textbox id="txtPos" Width="60px" runat="server"></asp:textbox>
    			    <asp:checkbox id="cbIsUse" runat="server"></asp:checkbox> Kích hoạt
                </td>
			</tr>
			<tr>
			    <td colspan="4">
			         <asp:TextBox ID="CKContent" ClientIDMode="Static" TextMode="MultiLine"  Height="300" CssClass="form-control editor" runat="server"></asp:TextBox>
                </td>
            </tr>            
		</table>
	</td>
</tr>
</table>

<script type="text/javascript">
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
            {title: 'Open Sans', inline: 'span', styles: {'font-family': 'Open Sans' } },
            {title: 'Arial', inline: 'span', styles: {'font-family': 'arial' } },
            {title: 'Book Antiqua', inline: 'span', styles: {'font-family': 'book antiqua' } },
            {title: 'Comic Sans MS', inline: 'span', styles: {'font-family': 'comic sans ms,sans-serif' } },
            {title: 'Courier New', inline: 'span', styles: {'font-family': 'courier new,courier' } },
            {title: 'Georgia', inline: 'span', styles: {'font-family': 'georgia,palatino' } },
            {title: 'Helvetica', inline: 'span', styles: {'font-family': 'helvetica' } },
            {title: 'Impact', inline: 'span', styles: {'font-family': 'impact,chicago' } },
            {title: 'Symbol', inline: 'span', styles: {'font-family': 'symbol' } },
            {title: 'Tahoma', inline: 'span', styles: {'font-family': 'tahoma' } },
            {title: 'Terminal', inline: 'span', styles: {'font-family': 'terminal,monaco' } },
            {title: 'Times New Roman', inline: 'span', styles: {'font-family': 'times new roman,times' } },
            {title: 'Verdana', inline: 'span', styles: {'font-family': 'Verdana' } }
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