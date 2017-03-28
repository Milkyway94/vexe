<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Enterprise.ascx.cs" Inherits="ucontrols_Enterprise" %>
<div class="content">
    <div class="container container-fluid">
        <div class="row">
            <!-- sidebar -->
            <div class="col-lg-3 col-md-3 hiden-sm hidden-xs">
                <div class="sidebar">
                    <div class="w100">
                        <div class="top-sidebar">
                            <h3><span class="icon i5"></span><a href="qhcd.htm" class="abc">Danh mục tin tức</a></h3>
                            <div class="td-sidebar-left">
                                <ul>
                                    <asp:Literal ID="ltrSidebar" runat="server"></asp:Literal>
                                </ul>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
            <!-- main content -->
            <div class="main-content col-md-9 col-lg-9 col-sm-12 col-xs-12">
                <div class="w100">
                    <div class="navigation">
                        <div class="breadcrumb">
                            <h2 id="crumbs"><span typeof="v:Breadcrumb"></span>&nbsp;<strong><asp:Label ID="lbNavigation" Text="" runat="server"></asp:Label></strong></span></h2>
                        </div>
                    </div>
                    <div class="w100 gioi_thieu fl">
                        <%
                        if (Request["e"] == null)
                        {%>
                        <asp:Literal ID="ltrEnterprise" runat="server"></asp:Literal>
                        <%}
                        else
                        {%>
                        <asp:Literal ID="ltrContent" runat="server"></asp:Literal>
                        <%
                            }
                         %>
                    </div>
                </div>
            </div>
        </div>
    </div>
</div>

