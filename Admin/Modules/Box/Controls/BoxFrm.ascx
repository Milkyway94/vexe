<%@ Control Language="C#" AutoEventWireup="true" CodeFile="BoxFrm.ascx.cs" Inherits="Admin_Modules_Box_Controls_BoxFrm" %>
<link rel="stylesheet" href="<%=sRootAppPath %>css/Style.css" type="text/css" />
<script type="text/javascript" src="/Scripts/jquery-1.7.1.min.js"></script>
<script type="text/javascript" src="/Scripts/ckfinder/ckfinder.js"></script>
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

<table class="controlbox" width="100%">	
<tr> 
	<td valign="top">
		<table class="fieldbox" width="100%" cellspacing="2">
			<tr> 		                        			
    			<td style="width:120px;">Tên Box</td>
				<td><asp:textbox id="txtName" Width="200px" runat="server"></asp:textbox></td>						
			</tr>
			<tr> 		                        			
    			<td>Mã Box</td>
				<td><asp:textbox id="txtCode" Width="200px" runat="server"></asp:textbox></td>						
			</tr>
			<tr> 		                        			
    			<td>Loại Box</td>
				<td><asp:DropDownList ID="ddlBoxtype" runat="server"></asp:DropDownList></td>						
			</tr>
			<tr> 		                        			
    			<td>Số thứ tự:&nbsp;</td>
				<td><asp:textbox id="txtPos" Width="60px" runat="server"></asp:textbox>
				&nbsp;&nbsp;&nbsp;&nbsp;
				<asp:checkbox id="cbIsUse" runat="server"></asp:checkbox> Hiển thị</td>						
			</tr>
			<tr> 		                        			
    			<td>Ảnh</td>
				<td><asp:textbox id="txtImg" ClientIDMode="Static" Width="650" runat="server"></asp:textbox>
            <input id="browseServer" onclick="BrowseServer('txtImg');"  type="button" value="Tải ảnh" />
             <script type="text/javascript">
                 function BrowseServer(field) {
                     var finder = new CKFinder();
                     finder.selectActionFunction = function (fileUrl) {
                         document.getElementById(field).value = fileUrl;
                     };
                     finder.popup();
                 }
            </script> </td>						
			</tr>			
		</table>
	</td>
</tr>
</table>