<%@ Control Language="C#" AutoEventWireup="true" CodeFile="VideoFrm.ascx.cs" Inherits="Admin_Modules_Content_Controls_WeblinkFrm" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc2" %>
<%@ Register Assembly="CKEditor.NET" Namespace="CKEditor.NET" TagPrefix="CKEditor" %>
<link rel="stylesheet" href="<%=sRootAppPath %>css/Style.css" type="text/css" />
<script type="text/javascript" src="/Scripts/jquery-1.7.1.min.js"></script>
<script type="text/javascript" src="/Scripts/ckeditor/ckeditor.js"></script>
<script type="text/javascript" src="/Scripts/ckfinder/ckfinder.js"></script>
<table id="toolbar" cellspacing="0">
<tr> 
	<td style="width: 149px"> 
		<table cellspacing="0">
			<tr> 
				<td class="toolBarButton"><img src="<%=sRootAppPath %>Themes/save.png" align="absmiddle" alt="" /> <asp:LinkButton
                        ID="lbtUpdate" runat="server" OnClick="lbtUpdate_Click">Cập nhật</asp:LinkButton></td>
				<td class="toolBarButton" onclick="javascript:window.close();"><img src="<%=sRootAppPath %>Themes/cancel.gif" align="absmiddle" alt="" /> Huỷ bỏ</td>
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
    			<td style="width:120px;">Tiêu đề:</td><td><asp:textbox id="txtName" Width="420" runat="server"></asp:textbox></td>
            </tr>
            <tr> 		                        			
    			<td>URL:</td><td><asp:textbox id="txtUrl" Width="420" runat="server"></asp:textbox></td>
            </tr>
			<tr> 
    			<td>Đề mục:</td><td><asp:DropDownList ID="ddlModID" runat="server"></asp:DropDownList></td>						
			</tr>
			<tr> 		                        			
    			<td>Đường dẫn:</td>
                <td>
                    <asp:textbox id="txtCode" ClientIDMode="Static" Width="440px" runat="server"></asp:textbox>
                    <input id="browseServer" onclick="BrowseServer('txtCode');"  type="button" value="Tải ảnh" />
                </td>
			</tr>
			<tr> 		                        			
    			<td>Ảnh đại diện:</td>
                <td>
                    <asp:textbox id="txtImg" ClientIDMode="Static" Width="440px" runat="server"></asp:textbox>
                    <input id="browseServerImg" onclick="BrowseServer('txtImg');"  type="button" value="Tải ảnh" />
                </td>
			</tr>
            <tr>
		        <td>Title page</td><td><asp:textbox id="txtTitle" Width="420" runat="server"></asp:textbox></td>
	        </tr>
	        <tr>
		        <td>Keywords</td><td><asp:textbox id="txtKey" Width="420" runat="server"></asp:textbox></td>
	        </tr>
	        <tr>
		        <td>Meta descripton</td><td><asp:textbox id="txtDes" Width="420" runat="server"></asp:textbox></td>
	        </tr>
            <%--<tr>
		        <td>Tags</td><td><asp:textbox id="txtTag" Width="420" runat="server"></asp:textbox></td>
	        </tr>	--%>						
			<tr>
			    <td>Vị trí:</td><td><asp:textbox id="txtPos" Width="100px" runat="server"></asp:textbox>
				<asp:checkbox id="cbIsUse" runat="server"></asp:checkbox> Kích hoạt
				&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
				<asp:checkbox id="cbIsHot" runat="server"></asp:checkbox> Ưu tiên
				</td>						
			</tr>
        </table>
	</td>
</tr>
</table>
<script type="text/javascript">
    function BrowseServer(field) {
        var finder = new CKFinder();
        finder.selectActionFunction = function (fileUrl) {
            document.getElementById(field).value = fileUrl;
        };
        finder.popup();
    }
</script>