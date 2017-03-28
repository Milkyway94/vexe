<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Profile_Info.ascx.cs" Inherits="ucontrols_include_Profile_Info" %>
<%@ Register Src="~/ucontrols/subcontrol/ProfileSidebar.ascx" TagPrefix="uc1" TagName="ProfileSidebar" %>

<div class="container content">
    <div class="row">
        <ul class="uk-breadcrumb hi-padding">
            <asp:Literal ID="lbnav" runat="server" Text=""></asp:Literal>
        </ul>
    </div>
    <div class="row">
        <div class="col-sm-9 profile-main">
            <h1 class="heading-title">Thông tin tài khoản</h1>
            <div class="dvinfo">
                <asp:Literal Text="" ID="ltrError" runat="server" />
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
                    <div class="col-sm-12">
                        <div class="row">
                            <table class="table table-striped" id="tbl_info">
                                <tr>
                                    <td>Họ và tên
                                    </td>
                                    <td class="text-bold">
                                        <%=member.Member_Name %>
                                    </td>
                                </tr>
                                <tr>
                                    <td>Email
                                    </td>
                                    <td class="text-bold">
                                        <%=member.Member_Email %>
                                    </td>
                                </tr>
                                <tr>
                                    <td>Số điện thọai
                                    </td>
                                    <td class="text-bold">
                                        <%=member.Member_Phone %>
                                    </td>
                                </tr>
                                <tr>
                                    <td>Địa chỉ
                                    </td>
                                    <td class="text-bold">
                                        <%=member.Member_Address %>
                                    </td>
                                </tr>
                            </table>
                        </div>

                    </div>
                </div>
            </div>
        </div>
        <div class="col-sm-3">
            <uc1:ProfileSidebar runat="server" ID="ProfileSidebar" />
        </div>
    </div>
</div>
