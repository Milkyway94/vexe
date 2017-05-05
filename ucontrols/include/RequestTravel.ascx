<%@ Control Language="C#" AutoEventWireup="true" CodeFile="RequestTravel.ascx.cs" Inherits="ucontrols_include_Home" %>
<div id="main" ng-controller="HomeController">
    <div class="container main-content">
        <div class="row">
            <div class="col-md-12 col-xs-12 col-sm-12 title-dv">
                <h1>Đặt vé xe điện tử với 3 bước</h1>
            </div>
        </div>
        <div class="row" id="r1">
            <div class="col-md-4 col-xs-12 col-sm-3 bg-position">
                <div class="tv1">
                    <img src="../../resources/img/icon/icon-timve.png" class="img-responsive" alt="Vé thanh toán" />
                </div>
                <div class="tv2">01</div>
                <div class="tv3">
                    <span class="b1">Bước 1</span><br />
                    <span class="b1tv">TÌM VÉ</span>
                </div>
                <img src="../../resources/img/icon/icon-next.png" class="tv4" />
            </div>
            <div class="col-md-5 col-xs-12 col-sm-6 bg-position">
                <div class="tv1">
                    <img src="../../resources/img/icon/icon-nhanve.png" class="img-responsive" alt="Vé thanh toán" />
                </div>
                <div class="tv2">02</div>
                <div class="tv3">
                    <span class="b1">Bước 2</span>
                    <div class="b1tv">ĐẶT VÉ<span class="b1tv tt"> & THANH TOÁN</span></div>
                </div>
                <img src="../../resources/img/icon/icon-next.png" class="tv4" />
            </div>
            <div class="col-md-3 col-xs-12 col-sm-3 bg-position">
                <div class="tv1">
                    <img src="../../resources/img/icon/icon-vethanhtoan.png" class="img-responsive" alt="nhận vé" />
                </div>
                <div class="tv2">03</div>
                <div class="tv3">
                    <span class="b1">Bước 3</span><br />
                    <span class="b1tv">NHẬN VÉ</span>
                </div>
            </div>
        </div>
        <div class="row" id="r2">
            <div class="col-sm-12 col-md-5 col-xs-12">
                <div class="search-form">
                    <form id="frmSearch1" action="/tim-ve-xe.htm" method="get" onsubmit="TimVeXe()">
                        <div class="form-group row">
                            <div class="col-sm-12">
                                <h2 class="form-title">Tìm kiếm vé xe</h2>
                            </div>
                        </div>
                        <div class="form-group row">
                            <div class="col-sm-12">
                                <autocomplete ng-model="Diemdi" inputclass="form-control" placeholder="Chọn điểm xuất phát" name="Diemdi" data="Diemdies"></autocomplete>
                                <%--<input type="text" id="Autocomplete" name="Diemdi" placeholder="Nhập điểm đi" class="form-control" ng-autocomplete ng-model="Diemdi" details="details2" options="options2"/>--%>
                            </div>
                        </div>
                        <div class="form-group row">
                            <div class="col-sm-12">
                                <autocomplete ng-model="Diemden" inputclass="form-control" placeholder="Chọn điểm đến" name="Diemden" data="Diemdies"></autocomplete>
                            </div>
                        </div>
                        <div class="form-group row">
                            <div class="col-sm-12 col-md-6 col-xs-12 wleft">
                                <input type="text" class="form-control datepicker" name="Ngaydi" placeholder="Chọn ngày đi" />
                                <span class="input-icon"><i class="fa fa-calendar"></i></span>
                            </div>
                            <div class="col-sm-12 col-md-6 col-xs-12 wright">
                                <select class="form-control select2" name="Thoigiandi">
                                    <option value="">Thời gian đi</option>
                                    <option value="5:00">5:00</option>
                                    <option value="5:00">6:00</option>
                                    <option value="5:00">7:00</option>
                                    <option value="5:00">8:00</option>
                                    <option value="5:00">9:00</option>
                                    <option value="5:00">10:00</option>
                                    <option value="5:00">11:00</option>
                                    <option value="5:00">12:00</option>
                                </select>
                            </div>
                        </div>
                        <div class="form-group row row-margin">
                            <div class="col-sm-12">
                                <button class="btn btn-block btn-search" id="btnSearch" type="submit">
                                    Tìm vé <i class="fa fa-spinner" style="display: none;" aria-hidden="true"></i>
                                </button>
                            </div>
                        </div>
                    </form>
                </div>
            </div>
            <div class="col-sm-12 col-md-7 col-xs-12">
                <div id="myCarousel" class="carousel slide" data-ride="carousel">
                    <!-- Indicators -->
                    <ol class="carousel-indicators">
                        <asp:Literal Text="" ID="ltrbannercouter" runat="server" />
                    </ol>

                    <!-- Wrapper for slides -->
                    <div class="carousel-inner" role="listbox">
                        <asp:Literal ID="ltrbanner" runat="server"></asp:Literal>
                    </div>

                    <!-- Left and right controls -->
                    <a class="left carousel-control" href="#myCarousel" role="button" data-slide="prev">
                        <span class="fa fa-arrow-circle-o-left" aria-hidden="true"></span>
                        <span class="sr-only">Previous</span>
                    </a>
                    <a class="right carousel-control" href="#myCarousel" role="button" data-slide="next">
                        <span class="fa fa-arrow-circle-o-right" aria-hidden="true"></span>
                        <span class="sr-only">Next</span>
                    </a>
                </div>
            </div>
        </div>
    </div>
