<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Profile_History.ascx.cs" Inherits="ucontrols_include_Profile_History" %>
<%@ Register Src="~/ucontrols/subcontrol/ProfileSidebar.ascx" TagPrefix="uc1" TagName="ProfileSidebar" %>
<%@ Register Src="~/ucontrols/subcontrol/Breadcrumb.ascx" TagPrefix="uc1" TagName="Breadcrumb" %>


<div class="container content">
    <uc1:Breadcrumb runat="server" ID="Breadcrumb" />
    <div class="row">
        <div class="col-sm-9 profile-main">
            <h1 class="heading-title">Lịch sử giao dịch</h1>
            <div class="table-responsive">
                <asp:Literal Text="" ID="ltrErr" runat="server" />
                <table class="table table-bordered table-hover" id="tblLSGD">
                    <thead>
                        <tr>
                            <th><i class="fa fa-steam"></i> Mã số vé</th>
                            <th><i class="fa fa-share""></i> Chuyến đi</th>
                            <th><i class="fa fa-bus"></i> Hãng xe</th>
                            <th><i class="fa fa-calendar"></i> Ngày mua</th>
                            <th><i class="fa fa-clock-o"></i> Thời gian đi</th>
                        </tr>
                    </thead>
                    <tbody>
                        <asp:Literal Text="" ID="ltrDsVeXe" runat="server" />
                    </tbody>
                </table>
            </div>

        </div>
        <div class="col-sm-3" id="sidebar" runat="server">
            
        </div>
    </div>
</div>
