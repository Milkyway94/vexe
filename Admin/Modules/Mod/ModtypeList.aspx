<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Admin/ChildPage.master" CodeFile="ModtypeList.aspx.cs" Inherits="Mod_ModtypeList" %>
<asp:Content ContentPlaceHolderID="head" runat="server">
    <link href="../../css/bootstrap.min.css" rel="stylesheet" />
</asp:Content>
<asp:Content ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server" />
    <div id="winVP" style="position: relative; height: 92%;">
        <table id="toolbar" cellspacing="0" style="display: block" border="0">
            <tr>
                <td>
                    <table cellspacing="0">
                        <tr>
                            <td class="toolBarButton">
                                <img alt="" src="<%=tp%>add.gif" align="absmiddle">&nbsp;<asp:HyperLink ID="hplAdd" runat="server">Thêm mới</asp:HyperLink></td>
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
                    <asp:GridView ID="gvData" runat="server" Width="100%" CssClass="table table-condensed table-bordered" CellPadding="3" BackColor="White" BorderColor="#E7E7FF" BorderStyle="None" BorderWidth="1px" GridLines="Horizontal" PagerSettings-Mode="NumericFirstLast"
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
                            <asp:TemplateField HeaderText="Tiêu đề" SortExpression="Modtype_Name">
                                <ItemTemplate>
                                    <asp:HyperLink ID="hplName" runat="server"></asp:HyperLink>
                                </ItemTemplate>
                            </asp:TemplateField>

                            <asp:BoundField DataField="Modtype_Code" HtmlEncode="False" HeaderText="Mã định dạng"></asp:BoundField>

                            <asp:TemplateField HeaderText="Tình trạng">
                                <HeaderStyle HorizontalAlign="Center" />
                                <ItemStyle HorizontalAlign="Center" Width="70px" />
                                <ItemTemplate>
                                    <asp:ImageButton ID="imgUse" CommandName="isUse" runat="server" CommandArgument='<%# Eval("Modtype_ID") %>' />
                                </ItemTemplate>
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="Option">
                                <HeaderStyle HorizontalAlign="Center" />
                                <ItemStyle HorizontalAlign="Center" Width="60px" />
                                <ItemTemplate>
                                    <asp:Image ID="imgEdit" CssClass="Img" runat="server" ImageUrl="../../Themes/edit.gif" />
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
</asp:Content>

