<%@ Control Language="C#" AutoEventWireup="true" CodeFile="SiteAccess.ascx.cs" Inherits="Administrator_Modules_Member_Controls_SiteAccess" %>
<link rel="stylesheet" href="<%=sRootAppPath %>css/ADCStyle.css" type="text/css" />
<script type="text/javascript" src="<%=sRootAppPath %>js/TreeView.js"></script>
<script type="text/javascript" src="<%=sRootAppPath %>js/toolBarButton.js"></script>

<table id=toolbar cellspacing="0">
<tr> 
	<td style="width: 149px"> 
		<table cellspacing="0">
			<tr> 
				<td class="toolBarButton" id="btnCreate"><img alt="" src="<%=sRootAppPath %>Themes/save.png" align="absmiddle" /> <asp:LinkButton ID="lbtUpdate" runat="server" OnClick="lbtUpdate_Click">Cập nhật</asp:LinkButton></td>
				<td class="toolBarButton" id="btnCancel" onclick="javascript:window.close();"><img alt="" src="<%=sRootAppPath %>Themes/cancel.gif" align="absmiddle" /> Huỷ bỏ</td>
			</tr>
		</table>
	</td>
</tr>
</table>

<table class="controlbox" width="100%">	
<tr> 
	<td valign="top">		
	    <div style="background:#ffffff; width:395px; height:300px; overflow-y:auto; overflow-x:hidden; border: solid 2px inset;">
            <div style="background-color:#CFCFCF; font-weight:bold; border-bottom:1px solid inset;">
                &nbsp;<input id="cbAll" type="checkbox" onclick="AllSelect(this)" /> Chọn tất
            </div>  
            <div>
                <asp:TreeView ID="TreeView1" ExpandDepth="2" ShowLines="true" ShowExpandCollapse="true" runat="server" 
                OnTreeNodePopulate="TreeView1_TreeNodePopulate" ShowCheckBoxes="All" PopulateNodesFromClient="False"></asp:TreeView>
            </div>
        </div>
	</td>
</tr>
</table>