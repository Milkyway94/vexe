<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ModtypeFrm.ascx.cs" Inherits="Admin_Modules_Mod_Controls_ModtypeFrm" %>
<link rel="stylesheet" href="<%=sRootAppPath %>css/ADCStyle.css" type="text/css">
<table id="toolbar" cellspacing="0">
<tr> 
	<td style="width: 149px"> 
		<table cellspacing="0">
			<tr> 
				<td class="toolBarButton" id="btnCreate">
				    <img alt="" src="<%=sRootAppPath %>Themes/save.png" align="absmiddle" /> <asp:LinkButton ID="lbtUpdate" runat="server" OnClick="lbtUpdate_Click">Cập nhật</asp:LinkButton></td>
				<td class="toolBarButton" id="btnCancel" onclick="javascript:window.close();">
				    <img alt="" src="<%=sRootAppPath %>Themes/cancel.gif" align="absmiddle" /> Huỷ bỏ
                </td>
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
    			<td>Tên định dạng</td>
				<td><asp:textbox id="txtName" Width="200px" runat="server"></asp:textbox></td>						
			</tr>			
			<tr> 		                        			
    			<td>Mã định dạng</td>
				<td><asp:textbox id="txtCode" Width="200px" runat="server"></asp:textbox></td>						
			</tr>											
			<tr> 		                        			
    			<td></td>
				<td><asp:checkbox id="cbIsUse" runat="server"></asp:checkbox> Hoạt động</td>						
			</tr>
		</table>
	</td>
</tr>
</table>