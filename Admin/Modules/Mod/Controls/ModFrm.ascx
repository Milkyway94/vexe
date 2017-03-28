<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ModFrm.ascx.cs" Inherits="Admin_Modules_Mod_Controls_ModFrm" %>
<%@ Register Assembly="CKEditor.NET" Namespace="CKEditor.NET" TagPrefix="CKEditor" %>
<link rel="stylesheet" href="<%=sRootAppPath %>css/ADCStyle.css" type="text/css" />
<script type="text/javascript" src="/Scripts/jquery-1.7.1.min.js"></script>
<script type="text/javascript" src="/Scripts/ckeditor/ckeditor.js"></script>
<script type="text/javascript" src="/Scripts/ckfinder/ckfinder.js"></script>
<script>
    $(document).ready(function () {
        $("#ctl02_txtName").change(function () {
            // Chuyển hết sang chữ thường
            title = document.getElementById("ctl02_txtName").value;
            str = title.toLowerCase();
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
            $(".code").val(str);
            $(".url").val(str);
            return str;
        });
    });
    
</script>
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
				<td><asp:DropDownList ID="ddlGroup" Width="200" runat="server"></asp:DropDownList></td>
				<td>Định dạng</td>
				<td><asp:DropDownList ID="ddlModtype" runat="server" ClientIDMode="Static"></asp:DropDownList></td>				
			</tr>
            <tr id="dMtypePt" style="display:none">
                <td>Danh mục sản phẩm : </td>
				<td><asp:DropDownList ID="ddlModtypePt" Width="200" runat="server"></asp:DropDownList></td>
            </tr>
            
			    <tr class="typeNM">
    			    <td>Tên mục</td>
				    <td><asp:textbox id="txtName" CssClass="name"  Width="193" runat="server"></asp:textbox></td>
    			    <td>Mã mục</td>
				    <td><asp:textbox id="txtCode" Width="150" CssClass="code" runat="server"></asp:textbox></td>						
			    </tr>
                <tr class="typeNM">
    			    <td>URL</td>
				    <td colspan="3"><asp:textbox id="txtURL" CssClass="url" Width="460" runat="server"></asp:textbox></td>
			    </tr>			
			    <tr class="typeNM">
    			    <td>Keywords</td>
				    <td colspan="3"><asp:textbox id="txtKey" Width="460" runat="server"></asp:textbox></td>
			    </tr>
			    <tr class="typeNM">
    			    <td>Title page</td>
				    <td colspan="3"><asp:textbox id="txtTitle" Width="460" runat="server"></asp:textbox></td>
			    </tr>
			    <tr class="typeNM">
    			    <td>Descripton</td>
				    <td colspan="3"><asp:textbox id="txtDes" Width="460" runat="server"></asp:textbox></td>
			    </tr>
			    <tr class="typeNM"> 		                        			
		            <td>Ảnh</td>
		            <td colspan="3">
                        <asp:textbox id="txtImg" ClientIDMode="Static" Width="420" runat="server"></asp:textbox>
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
			         <CKEditor:CKEditorControl ID="CKTeaser" Height="270" CustomConfig="/Scripts/ckeditor/article.js" runat="server"></CKEditor:CKEditorControl>
                </td>
            </tr>            
		</table>
	</td>
</tr>
</table>

<script type="text/javascript">
    //function displayVals() {
    //    var modID = $("#ddlModtype").val();
    //    var modName = $('#ddlModtype option:selected').text();

    //    if (modID == 21 || modName == 'Shop') // product
    //    {
    //        $('#dMtypePt').show();
    //        $('.typeNM').hide();
    //    } else {
    //        $('#dMtypePt').hide();
    //        $('.typeNM').show();
    //    }
        
    //}

    $("select#ddlModtype").change(displayVals);
    displayVals();

    function BrowseServer(field) {
        var finder = new CKFinder();
        finder.selectActionFunction = function (fileUrl) {
            document.getElementById(field).value = fileUrl;
        };
        finder.popup();
    };

    
</script> 