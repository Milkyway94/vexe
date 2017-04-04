<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Registers.ascx.cs" Inherits="ucontrols_include_Document" %>
<div class="container">
    <div class="row">
        <div class="col-sm-12">
            <p class="pad"><span class="glyphicon glyphicon-home"></span>>> Đăng kí tài khoản</p>
        </div>
        <div class="col-sm-12">
            <div class="row">
                <div class="col-sm-6 col-sm-offset-3">
                    <div class="hot-doc-header">
                        <h3>Đăng ký tài khoản</h3>
                    </div>
                    <div class="hot-doc-box">
                        <div class="doc-inside-box">
                            <form class="form-horizontal" method="post" role="form" runat="server">
                                <div class="uk-alert-success" uk-alert runat="server" id="dvsuccess">
                                    <a class="uk-alert-close" uk-close></a>
                                    <p>
                                        <span class="uk-margin-small-right" uk-icon="icon: ban"></span>
                                        <asp:Label Text="" ID="lbError" runat="server" />
                                    </p>
                                </div>
                                <div class="uk-alert-danger" uk-alert runat="server" id="dverror_sdt">
                                    <a class="uk-alert-close" uk-close></a>
                                    <p>
                                        <span class="uk-margin-small-right" uk-icon="icon: ban"></span>
                                        <asp:Label Text="" ID="lberror_sdt" runat="server" />
                                    </p>
                                </div>
                                <div class="form-group">
                                    <label for="code">Số Điện Thoại <span class="color">*</span></label>
                                    <asp:TextBox runat="server" TextMode="Phone" required MaxLength="20" CssClass="form-control" ID="phone" placeholder="VD : 0123456789 Dùng để xác nhận khi lên xe"></asp:TextBox>
                                </div>
                                <div class="uk-alert-danger" uk-alert runat="server" id="dverror_email">
                                    <a class="uk-alert-close" uk-close></a>
                                    <p>
                                        <span class="uk-margin-small-right" uk-icon="icon: ban"></span>
                                        <asp:Label Text="" ID="lberror_email" runat="server" />
                                    </p>
                                </div>
                                <div class="form-group">
                                    <label for="code">Email <span class="color">*</span></label>
                                    <asp:TextBox runat="server" required CssClass="form-control" TextMode="Email" ID="email" placeholder="VD : abc@gmail.com Dùng để nhận mã vé xe điện tử"></asp:TextBox>
                                </div>
                                <div class="uk-alert-danger" uk-alert runat="server" id="dverror_pass">
                                    <a class="uk-alert-close" uk-close></a>
                                    <p>
                                        <span class="uk-margin-small-right" uk-icon="icon: ban"></span>
                                        <asp:Label Text="" ID="lberror_pass" runat="server" />
                                    </p>
                                </div>
                                <div class="form-group">
                                    <label  for="code">Mật khẩu <span class="color">*</span></label>
                                    <asp:TextBox runat="server" required TextMode="Password" MaxLength="32" CssClass="form-control" ID="password" placeholder="Nhập mật khẩu"></asp:TextBox>
                                </div>
                                <div class="uk-alert-danger" uk-alert runat="server" id="dverror_verpass">
                                    <a class="uk-alert-close" uk-close></a>
                                    <p>
                                        <span class="uk-margin-small-right" uk-icon="icon: ban"></span>
                                        <asp:Label Text="" ID="lberror_verpass" runat="server" />
                                    </p>
                                </div>
                                <div class="form-group">
                                    <label for="code">Nhập lại mật khẩu <span class="color">*</span></label>
                                    <asp:TextBox runat="server" required CssClass="form-control" TextMode="Password" MaxLength="32" ID="repassword" placeholder="Nhập lại mật khẩu"></asp:TextBox>
                                </div>
                                <div class="form-group">
                                    <div class="col-sm-5 col-sm-offset-3">
                                        <asp:Button runat="server" CssClass="btn btn-block btn-search" ID="btnRegister" OnClick="btnRegister_Click" Text="Đăng Ký"></asp:Button>
                                    </div>
                                </div>
                                <div class="form-group">
                                    <p class=" text-center">Bạn đã có tài khoản ? <a href="/login.htm">Đăng Nhập</a></p>
                                </div>

                            </form>
                        </div>
                    </div>
                </div>
            </div>

        </div>
    </div>
</div>

