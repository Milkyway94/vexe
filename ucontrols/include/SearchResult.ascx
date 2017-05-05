<%@ Control Language="C#" AutoEventWireup="true" CodeFile="SearchResult.ascx.cs" Inherits="ucontrols_include_Search" %>
<div ng-controller="SearchController">
    <div class="modal fade" id="YCModal" role="dialog">
        <div class="modal-dialog modal-yc">
            <!-- Modal content-->
            <div class="modal-content">
                <div class="modal-header">
                    <button type="button" class="close" data-dismiss="modal">&times;</button>
                    <h4 class="modal-title ">Tạo yêu cầu đi xe</h4>
                </div>
                <div class="modal-body">
                    <h5 class="color-green" ng-show="showError">{{message}}</h5>
                    <form id="frmYcdx" ng-submit="SaveYC()">
                        <table class="table">
                            <tr>
                                <td>Bạn muốn đi từ</td>
                                <td class="autocomplete">
                                    <input type="text" placeholder="Chọn điểm đi" ng-model="YcDiemDi" maxlength="100" class="form-control txtdi diadiem" />
                                    <i class="icon-input glyphicon glyphicon-menu-down"></i>
                                </td>
                                <td class="tx">Đến</td>
                                <td class="autocomplete">
                                    <input type="text" ng-model="YcDiemDen" placeholder="Chọn điểm đến" maxlength="100" class="form-control txtdi diadiem" />
                                    <i class="icon-input glyphicon glyphicon-menu-down"></i>
                                </td>
                            </tr>
                            <tr>
                                <td>Vào ngày</td>
                                <td style="position: relative">
                                    <input type="text" ng-model="YcNgaydi" id="ycNgaydi" class="txtdi datepicker" placeholder="Chọn ngày đi" required />
                                    <i class="input-icon fa fa-calendar"></i>
                                </td>
                                <td class="tx">Giờ đi</td>
                                <td class="slGiodi" style="position: relative">
                                    <input type="text" class="form-control txtdi timepicker" data-provide="timepicker" required="required" ng-model="frmSearch.Giodi" placeholder="Chọn thời gian đi" />
                                    <i class="input-icon glyphicon glyphicon-menu-down"></i>
                                </td>
                            </tr>
                            <tr>
                                <td>Yêu cầu thêm</td>
                                <td colspan="3">
                                    <textarea class="form-control txtdi" name="ycthem" ng-model="YcMore" placeholder="VD:Tôi muốn dừng ở Văn Điển"></textarea>
                                </td>
                            </tr>
                            <tr>
                                <td></td>
                                <td><span class="text-danger">{{sdtError}}</span></td>
                            </tr>
                            <tr>
                                <td>Số điện thoại của bạn là:</td>
                                <td colspan="3">
                                    <input type="text" name="sdt" class="txtdi" maxlength="14" ng-model="YcSdt" placeholder="VD: 0123456789" required />
                                </td>
                            </tr>
                        </table>
                        <ul class="dsYc">
                            <li>Yêu cầu của bạn sẽ được chuyển đến các nhà xe có thể đáp ứng được.</li>
                            <li>Các nhà xe sẽ chủ động liên hệ với bạn theo số điện thoại <b>{{YcSdt}}</b>.</li>
                            <li>Sau khi đồng ý với nhà xe vui lòng <a href="/login.htm">Đăng nhập</a> lại hệ thống để <b>Hủy yêu cầu</b>.</li>
                        </ul>
                        <div class="row">
                            <div class="col-sm-6">
                                <button class="btn btn-warning pull-left" type="button" ng-show="showError" onclick="$('#YCModal').modal('hide')">Đóng</button>
                            </div>
                            <div class="col-sm-6">
                                <button class="btn btn-success btn-yc pull-right" type="submit" ng-class="loading?'disabled':''"><span class="ycdx text-bold" ng-hide="loading">GỬI YÊU CẦU</span><span class="ycdx text-bold" ng-show="loading">Đang lưu <i class="fa fa-spinner fa-pulse fa-fw"></i></span></button>
                            </div>
                        </div>
                    </form>
                </div>
            </div>
        </div>
    </div>
    <div class="tk-top">
        <div class="s-result" ng-show="showResult">
            <div class="container">
                <div class="col col-1">
                    <span class="sm-title hidden-xs">Vé xe đi từ: </span><span class="ttitle">{{Diemdi}}</span>&nbsp;<span class="mt fa fa-long-arrow-right color-green"></span>&nbsp;<span class="ttitle">{{Diemden}}</span>
                </div>
                <div class="col col-2 tn-title hidden-xs">
                    <span>Ngày đi:</span>
                </div>
                <div class="col col-3 ip-search">
                    <input type="text" name="Ngaydi" class="form-control nd-input ngaydi" readonly="readonly" ng-model="Ngaydi" />
                    <i class="input-icon fa fa-calendar"></i>
                </div>
                <div class="col col-4">
                    <button type="button" ng-click="showSearch=!showSearch" class="btn btn-block btn-success">
                        <span ng-show="showSearch==false" class="color-white text-bold">Tìm vé xe khác</span>
                        <span ng-show="showSearch==true" class="color-white text-bold">Đóng</span>
                    </button>
                </div>
                <div class="col col-5">
                    <span class="ttitle">Bạn cần hỗ trợ?</span><br />
                    <span>Gọi ngay: 0912310691</span>
                </div>
            </div>
        </div>
        <form id="frmSearch" class="frmsearch" method="get" ng-submit="Search()" ng-show="showSearch">
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
                <div class="col col-sm-2 pl30">
                    <div class="row">
                        <button class="btn btn-datve" tabindex="4" type="submit" ng-disabled="loading" ng-class="loading?'disabled':''"><span ng-hide="loading"><i class="fa fa-ticket"></i>Tìm vé</span><span ng-show="loading">Đang tìm <i class="fa fa-spinner fa-pulse fa-fw"></i></span></button>
                    </div>
                </div>
            </div>
        </form>
    </div>
    <div class="tk-content container">
        <div class="row">
            <div class="col-sm-9">
                <table class="table" id="tblSearch" autofocus>
                    <thead>
                        <tr>
                            <th>
                                <div class="dropdown col-sm-3">
                                    <input ng-model="sSelected.Nhaxe" ng-hide="true" />
                                    <span class="circle"><i class="fa fa-bus icon-circle"></i></span>
                                    <button class="btn btn-fake dropdown-toggle" type="button" id="btnNhaxe" data-toggle="dropdown">Nhà xe&nbsp;<span class="caret"></span></button>
                                    <ul class="dropdown-menu" role="menu" aria-labelledby="menu1">
                                        <li role="presentation"><a role="menuitem" tabindex="-1" href="#" ng-click="SortByNhaXe(0)">Tất cả Nhà xe</a></li>
                                        <li role="presentation" ng-repeat="item in Nhaxes"><a role="menuitem" tabindex="-1" href="#" ng-click="SortByNhaXe(item)">{{item.Tennhaxe}}</a></li>
                                    </ul>
                                </div>
                                <div class="dropdown col-sm-4 text-center">
                                    <input ng-model="sSelected.Giodi" ng-hide="true" />
                                    <span class="circle"><i class="fa fa-clock-o icon-circle"></i></span>
                                    <button class="btn btn-fake dropdown-toggle" type="button" id="btnGiodi" data-toggle="dropdown">Giờ xuất phát&nbsp;<span class="caret"></span></button>
                                    <ul class="dropdown-menu" role="menu" aria-labelledby="menu1">
                                        <li role="presentation"><a role="menuitem" tabindex="-1" href="#" ng-click="SortByGiodi(0)">Tất cả các giờ</a></li>
                                        <li ng-repeat="item in Giodies" role="presentation"><a role="menuitem" tabindex="-1" ng-click="SortByGiodi(item)" href="#">{{item.Giokhoihanh}}</a></li>
                                    </ul>
                                </div>
                                <div class="col-sm-2 dropdown text-center">
                                    <span class="circle"><i class="fa fa-info icon-circle"></i></span>
                                    <span>Chi tiết</span>
                                </div>
                                <div class="col-sm-3 dropdown text-center">
                                    <span class="circle"><i class="fa fa-ticket icon-circle"></i></span>
                                    <span>Giá vé</span>
                                    <span class="caret"></span>
                                </div>
                            </th>
                        </tr>
                    </thead>
                    <tbody>
                        <tr>
                            <td>
                                <div class="col-sm-12 ck-row" ng-repeat="item in SearchResult | filterBy: ['Xe.NhaXe1.Tennhaxe']:sSelected.Nhaxe | filterBy: ['Giokhoihanh']:sSelected.Giodi | filterBy: ['Xe.Hangxe']:sSelected.Hangxe">
                                    <div class="row">
                                        <div class="col-sm-4" id="c1">
                                            <div class="pull-left p5 xe-icon">
                                                <i class="fa fa-bus"></i>
                                            </div>
                                            <div class="pull-left ten-xe">
                                                <p class="title-xe">&nbsp;{{item.NhaXe.Tennhaxe}}</p>
                                                <p class="title-chuyen">({{item.Xe.Tenxe}} | Còn trống: <b>{{item.VeThuongConLai+item.VeVipConLai}}</b> ghế)</p>
                                                <span class="link-cx"><a href="javascript:void(0)" ng-click="Detail(item)">Lịch trình</a></span>
                                            </div>
                                        </div>
                                        <div class="col-sm-3" id="c2">
                                            <p><span class="title-date">{{item.Giokhoihanh}}&nbsp;<i class="fa fa-long-arrow-right"></i></span>&nbsp;<span class="title-time">{{item.Giotoi}}</span></p>
                                            <p>Thời gian: <b>{{item.Thoigiandukien}}</b></p>
                                        </div>
                                        <div class="col-sm-2" id="c3"><a class="title-date color-black underline" href="#" ng-click="Detail(item)">Chi tiết</a></div>
                                        <div class="col-sm-3" id="c4">
                                            <p><span class="gia-ve">{{item.GiaThuong | currency :"": 0}} đ</span></p>
                                            <button class="btn btn-datve btn-dv1" ng-show="item.VeVipConLai==0 && item.VeThuongConLai==0" ng-disabled="true" ng-class="item.VeVipConLai==0 && item.VeThuongConLai==0?'hetve':''" ng-click="DatVe(item)">Hết vé</button>
                                            <button class="btn btn-datve btn-dv1" ng-hide="item.VeVipConLai==0 && item.VeThuongConLai==0" ng-disabled="false" ng-class="item.VeVipConLai==0 && item.VeThuongConLai==0?'hetve':''" ng-click="DatVe(item)">Đặt vé</button>
                                        </div>
                                    </div>
                                    <div class="col-sm-12 displaynone br1" id="row-{{item.MaChuyenXe}}" ng-show="item ===Selected">
                                        <div class="row">
                                            <div class="col-sm-12">
                                                <div class="row">
                                                    <div class="vbody">
                                                        <div class="row">
                                                            <div class="col-sm-6">
                                                                <table class="table tbl-detail">
                                                                    <tr>
                                                                        <td>Hãng xe: </td>
                                                                        <td class="gia-ve">{{Selected.NhaXe.Tennhaxe}}</td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td>Giờ xuất bến: </td>
                                                                        <td>{{Selected.Giokhoihanh}}</td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td>Giờ tới bến: </td>
                                                                        <td>{{Selected.Giotoi}}</td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td>SĐT Lái xe: </td>
                                                                        <td>{{Selected.SDT}}</td>
                                                                    </tr>
                                                                </table>
                                                            </div>
                                                            <div class="col-sm-6">
                                                                <table class="table tbl-detail">
                                                                    <tr>
                                                                        <td>Số chỗ: </td>
                                                                        <td>{{Selected.TongVe}}</td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td>Số ghế còn trống: </td>
                                                                        <td>{{item.VeThuongConLai+item.VeVipConLai}} ghế</td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td>Tiện ích xe: </td>
                                                                        <td>{{Selected.Mota}}</td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td>Giá niêm yết: </td>
                                                                        <td>{{Selected.GiaThuong | currency:"":0}} đ</td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td>Khuyến mãi: </td>
                                                                        <td class="color-green">{{Selected.KhuyenMai}} %</td>
                                                                    </tr>
                                                                </table>
                                                            </div>
                                                        </div>

                                                    </div>
                                                    <div class="vheader">
                                                        <span class="vheader-title">{{Selected.LoTrinh}}</span>
                                                    </div>
                                                </div>

                                            </div>
                                        </div>
                                    </div>
                                </div>

                            </td>
                        </tr>
                    </tbody>
                </table>
            </div>
            <div class="col-sm-3">
                <%
                    if (Session["MemberId"] == null || rq == new QCMS_BUSSINESS.RequestTravel() || rq == null)
                    {%>
                <div class="sb-right">
                    <h3 class="ycdx">Tạo yêu cầu đi xe</h3>
                    <div class="desc">
                        <span class="ycdx-sm">Bạn tạo yêu cầu đi xe, các nhà
                            <br />
                            xe sẽ chủ động liên hệ với bạn.</span>
                    </div>

                    <button type="button" data-toggle="modal" data-target="#YCModal" class="btn-create">Tạo yêu cầu</button>

                </div>
                <%}
                    else
                    {%>
                <div class="sb-right">
                    <h3 class="ycdx">Hủy yêu cầu đi xe</h3>
                    <span class="ycdx-sm">Bạn hủy yêu cầu đi xe, các thông tin
                            <br />
                        bạn nhập sẽ được xóa bỏ.</span>
                    <button type="button" data-toggle="modal" data-target="#YCModal" class="btn-create">Hủy yêu cầu</button>
                </div>
                <%}

                %>
                <div class="w100">
                    <asp:Literal ID="ltrAdvertisment" runat="server" />
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
</div>

