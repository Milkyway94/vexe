<%@ Control Language="C#" AutoEventWireup="true" CodeFile="FunFrm.ascx.cs" Inherits="Function_FunFrm" %>
<link rel="stylesheet" href="<%=sRootAppPath %>css/Style.css" type="text/css" />
<table id="toolbar" cellspacing="0">
    <tr> 
	    <td style="width:149px"> 
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
		<fieldset> 
		<legend>Chi tiết:</legend>
		<table class="fieldbox" width="100%" cellspacing="4">		   
			<tr> 
				<td style="width: 146px">Nhóm chức năng:</td>
				<td><asp:DropDownList ID="ddlGroup" runat="server"></asp:DropDownList></td>
			</tr>
			<tr> 		                        			
    			<td>Tên chức năng: </td>
				<td><asp:textbox id="txtName" runat="server" Width="289px"></asp:textbox></td>						
			</tr>	
			<tr> 		                        			
    			<td>Đường dẫn: </td>
				<td><asp:textbox id="txtPath" runat="server" Width="289px">Modules/</asp:textbox></td>						
			</tr>					
			<tr> 		                        			
    			<td>Mô tả chức năng: </td>
				<td><asp:textbox id="txtInfo" Width="288px" runat="server" TextMode="MultiLine" Height="80px"></asp:textbox></td>						
			</tr>
			<tr> 		                        			
    			<td>Vị trí</td>
				<td><asp:textbox id="txtPos" runat="server" Width="100px"></asp:textbox> &nbsp;&nbsp;Cho phép hoạt động: <asp:checkbox id="cbIsUse" runat="server"></asp:checkbox></td>						
                <td>Biểu tượng</td>
				<td><asp:textbox id="txtIcon" runat="server" Width="100px"></asp:textbox></td>						
			</tr>			
		</table>
		</fieldset>
	</td>
</tr>
</table>