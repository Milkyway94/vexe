<%@ Control Language="C#" AutoEventWireup="true" CodeFile="CheckOut.ascx.cs" Inherits="ucontrols_CheckOut" %>
<%-- Đặt vé và thanh toán --%>
<div ng-controller="CheckOutController">
    <div class="datve fw">
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
                        <img src="../../resources/img/icon/icon-vethanhtoan.png" class="img-responsive" alt="Đặt vé và thanh toán" />
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
                        <img src="../../resources/img/icon/icon-nhanve.png" class="img-responsive" alt="Nhận vé" />
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
    <div class="checkout fw">
        <div class="container">
            <div class="row">
                <div class="col-sm-4 bdr1">
                    <h3>Chọn hình thức thanh toán</h3>
                    <ul class="uk-nav uk-nav-default" id="hi-checked" uk-switcher="connect: #component-nav,#my-id-one; animation: uk-animation-fade; toggle: > :not(.uk-nav-header)">
                        <li class="type-avn">
                            <a href="#" ng-click="selectedMethod(1)">
                                <img src="../../resources/img/icon/icon-atm.png" alt="Thanh toán qua ATM" class="fl" />
                                <div class="box-content">
                                    <h5>Thanh toán qua thẻ ATM</h5>
                                    <p>Thanh toán trực tiếp bằng thẻ ATM của hầu hết các ngân hàng ở Việt Nam</p>
                                </div>
                            </a>
                        </li>
                        <li class="type-avn">
                            <a href="#" ng-click="selectedMethod(2)">
                                <img src="../../resources/img/icon/icon-visa.png" alt="Thanh toán qua ATM" class="fl" />
                                <div class="box-content">
                                    <h5>Thanh toán bằng thẻ tín dụng</h5>
                                    <p>Thanh toán trực tiếp qua thẻ Visa</p>
                                </div>
                            </a>
                        </li>
                        <li class="type-avn">
                            <a href="#" ng-click="selectedMethod(3)">
                                <img src="../../resources/img/icon/icon-nganluong.png" alt="Thanh toán qua ATM" class="fl" />
                                <div class="box-content">
                                    <h5>Thanh toán qua số dư Ngân Lượng</h5>
                                    <p>Tạo tài khoản và thanh toán trên nganluong.vn</p>
                                </div>
                            </a>
                        </li>
                        <li class="type-snv">
                            <a href="#" ng-click="selectedMethod(4)">
                                <img src="../../resources/img/icon/icon-saunhanve.png" alt="Thanh toán qua ATM" class="fl" />
                                <div class="box-content">
                                    <h5>Thanh toán khi nhận vé</h5>
                                    <p>Trả tiền cho nhân viên giao vé sau khi nhận & kiểm tra vé tại nhà của bạn</p>
                                </div>
                            </a>
                        </li>
                        <li class="type-vola">
                            <a href="#" ng-click="selectedMethod(5)">
                                <img src="../../resources/img/icon/icon-diemtv.png" alt="Thanh toán qua ATM" class="fl" />
                                <div class="box-content">
                                    <h5>Thanh toán bằng điểm thành viên <span class="text-vola">(Vola)</span></h5>
                                    <p>
                                        Sử dụng điểm thành viên để thanh toán<br />
                                        <span class="text-primary"><i>Nạp điểm thành viên tại đây</i></span>
                                    </p>
                                </div>
                            </a>
                        </li>
                        <li class="type-datcho">
                            <a href="#" ng-click="selectedMethod(6)">
                                <img src="../../resources/img/icon/icon-datcho.png" alt="Thanh toán qua ATM" class="fl" />
                                <div class="box-content">
                                    <h5>Thanh toán khi lên xe (Đặt chỗ)</h5>
                                    <p>Thanh toán trực tiếp bằng thẻ ATM của hầu hết các ngân hàng ở Việt Nam</p>
                                </div>
                            </a>
                        </li>
                    </ul>
                </div>
                <div class="col-sm-4">
                    <ul id="my-id-one" class="uk-switcher">
                        <li>Nếu bạn đã có tài khoản tại vedientu.vn<br />
                            vui lòng <a ng-click="Login()">Đăng nhập</a> tại đây!<br />
                            <h3>Thông tin của bạn</h3>
                            <p>Dấu <span class="s">(*)</span> là trường bắt buộc nhập</p>
                            <form>
                                <div class="form-group">
                                    Họ và tên: <span class="s">*</span>
                                    <div class="uk-form-controls">
                                        <input class="form-control" id="txt_name" type="text" placeholder="Là Họ tên để xác nhận khi lên xe">
                                    </div>
                                </div>
                                <div class="form-group">
                                    Email: <span class="s">*</span>
                                    <div class="uk-form-controls">
                                        <input class="form-control" id="txt_email" type="text" placeholder="Là Email để hệ thống gửi mã vé xe điện tử">
                                    </div>
                                </div>
                                <div class="form-group">
                                    Số điện thoại: <span class="s">*</span>
                                    <div class="uk-form-controls">
                                        <input class="form-control" id="txt_phone" type="text" placeholder="Là SĐT để xác nhận khi lên xe">
                                    </div>
                                </div>
                                <div class="form-group">
                                    Địa chỉ: <span class="s">*</span>
                                    <div class="uk-form-controls">
                                        <textarea class="form-control" rows="3" placeholder="VD: Ngõ 59 đường Văn Tiến Dũng, Nam Từ Liêm, Hà Nội"></textarea>
                                    </div>
                                </div>
                            </form>
                        </li>
                        <li>Nếu bạn đã có tài khoản tại vedientu.vn<br />
                            vui lòng <a ng-click="Login()">Đăng nhập</a> tại đây!<br />
                            <h3>Thông tin của bạn</h3>
                            <p>Dấu <span class="s">(*)</span> là trường bắt buộc nhập</p>
                            <form>
                                <div class="form-group">
                                    Họ và tên: <span class="s">*</span>
                                    <div class="uk-form-controls">
                                        <input class="form-control" id="txt_name" type="text" placeholder="Là Họ tên để xác nhận khi lên xe">
                                    </div>
                                </div>
                                <div class="form-group">
                                    Email: <span class="s">*</span>
                                    <div class="uk-form-controls">
                                        <input class="form-control" id="txt_email" type="text" placeholder="Là Email để hệ thống gửi mã vé xe điện tử">
                                    </div>
                                </div>
                                <div class="form-group">
                                    Số điện thoại: <span class="s">*</span>
                                    <div class="uk-form-controls">
                                        <input class="form-control" id="txt_phone" type="text" placeholder="Là SĐT để xác nhận khi lên xe">
                                    </div>
                                </div>
                                <div class="form-group">
                                    Địa chỉ: <span class="s">*</span>
                                    <div class="uk-form-controls">
                                        <textarea class="form-control" rows="3" placeholder="VD: Ngõ 59 đường Văn Tiến Dũng, Nam Từ Liêm, Hà Nội"></textarea>
                                    </div>
                                </div>
                            </form>
                        </li>
                        <li>Nếu bạn đã có tài khoản tại vedientu.vn<br />
                            vui lòng <a href="#">Đăng nhập</a> tại đây!<br />
                            <h3>Thông tin của bạn</h3>
                            <p>Dấu <span class="s">(*)</span> là trường bắt buộc nhập</p>
                            <form>
                                <div class="form-group">
                                    Họ và tên: <span class="s">*</span>
                                    <div class="uk-form-controls">
                                        <input class="form-control" id="txt_name" type="text" placeholder="Là Họ tên để xác nhận khi lên xe">
                                    </div>
                                </div>
                                <div class="form-group">
                                    Email: <span class="s">*</span>
                                    <div class="uk-form-controls">
                                        <input class="form-control" id="txt_email" type="text" placeholder="Là Email để hệ thống gửi mã vé xe điện tử">
                                    </div>
                                </div>
                                <div class="form-group">
                                    Số điện thoại: <span class="s">*</span>
                                    <div class="uk-form-controls">
                                        <input class="form-control" id="txt_phone" type="text" placeholder="Là SĐT để xác nhận khi lên xe">
                                    </div>
                                </div>
                                <div class="form-group">
                                    Địa chỉ: <span class="s">*</span>
                                    <div class="uk-form-controls">
                                        <textarea class="form-control" rows="3" placeholder="VD: Ngõ 59 đường Văn Tiến Dũng, Nam Từ Liêm, Hà Nội"></textarea>
                                    </div>
                                </div>
                            </form>
                        </li>
                        <li>
                            <span class="text-danger">*</span> Bạn cần <a href="#" ng-click="Login()"><b>Đăng nhập</b></a> để thực hiện chức năng này. Nếu bạn chưa có tài khoản xin vui lòng <a href="/dang-ki.htm" class="text-res">Đăng ký</a> tại đây.
                            <p><%=Session["Email"] %></p>
                        </li>
                        <li><span class="text-danger">*</span> Bạn cần <a ng-click="Login()"><b>Đăng nhập</b></a> để thực hiện chức năng này. Nếu bạn chưa có tài khoản xin vui lòng <a href="/dang-ki.htm" class="text-res">Đăng ký</a> tại đây.</li>
                        <li><span class="text-danger">*</span> Bạn cần <a ng-click="Login()"><b>Đăng nhập</b></a> để thực hiện chức năng này. Nếu bạn chưa có tài khoản xin vui lòng <a href="/dang-ki.htm" class="text-res">Đăng ký</a> tại đây.</li>
                    </ul>
                </div>
                <div class="col-sm-4 bdl1">
                    <div class="component-nav">
                        <h3>Thông tin chuyến đi</h3>
                        <table class="table tbl-info">
                            <tr>
                                <td>Hãng xe:</td>
                                <td><%=cx.Xe.NhaXe1.Tennhaxe %></td>
                            </tr>
                            <tr>
                                <td>Điểm xuất phát:</td>
                                <td><%=cx.Diemdi %></td>
                            </tr>
                            <tr>
                                <td>Điểm đến:</td>
                                <td><%=cx.Diemden %></td>
                            </tr>
                            <tr>
                                <td>Giờ đi:</td>
                                <td><%=cx.Giokhoihanh.Value.ToString("HH:mm - dd/MM/yyyy") %></td>
                            </tr>
                            <tr>
                                <td>Thời gian đi dự kiến:</td>
                                <td><%=cx.Thoigiandukien.Value.Hours %> giờ <%=cx.Thoigiandukien.Value.Minutes %> phút </td>
                            </tr>
                            <tr>
                                <td>Số vé còn lại: </td>
                                <td>
                                    <table class="table tbl-info">
                                        <tr>
                                            <td>Thường: </td>
                                            <td class="text-right"><%=cx.VeThuongConLai %> vé</td>
                                        </tr>
                                        <tr>
                                            <td>Vip: </td>
                                            <td class="text-right"><%=cx.VeVipConLai %> vé</td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                            <tr>
                                <td>Chọn số lượng vé:</td>
                                <td>
                                    <input type="number" min="0" ng-change="updateTicket()" max="<%=cx.VeVipConLai %>" ng-model="selectedTicket.VIP" />
                                    vé VIP</td>
                            </tr>
                            <tr>
                                <td></td>
                                <td>
                                    <input type="number" min="0" ng-change="updateTicket()" max="<%=cx.VeThuongConLai %>" ng-model="selectedTicket.THUONG" />
                                    vé Thường
                                </td>
                            </tr>
                        </table>
                        <%--<div class="chair">
                            <div class="item-chair">
                                <img src="../../resources/img/icon/icon-ghevip.png" alt="Alternate Text" />&nbsp;Ghế VIP:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <b><%=cx.GiaVIP.HasValue?cx.GiaVIP.Value.ToString("N0")+" VNĐ":"Hết" %></b>&nbsp;
                            </div>
                            <div class="item-chair">
                                <img src="../../resources/img/icon/icon-ghethuong.png" alt="Alternate Text" />&nbsp;Ghế thường: <b><%=cx.GiaThuong.HasValue?cx.GiaThuong.Value.ToString("N0")+"&nbsp;VNĐ":"Hết" %></b>
                            </div>
                            <div class="item-chair">
                                <img src="../../resources/img/icon/icon-dadat.png" alt="Alternate Text" />&nbsp;Ghế đã đặt
                            </div>
                        </div>--%>
                        <form name="frmThanhToan">
                            <table class="tbl-thanhtoan table">
                                <tr ng-hide="Method==5">
                                    <td>
                                        <b>Tổng tiền</b>
                                    </td>
                                    <td>{{TongTien | currency:"":0}} VNĐ</td>
                                    <td><span class="doive" ng-hide="Method==6">
                                        <input type="checkbox" ng-model="Exchange" class="displaynone" value="" />
                                        <img src="../../resources/img/icon/icon-doive.png" ng-show="isExchage==true" ng-click="isExchage=!isExchage" />
                                        <img src="../../resources/img/icon/icon-uncheck-doive.png" ng-show="isExchage==false" ng-click="isExchage=!isExchage" />
                                        Đổi vé </span></td>
                                </tr>
                                <tr ng-show="isExchage" ng-show="Method!=5 && Method!=6">
                                    <td colspan="2">
                                        <input class="form-control" type="text" ng-model="Mavedoi" name="name" value="" placeholder="Nhập mã vé cũ" /></td>
                                    <td>
                                        <button class="btn btn-success" ng-disabled="loadding" ng-click="DoiVe()"><span ng-hide="loadding">Kiểm tra</span><span ng-show="loadding">Đang kiểm tra <i class="fa fa-spinner fa-pulse fa-fw"></i></span></button>
                                    </td>
                                </tr>
                                <tr ng-show="isExchage" ng-show="Method!=5 && Method!=6">
                                    <td colspan="3">
                                        <div class="uk-alert-danger" ng-show="showerror" uk-alert>
                                            <a class="uk-alert-close" ng-click="showerror=false"></a>
                                            <p>{{message}}</p>
                                        </div>
                                        <span class="text-primary">Số tiền giảm trừ: <b>{{GiaTriVeCu | currency:"":0}}</b> Vnđ</span>
                                    </td>
                                </tr>
                                <tr ng-show="Method!=5">
                                    <td>Bạn có mã giảm giá?</td>
                                    <td>
                                        <input type="text" class="form-control" name="name" ng-model="MaKhuyenMai" style="width: 125px" value="" placeholder="VD:NHT25091995" />
                                    </td>
                                    <td>
                                        <button class="btn btn-success" ng-disabled="loaddingKM" ng-click="CheckPromote()"><span ng-hide="loaddingKM">Áp dụng</span><span ng-show="loaddingKM">Đang kiểm tra...<i class="fa fa-spinner fa-pulse fa-fw"></i></span></button></td>
                                </tr>
                                <tr ng-show="showErrorKM" ng-show="Method!=5">
                                    <td colspan="3">
                                        <div class="uk-alert-{{alertType}}" ng-show="showErrorKM" uk-alert>
                                            <p>{{message}}</p>
                                        </div>
                                        <span class="text-primary">Số tiền khuyến mãi: <b class="text-danger">{{KhuyenMai | currency:"":0}}</b> vnđ <a ng-click="KhuyenMai=0" ng-show="KhuyenMai!=0" class="text-danger">(Bỏ áp dụng &times;)</a></span>
                                    </td>
                                </tr>
                                <tr ng-show="Method==4">
                                    <td colspan="3">
                                        <fieldset>
                                            <legend>Địa chỉ nhận vé</legend>
                                            <div class="form-group row">
                                                <select ng-model="Province" id="province" ng-change="SelectDistrict()" data-placeholder="Chọn tỉnh" ng-options="option.text for option in Tinhs track by option.id" class="form-control select2">
                                                    <option style="display: none" value="">select a type</option>
                                                </select>
                                            </div>
                                            <div class="form-group row">
                                                <select ng-model="District" id="district" class="form-control select2" ng-options="option.text for option in Huyens track by option.id" data-placeholder="Chọn huyện">
                                                    <option style="display: none" value="">select a type</option>
                                                </select>
                                            </div>
                                            <textarea ng-model="Address" id="address" class="form-control" placeholder="Nhập địa chỉ chính xác (Số nhà, thôn tổ, phường xã)" required></textarea>
                                        </fieldset>
                                        <span class="text-danger" ng-show="!Address || !District || !Province" ng-focus="!Address">Bạn phải chọn và nhập đầy đủ Địa chỉ nhận hàng.</span>
                                    </td>
                                </tr>
                                <tr ng-hide="Method==5">
                                    <td><b>TỔNG THANH TOÁN</b></td>
                                    <td colspan="2"><b class="text-danger">{{(TongTien-KhuyenMai-GiaTriVeCu)|currency:"":0}} VNĐ</b></td>
                                </tr>
                            </table>
                            <!--Vola-->
                            <table class="tbl-thanhtoan table" ng-show="Method==5">
                                <tr>
                                    <td>
                                        <b>Tổng thanh toán</b>
                                    </td>
                                    <td>280.000  &nbsp;<span class="text-vola">Vola</span></td>
                                    <td><a href="#" class="doive">
                                        <img src="../../resources/img/icon/icon-doive.png" />
                                        Đổi vé </a></td>
                                </tr>
                                <tr>
                                    <td colspan="2">
                                        <input class="form-control" type="text" name="name" value="" placeholder="Nhập mã vé cũ" /></td>
                                    <td>
                                        <button class="btn btn-success">Kiểm tra</button></td>
                                </tr>
                                <tr>
                                    <td colspan="3"><span class="text-primary">Số <span class="text-vola">Vola</span> giảm trừ: <b>100.000</b><span class="text-vola">Vola</span></span></td>
                                </tr>
                                <tr>
                                    <td>Bạn có mã giảm giá?</td>
                                    <td>
                                        <input type="text" class="form-control" name="name" style="width: 125px" value="" placeholder="VD:NHT25091995" />
                                    </td>
                                    <td><span class="text-success">Kiểm tra</span></td>
                                </tr>
                                <tr>
                                    <td colspan="3" style="border-top: none !important; text-align: center">
                                        <span class="text-danger" ng-show="isCheckPromote"><i>Mã số không hợp lệ</i></span>
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="2">Số dư  <span class="text-vola">Vola</span> hiện tại:</td>
                                    <td><b>560</b></td>
                                </tr>
                                <tr>
                                    <td colspan="2">Số <span class="text-vola">Vola</span> sử dụng:</td>
                                    <td><b>280</b></td>
                                </tr>
                                <tr>
                                    <td colspan="2">Số <span class="text-vola">Vola</span> được giảm trừ:</td>
                                    <td><b>100</b></td>
                                </tr>
                                <tr>
                                    <td colspan="2">Số dư  <span class="text-vola">Vola</span> còn lại:</td>
                                    <td><b>380</b></td>
                                </tr>
                            </table>
                            <button class="btn btn-success btn-accept" type="submit" ng-disabled="loadding && !Address" ng-click="ThanhToan()"><span ng-hide="loadding">Thanh toán</span><span ng-show="loadding">Đang thực hiện... <i class="fa fa-spinner fa-pulse fa-fw"></i></span></button>
                        </form>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <div class="alert alert-warning alert-toast alert-dismissable" ng-show="showAlert">
        <a class="close" ng-click="showAlert=false" aria-label="close">×</a>
        <strong><i class="fa fa-warning"></i></strong>{{alertMsg}}
    </div>
    <div class="container">
        <!-- Modal -->
        <div class="modal fade" id="LoginModal" role="dialog">
            <div class="modal-dialog">
                <!-- Modal content-->
                <div class="modal-content">
                    <div class="modal-header">
                        <button type="button" class="close" data-dismiss="modal">&times;</button>
                        <span class="glyphicon glyphicon-lock"></span>ĐĂNG NHẬP HỆ THỐNG
                    </div>
                    <div class="modal-body">
                        <form role="form">
                            <div ng-if="loadding" class="uk-alert-warning" uk-alert>
                                <a class="uk-alert-close" uk-close></a>
                                <p>
                                    <span class="uk-margin-small-right" uk-icon="icon: ban">{{loginMsg}}</span>
                                </p>
                            </div>
                    </div>
                    <div class="form-group">
                        <label for="usrname"><span class="glyphicon glyphicon-user"></span>Email hoặc số điện thoại</label>
                        <input id="txtUsername" type="text" ng-model="login.username" class="form-control" placeholder="Nhập email hoặc số điện thoại" />
                    </div>
                    <div class="form-group">
                        <label for="usrname"><span class="glyphicon glyphicon-lock"></span>Mật khẩu</label>
                        <input id="txtPassword" ng-model="login.password" type="Password" class="form-control" placeholder="Nhập mật khẩu của bạn" />
                    </div>
                    <div class="form-group">
                        <button id="btnLogin" ng-click="doLogin()" ng-disabled="loadding" class="btn btn-success btn-block"><i class="fa fa-key"></i>Đăng nhập <i class="fa fa-spinner" ng-show="loadding"></i></button>
                    </div>
                    </form>
                </div>
            </div>

        </div>
    </div>
</div>
</div>

