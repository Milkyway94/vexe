<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Header.ascx.cs" Inherits="ucontrols_subcontrol_Header" %>
<header>
    <div class="container">
        <div class="top-menu">
            <div class="pull-left hidden-xs">
                <ul>
                    <asp:Literal ID="MenuTopItem" runat="server" />
                </ul>
            </div>
            <div class="top-right pull-right">
                <ul class="header-right">

                    <li>
                        <i class="fa fa-phone"></i>&nbsp;<a href="javascript:void(0)" id="link-phone"><asp:Label ID="lbSDT" runat="server"></asp:Label></a>
                        &nbsp;
                    </li>
                    <li><i>|</i></li>
                    <%if (Session["MemberID"] != null)
                        {%>
                    <li>
                        <img src="<% string str1 = string.IsNullOrEmpty(SMAC.SessionUtil.GetValue("Member_Avarta")) ? "../../resources/img/icon/images.jpg" : SMAC.SessionUtil.GetValue("Member_Avarta"); Response.Write(str1); %>" class="img-responsive img-circle avartar" />
                    </li>
                    <li>
                        <span class="color-white pull-left"><%string ss=!string.IsNullOrEmpty(SMAC.SessionUtil.GetValue("Member_Name")) ? SMAC.SessionUtil.GetValue("Member_Name") : SMAC.SessionUtil.GetValue("Member_Email"); Response.Write(ss); %></span>
                    </li>
                    <li>
                        <div class="pull-right dropdown">
                            <a class="dropdown-toggle" data-toggle="dropdown">
                                <span class="fa fa-bars"></span>
                            </a>
                            <ul class="dropdown-menu dr-menu">
                                <% Response.Write(LoadKhachMenu()); %>
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
                    <li><i>|</i></li>
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
                                <li><a href="Admin/login.aspx?act=logout"><i class="fa fa-sign-out"></i>&nbsp;Đăng xuất</a></li>
                            </ul>
                        </div>
                    </li>
                    <%} %>
                </ul>

            </div>
        </div>
    </div>
</header>
