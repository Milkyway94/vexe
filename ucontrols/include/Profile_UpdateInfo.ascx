<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Profile_UpdateInfo.ascx.cs" Inherits="ucontrols_include_Profile_History" %>
<%@ Register Src="~/ucontrols/subcontrol/ProfileSidebar.ascx" TagPrefix="uc1" TagName="ProfileSidebar" %>
<%@ Register Src="~/ucontrols/subcontrol/Breadcrumb.ascx" TagPrefix="uc1" TagName="Breadcrumb" %>


<div class="container">
    <uc1:Breadcrumb runat="server" ID="Breadcrumb" />
    <div class="row">
        <div class="col-sm-9 profile-main">
            <form runat="server">
                <asp:ScriptManager ID="ScriptManager1" runat="server" EnablePartialRendering="true"></asp:ScriptManager>
                <h1 class="title-page">Cập nhật Thông tin tài khoản</h1>
                <asp:Literal Text="" ID="ltrError" runat="server" />
                <div class="dvinfo" id="dvinfo" runat="server">
                    <div class="row">
                        <div class="col-sm-2">
                            <asp:Image ID="avartar" runat="server" />
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
                                <div class="col-sm-12" style="position: relative">
                                    <asp:FileUpload ID="fAvartar" ClientIDMode="Static" runat="server" CssClass="uploadfile" />
                                    <button type="button" class="btn btn-upload">Chọn tệp tin...</button>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-sm-12" id="frmUpdateInfo">
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
                                <asp:UpdatePanel runat="server">
                                    <ContentTemplate>
                                        <div class="form-group">
                                            <label class="col-sm-2">Tỉnh</label>
                                            <div class="col-sm-10">
                                                <asp:DropDownList runat="server" ID="ddlTinh" AutoPostBack="true" CssClass="form-control txtdi select2" OnSelectedIndexChanged="ddlTinh_SelectedIndexChanged">
                                                </asp:DropDownList>
                                            </div>
                                        </div>
                                        <div class="form-group">
                                            <label class="col-sm-2">Quận/huyện</label>
                                            <div class="col-sm-10">
                                                <asp:DropDownList runat="server" ID="ddlQuanHuyen" CssClass="form-control txtdi select2">
                                                </asp:DropDownList>
                                            </div>
                                        </div>
                                    </ContentTemplate>
                                </asp:UpdatePanel>
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

                        </div>
                    </div>
                </div>
            </form>
        </div>
        <div class="col-sm-3" runat="server" id="sidebar">
            
        </div>
    </div>
</div>
<script> 
    function pageLoad() { $(".select2").select2(); }
</script>