</div>
<div class="popular">
    <div class="container content-popular">
        <h1 class="heading-title">Danh sách khách hàng tạo yêu cầu đi tuyến mà bạn có</h1>
        <p class="text-danger text-center text-18 text-bold text-italic">Lái xe lưu ý khách hàng đồng ý lên xe hãy báo khách hàng  đăng nhập lại hệ thống để Hủy yêu cầu</p>
        <div class="table-responsive">
            <table class="tbYeucau">
                <tr>
                    <th>STT</th>
                    <th>Đi từ</th>
                    <th>Đến</th>
                    <th>Số điện thoại</th>
                    <th>Ngày/tháng</th>
                    <th>Giờ</th>
                    <th>Yêu cầu khác</th>
                </tr>
                <tr>
                    <asp:Literal Text="" ID="ltrListRequest" runat="server" />
                </tr>
            </table>
        </div>

    </div>
    <div class="container content-thanhtoan">
        <div class="thanhtoan">
            <h3 class="col-sm-3">Chấp nhận thanh toán: </h3>
            <div class="col-sm-9">
                <a href="#" onclick="event.preventDefault();">
                    <img src="/resources/img/thanhtoan.png" alt="Chấp nhận thanh toán" class="img-responsive" /></a>
            </div>
        </div>
    </div>
    <div class="container content-xe">
        <ul class="uk-grid-small uk-child-width-1-2 uk-child-width-1-5@s uk-text-center" uk-grid>
            <li class="xe">
                <a href="#">
                    <img src="/resources/img/oto.png" alt="Tuyến đường" />
                    <span class="tenxe">Hà Nội</span>
                </a>
            </li>
            <li class="xe">
                <a href="#">
                    <img src="/resources/img/oto.png" alt="Tuyến đường" />
                    <span class="tenxe">Hà Nội</span>
                </a>
            </li>
            <li class="xe">
                <a href="#">
                    <img src="/resources/img/oto.png" alt="Tuyến đường" />
                    <span class="tenxe">Hà Nội</span>
                </a>
            </li>
            <li class="xe">
                <a href="#">
                    <img src="/resources/img/oto.png" alt="Tuyến đường" />
                    <span class="tenxe">Hà Nội</span>
                </a>
            </li>
            <li class="xe">
                <a href="#">
                    <img src="/resources/img/oto.png" alt="Tuyến đường" />
                    <span class="tenxe">Hà Nội</span>
                </a>
            </li>
            <li class="xe">
                <a href="#">
                    <img src="/resources/img/oto.png" alt="Tuyến đường" />
                    <span class="tenxe">Hà Nội</span>
                </a>
            </li>
            <li class="xe">
                <a href="#">
                    <img src="/resources/img/oto.png" alt="Tuyến đường" />
                    <span class="tenxe">Hà Nội</span>
                </a>
            </li>
            <li class="xe">
                <a href="#">
                    <img src="/resources/img/oto.png" alt="Tuyến đường" />
                    <span class="tenxe">Hà Nội</span>
                </a>
            </li>
            <li class="xe">
                <a href="#">
                    <img src="/resources/img/oto.png" alt="Tuyến đường" />
                    <span class="tenxe">Hà Nội</span>
                </a>
            </li>
            <li class="xe">
                <a href="#">
                    <img src="/resources/img/oto.png" alt="Tuyến đường" />
                    <span class="tenxe">Hà Nội</span>
                </a>
            </li>
        </ul>
    </div>
</div>
