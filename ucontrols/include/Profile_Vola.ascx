<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Profile_Vola.ascx.cs" Inherits="ucontrols_include_Profile_Vola" %>
<%@ Register Src="~/ucontrols/subcontrol/ProfileSidebar.ascx" TagPrefix="uc1" TagName="ProfileSidebar" %>

<div class="container content">
    <div class="row">
        <ul class="uk-breadcrumb hi-padding">
            <asp:Literal ID="lbnav" runat="server" Text=""></asp:Literal>
        </ul>
    </div>
    <div class="row">
        <div class="col-sm-9 profile-main">
            <h1 class="heading-title">Nạp tiền VOLA</h1>
            <div class="dvinfo" id="dvinfo" runat="server">
                <form runat="server">
                    <div class="form-horizontal">
                        <div class="form-group">
                            <label class="col-sm-3">Nhập mã thẻ nạp</label>
                            <div class="col-sm-7">
                                <asp:TextBox runat="server" placeholder="Nhập mã thẻ nạp" CssClass="form-control" />
                            </div>
                            <div class="col-sm-2">
                                <asp:Button Text="Nạp thẻ" CssClass="btn btn-success" runat="server" />
                            </div>
                        </div>
                    </div>
                </form>
            </div>
        </div>
        <div class="col-sm-3">
            <uc1:ProfileSidebar runat="server" ID="ProfileSidebar" />
        </div>
    </div>
</div>
