<%@ Control Language="C#" AutoEventWireup="true" CodeFile="LoginMember.ascx.cs" Inherits="ucontrols_include_LoginMember" %>
<div class="container content">
    <div class="row">
        <div class="col-sm-12">
            <p class="pad"><span class="glyphicon glyphicon-home"></span>>> Đăng nhập</p>
        </div>
        <div class="con-sm-12">
            <div class="row">
                <div class="col-sm-4 col-sm-offset-4">
                    <div class="row">
                        <div class="hot-doc-header">
                            <h3>Đăng nhập</h3>
                        </div>
                        <div class="hot-doc-box">
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
                                        <asp:CheckBox Text=" Nhớ mật khẩu" ID="ckRemember" runat="server" />
                                        <span class="forgot"><a href="/quen-mat-khau.htm">Quên mật khẩu</a>  |  <a href="/dang-ki.htm">Đăng Ký</a></span>
                                    </div>
                                    <div class="form-group text-center">
                                        <asp:Button runat="server" ID="btnLogin"  ClientIDMode="Static" OnClick="btLogin_Click" CssClass="btn btn-search" Text="Đăng nhập" />
                                    </div>
                                </form>
                            </div>
                        </div>
                    </div>
                </div>
            </div>

        </div>
    </div>
</div>
