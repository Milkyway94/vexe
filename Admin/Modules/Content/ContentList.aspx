<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ContentList.aspx.cs" Inherits="Admin_Modules_Content_ContentList" %>
<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title>Untitled Page</title>
    <script type="text/javascript" src="../../JS/toolBarButton.js"></script>
	<script type="text/javascript" src="../../JS/windowtracking.js"></script>
    <link rel="stylesheet" href="../../CSS/Style.css" type="text/css" /> 
    <link href="../../css/bootstrap.min.css" rel="stylesheet" />
    <link href="/css/font-awesome.min.css" rel="stylesheet" />
    <script type="text/javascript">	
	function PopupWin(url,w,h)
    {
	    window.open(url, '_blank', 'resizable=yes,width='+w+',height='+h+',left=270,top=80,scrollbars=0,menubar=0,status=0,derectories=0,toolbar=0,location=0,resizable=0');
    }
    function AllSelect(theBox)
	{	
		xState=theBox.checked;    
        elm=theBox.form.elements;
        for(i=0;i<elm.length;i++)
        if(elm[i].type=="checkbox" && elm[i].id!=theBox.id)
        {
            if(elm[i].checked!=xState)
            elm[i].click();
        }
	}
    function Search_Onclick(txt , objid)
    {
	    var obj = document.getElementById(objid);	
	    if(window.event.keyCode == 13)
	    {
		    if(txt.value != '')	{ obj.click();window.event.returnValue = false; }
	    }
    }
    function viewit(id)
    {
        parent.frames["context"].document.location.replace("FileList.aspx?TopicID=" + id);
    }
    function LoadFile(p) {
        var b = parent.dhxLayout.cells("b");
        b.attachURL("ImagesList.aspx?p=" + p);
    }
	</script> 
