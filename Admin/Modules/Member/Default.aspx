<%@ Page Language="C#" MasterPageFile="~/Admin/AdminMasterPage.master" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="Admin_Modules_Content_Default" %>
<asp:Content ID="Content" ContentPlaceHolderID="Main" Runat="Server">
        <div id="winVP" class="container table-responsive">
            <asp:Button ID="btntoExcel" CssClass="btn btn-success" runat="server" Text="Export to Excel" onclick="btntoExcel_Click" />
	        <div style="width: 100%; height: 99%; overflow-y:auto; overflow-x:hidden;">
                <asp:GridView ID="gvMember" runat="server" Width="100%" CssClass="table table-hover table-stripped datatable" HeaderStyle-BackColor="#007000" >
                </asp:GridView>
            </div>
        </div>
</asp:Content>