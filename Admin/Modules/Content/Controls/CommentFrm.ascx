<%@ Control Language="C#" AutoEventWireup="true" CodeFile="CommentFrm.ascx.cs" Inherits="Admin_Modules_Comment_Controls_CommentFrm" %>
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
				<td class="toolBarButton"><img src="<%=sRootAppPath %>Themes/save.png" align="absmiddle" width="16" height="20">&nbsp;<asp:LinkButton
                        ID="lbtUpdate" runat="server" OnClick="lbtUpdate_Click">Cập nhật</asp:LinkButton></td>
				<td class="toolBarButton" onclick="javascript:window.close();"><img src="<%=sRootAppPath %>Themes/cancel.gif" align="absmiddle" width="16" height="20">&nbsp;Huỷ bỏ</td>
			</tr>
		</table>
	</td>
</tr>
</table>
<table class="controlbox" width="100%" cellspacing="2" cellpadding="2">
    <tr> 		                        			
		<td style="width:130px;">Tiêu đề</td>
		<td colspan="3"><asp:textbox id="txtTitle" Width="600px" runat="server"></asp:textbox></td>
	</tr>
     <tr> 		                        			
		<td>Họ tên</td>
		<td><asp:textbox id="txtName" Width="200px" runat="server"></asp:textbox></td>
		<td>Địa chỉ</td>
		<td><asp:textbox id="txtAddress" Width="200px" runat="server"></asp:textbox></td>
	</tr>
     <tr> 		                        			
		<td style="width:130px;">Email</td>
		<td><asp:textbox id="txtEmail" Width="200px" runat="server"></asp:textbox></td>
		<td style="width:130px;">Điện thoại</td>
		<td><asp:textbox id="txtTel" Width="200px" runat="server"></asp:textbox></td>
	</tr>
	<tr> 		                        			
		<td>Vị trí:&nbsp;</td>
		<td colspan="3">
		    <asp:textbox id="txtPos" Width="160px" runat="server"></asp:textbox>
		    <asp:checkbox id="cbIsUse" runat="server"></asp:checkbox> Hoạt động
		</td>						
	</tr>		
    <tr>
        <td colspan="4">
            <CKEditor:CKEditorControl ID="CKContent" Height="300" CustomConfig="/Scripts/ckeditor/article.js" runat="server"></CKEditor:CKEditorControl>
        </td>
    </tr>
</table>