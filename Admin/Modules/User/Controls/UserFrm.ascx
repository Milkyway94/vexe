<%@ Control Language="C#" AutoEventWireup="true" CodeFile="UserFrm.ascx.cs" Inherits="Administrator_Modules_User_Controls_UserFrm" %>
<link rel="stylesheet" href="<%=sRootAppPath %>css/Style.css" type="text/css" />
<script type="text/javascript" src="/Scripts/jquery-1.7.1.min.js"></script>
<script type="text/javascript" src="/Scripts/ckfinder/ckfinder.js"></script>
<table id="toolbar" cellspacing="0">
<tr> 
	<td style="width:149px;"> 
		<table cellspacing="0">
			<tr> 
				<td class="toolBarButton" id=btnCreate><img alt="" src="<%=sRootAppPath %>Themes/save.png" align="absmiddle" /> <asp:LinkButton ID="lbtUpdate" runat="server" OnClick="lbtUpdate_Click">Cập nhật</asp:LinkButton></td>
				<td class="toolBarButton" id=btnCancel onclick="javascript:window.close();"><img alt="" src="<%=sRootAppPath %>Themes/cancel.gif" align="absmiddle" /> Huỷ bỏ</td>
			</tr>
		</table>
	</td>
</tr>
</table>

<table width="100%" cellspacing="2">
    <tr>
        <td colSpan="2"><asp:Label ID="lblMsg" runat="server" ForeColor="Red"></asp:Label></td>
    </tr>
	<tr> 
		<td style="width: 140px"><nobr>Phòng ban</nobr></td>
		<td><asp:DropDownList ID="ddlPb" runat="server"></asp:DropDownList></td>
	</tr>
	<tr> 		                        			
		<td>Tên đăng nhập</td>
		<td><asp:textbox id="txtUser" Width="200px" runat="server"></asp:textbox><img src="<%=sRootAppPath %>Images/Icons/button_security.gif" align="absmiddle"></td>						
	</tr>
	<tr> 		                        			
		<td>Email</td>
		<td><asp:textbox id="txtEmail" Width="200px" runat="server"></asp:textbox></td>						
	</tr>			
	<tr> 		                        			
		<td>Mật khẩu</td>
		<td><asp:textbox id="txtPass" runat="server" TextMode="Password"></asp:textbox></td>						
	</tr>
	<tr> 		                        			
		<td>Họ Tên</td>
		<td><asp:textbox id="txtName" Width="200px" runat="server"></asp:textbox></td>						
	</tr>
	<tr> 		                        			
		<td>Giới tính</td>
		<td><asp:radiobuttonlist id="rbSex" Width="128px" runat="server" RepeatDirection="Horizontal">
	            <asp:ListItem Value="1" Selected="True">Nam</asp:ListItem>
	            <asp:ListItem Value="0">Nữ</asp:ListItem>
            </asp:radiobuttonlist></td>						
	</tr>
	<tr> 		                        			
		<td>Điện thoại</td>
		<td><asp:textbox id="txtTel" runat="server"></asp:textbox></td>						
	</tr>
	<tr> 		                        			
		<td>Mobile</td>
		<td><asp:textbox id="txtMobile" runat="server"></asp:textbox></td>						
	</tr>
	<tr> 		                        			
		<td>Địa chỉ</td>
		<td><asp:textbox id="txtAddress" Width="288px" runat="server"></asp:textbox></td>						
	</tr>
	<tr> 		                        			
		<td>Thông tin liên hệ</td>
		<td><asp:textbox id="txtInfo" Width="288px" runat="server" TextMode="MultiLine" Height="80px"></asp:textbox></td>						
	</tr>
    <tr> 		                        			
		<td>Ảnh</td>
		<td>
            <asp:textbox id="txtImg" ClientIDMode="Static" Width="339" runat="server"></asp:textbox>
            <input id="browseServer" onclick="BrowseServer('txtImg');"  type="button" value="Tải ảnh" />
                <script type="text/javascript">
                    function BrowseServer(field) {
                        var finder = new CKFinder();
                        finder.selectActionFunction = function (fileUrl) {
                            document.getElementById(field).value = fileUrl;
                        };
                        finder.popup();
                    }
            </script>
		</td>									
	</tr>
	<tr>
		<td style="width: 140px">Thứ tự hiển thị</td>
		<td><asp:textbox id="txtOrder" Width="49px" runat="server"></asp:textbox> (Chỉ nhập số)</td>
	</tr>
	<tr> 		                        			
		<td>Cho phép hoạt động</td>
		<td><asp:checkbox id="cbIsUse" runat="server"></asp:checkbox></td>
	</tr>
    <tr> 		                      			
		<td>Vai trò</td>
		<td><asp:DropDownList ID="dllRole" runat="server"></asp:DropDownList>  </td>
	</tr>
</table>