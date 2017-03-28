<%@ Control Language="C#" AutoEventWireup="true" CodeFile="DepartFrm.ascx.cs" Inherits="Administrator_Modules_User_Controls_DepartFrm" %>
<link rel="stylesheet" href="<%=sRootAppPath %>css/ADCStyle.css" type="text/css" />
<table id="toolbar" cellspacing="0">
<tr> 
	<td style="width: 149px"> 
		<table cellspacing="0">
			<tr> 
				<td class="toolBarButton" id="btnCreate"><img src="<%=sRootAppPath %>Themes/save.png" align="absmiddle" width="16" height="20">&nbsp;<asp:LinkButton
                        ID="lbtUpdate" runat="server" OnClick="lbtUpdate_Click">Cập nhật</asp:LinkButton></td>
				<td class="toolBarButton" id="btnCancel" onclick="javascript:window.close();"><img src="<%=sRootAppPath %>Themes/cancel.gif" align="absmiddle" width="16" height="20">&nbsp;Huỷ bỏ</td>
			</tr>
		</table>
	</td>
</tr>
</table>

<table id="FrmUpdate" runat="server" class="fieldbox" width="100%" cellspacing="4">
    <tr>
        <td colspan="2"><asp:Label ID="lblMsg" runat="server" ForeColor="Red"></asp:Label></td>
    </tr>			
	<tr> 		                        			
		<td align="right" style="width: 140px;">Tên vai trò:&nbsp;</td>
		<td><asp:textbox id="txtName" Width="200px" runat="server"></asp:textbox></td>						
	</tr>			
	<tr> 		                        			
		<td align="right">Kích hoạt:&nbsp;</td>
		<td><asp:checkbox id="cbIsUse" runat="server"></asp:checkbox></td>						
	</tr>
</table>