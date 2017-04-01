<%@ Page Language="C#" AutoEventWireup="true" CodeFile="MemberList.aspx.cs" Inherits="Admin_Modules_Member_MemberList" %>
<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title>Untitled Page</title>
    <script type="text/javascript" src="../../js/toolBarButton.js"></script>
	<script type="text/javascript" src="../../js/windowtracking.js"></script>
	<script type="text/javascript" src="../../js/Common.js"></script>
    <link rel="stylesheet" href="../../CSS/Style.css" type="text/css" /> 
    <script type="text/javascript">
    function processClick(id)
    {	
	    var b = parent.dhxLayout.cells("b");
        b.attachURL("MemberView.aspx?id="+id);
    }
</script>
</head>
<body style="background-color:White; overflow: hidden;" leftmargin="0" topmargin="0">
    <form id="frmMember" runat="server">
        <div id="winVP" style="position: relative; height: 92%;">
            
            <table id="toolbar" cellspacing="0" style="display:block" border=0>
		        <tr>
			        <td> 
				        <table cellspacing="0">
					        <tr>
						        <td><asp:Button ID="btntoExcel" runat="server" Text="Export to Excel" onclick="btntoExcel_Click" /></td>	
						        <%--<td><img alt="" src="<%=tp%>line.gif" align="absmiddle" /></td>
						        <td class="toolBarButton"><img alt="" src="<%=tp%>delete.gif" align="absmiddle" /> <asp:LinkButton ID="lbtDelAll" runat="server" OnClick="lbtDelAll_Click">Xoá hết</asp:LinkButton></td>
						        <td><img alt="" src="<%=tp%>line.gif" align="absmiddle" /></td>						
						        <td><input type="text" name="txtFind" id="txtFind" value="" runat="server" style="width:200;"></td>
						        <td class="toolBarButton"><img alt="" src="<%=tp%>search.gif" align="absmiddle" /> <asp:LinkButton ID="lbtSearch" runat="server" OnClick="lbtSearch_Click">Tìm kiếm</asp:LinkButton>	
						        </td>--%>
					        </tr>
				        </table>
			        </td>
		        </tr>
	        </table>
	        <div style="width: 100%; height: 99%; overflow-y:auto; overflow-x:hidden;">
                <asp:GridView ID="gvMember" runat="server" Width="100%"></asp:GridView>
            </div>
        </div>
    </form>
</body>
</html>