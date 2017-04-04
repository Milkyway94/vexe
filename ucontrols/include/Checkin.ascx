<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Checkin.ascx.cs" Inherits="ucontrols_include_Checkin" %>
<%@ Register Src="~/ucontrols/subcontrol/NhaXeProfileSidebar.ascx" TagPrefix="uc1" TagName="NhaXeProfileSidebar" %>


<div class="container content">
    <div class="row">
        <ul class="uk-breadcrumb hi-padding">
            <asp:Literal ID="lbnav" runat="server" Text=""></asp:Literal>
        </ul>
    </div>
    <div class="row">
        <div class="col-sm-9 profile-main">
            <h1 class="heading-title">Điểm danh khách hàng</h1>
            <div class="dvinfo" id="dvinfo" runat="server">
                <form runat="server">
                    <div class="form-horizontal">
                        <div class="form-group">
                            <label class="col-sm-3">Nhập mã vé</label>
                            <div class="col-sm-7">
                                <asp:TextBox runat="server" placeholder="Nhập mã vé" CssClass="form-control" />
                            </div>
                            <div class="col-sm-2">
                                <asp:Button Text="Điểm danh" CssClass="btn btn-success" runat="server" />
                            </div>
                        </div>
                    </div>
                </form>
            </div>
        </div>
        <div class="col-sm-3">
            <uc1:NhaXeProfileSidebar runat="server" ID="NhaXeProfileSidebar" />
        </div>
    </div>
</div>