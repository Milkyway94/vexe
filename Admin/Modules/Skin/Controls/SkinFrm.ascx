<%@ Control Language="C#" AutoEventWireup="true" CodeFile="SkinFrm.ascx.cs" Inherits="Admin_Modules_Skin_Controls_SkinFrm" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc2" %>
<%@ Register Assembly="CKEditor.NET" Namespace="CKEditor.NET" TagPrefix="CKEditor" %>
<link rel="stylesheet" href="<%=sRootAppPath %>css/ADCStyle.css" type="text/css" />
<script type="text/javascript" src="/Scripts/jquery-1.7.1.min.js"></script>
<script type="text/javascript" src="/Scripts/ckeditor/ckeditor.js"></script>
<script type="text/javascript" src="/Scripts/ckfinder/ckfinder.js"></script>
<table id="toolbar" cellspacing="0">
<tr> 
	<td style="width: 149px"> 
		<table cellspacing="0">
			<tr> 
				<td class="toolBarButton"><img alt="" src="<%=sRootAppPath %>Themes/save.png" align="absmiddle" /> <asp:LinkButton ID="lbtUpdate" runat="server" OnClick="lbtUpdate_Click">Cập nhật</asp:LinkButton></td>
				<td class="toolBarButton" onclick="javascript:window.close();"><img alt="" src="<%=sRootAppPath %>Themes/cancel.gif" align="absmiddle" /> Huỷ bỏ</td>
			</tr>
		</table>
	</td>
</tr>
</table>
<table class="controlbox" width="100%">	
<tr> 
	<td valign="top">
		<table class="fieldbox" width="100%" cellspacing="4">	
		    <tr> 		                        			
    			<td>Tiêu đề</td>
				<td><asp:textbox id="txtName" runat="server" Width="410px"></asp:textbox></td>						
			</tr>	   
			<tr> 
				<td>Vị trí</td>
				<td><asp:DropDownList ID="ddlSkintype" Width="170px" runat="server"></asp:DropDownList>
				&nbsp;&nbsp;Module <asp:DropDownList ID="ddlMod" Width="200px" runat="server"></asp:DropDownList></td>
			</tr>
			<tr> 		                        			
    			<td>Skin file</td>
				<td>
                    <asp:textbox id="txtImg" ClientIDMode="Static" Width="345" runat="server"></asp:textbox>
                    <input id="browseServer" onclick="BrowseServer('txtImg');"  type="button" value="Tải ảnh" />
                </td>									
			</tr>
            <%--<tr> 		                        			
    			<td>Background</td>
				<td>
                    <asp:textbox id="txtBackground" ClientIDMode="Static" Width="345" runat="server"></asp:textbox>
                    <input id="Button1" onclick="BrowseServer('txtBackground');"  type="button" value="Tải ảnh" />
                </td>									
			</tr>--%>
			<tr> 		                        			
    			<td>Liên kết</td>
				<td><asp:textbox id="txtLink" runat="server" Width="410px"></asp:textbox></td>						
			</tr>
			<tr> 		                        			
	            <td>Chiều rộng:</td>
	            <td><asp:textbox id="txtWidth" Width="70px" runat="server"></asp:textbox> px - Chiều cao: <asp:textbox id="txtHeight" Width="70px" runat="server"></asp:textbox> px</td>						
            </tr>
			<tr> 		                        			
    			<td>STT</td>
				<td><asp:textbox id="txtPos" runat="server" Width="100px"></asp:textbox> 
				&nbsp;&nbsp;&nbsp;&nbsp;Hiển thị:&nbsp;<asp:checkbox id="cbIsUse" runat="server"></asp:checkbox></td>						
			</tr>
            <tr>
			    <td colspan="4">
			        <CKEditor:CKEditorControl ID="CKTeaser" Height="220" Width="100%" CustomConfig="/Scripts/ckeditor/article.js" runat="server" Toolbar="Source|Bold|Italic|Underline|Strike|Indent/Styles|Format|Font|FontSize|TextColor|BGColor"></CKEditor:CKEditorControl>
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