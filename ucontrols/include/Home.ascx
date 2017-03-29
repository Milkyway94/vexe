﻿<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Home.ascx.cs" Inherits="ucontrols_include_Home" %>
<div id="main" ng-controller="HomeController">
    <div class="container main-content">
        <div class="row">
            <div class="col-md-12 col-xs-12 col-sm-12 title-dv">
                <h1>Đặt vé xe điện tử với 3 bước</h1>
            </div>
        </div>
        <style>
            .bg-position {
                /*  background: url("../../resources/img/icon/bg-next.png") no-repeat;
                background-position: right 10px;*/
                position: relative;
            }

            .tv4 {
                position: absolute;
                top: 15px;
                right: -20px;
            }
        </style>
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
                <img src="../../resources/img/icon/bg-next.png" class="tv4" />
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
                <img src="../../resources/img/icon/bg-next.png" class="tv4" />
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
                <img src="../../resources/img/icon/bg-next.png" class="tv4-last" />
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
                                <autocomplete ng-model="Diemdi" placeholder="Chọn điểm xuất phát" name="Diemdi" data="Diemdies"></autocomplete>
                                <%--<input type="text" id="Autocomplete" name="Diemdi" placeholder="Nhập điểm đi" class="form-control" ng-autocomplete ng-model="Diemdi" details="details2" options="options2"/>--%>
                            </div>
                        </div>
                        <div class="form-group row">
                            <div class="col-sm-12">
                                <autocomplete ng-model="Diemden" placeholder="Chọn điểm đến" name="Diemden" data="Diemdies"></autocomplete>
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
        <h1>Các tuyến xe phổ biến</h1>
        <ul class="nav nav-pills">
            <li class="active"><a data-toggle="pill" href="#home">Hà Nội</a></li>
            <li><a data-toggle="pill" href="#menu1">TP. Hồ Chí Minh</a></li>
            <li><a data-toggle="pill" href="#menu2">Đà Nẵng</a></li>
            <li><a data-toggle="pill" href="#menu3">Hải Phòng</a></li>
            <li><a data-toggle="pill" href="#menu3">Nha Trang</a></li>
        </ul>
        <div class="tab-content">
            <div id="home" class="tab-pane fade in active">
                <div class="row">
                    <asp:Literal Text="" ID="PopularTravel" runat="server" />
                    <div class="col-sm-6 popular">
                        <div class="col-sm-5 name">
                            <span class="diemdi">Hà Nội</span>
                            <span class="fa fa-long-arrow-right muiten"></span>
                            <span class="diemden">TP.Hồ Chí Minh</span>
                        </div>
                        <div class="col-sm-4 name">
                            <span class="gia">269,000 đ/vé</span>
                        </div>
                        <div class="col-sm-3 btn-area">
                            <a href="#" class="btn btn-flat btn-datve">Đặt vé</a>
                        </div>
                    </div>
                    <div class="col-sm-6 popular">
                        <div class="col-sm-5 name">
                            <span class="diemdi">Hà Nội</span>
                            <span class="fa fa-long-arrow-right muiten"></span>
                            <span class="diemden">TP.Hồ Chí Minh</span>
                        </div>
                        <div class="col-sm-4 name">
                            <span class="gia">269,000 đ/vé</span>
                        </div>
                        <div class="col-sm-3 btn-area">
                            <a href="#" class="btn btn-flat btn-datve">Đặt vé</a>
                        </div>
                    </div>
                    <div class="col-sm-6 popular">
                        <div class="col-sm-5 name">
                            <span class="diemdi">Hà Nội</span>
                            <span class="fa fa-long-arrow-right muiten"></span>
                            <span class="diemden">TP.Hồ Chí Minh</span>
                        </div>
                        <div class="col-sm-4 name">
                            <span class="gia">269,000 đ/vé</span>
                        </div>
                        <div class="col-sm-3 btn-area">
                            <a href="#" class="btn btn-flat btn-datve">Đặt vé</a>
                        </div>
                    </div>
                    <div class="col-sm-6 popular">
                        <div class="col-sm-5 name">
                            <span class="diemdi">Hà Nội</span>
                            <span class="fa fa-long-arrow-right muiten"></span>
                            <span class="diemden">TP.Hồ Chí Minh</span>
                        </div>
                        <div class="col-sm-4 name">
                            <span class="gia">269,000 đ/vé</span>
                        </div>
                        <div class="col-sm-3 btn-area">
                            <a href="#" class="btn btn-flat btn-datve">Đặt vé</a>
                        </div>
                    </div>
                    <div class="col-sm-6 popular">
                        <div class="col-sm-5 name">
                            <span class="diemdi">Hà Nội</span>
                            <span class="fa fa-long-arrow-right muiten"></span>
                            <span class="diemden">TP.Hồ Chí Minh</span>
                        </div>
                        <div class="col-sm-4 name">
                            <span class="gia">269,000 đ/vé</span>
                        </div>
                        <div class="col-sm-3 btn-area">
                            <a href="#" class="btn btn-flat btn-datve">Đặt vé</a>
                        </div>
                    </div>
                    <div class="col-sm-6 popular">
                        <div class="col-sm-5 name">
                            <span class="diemdi">Hà Nội</span>
                            <span class="fa fa-long-arrow-right muiten"></span>
                            <span class="diemden">TP.Hồ Chí Minh</span>
                        </div>
                        <div class="col-sm-4 name">
                            <span class="gia">269,000 đ/vé</span>
                        </div>
                        <div class="col-sm-3 btn-area">
                            <a href="#" class="btn btn-flat btn-datve">Đặt vé</a>
                        </div>
                    </div>
                </div>
            </div>
            <div id="menu1" class="tab-pane fade">
                <div class="row">
                    <asp:Literal Text="" ID="Literal1" runat="server" />
                    <div class="col-sm-6 popular">
                        <div class="col-sm-5 name">
                            <span class="diemdi">Hà Nội</span>
                            <span class="fa fa-long-arrow-right muiten"></span>
                            <span class="diemden">TP.Hồ Chí Minh</span>
                        </div>
                        <div class="col-sm-4 name">
                            <span class="gia">269,000 đ/vé</span>
                        </div>
                        <div class="col-sm-3 btn-area">
                            <a href="#" class="btn btn-flat btn-datve">Đặt vé</a>
                        </div>
                    </div>
                    <div class="col-sm-6 popular">
                        <div class="col-sm-5 name">
                            <span class="diemdi">Hà Nội</span>
                            <span class="fa fa-long-arrow-right muiten"></span>
                            <span class="diemden">TP.Hồ Chí Minh</span>
                        </div>
                        <div class="col-sm-4 name">
                            <span class="gia">269,000 đ/vé</span>
                        </div>
                        <div class="col-sm-3 btn-area">
                            <a href="#" class="btn btn-flat btn-datve">Đặt vé</a>
                        </div>
                    </div>
                    <div class="col-sm-6 popular">
                        <div class="col-sm-5 name">
                            <span class="diemdi">Hà Nội</span>
                            <span class="fa fa-long-arrow-right muiten"></span>
                            <span class="diemden">TP.Hồ Chí Minh</span>
                        </div>
                        <div class="col-sm-4 name">
                            <span class="gia">269,000 đ/vé</span>
                        </div>
                        <div class="col-sm-3 btn-area">
                            <a href="#" class="btn btn-flat btn-datve">Đặt vé</a>
                        </div>
                    </div>
                    <div class="col-sm-6 popular">
                        <div class="col-sm-5 name">
                            <span class="diemdi">Hà Nội</span>
                            <span class="fa fa-long-arrow-right muiten"></span>
                            <span class="diemden">TP.Hồ Chí Minh</span>
                        </div>
                        <div class="col-sm-4 name">
                            <span class="gia">269,000 đ/vé</span>
                        </div>
                        <div class="col-sm-3 btn-area">
                            <a href="#" class="btn btn-flat btn-datve">Đặt vé</a>
                        </div>
                    </div>
                    <div class="col-sm-6 popular">
                        <div class="col-sm-5 name">
                            <span class="diemdi">Hà Nội</span>
                            <span class="fa fa-long-arrow-right muiten"></span>
                            <span class="diemden">TP.Hồ Chí Minh</span>
                        </div>
                        <div class="col-sm-4 name">
                            <span class="gia">269,000 đ/vé</span>
                        </div>
                        <div class="col-sm-3 btn-area">
                            <a href="#" class="btn btn-flat btn-datve">Đặt vé</a>
                        </div>
                    </div>
                    <div class="col-sm-6 popular">
                        <div class="col-sm-5 name">
                            <span class="diemdi">Hà Nội</span>
                            <span class="fa fa-long-arrow-right muiten"></span>
                            <span class="diemden">TP.Hồ Chí Minh</span>
                        </div>
                        <div class="col-sm-4 name">
                            <span class="gia">269,000 đ/vé</span>
                        </div>
                        <div class="col-sm-3 btn-area">
                            <a href="#" class="btn btn-flat btn-datve">Đặt vé</a>
                        </div>
                    </div>
                </div>
            </div>
            <div id="menu2" class="tab-pane fade">
                <div class="row">
                    <asp:Literal Text="" ID="Literal2" runat="server" />
                    <div class="col-sm-6 popular">
                        <div class="col-sm-5 name">
                            <span class="diemdi">Hà Nội</span>
                            <span class="fa fa-long-arrow-right muiten"></span>
                            <span class="diemden">TP.Hồ Chí Minh</span>
                        </div>
                        <div class="col-sm-4 name">
                            <span class="gia">269,000 đ/vé</span>
                        </div>
                        <div class="col-sm-3 btn-area">
                            <a href="#" class="btn btn-flat btn-datve">Đặt vé</a>
                        </div>
                    </div>
                    <div class="col-sm-6 popular">
                        <div class="col-sm-5 name">
                            <span class="diemdi">Hà Nội</span>
                            <span class="fa fa-long-arrow-right muiten"></span>
                            <span class="diemden">TP.Hồ Chí Minh</span>
                        </div>
                        <div class="col-sm-4 name">
                            <span class="gia">269,000 đ/vé</span>
                        </div>
                        <div class="col-sm-3 btn-area">
                            <a href="#" class="btn btn-flat btn-datve">Đặt vé</a>
                        </div>
                    </div>
                    <div class="col-sm-6 popular">
                        <div class="col-sm-5 name">
                            <span class="diemdi">Hà Nội</span>
                            <span class="fa fa-long-arrow-right muiten"></span>
                            <span class="diemden">TP.Hồ Chí Minh</span>
                        </div>
                        <div class="col-sm-4 name">
                            <span class="gia">269,000 đ/vé</span>
                        </div>
                        <div class="col-sm-3 btn-area">
                            <a href="#" class="btn btn-flat btn-datve">Đặt vé</a>
                        </div>
                    </div>
                    <div class="col-sm-6 popular">
                        <div class="col-sm-5 name">
                            <span class="diemdi">Hà Nội</span>
                            <span class="fa fa-long-arrow-right muiten"></span>
                            <span class="diemden">TP.Hồ Chí Minh</span>
                        </div>
                        <div class="col-sm-4 name">
                            <span class="gia">269,000 đ/vé</span>
                        </div>
                        <div class="col-sm-3 btn-area">
                            <a href="#" class="btn btn-flat btn-datve">Đặt vé</a>
                        </div>
                    </div>
                    <div class="col-sm-6 popular">
                        <div class="col-sm-5 name">
                            <span class="diemdi">Hà Nội</span>
                            <span class="fa fa-long-arrow-right muiten"></span>
                            <span class="diemden">TP.Hồ Chí Minh</span>
                        </div>
                        <div class="col-sm-4 name">
                            <span class="gia">269,000 đ/vé</span>
                        </div>
                        <div class="col-sm-3 btn-area">
                            <a href="#" class="btn btn-flat btn-datve">Đặt vé</a>
                        </div>
                    </div>
                    <div class="col-sm-6 popular">
                        <div class="col-sm-5 name">
                            <span class="diemdi">Hà Nội</span>
                            <span class="fa fa-long-arrow-right muiten"></span>
                            <span class="diemden">TP.Hồ Chí Minh</span>
                        </div>
                        <div class="col-sm-4 name">
                            <span class="gia">269,000 đ/vé</span>
                        </div>
                        <div class="col-sm-3 btn-area">
                            <a href="#" class="btn btn-flat btn-datve">Đặt vé</a>
                        </div>
                    </div>
                </div>
            </div>
            <div id="menu3" class="tab-pane fade">
                <div class="row">
                    <asp:Literal Text="" ID="Literal3" runat="server" />
                    <div class="col-sm-6 popular">
                        <div class="col-sm-5 name">
                            <span class="diemdi">Hà Nội</span>
                            <span class="fa fa-long-arrow-right muiten"></span>
                            <span class="diemden">TP.Hồ Chí Minh</span>
                        </div>
                        <div class="col-sm-4 name">
                            <span class="gia">269,000 đ/vé</span>
                        </div>
                        <div class="col-sm-3 btn-area">
                            <a href="#" class="btn btn-flat btn-datve">Đặt vé</a>
                        </div>
                    </div>
                    <div class="col-sm-6 popular">
                        <div class="col-sm-5 name">
                            <span class="diemdi">Hà Nội</span>
                            <span class="fa fa-long-arrow-right muiten"></span>
                            <span class="diemden">TP.Hồ Chí Minh</span>
                        </div>
                        <div class="col-sm-4 name">
                            <span class="gia">269,000 đ/vé</span>
                        </div>
                        <div class="col-sm-3 btn-area">
                            <a href="#" class="btn btn-flat btn-datve">Đặt vé</a>
                        </div>
                    </div>
                    <div class="col-sm-6 popular">
                        <div class="col-sm-5 name">
                            <span class="diemdi">Hà Nội</span>
                            <span class="fa fa-long-arrow-right muiten"></span>
                            <span class="diemden">TP.Hồ Chí Minh</span>
                        </div>
                        <div class="col-sm-4 name">
                            <span class="gia">269,000 đ/vé</span>
                        </div>
                        <div class="col-sm-3 btn-area">
                            <a href="#" class="btn btn-flat btn-datve">Đặt vé</a>
                        </div>
                    </div>
                    <div class="col-sm-6 popular">
                        <div class="col-sm-5 name">
                            <span class="diemdi">Hà Nội</span>
                            <span class="fa fa-long-arrow-right muiten"></span>
                            <span class="diemden">TP.Hồ Chí Minh</span>
                        </div>
                        <div class="col-sm-4 name">
                            <span class="gia">269,000 đ/vé</span>
                        </div>
                        <div class="col-sm-3 btn-area">
                            <a href="#" class="btn btn-flat btn-datve">Đặt vé</a>
                        </div>
                    </div>
                    <div class="col-sm-6 popular">
                        <div class="col-sm-5 name">
                            <span class="diemdi">Hà Nội</span>
                            <span class="fa fa-long-arrow-right muiten"></span>
                            <span class="diemden">TP.Hồ Chí Minh</span>
                        </div>
                        <div class="col-sm-4 name">
                            <span class="gia">269,000 đ/vé</span>
                        </div>
                        <div class="col-sm-3 btn-area">
                            <a href="#" class="btn btn-flat btn-datve">Đặt vé</a>
                        </div>
                    </div>
                    <div class="col-sm-6 popular">
                        <div class="col-sm-5 name">
                            <span class="diemdi">Hà Nội</span>
                            <span class="fa fa-long-arrow-right muiten"></span>
                            <span class="diemden">TP.Hồ Chí Minh</span>
                        </div>
                        <div class="col-sm-4 name">
                            <span class="gia">269,000 đ/vé</span>
                        </div>
                        <div class="col-sm-3 btn-area">
                            <a href="#" class="btn btn-flat btn-datve">Đặt vé</a>
                        </div>
                    </div>
                </div>
            </div>
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