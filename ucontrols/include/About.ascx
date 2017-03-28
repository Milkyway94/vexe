<%@ Control Language="C#" AutoEventWireup="true" CodeFile="About.ascx.cs" Inherits="ucontrols_include_OneContent" %>
<div class="content">
    <div class="container container-fluid">
        <div class="row">
            <!-- main content -->
            <div class="main-content col-md-9 col-lg-9 col-sm-12 col-xs-12">
                <div class="fw">
                    <ul class="uk-breadcrumb hi-padding">
                        <asp:Literal ID="lbnav" runat="server" Text=""></asp:Literal>
                    </ul>
                    <div class="w100 gioi_thieu fl">
                        <asp:Literal ID="ltrListContent" runat="server"></asp:Literal>
                    </div>
                </div>
            </div>
        </div>
        <!-- sidebar -->
            <div class="col-lg-3 col-md-3 hiden-sm hidden-xs">
                <div class="sidebar fw">
                    <h3><span><%= SMAC.ModControl.GetName_From_Code(url) %></span></h3>
                    <ul class="lstSidebar">
                        <asp:Literal ID="ltrSidebar" runat="server"></asp:Literal>
                    </ul>
                </div>
            </div>
    </div>
</div>

