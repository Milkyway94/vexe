<%@ Control Language="C#" AutoEventWireup="true" CodeFile="News.ascx.cs" Inherits="ucontrols_include_News" %>
<div class="content">
    <div class="container container-fluid">
        <ul class="uk-breadcrumb hi-padding">
            <asp:Literal ID="lbNavigation" runat="server"></asp:Literal>
        </ul>
        <div class="row">
            <!-- main content -->
            <div class="main-content col-md-9 col-lg-9 col-sm-12 col-xs-12">
                <div class="fw">
                    <div class="fw news">
                        <asp:Literal ID="ltrListContent" runat="server"></asp:Literal>
                        <h3><span>Tin tức</span></h3>
                        <%
                            if (m == null)
                            {%>

                        <%}
                            else
                            {%>
                        <div class="tindocnhieu fw">
                            <div class="col-md-8 col-xs-12">
                                <asp:Literal ID="ltrtdn" runat="server"></asp:Literal>

                            </div>
                            <div class="col-md-4 col-xs-12 sidebar lst-tdn <%=display %>">
                                <h3><span>Tin đọc nhiều nhất</span></h3>
                                <ul class="lstSidebar">
                                    <asp:Literal ID="ltrHotNew" runat="server"></asp:Literal>
                                </ul>
                            </div>
                        </div>
                        <%
                            }
                        %>
                        <div class="fw dstintuc">
                            <asp:Literal ID="ltrContent" runat="server"></asp:Literal>
                        </div>
                    </div>
                    <%-- <div class="fw pagination1">
                        <ul class="uk-pagination uk-flex-center" uk-margin>
                            <li><a href="#"><span uk-pagination-previous></span></a></li>
                            <li><a href="#">1</a></li>
                            <li><a href="#">2</a></li>
                            <li class="uk-active"><span>3</span></li>
                            <li><a href="#">4</a></li>
                            <li><a href="#">5</a></li>
                            <li><a href="#">6</a></li>
                            <li><a href="#"><span uk-pagination-next></span></a></li>
                        </ul>
                    </div>--%>
                    <div class="lstRelated fw" style="margin-top: 30px">
                        <ul class="fw lstSidebar">
                            <asp:Literal ID="ltrListRelated" runat="server"></asp:Literal>
                        </ul>
                    </div>
                </div>

            </div>
            <!-- sidebar -->
            <div class="col-lg-3 col-md-3 hiden-sm hidden-xs">
                <div class="sidebar fw">
                    <h3><span>Về công ty</span></h3>
                    <ul class="lstSidebar">
                        <li><a href="/ve-cong-ty.htm">Giới thiệu</a></li>
                        <li><a href="/tin-tuc.htm">Tin tức</a></li>
                        <li><a href="/ve-cong-ty/bao-chi-viet.htm">Báo chí viết</a></li>
                        <li><a href="/huong-dan.htm">Hướng dẫn</a></li>
                        <li><a href="/tuyen-dung.htm">Tuyển dụng</a></li>
                    </ul>
                </div>
            </div>
        </div>
    </div>
<div class="content hidden-lg">
        <div class="container container-fluid">
            <div class="row">
                <!-- sidebar -->
                <div class="col-lg-3 col-md-3 hiden-sm hidden-xs">
                    <div class="sidebar">
                        <div class="w100">
                            <div class="top-sidebar">
                                <h3><span class="icon i5"></span><a href="#"><%=Value.GetValue(Session["vlang"].ToString(), "lbHotNews ") %></a></h3>
                                <div class="td-sidebar-left">
                                    <marquee class="marquee" scrollamount="1" scrolldelay="1" direction="up">
                                <ul>
                                    <asp:Literal ID="ltrSidebar" runat="server"></asp:Literal>
                                </ul>
                                    </marquee>
                                </div>
                                <h3><span class="icon i5"></span><a href="#"><%=Value.GetValue(Session["vlang"].ToString(), "lbNewArival ") %></a></h3>
                                <div class="td-sidebar-left">
                                    <ul>
                                        <asp:Literal ID="ltrNews" runat="server"></asp:Literal>
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
                                <h2 id="crumbs"><span typeof="v:Breadcrumb"></span>&nbsp;<strong style="color: #0660ad"><%--<asp:Label ID="lbNavigation" Text="" runat="server"></asp:Label>--%></strong></span></h2>
                            </div>
                        </div>
                        <div class="w100">
                            <%-- <asp:Literal ID="ltrContent" runat="server"></asp:Literal>--%>
                            <%
                                if (m == null)
                                {%>

                            <%}
                                else
                                {%>
                            <div class="tinlienquan">
                                <ul>
                                    <%--<asp:Literal ID="ltrListRelated" runat="server"></asp:Literal>--%>
                                </ul>
                            </div>
                        </div>
                    </div>
                    <%
                        }
                    %>
                </div>
            </div>
        </div>
    </div>
    <asp:Literal ID="ltrCss" runat="server"></asp:Literal>
