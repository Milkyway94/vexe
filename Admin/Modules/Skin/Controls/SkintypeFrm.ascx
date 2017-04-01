<%@ Control Language="C#" AutoEventWireup="true" CodeFile="SkintypeFrm.ascx.cs" Inherits="Admin_Modules_Skin_Controls_SkintypeFrm" %>
<link rel="stylesheet" href="<%=sRootAppPath %>css/Style.css" type="text/css" />
<table id="toolbar" cellspacing="0">
<tr> 
	<td style="width:149px"> 
		<table cellspacing="0">
			<tr> 
				<td class="toolBarButton"><img src="<%=sRootAppPath %>Themes/save.png" align="absmiddle" /> <asp:LinkButton ID="lbtUpdate" runat="server" OnClick="lbtUpdate_Click">Cập nhật</asp:LinkButton></td>
				<td class="toolBarButton" onclick="javascript:window.close();"><img alt="" src="<%=sRootAppPath %>Themes/cancel.gif" align="absmiddle" /> Huỷ bỏ</td>
			</tr>
		</table>
	</td>
</tr>
</table>
<table class="controlbox" width="100%">	
<tr> 
	<td valign="top">
		<table width="100%">
		    <tr>
		        <td width="55%" valign="top">
		            <table class="fieldbox" width="100%" cellspacing="4">
			            <tr> 		                        			
    			            <td>Tiêu đề:</td>
				            <td><asp:textbox id="txtName" Width="150" runat="server"></asp:textbox>
                                <asp:RequiredFieldValidator ID="rvfName" runat="server" ControlToValidate="txtName"
                                    Display="Dynamic" ErrorMessage="*"></asp:RequiredFieldValidator></td>						
			            </tr>			
			            <tr> 		                        			
    			            <td>Mã loại:</td>
				            <td><asp:textbox id="txtCode" Width="150" runat="server"></asp:textbox>
                                <asp:RequiredFieldValidator ID="rvfCode" runat="server" ControlToValidate="txtCode"
                                    Display="Dynamic" ErrorMessage="*"></asp:RequiredFieldValidator></td>					
			            </tr>
			            <tr> 		                        			
    			            <td>Số lượng hiển thị:</td>
				            <td><asp:textbox id="txtLimit" Width="150" runat="server"></asp:textbox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtLimit"
                                    Display="Dynamic" ErrorMessage="*"></asp:RequiredFieldValidator></td>					
			            </tr>
			            <tr>
			                <td>Kiểu hiện thị:</td>
			                <td>
                                <asp:DropDownList ID="ddlViewtype" runat="server">
                                    <asp:ListItem Value="0">Hàng ngang</asp:ListItem>
                                    <asp:ListItem Value="1">Hàng dọc</asp:ListItem>
                                </asp:DropDownList>
                            </td>
			            </tr>		
		            </table>
		        </td>
		        <td valign="top">
		            <table class="fieldbox" width="100%" cellspacing="4">
			            <tr> 		                        			
    			            <td>Chiều rộng:</td>
				            <td style="height:26px;"><asp:textbox id="txtWidth" Width="70px" runat="server"></asp:textbox> px</td>						
			            </tr>			
			            <tr> 		                        			
    			            <td>Chiều cao:</td>
				            <td><asp:textbox id="txtHeight" Width="70px" runat="server"></asp:textbox> px</td>					
			            </tr>
			            <tr> 		                        			
    			            <td>Khoảng cách doc:</td>
				            <td><asp:textbox id="txtVspace" Width="70px" runat="server"></asp:textbox> px</td>					
			            </tr>
			            <tr> 		                        			
    			            <td>Khoảng cách ngang:</td>
				            <td><asp:textbox id="txtHspace" Width="70px" runat="server"></asp:textbox> px</td>					
			            </tr>
			            <tr>
			                <td>Kiểu liên kết</td>
			                <td>
                                <asp:DropDownList ID="ddlTarget" runat="server">
                                    <asp:ListItem Value="_none">_none</asp:ListItem>
                                    <asp:ListItem Value="_blank">_blank</asp:ListItem>
                                    <asp:ListItem Value="_parent">_parent</asp:ListItem>
                                    <asp:ListItem Value="_search">_search</asp:ListItem>
                                    <asp:ListItem Value="_self">_self</asp:ListItem>
                                </asp:DropDownList>
                            </td>
			            </tr>		
		            </table>
		        </td>
		    </tr>
		</table>
	</td>
</tr>
</table>