</head>
<body style="background-color:White; overflow: hidden;" leftmargin="0" topmargin="0">
    <form id="form1" runat="server">
    <div id="winVP" style="position: relative; height: 92%;">
        <table id="toolbar" cellspacing="0" style="display:block" border=0>
		    <tr>
			    <td> 
				    <table cellspacing="0">
					    <tr>
						    <td class="toolBarButton"><i class="fa fa-plus"></i><asp:HyperLink ID="hplAdd" runat="server">Thêm mới</asp:HyperLink></td>	
						    <td><img src="<%=tp%>line.gif" align="absmiddle" /></td>
						    <td class="toolBarButton"><i class="fa fa-exclamation-triangle"></i><asp:HyperLink ID="hplHot" runat="server">Ưu tiên</asp:HyperLink></td>	
						    <%--<td><img src="<%=tp%>line.gif" align="absmiddle" /></td>
						    <td class="toolBarButton"><asp:HyperLink ID="hplHome" runat="server">Trang chủ</asp:HyperLink></td>	
						    <td><img src="<%=tp%>line.gif" align="absmiddle" /></td>
						    <td class="toolBarButton"><asp:HyperLink ID="hplRSS" runat="server">RSS</asp:HyperLink></td>	
						    <td><img src="<%=tp%>line.gif" align="absmiddle" /></td>
                            <td class="toolBarButton"><asp:HyperLink ID="hplShare" runat="server">Share</asp:HyperLink></td>	--%>
						    <td><img src="<%=tp%>line.gif" align="absmiddle" /></td>
						    <td class="toolBarButton"><i class="fa fa-trash-o"></i>
						        &nbsp;<asp:LinkButton ID="lbtDelAll" runat="server" OnClick="lbtDelAll_Click">Xoá hết</asp:LinkButton></td>
						    <td><img src="<%=tp%>line.gif" align="absmiddle" /></td>						
						    <td><input type="text" name="txtFind" id="txtFind" value="" runat="server" style="width:200px;"></td>
						    <td class="toolBarButton"><i class="fa fa-search"></i>
						    <asp:LinkButton ID="lbtSearch" runat="server" OnClick="lbtSearch_Click">Tìm kiếm</asp:LinkButton>	
						    </td>
					    </tr>
				    </table>
			    </td>
		    </tr>
	    </table>
	    <div style="width: 100%; height: 99%; overflow-y:auto; overflow-x:hidden;">
        <asp:GridView ID="gvData" runat="server" CssClass="table table-stripped table-hover" GridLines="Horizontal" PagerSettings-Mode="NumericFirstLast"
            AutoGenerateColumns="False" AllowPaging="True" AllowSorting="True" EmptyDataText="Chưa có dữ liệu." OnRowCommand="gvData_RowCommand" OnRowDataBound="gvData_RowDataBound" ShowFooter="True" OnPageIndexChanging="gvData_PageIndexChanging" OnSorting="gvData_Sorting" PageSize="50" OnRowCreated="gvData_RowCreated">
            <Columns>                
                <asp:TemplateField HeaderText="Check">
                    <HeaderTemplate>
                        <input id="cbAll" type="checkbox" onclick="AllSelect(this)" />
                    </HeaderTemplate>
                    <ItemTemplate>
                        <asp:CheckBox ID="cbItem" runat="server" />
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Tiêu đề" SortExpression="Content_Name">
                    <ItemTemplate>
                        <asp:HyperLink ID="hplName" runat="server"></asp:HyperLink>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:BoundField DataField="Content_Date" DataFormatString = "{0:dd-MM-yyyy}" HtmlEncode="False" HeaderText="Ngày đăng" SortExpression="Content_Date"></asp:BoundField>
                <asp:TemplateField HeaderText="Lượt xem" SortExpression="Content_Count">
                    <ItemTemplate>
                        <asp:HyperLink ID="hplView" runat="server"></asp:HyperLink>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField>
					<ItemStyle HorizontalAlign="Center" Width="50px"></ItemStyle>
					<HeaderTemplate>
						<asp:LinkButton id="lbtOrder01" Runat="server" ForeColor="#000000" Font-Underline="False" Text=""
							CommandName="Order01"><i class="fa fa-save"></i>Vị trí</asp:LinkButton>
					</HeaderTemplate>
					<ItemTemplate>
						<asp:TextBox id="txtOrder01" runat="server" Width="34px"></asp:TextBox>
                        &nbsp;
					</ItemTemplate>
				</asp:TemplateField>
				           
                <%--<asp:TemplateField HeaderText="Avatar">
                    <HeaderStyle HorizontalAlign="Center" />
                    <ItemStyle HorizontalAlign="Center" Width="70px" />
                    <ItemTemplate>
                        <asp:Image ID="imgDisplay" runat="server" CssClass="img" />
                    </ItemTemplate>
                </asp:TemplateField>  --%>
                
                <asp:TemplateField HeaderText="Tình trạng">
                    <HeaderStyle HorizontalAlign="Center" />
                    <ItemStyle HorizontalAlign="Center" Width="70px" />
                    <ItemTemplate>
                        <asp:ImageButton ID="imgUse" CommandName="isUse" runat="server" CommandArgument='<%# Eval("Content_ID") %>' />
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Ưu tiên">
                    <HeaderStyle HorizontalAlign="Center" />
                    <ItemStyle HorizontalAlign="Center" Width="70px" />
                    <ItemTemplate>
                        <asp:ImageButton ID="imgHot" CommandName="isHot" runat="server" CommandArgument='<%# Eval("Content_ID") %>' />
                    </ItemTemplate>
                </asp:TemplateField>
                <%--<asp:TemplateField HeaderText="Images" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" ItemStyle-Width="70px">
                    <ItemTemplate>
                        <asp:Image ID="imgAddPic" runat="server" CssClass="img" />
                    </ItemTemplate>
                </asp:TemplateField> --%>
                <asp:TemplateField HeaderText="Tùy chọn">
                    <HeaderStyle HorizontalAlign="Center" />
                    <ItemStyle HorizontalAlign="Center" Width="90px" />
                    <ItemTemplate>
                        <%--<asp:Image ID="imgShare" CssClass="Img" runat="server" ImageUrl="../../Themes/share-icon.png" />--%>
                        
                        <asp:Image ID="imgEdit" CssClass="Img" runat="server" ImageUrl="../../Themes/edit.gif" />
                        &nbsp;&nbsp;&nbsp;
                        <asp:ImageButton ID="imgDel" CommandName="del" runat="server" CommandArgument='<%# Eval("Content_ID") %>' ImageUrl="../../Themes/delete.gif" />
                    </ItemTemplate>
                </asp:TemplateField>
                </Columns>
                <PagerStyle HorizontalAlign="Center" CssClass="cssPager" BackColor="#E7E7FF" ForeColor="#4A3C8C" />
                <FooterStyle BackColor="#B5C7DE" ForeColor="#4A3C8C" />
                <SelectedRowStyle BackColor="#738A9C" Font-Bold="True" ForeColor="#F7F7F7" />
                <AlternatingRowStyle BackColor="#F7F7F7" />
                <RowStyle BackColor="#F7F7FF" ForeColor="#4A3C8C" />
                <HeaderStyle BackColor="#E1F0F5" Font-Bold="True" ForeColor="Black" Font-Size="11px" HorizontalAlign="Left" />
                <PagerSettings Mode="NumericFirstLast" />
        </asp:GridView>

        <asp:GridView ID="gvRaovat" runat="server" Width="100%" CellPadding="3" BackColor="White" BorderColor="#E7E7FF" BorderStyle="None" BorderWidth="1px" GridLines="Horizontal" PagerSettings-Mode="NumericFirstLast"
            AutoGenerateColumns="False" AllowPaging="True" AllowSorting="True" EmptyDataText="Chưa có dữ liệu." OnRowCommand="gvRaovat_RowCommand" OnRowDataBound="gvRaovat_RowDataBound" ShowFooter="True" OnPageIndexChanging="gvRaovat_PageIndexChanging" OnSorting="gvRaovat_Sorting" PageSize="50" OnRowCreated="gvRaovat_RowCreated">
            <Columns>                
                <asp:TemplateField HeaderText="Check">
                    <HeaderTemplate>
                        <input id="cbAll" type="checkbox" onclick="AllSelect(this)" />
                    </HeaderTemplate>
                    <ItemTemplate>
                        <asp:CheckBox ID="cbItem" runat="server" />
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:BoundField DataField="Raovat_Title" HeaderText="Tiêu để" SortExpression="Raovat_Title"></asp:BoundField>
                <asp:BoundField DataField="Raovat_Date" DataFormatString = "{0:dd-MM-yyyy}" HtmlEncode="False" HeaderText="Ngày đăng" SortExpression="Raovat_Date"></asp:BoundField>
                <asp:BoundField DataField="Raovat_Count" HeaderText="Lượt xem" SortExpression="Raovat_Count"></asp:BoundField>
                <asp:TemplateField HeaderText="Ảnh">
                    <HeaderStyle HorizontalAlign="Center" />
                    <ItemStyle HorizontalAlign="Center" Width="70px" />
                    <ItemTemplate>
                        <asp:Image ID="imgDisplay" runat="server" CssClass="img" />
                    </ItemTemplate>
                </asp:TemplateField>
                
                <asp:TemplateField HeaderText="Tình trạng">
                    <HeaderStyle HorizontalAlign="Center" />
                    <ItemStyle HorizontalAlign="Center" Width="70px" />
                    <ItemTemplate>
                        <asp:ImageButton ID="imgUse" CommandName="isUse" runat="server" CommandArgument='<%# Eval("Raovat_ID") %>' />
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="VIP1">
                    <HeaderStyle HorizontalAlign="Center" />
                    <ItemStyle HorizontalAlign="Center" Width="70px" />
                    <ItemTemplate>
                        <asp:ImageButton ID="imgVIP1" CommandName="isVIP1" runat="server" CommandArgument='<%# Eval("Raovat_ID") %>' />
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="VIP2">
                    <HeaderStyle HorizontalAlign="Center" />
                    <ItemStyle HorizontalAlign="Center" Width="70px" />
                    <ItemTemplate>
                        <asp:ImageButton ID="imgVIP2" CommandName="isVIP2" runat="server" CommandArgument='<%# Eval("Raovat_ID") %>' />
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Option">
                    <HeaderStyle HorizontalAlign="Center" />
                    <ItemStyle HorizontalAlign="Center" Width="60px" />
                    <ItemTemplate>
                        <asp:Image ID="imgEdit" CssClass="Img" runat="server" ImageUrl="../../Themes/edit.gif" />
                        &nbsp;&nbsp;&nbsp;
                        <asp:ImageButton ID="imgDel" CommandName="del" runat="server" CommandArgument='<%# Eval("Raovat_ID") %>' ImageUrl="../../Themes/delete.gif" />
                    </ItemTemplate>
                </asp:TemplateField>
                </Columns>
                <PagerStyle HorizontalAlign="Center" CssClass="cssPager" BackColor="#E7E7FF" ForeColor="#4A3C8C" />
                <FooterStyle BackColor="#B5C7DE" ForeColor="#4A3C8C" />
                <SelectedRowStyle BackColor="#738A9C" Font-Bold="True" ForeColor="#F7F7F7" />
                <AlternatingRowStyle BackColor="#F7F7F7" />
                <RowStyle BackColor="#F7F7FF" ForeColor="#4A3C8C" />
                <HeaderStyle BackColor="#E1F0F5" Font-Bold="True" ForeColor="Black" Font-Size="11px" HorizontalAlign="Left" />
                <PagerSettings Mode="NumericFirstLast" />
        </asp:GridView>
        </div>
    </div>
</form>
</body>
</html>