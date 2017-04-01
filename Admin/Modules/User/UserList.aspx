<%@ Page Language="C#" AutoEventWireup="true" CodeFile="UserList.aspx.cs" Inherits="Admin_Modules_User_UserList" %>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Untitled Page</title>
    <script type="text/javascript" src="../../JS/toolBarButton.js"></script>
    <script type="text/javascript" src="../../JS/windowtracking.js"></script>
    <link rel="stylesheet" href="../../CSS/Style.css" type="text/css" />

    <script type="text/javascript" language="javascript">
        function PopupWin(url, w, h) {
            window.open(url, '_blank', 'resizable=yes,width=' + w + ',height=' + h + ',left=270,top=80,scrollbars=0,menubar=0,status=0,derectories=0,toolbar=0,location=0,resizable=0');
        }
        function AllSelect(theBox) {
            xState = theBox.checked;
            elm = theBox.form.elements;
            for (i = 0; i < elm.length; i++)
                if (elm[i].type == "checkbox" && elm[i].id != theBox.id) {
                    if (elm[i].checked != xState)
                        elm[i].click();
                }
        }
        function Search_Onclick(txt, objid) {
            var obj = document.getElementById(objid);
            if (window.event.keyCode == 13) {
                if (txt.value != '') { obj.click(); window.event.returnValue = false; }
            }
        }
        function viewit(id) {
            parent.frames["context"].document.location.replace("FileList.aspx?TopicID=" + id);
        }
    </script>
</head>
<body style="background-color: White; overflow: hidden;" leftmargin="0" topmargin="0">
    <form id="form1" runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server" />
        <div id="winVP" style="position: relative; height: 92%;">
            <table id="toolbar" cellspacing="0" style="display: block" border="0">
                <tr>
                    <td>
                        <table cellspacing="0">
                            <tr>
                                <td class="toolBarButton">
                                    <img alt="" src="<%=tp%>add.gif" align="absmiddle" />
                                    <asp:HyperLink ID="hplAddDepart" runat="server">Thêm vai trò</asp:HyperLink></td>
                                <td>
                                    <img src="<%=tp%>line.gif" align="absmiddle" alt="" /></td>

                                <td class="toolBarButton">
                                    <img alt="" src="<%=tp%>add.gif" align="absmiddle" />
                                    <asp:HyperLink ID="hplAdd" runat="server">Thêm user</asp:HyperLink></td>
                                <td>
                                    <img src="<%=tp%>line.gif" align="absmiddle" alt="" /></td>

                                <td class="toolBarButton">
                                    <img alt="" src="<%=tp%>delete.gif" align="absmiddle" />
                                    &nbsp;<asp:LinkButton ID="lbtDelAll" runat="server" OnClick="lbtDelAll_Click">Xoá hết</asp:LinkButton></td>
                                <td>
                                    <img src="<%=tp%>line.gif" align="absmiddle" /></td>
                                <td>
                                    <input type="text" name="txtFind" id="txtFind" value="" runat="server" style="width: 200;"></td>
                                <td class="toolBarButton" id="btnSearch">
                                    <img alt="" src="<%=tp%>search.gif" align="absmiddle" />&nbsp;
						    <asp:LinkButton ID="lbtSearch" runat="server" OnClick="lbtSearch_Click">Tìm kiếm</asp:LinkButton>
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
            </table>
            <div style="width: 100%; height: 99%; overflow-y: auto; overflow-x: hidden;">
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

                                <asp:TemplateField HeaderText="Họ tên" SortExpression="User_Name">
                                    <ItemTemplate>
                                        <asp:HyperLink ID="hplName" runat="server"></asp:HyperLink>
                                    </ItemTemplate>
                                </asp:TemplateField>

                                <asp:BoundField DataField="Username" HtmlEncode="False" HeaderText="Tên đăng nhập"></asp:BoundField>
                                <asp:BoundField DataField="User_Email" HtmlEncode="False" HeaderText="Email"></asp:BoundField>
                                <asp:BoundField DataField="User_Date" HtmlEncode="False" HeaderText="Ngày tạo" DataFormatString="{0:dd-MM-yyyy}"></asp:BoundField>
                                <asp:TemplateField HeaderText="Hệ thống" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" ItemStyle-Width="80px">
                                    <ItemTemplate>
                                        <asp:Image ID="AdminAccess" CssClass="Img" runat="server" ImageUrl="../../Themes/add-item.gif" />
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Module" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" ItemStyle-Width="80px">
                                    <ItemTemplate>
                                        <asp:Image ID="SiteAccess" CssClass="Img" runat="server" ImageUrl="../../Themes/add-item.gif" />
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <%-- <asp:TemplateField HeaderText="Role" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" ItemStyle-Width="80px">
                    <ItemTemplate>
                        <asp:Image ID="Role" CssClass="Img" runat="server" ImageUrl="../../Themes/add-item.gif" />                        
                    </ItemTemplate>
                </asp:TemplateField>  --%>

                                <asp:TemplateField HeaderText="Tình trạng">
                                    <HeaderStyle HorizontalAlign="Center" />
                                    <ItemStyle HorizontalAlign="Center" Width="70px" />
                                    <ItemTemplate>
                                        <asp:ImageButton ID="imgUse" CommandName="isUse" runat="server" CommandArgument='<%# Eval("User_ID") %>' />
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Gửi thông tin?">
                                    <HeaderStyle HorizontalAlign="Center" />
                                    <ItemStyle HorizontalAlign="Center" Width="70px" />
                                    <ItemTemplate>
                                        <asp:ImageButton ID="imgSent" CommandName="isSent" runat="server" CommandArgument='<%# Eval("User_ID") %>' />
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Option">
                                    <HeaderStyle HorizontalAlign="Center" />
                                    <ItemStyle HorizontalAlign="Center" Width="60px" />
                                    <ItemTemplate>
                                        <asp:Image ID="imgEdit" CssClass="Img" runat="server" ImageUrl="../../Themes/edit.gif" />
                                        &nbsp;&nbsp;&nbsp;
                        <asp:ImageButton ID="imgDel" CommandName="del" runat="server" CommandArgument='<%# Eval("User_ID") %>' ImageUrl="../../Themes/delete.gif" />
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
