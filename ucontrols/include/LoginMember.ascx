<%@ Control Language="C#" AutoEventWireup="true" CodeFile="LoginMember.ascx.cs" Inherits="ucontrols_include_LoginMember" %>
<%@ Register Src="~/ucontrols/subcontrol/Breadcrumb.ascx" TagPrefix="uc1" TagName="Breadcrumb" %>

<div class="container">
    <div class="row">
        <uc1:Breadcrumb runat="server" ID="Breadcrumb" />
    </div>
    <div class="row pb100">
        <div class="con-sm-12">
            <div class="col-sm-5 col-sm-offset-3">
                <div class="hot-doc-header">
                    <h3>ĐĂNG NHẬP</h3>
                </div>
                <div class="doc-inside-box">
                    <form class="form-horizontal" runat="server" method="post" role="form">
                        <asp:Literal Text="" ID="ltrLoginMessage" runat="server" />
                        <div class="form-group">
                            <asp:TextBox runat="server" MaxLength="14" ID="txtUsername" TextMode="Number" CssClass="form-control txtdk" placeholde="Nhập số điện thoại để đăng nhập" />
                        </div>

                        <div class="form-group">
                            <asp:TextBox runat="server" MaxLength="32" TextMode="Password" ID="txtPassword" CssClass="form-control txtdk" placeholde="Nhập Mật khẩu" />
                        </div>
                        <div class="form-group ck">
                            <asp:CheckBox Text="Nhớ mật khẩu" ID="ckRemember" runat="server" />
                            <span class="forgot"><a href="/quen-mat-khau.htm">Quên mật khẩu</a>  |  <a href="/dang-ki.htm">Đăng Ký</a> | <a href="Admin/Login.aspx">Đăng nhập nhà xe</a></span>
                        </div>
                        <div class="form-group text-center btnarea">
                            <asp:Button runat="server" ID="btnLogin" ClientIDMode="Static" OnClick="btLogin_Click" CssClass="btn btn-success btn-yc btn-dk" Text="ĐĂNG NHẬP" />
                        </div>
                    </form>
                </div>
            </div>
        </div>
    </div>
</div>
