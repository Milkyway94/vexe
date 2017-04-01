<%@ Control Language="C#" AutoEventWireup="true" CodeFile="AddMod.ascx.cs" Inherits="Adadmin_Modules_Box_Controls_AddMod" %>
<link rel="stylesheet" href="<%=sRootAppPath %>css/Style.css" type="text/css">
<script type="text/javascript" src="<%=sRootAppPath %>js/TreeView.js"></script>
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
	    <div style="background:#ffffff; width: 300px; height: 288px; overflow-y:auto; overflow-x:hidden; border: solid 2px inset;">
            <div style="background-color:#CFCFCF; font-weight:bold; border-bottom:1px solid inset;">
                &nbsp;<input id="cbAll" type="checkbox" onclick="AllSelect(this)" /> Chọn tất
            </div>  
            <div>
                <asp:CheckBoxList ID="cblRight" runat="server"></asp:CheckBoxList>
            </div>
        </div>
	</td>
</tr>
</table>