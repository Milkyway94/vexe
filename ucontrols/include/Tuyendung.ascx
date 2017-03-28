<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Tuyendung.ascx.cs" Inherits="ucontrols_include_Tuyendung" %>
<script>
    $(function () {
        $(".datepicker").datepicker();
    });
</script>
<div class="container">
    <div class="col-md-3 col-sm-3 hidden-xs l-sidebar">
        <div class="td-sidebar">
            <h3><a href="#"><%=Value.GetValue(Session["vlang"].ToString(), "lbPos") %></a></h3>
            <div class="td-sidebar-left">
                <asp:Literal ID="ltrSidebar" runat="server"></asp:Literal>
            </div>

        </div>
    </div>
    <div class=" main-content col-md-9 col-sm-9 col-xs-12">
        <div class="navigation">
            <div class="breadcrumb">
                <h2 id="crumbs"><span typeof="v:Breadcrumb"><strong>
                    <asp:Label ID="lbNavigation" Text="" runat="server" /></strong></span></h2>
            </div>
        </div>
        <div class="td-main-content">
            <asp:Literal ID="ltrContent" runat="server"></asp:Literal>
        </div>
        <div class="modal fade" id="myModal" role="dialog">
            <div class="modal-dialog modal-lg">
                <div class="modal-content">
                    <div class="modal-header">
                        <button type="button" class="close" data-dismiss="modal"><i class="fa fa-close"></i></button>
                        <h2 style="text-transform: uppercase" class="modal-title"><%=Value.GetValue(Session["vlang"].ToString(), "lbFormTDTitle") %></h2>
                    </div>
                    <div class="modal-body">
                        <form runat="server">
                            <div class="col col-md-12">
                                <div class="input_style">
                                    <asp:TextBox ID="txtName" runat="server" required="true"></asp:TextBox>
                                </div>
                            </div>

                            <div class="col col-md-12">
                                <div class="input_style">
                                    <asp:TextBox ID="txtBirthYear" CssClass="datepicker" runat="server" required="true"></asp:TextBox>
                                </div>
                            </div>
                            <div class="col col-md-6">
                                <div class="input_style">
                                    <asp:TextBox runat="server" ID="txtPhone" required type="text"></asp:TextBox>
                                </div>
                            </div>
                            <div class="col col-md-6">
                                <div class="input_style">
                                    <asp:TextBox ID="txtEmail" runat="server" required type="email" TextMode="Email"></asp:TextBox>
                                </div>
                            </div>
                            <div class="col col-md-12">
                                <div class="input_style">
                                    <asp:TextBox ID="txtAddress" runat="server" required></asp:TextBox>
                                </div>
                            </div>
                            <div class="col col-md-12">
                                <div class="input_style">
                                    <asp:TextBox ID="txtCurrentAddress" runat="server" required></asp:TextBox>
                                </div>
                            </div>
                            <div class="col col-md-12">
                                <div class="input_style">
                                    <asp:TextBox ID="txtPos" runat="server" required></asp:TextBox>
                                </div>
                            </div>
                            <div class="col col-md-2">
                                <div class="input_style uploadcv">
                                    <%=Value.GetValue(Session["vlang"].ToString(), "lbUploadTitle") %>: 
                                </div>
                            </div>
                            <div class="col col-md-10">
                                <div class="input_style">
                                    <asp:FileUpload ID="fileCV" runat="server" />
                                </div>
                            </div>
                            <div class="col col-md-4">
                                <div class="input_style">
                                    <asp:TextBox ID="txtCapcha" runat="server" required type="text"></asp:TextBox>
                                </div>
                            </div>
                            <div class="col col-md-5">
                                <div class="input_style">
                                    <img id="captcha_image" src="../../ashx/captcha.ashx" alt="captcha" />
                                </div>
                            </div>
                            <div class="col col-md-3">
                                <div class="input_style">
                                    <%--<asp:Button ID="btnApply" OnClick="btnApply_Click" CssClass="btn btn-primary" runat="server" />--%>
                                </div>
                            </div>
                        </form>
                        <div class="bottomForm">
                            <div class="row">
                                <div class="col-sm-3">
                                    <img src="../../resources/images/icon-hotline.png" alt="hotline" />&nbsp;<span>Hotline: 
                                    <span style="color: #0660ae">
                                        <asp:Literal ID="ltrHotline" runat="server"></asp:Literal></span>
                                    </span>
                                </div>
                                <div class="col-sm-3">
                                    <img src="../../resources/images/icon-info.png" alt="Email" />&nbsp;<span>Email :
                                    <asp:Literal ID="ltrEmail" runat="server"></asp:Literal></span>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="modal-footer">
                        <button type="button" class="btn btn-default" data-dismiss="modal">Close</button>
                    </div>
                </div>
            </div>
        </div>
    </div>
</div>


