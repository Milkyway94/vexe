<%@ Control Language="C#" AutoEventWireup="true" CodeFile="OtherFrm.ascx.cs" Inherits="Admin_Modules_Other_Controls_OtherFrm" %>
<%@ Register Assembly="CKEditor.NET" Namespace="CKEditor.NET" TagPrefix="CKEditor" %>
<link rel="stylesheet" href="<%=sRootAppPath %>css/ADCStyle.css" type="text/css" />
<script type="text/javascript" src="/Scripts/jquery-1.7.1.min.js"></script>
<script type="text/javascript" src="/Scripts/ckeditor/ckeditor.js"></script>
<table id="toolbar" cellspacing="0">
<tr> 
	<td style="width: 149px"> 
		<table cellspacing="0">
			<tr> 
				<td class="toolBarButton" id="btnCreate"><img src="<%=sRootAppPath %>Themes/save.png" align="absmiddle" alt="">&nbsp;<asp:LinkButton
                        ID="lbtUpdate" runat="server" OnClick="lbtUpdate_Click">Cập nhật</asp:LinkButton></td>
				<td class="toolBarButton" id="btnCancel" onclick="javascript:window.close();"><img src="<%=sRootAppPath %>Themes/cancel.gif" align="absmiddle" alt="">&nbsp;Huỷ bỏ</td>
			</tr>
		</table>
	</td>
</tr>
</table>
<table class="controlbox" width="100%" cellspacing="2" cellpadding="2">
    <tr> 		                        			
		<td>Tiêu đề</td>
		<td><asp:textbox id="txtName" Width="300" runat="server"></asp:textbox></td>
		<td>Mã</td>
		<td><asp:textbox id="txtMod" Width="300" runat="server"></asp:textbox></td>
	</tr>
    <tr>
        <td colspan="4">
            <CKEditor:CKEditorControl ID="CKContent" Height="270" CustomConfig="/Scripts/ckeditor/article.js" runat="server"></CKEditor:CKEditorControl>
            <asp:checkbox id="cbIsUse" runat="server"></asp:checkbox> kích hoạt
        </td>
    </tr>
</table>