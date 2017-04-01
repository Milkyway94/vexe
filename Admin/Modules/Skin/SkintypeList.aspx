<%@ Page Language="C#" AutoEventWireup="true" CodeFile="SkintypeList.aspx.cs" Inherits="SkintypeList" %>
<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title>Untitled Page</title>
    <script type="text/javascript" src="../../js/toolBarButton.js"></script>
	<script type="text/javascript" src="../../js/windowtracking.js"></script>
	<script type="text/javascript" src="../../js/Common.js"></script>
    <link rel="stylesheet" href="../../css/Style.css" type="text/css" /> 
</head>
<body style="background-color:White; overflow: hidden;" leftmargin="0" topmargin="0">
    <form id="form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server" />
    <div id="winVP" style="position: relative; height: 92%;">
        <table id="toolbar" cellspacing="0" style="display:block" border=0>
		    <tr>
			    <td> 
				    <table cellspacing="0">
					    <tr>
						    <td class="toolBarButton"><img alt="" src="<%=tp%>add.gif" align="absmiddle" /> <asp:HyperLink ID="hplAdd" runat="server">Thêm mới</asp:HyperLink></td>	
						    <td><img alt="" src="<%=tp%>line.gif" align="absmiddle" /></td>
						    <td class="toolBarButton"><img alt="" src="<%=tp%>delete.gif" align="absmiddle" /> <asp:LinkButton ID="lbtDelAll" runat="server" OnClick="lbtDelAll_Click">Xoá hết</asp:LinkButton></td>
						    <td><img alt="" src="<%=tp%>line.gif" align="absmiddle" /></td>						
					    </tr>
				    </table>
			    </td>
		    </tr>
	    </table>
	    <div style="width: 100%; height: 99%; overflow-y:auto; overflow-x:hidden;">
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>        
        <asp:UpdateProgress ID="UpdateProgress1" runat="server">
            <ProgressTemplate> 
                <img alt="" src="skin/loading.gif" />
           </ProgressTemplate>
        </asp:UpdateProgress>  
        <asp:GridView ID="gvData" runat="server" Width="100%" CellPadding="3" BackColor="White" BorderColor="#E7E7FF" BorderStyle="None" BorderWidth="1px" GridLines="Horizontal" PagerSettings-Mode="NumericFirstLast"
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
                
                <asp:TemplateField HeaderText="Vị trí hình" SortExpression="Skintype_Name">
                    <ItemTemplate>
                        <asp:HyperLink ID="hplName" runat="server"></asp:HyperLink>
                    </ItemTemplate>
                </asp:TemplateField>
                
                <asp:TemplateField HeaderText="Kiểu hiện thị">
                    <ItemTemplate>
                        <asp:HyperLink ID="hplType" runat="server"></asp:HyperLink>
                    </ItemTemplate>
                </asp:TemplateField>
                
                <asp:TemplateField HeaderText="Chiều rộng">
                    <ItemTemplate>
                        <asp:HyperLink ID="hplWidth" runat="server"></asp:HyperLink>
                    </ItemTemplate>
                </asp:TemplateField>
                
                <asp:TemplateField HeaderText="Chiều cao">
                    <ItemTemplate>
                        <asp:HyperLink ID="hplHeight" runat="server"></asp:HyperLink>
                    </ItemTemplate>
                </asp:TemplateField>
                
                <asp:TemplateField>
					<ItemStyle HorizontalAlign="Center" Width="50px"></ItemStyle>
					<HeaderTemplate>
						<asp:LinkButton id="lbtOrder01" Runat="server" ForeColor="#000000" Font-Underline="False" Text=""
							CommandName="Order01"><img alt="" src="<%=tp%>save.png" border="0" align="absmiddle"> Vị trí</asp:LinkButton>
					</HeaderTemplate>
					<ItemTemplate>
						<asp:TextBox id="txtOrder01" runat="server" Width="34px"></asp:TextBox>
                        &nbsp;
					</ItemTemplate>
				</asp:TemplateField>
				           
                <asp:TemplateField HeaderText="Tình trạng">
                    <HeaderStyle HorizontalAlign="Center" />
                    <ItemStyle HorizontalAlign="Center" Width="70px" />
                    <ItemTemplate>
                        <asp:ImageButton ID="imgUse" CommandName="isUse" runat="server" CommandArgument='<%# Eval("Skintype_ID") %>' />
                    </ItemTemplate>
                </asp:TemplateField>
                
                <asp:TemplateField HeaderText="Option">
                    <HeaderStyle HorizontalAlign="Center" />
                    <ItemStyle HorizontalAlign="Center" Width="60px" />
                    <ItemTemplate>
                        <asp:Image ID="imgEdit" CssClass="Img" runat="server" ImageUrl="../../Themes/edit.gif" />
                        &nbsp;&nbsp;&nbsp;
                        <asp:ImageButton ID="imgDel" CommandName="del" runat="server" CommandArgument='<%# Eval("Skintype_ID") %>' ImageUrl="../../Themes/delete.gif" />
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
        </ContentTemplate>
        </asp:UpdatePanel>
        </div>
    </div>
</form>
</body>
</html>