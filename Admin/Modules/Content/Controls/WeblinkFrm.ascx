<%@ Control Language="C#" AutoEventWireup="true" CodeFile="WeblinkFrm.ascx.cs" Inherits="Admin_Modules_Content_Controls_WeblinkFrm" %>
<link rel="stylesheet" href="<%=sRootAppPath %>css/ADCStyle.css" type="text/css" />
<script type="text/javascript" src="/Scripts/jquery-1.7.1.min.js"></script>
<script type="text/javascript" src="/Scripts/ckfinder/ckfinder.js"></script>
<table id="toolbar" cellspacing="0">
<tr> 
	<td style="width: 149px"> 
		<table cellspacing="0">
			<tr> 
				<td class="toolBarButton" id="btnCreate"><img src="<%=sRootAppPath %>Themes/save.png" align="absmiddle" alt="" />&nbsp;<asp:LinkButton
                        ID="lbtUpdate" runat="server" OnClick="lbtUpdate_Click">Cập nhật</asp:LinkButton></td>
				<td class="toolBarButton" id="btnCancel" onclick="javascript:window.close();"><img src="<%=sRootAppPath %>Themes/cancel.gif" align="absmiddle" alt="" />&nbsp;Huỷ bỏ</td>
			</tr>
		</table>
	</td>
</tr>
</table>
<table class="controlbox" style="width:100%;padding:2px">	
    <tr> 		                        			
		<td style="width:100px;">Tiêu đề:</td><td><asp:textbox id="txtName" Width="200" runat="server"></asp:textbox>
		Đề mục:&nbsp;<asp:DropDownList ID="ddlModID" runat="server"></asp:DropDownList></td>						
	</tr>
	<tr> 		                        			
		<td style="width:100px;">Ảnh đại diện:</td><td>
            <asp:textbox id="txtImg" ClientIDMode="Static" Width="200" runat="server"></asp:textbox>
                <input id="browseServer" onclick="BrowseServer('txtImg');"  type="button" value="Tải ảnh" />
                 <script type="text/javascript">
                     function BrowseServer(field) {
                         var finder = new CKFinder();
                         finder.selectActionFunction = function (fileUrl) {
                             document.getElementById(field).value = fileUrl;
                         };
                         finder.popup();
                     }
                </script></td>
	</tr>	
	<tr> 		                        			
		<td style="width:100px;">Website</td><td><asp:textbox id="txtLink" Width="400" runat="server"></asp:textbox></td>
	</tr>								
	<tr>
	    <td>Vị trí:</td><td><asp:textbox id="txtPos" Width="100px" runat="server"></asp:textbox>
		<asp:checkbox id="cbIsUse" runat="server"></asp:checkbox> Hiển thị
		&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
		<asp:checkbox id="cbIsHot" runat="server"></asp:checkbox> Ưu tiên
		</td>						
	</tr>
</table>