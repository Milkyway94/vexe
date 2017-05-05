<%@ Control Language="C#" AutoEventWireup="true" CodeFile="doSearch.ascx.cs" Inherits="ucontrols_include_doSearch" %>
<div ng-controller="DoSearchController">
    <div class="row" id="row-1">
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
    </div>
    <div class="row" id="row-2">
        <div class="tk-top">
            <form id="frmSearch" class="frmsearch" method="get" ng-submit="Search()">
                <div class="container">
                    <div class="col col-sm-2">
                        <div class="row ipt-search autocomplete">
                            <i class="fa fa-map-marker pre-icon-input"></i>
                            <input type="text" class="form-control diadiem" placeholder="Chọn điểm đi" ng-model="frmSearch.Diemdi" />
                            <i class="icon-input glyphicon glyphicon-menu-down"></i>
                        </div>
                    </div>
                    <div class="col col-sm-1">
                        <a class="color-white text-bold pl15" ng-click="DaoTuyen()" href="#"><i class="fa fa-arrows-h fa-2x"></i></a>
                    </div>
                    <div class="col col-sm-2">
                        <div class="row ipt-search autocomplete">
                            <i class="fa fa-map-marker pre-icon-input"></i>
                            <input type="text" class="form-control diadiem" placeholder="Chọn điểm đến" ng-model="frmSearch.Diemden" />
                            <i class="icon-input glyphicon glyphicon-menu-down"></i>
                        </div>
                    </div>
                    <div class="col col-sm-2 pl30">
                        <div class="row">
                            <input type="Text" ng-model="frmSearch.Ngaydi" placeholder="Chọn ngày đi" required="required" tabindex="3" name="Ngaydi" id="ngaydi" class="btn form-control ngaydi datepicker" />
                            <i class="input-icon fa fa-calendar"></i>
                        </div>
                    </div>
                    <div class="col col-sm-2 pl30 ipt-search">
                        <div class="row autocomplete">
                            <input type="text" class="form-control timepicker" required="required" ng-model="frmSearch.Giodi" placeholder="Chọn thời gian đi" />
                            <i class="icon-input glyphicon glyphicon-menu-down"></i>
                        </div>
                    </div>
                    <div class="col col-sm-2 pl30">
                        <div class="row">
                            <button class="btn btn-datve" tabindex="4" type="submit" ng-disabled="loading" ng-class="loading?'disabled':''"><span ng-hide="loading"><i class="fa fa-ticket"></i>Tìm vé</span><span ng-show="loading">Đang tìm <i class="fa fa-spinner fa-pulse fa-fw"></i></span></button>
                        </div>
                    </div>
                </div>
            </form>
        </div>
    </div>
    <div class="row">
        <div class="popular">
            <div class="container content-popular">
                <h1>Các tuyến xe phổ biến</h1>
                <asp:Literal Text="" ID="ltrPioriryFrom" runat="server" />
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
        </div>
    </div>

</div>

