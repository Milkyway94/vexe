<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Step3.ascx.cs" Inherits="ucontrols_include_Step3" %>
<div class="fw">
    <div class="datve">
        <div class="container">
            <div class="row" id="r1">
                <div class="col-md-4 col-xs-12 col-sm-3 p0">
                    <div class="tv1">
                        <img src="../../resources/img/icon/icon-timve.png" class="img-responsive" alt="Tìm vé" />
                    </div>
                    <div class="tv2">01</div>
                    <div class="tv3">
                        <span class="b1">&nbsp;</span><br />
                        <span class="b1tv disable">TÌM VÉ</span>
                    </div>
                    <div class="tv4">
                        <img src="../../resources/img/icon/icon-next.png" />
                    </div>
                </div>
                <div class="col-md-5 col-xs-12 col-sm-6 p0">
                    <div class="tv1">
                        <img src="../../resources/img/icon/icon_datve_disable.png" class="img-responsive" alt="Đặt vé và thanh toán" />
                    </div>
                    <div class="tv2">02</div>
                    <div class="tv3">
                        <span class="b1">&nbsp;</span>
                        <div class="b1tv">ĐẶT VÉ<span class="b1tv tt"> & THANH TOÁN</span></div>
                    </div>
                    <div class="tv4">
                        <img src="../../resources/img/icon/icon-next.png" />
                    </div>
                </div>
                <div class="col-md-3 col-xs-12 col-sm-3 p0">
                    <div class="tv1">
                        <img src="../../resources/img/icon/icon_nhanve_enable.png" class="img-responsive" alt="Nhận vé" />
                    </div>
                    <div class="tv2">03</div>
                    <div class="tv3">
                        <span class="b1">&nbsp;</span><br />
                        <span class="b1tv disable">NHẬN VÉ</span>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <asp:Literal ID="ltrError" runat="server" />
    <div class="message container" ng-controller="Step3Controller" id="dvmain" runat="server">
        <div class="row">
            <div class="col-sm-6 col-sm-offset-3">
                <h4 class="text-center text-bold">CHÚC MỪNG QUÝ KHÁCH ĐÃ ĐẶT VÉ THÀNH CÔNG</h4>
                <p class="text-center">
                    Vexedientu sẽ thực hiện giao vé cho Quý khách trong vòng 24h tại nội thành Hà Nội. Nếu sau 24h quý khách
    không nhận được vé vui lòng liên hệ hotline: <span class="color-green">096 5682 268</span> để được hỗ trợ. Xin cảm ơn!
                </p>
            </div>
        </div>
        <div class="row tbNhanve">
            <div class="col-sm-12 tbnv_header">
                <div class="pull-left">
                    <h3 class="color-white">THÔNG TIN ĐẶT VÉ</h3>
                </div>
                <div class="pull-right">
                    <h5>Mã đơn hàng: <%=order.Order_Code %></h5>
                </div>
            </div>
            <div class="col-sm-6" id="col-1">
                <h3>1. Thông tin vé xe</h3>
                <table class="table tbl-nv">
                    <tbody>
                        <tr>
                            <td>Vé xe đi từ:</td>
                            <td><%=chuyenxe.Diemdi %> <span class="text-success"><i class="fa fa-arrow-right"></i></span><%=chuyenxe.Diemden %></td>
                        </tr>
                        <tr>
                            <td>Hãng xe:</td>
                            <td><%=chuyenxe.Xe.NhaXe1.Tennhaxe %></td>
                        </tr>
                        <tr>
                            <td>Đón khách tại:</td>
                            <td><%=chuyenxe.Diemdi %></td>
                        </tr>
                        <tr>
                            <td>Trả khách tại:</td>
                            <td><%=chuyenxe.Diemden %></td>
                        </tr>
                        <tr>
                            <td>Giờ khởi hành:</td>
                            <td><%=chuyenxe.Giokhoihanh %> - <%=chuyenxe.Ngaydi.Value.ToString("dd/MM/yyyy") %></td>
                        </tr>
                        <tr>
                            <td>Khoảng thời gian đi:</td>
                            <td><%=chuyenxe.Thoigiandukien %></td>
                        </tr>
                        <tr>
                            <td>Loại ghế:</td>
                            <td><%=order.Order_Thuong %> Thường, <%=order.Order_Vip %> VIP</td>
                        </tr>
                        <tr>
                            <td>Số lượng chỗ:</td>
                            <td><%=order.Order_Thuong %> chỗ Thường, <%=order.Order_Vip %> chỗ VIP</td>
                        </tr>
                        <tr>
                            <td>Tiện ích:</td>
                            <td><%=chuyenxe.Mota %></td>
                        </tr>
                    </tbody>
                </table>
            </div>
            <div class="col-sm-6" id="col-2">
                <h3>2. Thông tin khách hàng</h3>
                <table class="table tbl-nv">
                    <tr>
                        <td>Tên khách hàng:</td>
                        <td><%=order.Order_Account.HasValue?order.Order_Ten:member.Member_Name %></td>
                    </tr>
                    <tr>
                        <td>Số điện thoại:</td>
                        <td><%=order.Order_Account.HasValue?order.Order_Tel:member.Member_Phone %></td>
                    </tr>
                    <tr>
                        <td>Email:</td>
                        <td><%=string.IsNullOrEmpty(order.Order_Email)?order.Order_Ten:member.Member_Email %></td>
                    </tr>
                    <tr>
                        <td>Địa chỉ:</td>
                        <td><%=string.IsNullOrEmpty(order.Order_Address)?order.Order_Ten:member.Member_Address %></td>
                    </tr>
                    <tr>
                        <td>Hình thức thanh toán:</td>
                        <td><%=method.Name %></td>
                    </tr>
                    <tr>
                        <td>Tổng tiền:</td>
                        <td><span class="color-red"><%=order.Order_Tongtien.Value.ToString("N0") %></span> đ</td>
                    </tr>
                </table>
            </div>
        </div>
    </div>
</div>



