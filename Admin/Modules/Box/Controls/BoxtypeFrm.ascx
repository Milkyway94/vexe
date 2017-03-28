<%@ Control Language="C#" AutoEventWireup="true" CodeFile="BoxtypeFrm.ascx.cs" Inherits="Admin_Modules_Box_Controls_BoxtypeFrm" %>
<link rel="stylesheet" href="<%=sRootAppPath %>css/ADCStyle.css" type="text/css">

<table id=toolbar cellspacing="0">
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

<table class="controlbox" width="100%">	
<tr>
	<td valign="top">
		<table class="fieldbox" width="100%" cellspacing="4">
			<tr>
    			<td>Tên loại Box</td>
				<td><asp:textbox id="txtName" Width="200px" runat="server"></asp:textbox></td>						
			</tr>			
			<tr> 		                        			
    			<td>Mã loại Box</td>
				<td><asp:textbox id="txtCode" Width="200px" runat="server"></asp:textbox></td>						
			</tr>		
			<tr> 		                        			
    			<td>Số Box hiển thị</td>
				<td><asp:textbox id="txtLimit" Width="40px" runat="server"></asp:textbox></td>						
			</tr>	
			<tr> 		                        			
    			<td></td>
				<td><asp:checkbox id="cbIsUse" runat="server"></asp:checkbox> Hiển thị</td>						
			</tr>
		</table>
	</td>
</tr>
</table>