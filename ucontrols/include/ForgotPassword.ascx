<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ForgotPassword.ascx.cs" Inherits="ucontrols_include_ForgotPassword" %>
<%@ Register Src="~/ucontrols/subcontrol/Breadcrumb.ascx" TagPrefix="uc1" TagName="Breadcrumb" %>

<div class="container">
    <div class="row">
        <div class="col-sm-12">
            <uc1:Breadcrumb runat="server" ID="Breadcrumb" />
        </div>
        <div class="col-sm-12">
            <div class="row">
                <div class="col-sm-6 col-sm-offset-3">
                    <div class="hot-doc-header">
                        <h3>Lấy lại mật khẩu</h3>
                    </div>
                    <div class="hot-doc-box">
                        <div class="doc-inside-box">
                             <div class="uk-alert-danger" uk-alert runat="server" id="Div1">
                                    <a class="uk-alert-close" uk-close></a>
                                    <p>
                                        <span class="uk-margin-small-right" uk-icon="icon: ban"></span>
                                        <asp:Label Text="" ID="lbError" runat="server" />
                                    </p>
                                </div>
                            <div class="uk-alert-success" uk-alert runat="server" id="Div2">
                                    <a class="uk-alert-close" uk-close></a>
                                    <p>
                                        <span class="uk-margin-small-right" uk-icon="icon: ban"></span>
                                        <asp:Label Text="" ID="lbSuccess" runat="server" />
                                    </p>
                                </div>
                            <form class="form-horizontal" method="post" id="frmGetPass" role="form" runat="server">
                                <div class="uk-alert-danger" uk-alert runat="server" id="dverror_email">
                                    <a class="uk-alert-close" uk-close></a>
                                    <p>
                                        <span class="uk-margin-small-right" uk-icon="icon: ban"></span>
                                        <asp:Label Text="" ID="lberror_email" runat="server" />
                                    </p>
                                </div>
                                <div class="form-group">
                                    <label for="code">Email <span class="color">*</span></label>
                                    <asp:TextBox runat="server" required CssClass="form-control txtdk" TextMode="Email" ID="email" placeholder="VD : abc@gmail.com Dùng để nhận mã vé xe điện tử"></asp:TextBox>
                                </div>
                                
                                <div class="form-group">
                                    <div class="col-sm-5 col-sm-offset-3 btnarea">
                                        <asp:Button runat="server" CssClass="btn btn-success btn-yc btn-dk" ID="btnPassword" OnClick="btnPassword_Click" Text="Gửi yêu cầu"></asp:Button>
                                    </div>
                                </div>
                                <div class="form-group">
                                    <p class=" text-center"><a href="/login.htm">Đăng Nhập</a></p>
                                </div>
                            </form>
                        </div>
                    </div>
                </div>
            </div>

        </div>
    </div>
</div>
