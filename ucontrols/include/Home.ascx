<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Home.ascx.cs" Inherits="ucontrols_include_Home" %>
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
                    <span class="b1"></span>
                    <br />
                    <span class="b1tv">TÌM VÉ</span>
                </div>
                <img src="../../resources/img/icon/bg-next.png" class="tv4" />
            </div>
            <div class="col-md-5 col-xs-12 col-sm-6 bg-position">
                <div class="tv1">
                    <img src="../../resources/img/icon/icon-vethanhtoan.png" class="img-responsive" alt="Đặt vé và thanh toán" />
                </div>
                <div class="tv2">02</div>
                <div class="tv3">
                    <span class="b1">&nbsp;</span>
                    <div class="b1tv">ĐẶT VÉ<span class="b1tv tt"> & THANH TOÁN</span></div>
                </div>
                <img src="../../resources/img/icon/bg-next.png" class="tv4" />
            </div>
            <div class="col-md-3 col-xs-12 col-sm-3 bg-position">
                <div class="tv1">
                    <img src="../../resources/img/icon/icon-nhanve.png" class="img-responsive" alt="NHận vé" />
                </div>
                <div class="tv2">03</div>
                <div class="tv3">
                    <span class="b1"></span>
                    <br />
                    <span class="b1tv">NHẬN VÉ</span>
                </div>
            </div>
        </div>
        <div class="row" id="r2">
            <div class="col-sm-12 col-md-5 col-xs-12">
                <div class="search-form">
                    <form id="frmSearch1" method="get" ng-submit="TimVeXe()">
                        <div class="col-sm-12">
                            <h2 class="form-title">Tìm kiếm vé xe</h2>
                        </div>
                        <div class="form-group row">
                            <div class="col-sm-12">
                                 <div class="autocomplete">
                                <input ng-model="frmSearch.Diemdi" id="Diemdi" placeholder="Chọn điểm đi" class="form-control diadiem" required />
                                <i class="icon-input glyphicon glyphicon-menu-down"></i>
                                     </div>
                            </div>
                        </div>
                        <div class="form-group row ">
                            <div class="col-sm-12">
                                 <div class="autocomplete">
                                <input ng-model="frmSearch.Diemden" id="Diemden" placeholder="Chọn điểm đến" class="form-control diadiem" required />
                                <i class="icon-input glyphicon glyphicon-menu-down"></i>
                                     </div>
                            </div>
                        </div>
                        <div class="form-group row">
                            <div class="col-sm-12 col-md-6 col-xs-12 wleft">
                                 <div class="autocomplete">
                                <input type="text" class="form-control datepicker" required="required" ng-model="frmSearch.Ngaydi" name="Ngaydi" placeholder="Chọn ngày đi" />
                                <span class="icon-input"><i class="fa fa-calendar"></i></span>
                                     </div>
                            </div>
                            <div class="col-sm-12 col-md-6 col-xs-12 wright">
                                <div class="autocomplete">
                                    <input type="text" class="form-control timepicker" data-provide="timepicker" required="required" ng-model="frmSearch.Giodi" placeholder="Chọn thời gian đi" />
                                    <span class="icon-input"><i class="glyphicon glyphicon-menu-down"></i></span>
                                </div>
                            </div>
                        </div>
                        <div class="form-group row row-margin">
                            <div class="col-sm-12">
                                <button class="btn btn-block btn-search" id="btnSearch" type="submit">
                                    Tìm vé <i class="fa fa-spinner fa-pulse fa-fw" ng-if="loadding" aria-hidden="true"></i>
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
    <div class="container content-xe">
        <div class="row">
            <ul class="uk-grid-small uk-child-width-1-2 uk-child-width-1-5@s uk-text-center" uk-grid>
                <% foreach (var item in lstNhaxe())
                    {%>
                <li class="xe">
                    <a href="/nha-xe.htm?nha-xe-o-tinh=<%=item.TenTinh %>">
                        <img src="/resources/img/oto.png" alt="Tuyến đường" />
                        <span class="tenxe"><%=item.TenTinh %></span>
                    </a>
                </li>
                <%} %>
            </ul>
        </div>
    </div>
</div>
