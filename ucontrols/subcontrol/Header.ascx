<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Header.ascx.cs" Inherits="ucontrols_subcontrol_Header" %>
<header>
    <div class="top-menu">
        <div class="container">
            <div class="pull-left hidden-xs">
                <ul>
                    <asp:Literal ID="MenuTopItem" runat="server" />
                </ul>
            </div>
            <div class="top-right pull-right">
                <ul class="header-right">
                    
                    <li>
                        <i class="fa fa-phone"></i>&nbsp;<asp:Label ID="lbSDT" runat="server"></asp:Label>
                        &nbsp;|&nbsp;
                    </li>
                    <%if (Session["MemberID"] != null)
                        {%>
                    <li>
                        <img src="<%=string.IsNullOrEmpty(Session["Member_Avarta"].ToString())?"../../resources/img/icon/images.jpg":Session["Member_Avarta"] %>" class="img-responsive img-circle avartar" />
                    </li>
                    <li>
                        <span class="color-white pull-left"><%=!string.IsNullOrEmpty(Session["Member_Name"].ToString())?Session["Member_Name"]:Session["Member_Email"] %></span>
                    </li>
                    <li>
                        <div class="pull-right dropdown">
                            <a class="dropdown-toggle" data-toggle="dropdown">
                                <span class="fa fa-bars"></span>
                            </a>
                            <%if (Session["Member_Role"].ToString() == "1")
                                { %>
                            <ul class="dropdown-menu dr-menu">
                                <%=LoadKhachMenu() %>
                                <li><a href="/login.htm?act=logout"><i class="fa fa-sign-out"></i>&nbsp;Đăng xuất</a></li>
                            </ul>
                            <%}
    else
    { %>
                            <ul class="dropdown-menu dr-menu">
                                <%=LoadNhaXeMenu() %>
                                <li><a href="/login.htm?act=logout"><i class="fa fa-sign-out"></i>&nbsp;Đăng xuất</a></li>
                            </ul>
                            <%} %>
                        </div>
                    </li>
                    <%}
                        else
                        { %>
                    <li>
                        <a onclick="Login()" class="color-white">Đăng nhập</a>|
                    </li>
                    <li>
                        <a href="/dang-ki.htm" class="color-white">Đăng ký</a>
                    </li>

                    <%} %>
                </ul>

            </div>
        </div>
    </div>
</header>
