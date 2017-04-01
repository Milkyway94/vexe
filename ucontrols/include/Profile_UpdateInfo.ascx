<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Profile_UpdateInfo.ascx.cs" Inherits="ucontrols_include_Profile_History" %>
<%@ Register Src="~/ucontrols/subcontrol/ProfileSidebar.ascx" TagPrefix="uc1" TagName="ProfileSidebar" %>

<div class="container content">
    <div class="row">
        <ul class="uk-breadcrumb hi-padding">
            <asp:Literal ID="lbnav" runat="server" Text=""></asp:Literal>
        </ul>
    </div>
    <div class="row">
        <div class="col-sm-9 profile-main">
            <h1 class="heading-title">Cập nhật Thông tin tài khoản</h1>
            <asp:Literal Text="" ID="ltrError" runat="server" />
            <div class="dvinfo" id="dvinfo" runat="server">
                <div class="row">
                    <div class="col-sm-2">
                        <img src="<%=string.IsNullOrEmpty(member.Member_Avarta)?"/resources/img/icon/images.jpg":member.Member_Avarta %>" alt="<%=member.Member_Name %>" />
                    </div>
                    <div class="col-sm-10">
                        <div class="row">
                            <div class="col-sm-12">
                                <h3 class="t-title"><%=member.Member_Email %></h3>
                            </div>
                            <div class="col-sm-12">
                                <div class="pull-left">
                                    <img src="/resources/img/icon/icon-diemtv.png" width="20" height="20" class="img-responsive" alt="Vola" />
                                </div>
                                <span class="pull-left text-vola"><%=member.Member_Vola%></span>
                            </div>
                            <div class="col-sm-12">
                                <span class="text-mo">Thay ảnh đại diện</span>
                            </div>
                            <div class="col-sm-12">
                                <button class="btn btn-upload">Chọn tệp tin...</button>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="row">
                    <div class="col-sm-12" id="frmUpdateInfo">
                        <form runat="server">
                            <div class="form-horizontal">
                                <div class="form-group">
                                    <label class="col-sm-2">Họ và tên</label>
                                    <div class="col-sm-10">
                                        <asp:TextBox runat="server" ID="txtName" CssClass="form-control" required />
                                    </div>
                                </div>
                                <div class="form-group">
                                    <label class="col-sm-2">Email</label>
                                    <div class="col-sm-10">
                                        <asp:TextBox runat="server" ID="txtEmail" CssClass="form-control" required />
                                    </div>
                                </div>
                                <div class="form-group">
                                    <label class="col-sm-2">Số điện thoại</label>
                                    <div class="col-sm-10">
                                        <asp:TextBox runat="server" ID="txtSdt" CssClass="form-control" required />
                                    </div>
                                </div>
                                <div class="form-group">
                                    <label class="col-sm-2">Địa chỉ</label>
                                    <div class="col-sm-10">
                                        <asp:TextBox TextMode="MultiLine" runat="server" ID="txtDiachi" CssClass="form-control" required />
                                    </div>
                                </div>
                                <div class="form-group">
                                    <div class="col-sm-12">
                                        <div class="text-center">
                                            <asp:Button Text="Lưu cập nhật" CssClass="btn btn-success" ID="btnSave" OnClick="btnSave_Click" runat="server" />
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </form>
                    </div>
                </div>
            </div>
        </div>
        <div class="col-sm-3">
            <uc1:ProfileSidebar runat="server" ID="ProfileSidebar" />
        </div>
    </div>
</div>
