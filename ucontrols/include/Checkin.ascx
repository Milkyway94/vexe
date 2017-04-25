<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Checkin.ascx.cs" Inherits="ucontrols_include_Checkin" %>
<%@ Register Src="~/ucontrols/subcontrol/NhaXeProfileSidebar.ascx" TagPrefix="uc1" TagName="NhaXeProfileSidebar" %>


<div class="container content">
    <div class="row">
        <ul class="uk-breadcrumb hi-padding">
            <asp:Literal ID="lbnav" runat="server" Text=""></asp:Literal>
        </ul>
    </div>
    <div class="row">
        <div class="col-sm-9 profile-main">
            <h1 class="heading-title">Điểm danh khách hàng</h1>
            <div class="dvinfo" id="dvinfo" runat="server">
                <form runat="server">
                    <div class="form-horizontal">
                        <asp:Literal Text="" ID="ltrError" runat="server" />
                        <div class="form-group">
                            <label class="col-sm-3">Nhập mã vé</label>
                            <div class="col-sm-7">
                                <asp:TextBox runat="server" ID="txtMaVe" required placeholder="Nhập mã vé" CssClass="form-control" />
                            </div>
                            <div class="col-sm-2 col-xs-12 col-xs-12-offset-4">
                                <asp:Button Text="Điểm danh" ID="btnCheckIn" OnClick="btnCheckIn_Click" CssClass="btn btn-success" runat="server" />
                            </div>
                        </div>
                    </div>
                </form>
            </div>
            <div class="pt20 <%=displayDetail %> ">
                <div class="tbNhanve row" id="ticket">
                    <div class="col-sm-12 tbnv_header">
                        <div class="pull-left">
                            <h5 class="text-bold">THÔNG TIN VÉ</h5>
                        </div>
                        <div class="pull-right">
                            <h5>Mã vé: <%=mave %></h5>
                        </div>
                    </div>
                    <div class="col-sm-6" id="col-1">
                        <h3>1. Thông tin vé xe</h3>
                        <table class="table tbl-nv">
                            <tbody>
                                <tr>
                                    <td>Vé xe đi từ:</td>
                                    <td><%=diemdi %> <span class="text-success"><i class="fa fa-arrow-right"></i></span><%=diemden %></td>
                                </tr>
                                <tr>
                                    <td>Giờ khởi hành:</td>
                                    <td><%=giodi %> - <%=ngaydi %></td>
                                </tr>
                                <tr>
                                    <td>Loại ghế:</td>
                                    <td><%=loaive%> VIP</td>
                                </tr>
                            </tbody>
                        </table>
                    </div>
                    <div class="col-sm-6" id="col-2">
                        <h3>2. Thông tin khách hàng</h3>
                        <table class="table tbl-nv">
                            <tr>
                                <td>Tên khách hàng:</td>
                                <td><%=nguoimua %></td>
                            </tr>
                            <tr>
                                <td>Số điện thoại:</td>
                                <td><%=sdt %></td>
                            </tr>
                            <tr>
                                <td>Email:</td>
                                <td><%=email %></td>
                            </tr>
                            <tr>
                                <td>Địa chỉ:</td>
                                <td><%=diachi %></td>
                            </tr>
                            <tr>
                                <td>Hình thức thanh toán:</td>
                                <td><%=method %></td>
                            </tr>
                            <tr>
                                <td>Giá:</td>
                                <td><span class="color-red"><%=giave %></span> đ</td>
                            </tr>
                        </table>
                    </div>
                </div>
            </div>
        </div>
        <div class="col-sm-3">
            <uc1:NhaXeProfileSidebar runat="server" ID="NhaXeProfileSidebar" />
        </div>
    </div>

</div>
