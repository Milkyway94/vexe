<%@ Control Language="C#" AutoEventWireup="true" CodeFile="LoginMember.ascx.cs" Inherits="ucontrols_include_LoginMember" %>
<div class="container content">
    <div class="row">
        <div class="col-sm-12">
            <p class="pad"><span class="glyphicon glyphicon-home"></span>>> Đăng nhập</p>
        </div>
    </div>
    <div class="row">
        <div class="con-sm-12">
            <div class="col-sm-5 col-sm-offset-3">
                <div class="hot-doc-header">
                    <h3>Đăng nhập hệ thống khách hàng</h3>
                </div>
                <div class="doc-inside-box">
                    <form class="form-horizontal" runat="server" method="post" role="form">
                        <asp:Literal Text="" ID="ltrLoginMessage" runat="server" />
                        <div class="form-group">
                            <asp:TextBox runat="server" MaxLength="256" ID="txtUsername" CssClass="form-control" placeholde="Nhập Email hoặc số điện thoại" />
                        </div>

                        <div class="form-group">
                            <asp:TextBox runat="server" MaxLength="32" TextMode="Password" ID="txtPassword" CssClass="form-control" placeholde="Nhập Mật khẩu" />
                        </div>
                        <div class="form-group">
                            <asp:CheckBox Text="Nhớ mật khẩu" ID="ckRemember" runat="server" />
                            <span class="forgot"><a href="/quen-mat-khau.htm">Quên mật khẩu</a>  |  <a href="/dang-ki.htm">Đăng Ký</a> | <a href="Admin/Login.aspx">Đăng nhập nhà xe</a></span>
                        </div>
                        <div class="form-group text-center">
                            <asp:Button runat="server" ID="btnLogin" ClientIDMode="Static" OnClick="btLogin_Click" CssClass="btn btn-search" Text="Đăng nhập" />
                        </div>
                    </form>
                </div>
            </div>
        </div>
    </div>
</div>
