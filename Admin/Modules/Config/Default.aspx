<%@ Page Language="C#" MasterPageFile="~/Admin/AdminMasterPage.master" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="Config_Default" %>

<asp:Content ID="Content" ContentPlaceHolderID="Main" runat="Server">
    <asp:ScriptManager ID="ScriptManager1" runat="server" />
    <h1 class="text-center">QUẢN LÝ CẤU HÌNH</h1>
    <div class="container">
        <div id="winVP" style="border: 1px solid #cdcdcd;">
            <table id="toolbar" cellspacing="0" style="display: block" border="0">
                <tr>
                    <td>
                        <table cellspacing="0">
                            <tr>
                                <td class="toolBarButton">
                                    <img alt="" src="<%=tp%>add.gif" align="absmiddle">&nbsp;<asp:HyperLink ID="hplAdd" runat="server">Thêm mới</asp:HyperLink></td>
                                <td>
                                    <img src="<%=tp%>line.gif" align="absmiddle" /></td>
                                <td class="toolBarButton">
                                    <img alt="" src="<%=tp%>delete.gif" align="absmiddle" />
                                    &nbsp;<asp:LinkButton ID="lbtDelAll" runat="server" OnClick="lbtDelAll_Click">Xoá hết</asp:LinkButton></td>
                                <td>
                                    <img src="<%=tp%>line.gif" align="absmiddle" /></td>
                                <td>
                                    <input type="text" name="txtFind" id="txtFind" value="" runat="server" style="width: 200;"></td>
                                <td class="toolBarButton">
                                    <img src="<%=tp%>search.gif" align="absmiddle" />&nbsp;
						    <asp:LinkButton ID="lbtSearch" runat="server" OnClick="lbtSearch_Click">Tìm kiếm</asp:LinkButton>
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
            </table>
            <div style="overflow-y: auto; overflow-x: hidden;">
                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                    <ContentTemplate>
                        <asp:UpdateProgress ID="UpdateProgress1" runat="server">
                            <ProgressTemplate>
                                <img src="../../../img/loading.gif" />
                            </ProgressTemplate>
                        </asp:UpdateProgress>
                        <asp:GridView ID="gvData" runat="server" CellPadding="3" CssClass="table" BorderColor="#E7E7FF" BorderStyle="None" BorderWidth="1px" GridLines="Horizontal" PagerSettings-Mode="NumericFirstLast"
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
                                <asp:TemplateField HeaderText="Tiêu đề" SortExpression="Config_Name">
                                    <ItemTemplate>
                                        <asp:HyperLink ID="hplName" runat="server"></asp:HyperLink>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:BoundField DataField="Config_Values" HtmlEncode="False" HeaderText="Giá trị"></asp:BoundField>
                                <asp:BoundField DataField="Config_Code" HtmlEncode="False" HeaderText="Mã nhận biết"></asp:BoundField>
                                <asp:TemplateField HeaderText="Tình trạng">
                                    <HeaderStyle HorizontalAlign="Center" />
                                    <ItemStyle HorizontalAlign="Center" Width="70px" />
                                    <ItemTemplate>
                                        <asp:ImageButton ID="imgUse" CommandName="isUse" runat="server" CommandArgument='<%# Eval("Config_ID") %>' />
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Option">
                                    <HeaderStyle HorizontalAlign="Center" />
                                    <ItemStyle HorizontalAlign="Center" Width="60px" />
                                    <ItemTemplate>
                                        <asp:Image ID="imgEdit" CssClass="Img" runat="server" ImageUrl="../../Themes/edit.gif" />
                                        &nbsp;&nbsp;&nbsp;
                        <asp:ImageButton ID="imgDel" CommandName="del" runat="server" CommandArgument='<%# Eval("Config_ID") %>' ImageUrl="../../Themes/delete.gif" />
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
            <div class="modal fade modal-primary" id="add-modal" role="dialog">
                <div class="modal-dialog modal-lg" id="modalCT">
                    <div class="modal-content">
                        <a class="pull-right" style="padding: 5px;" onclick="$('#add-modal').modal('hide');"><i class="glyphicon glyphicon-remove"></i></a>&nbsp;&nbsp;
                        <a class="pull-right" style="padding: 5px;" onclick="$('#modalCT').toggleClass('fullscreen');"><i class="glyphicon glyphicon-fullscreen"></i></a>&nbsp;&nbsp;
                        <iframe id="updateframe" style="width: 100%; height: 580px; border: none; border-radius: 4px" allowfullscreen></iframe>
                    </div>
                    <!-- /.modal-content -->
                </div>
                <!-- /.modal-dialog -->
            </div>
        </div>
    </div>

</asp:Content>
