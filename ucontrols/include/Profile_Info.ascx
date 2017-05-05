<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Profile_Info.ascx.cs" Inherits="ucontrols_include_Profile_Info" %>
<%@ Register Src="~/ucontrols/subcontrol/ProfileSidebar.ascx" TagPrefix="uc1" TagName="ProfileSidebar" %>
<%@ Register Src="~/ucontrols/subcontrol/Breadcrumb.ascx" TagPrefix="uc1" TagName="Breadcrumb" %>

<div class="container">
    <uc1:Breadcrumb runat="server" ID="Breadcrumb" />
    <div class="row">
        <div class="col-sm-9 profile-main">
            <h3 class="title-page">Thông tin tài khoản</h3>
            <asp:Literal Text="" ID="ltrError" runat="server" />
            <div class="dvinfo" runat="server" id="mainarea">
                <div class="row">
                    <div class="col-sm-2">
                        <img src="<%=string.IsNullOrEmpty(member.Member_Avarta)?"/resources/img/icon/images.jpg":member.Member_Avarta %>" alt="<%=member.Member_Name %>" />
                    </div>
                    <div class="col-sm-10">
                        <div class="row" id="row-profile">
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
                                    <td>Tỉnh
                                    </td>
                                    <td class="text-bold">
                                        <%=member.Member_Tinh.HasValue? new QCMS_BUSSINESS.Repositories.ProvinceRepository().Find(member.Member_Tinh.Value).TenTinh:"" %>
                                    </td>
                                </tr>
                                <tr>
                                    <td>Quận/Huyện
                                    </td>
                                    <td class="text-bold">
                                        <%=member.Member_QuanHuyen.HasValue? new QCMS_BUSSINESS.Repositories.DistrictRepository().Find(member.Member_QuanHuyen.Value).TenHuyen: ""%>
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
        <div class="col-sm-3" runat="server" id="sidebar">
        </div>
    </div>
</div>
