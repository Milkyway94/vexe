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
                        <i class="fa fa-phone"></i>&nbsp;<a href="javascript:void(0)"><asp:Label ID="lbSDT" runat="server"></asp:Label></a>
                        &nbsp;
                    </li>
                    <%if (Session["MemberID"] != null)
                        {%>
                    <li>
                        <img src="<%=string.IsNullOrEmpty(Session["Member_Avarta"].ToString()) ? "../../resources/img/icon/images.jpg" : Session["Member_Avarta"] %>" class="img-responsive img-circle avartar" />
                    </li>
                    <li>
                        <span class="color-white pull-left"><%=!string.IsNullOrEmpty(Session["Member_Name"].ToString()) ? Session["Member_Name"] : Session["Member_Email"] %></span>
                    </li>
                    <li>
                        <div class="pull-right dropdown">
                            <a class="dropdown-toggle" data-toggle="dropdown">
                                <span class="fa fa-bars"></span>
                            </a>
                            <ul class="dropdown-menu dr-menu">
                                <%=LoadKhachMenu() %>
                                <li><a href="/login.htm?act=logout"><i class="fa fa-sign-out"></i>&nbsp;Đăng xuất</a></li>
                            </ul>
                        </div>
                    </li>
                    <%}
                        else if (SMAC.SessionUtil.GetValue("UserID") == "")
                        { %>
                    <li>
                        <a onclick="Login()" class="color-white">Đăng nhập</a>
                    </li>
                    <li>
                        <a href="/dang-ki.htm" class="color-white">Đăng ký</a>
                    </li>

                    <%}
                        else
                        {%>
                    <li>
                        <img src="<%=string.IsNullOrEmpty(Session["User_Avarta"].ToString()) ? "../../resources/img/icon/images.jpg" : Session["User_Avarta"] %>" class="img-responsive img-circle avartar" />
                    </li>
                    <li>
                        <span class="color-white pull-left"><%=!string.IsNullOrEmpty(Session["User_Name"].ToString()) ? Session["User_Name"] : Session["UserName"] %></span>
                    </li>
                    <li>
                        <div class="pull-right dropdown">
                            <a class="dropdown-toggle" data-toggle="dropdown">
                                <span class="fa fa-bars"></span>
                            </a>
                            <ul class="dropdown-menu dr-menu">
                                <%=LoadNhaXeMenu() %>
                                <li><a href="/login.htm?act=logout"><i class="fa fa-sign-out"></i>&nbsp;Đăng xuất</a></li>
                            </ul>
                        </div>
                    </li>
                    <%} %>
                </ul>

            </div>
        </div>
    </div>
</header>
