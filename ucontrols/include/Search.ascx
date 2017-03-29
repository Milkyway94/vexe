<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Search.ascx.cs" Inherits="ucontrols_include_Search" %>
<div ng-controller="SearchController">
    <div class="tk-top">
        <div class="s-result" ng-show="showResult">
            <div class="container">
                <div class="col-sm-4">
                    <div class="row form-group">
                        <span class="sm-title">Vé xe đi từ: </span><span class="ttitle">{{Diemdi}}</span><span class="mt fa fa-long-arrow-right"></span><span class="ttitle">{{Diemden}}</span>
                    </div>
                </div>
                <div class="col-sm-4 form-group">
                    <div class="col-sm-3 tn-title">Ngày đi</div>
                    <div class="col-sm-9 ip-search">
                        <input type="text" name="Ngaydi" class="form-control nd-input ngaydi" readonly="readonly" ng-model="Ngaydi" />
                        <i class="input-icon fa fa-calendar"></i>
                    </div>
                </div>
                <div class="col-sm-2 form-group">
                    <button type="button" ng-click="showSearch=!showSearch" class="btn btn-block btn-search">
                        <span ng-show="showSearch==false" class="color-white">Tìm vé khác</span>
                        <span ng-show="showSearch==true" class="color-white">Đóng</span>
                    </button>
                </div>
                <div class="col-sm-2 form-group">
                    <span class="ttitle">Bạn cần hỗ trợ?</span><br />
                    <span>Gọi ngay: 0912310691</span>
                </div>
            </div>
        </div>
        <form id="frmSearch" class="frmsearch" method="get" action="/tim-ve-xe.htm" ng-submit="Search()" ng-show="showSearch">
            <div class="container">
                <div class="row">
                    <div class="col-sm-6">
                        <div class="row">
                            <div class="col-sm-5">
                                <div class="row ipt-search">
                                    <i class="fa fa-map-marker pre-icon-input"></i>
                                    <autocomplete ng-model="Diemdi" name="Diemdi" autocompleterequired="required" data="Diemdies" placeholder="Chọn điểm đi"></autocomplete>
                                    <%--<input type="text" placeholder="Chọn điểm đi" tabindex="1" id="Autocomplete" required="required" class="form-control ngaydi" name="Diemdi" ng-autocomplete ng-model="Diemdi" details="details2" options="options2" />--%>
                                </div>
                            </div>
                            <div class="col-sm-2">
                                <a class="color-white text-bold pl15" ng-click="DaoTuyen()" href="#"><i class="fa fa-arrows-h fa-2x"></i></a>
                            </div>
                            <div class="col-sm-5">
                                <div class="row ipt-search">
                                    <i class="fa fa-map-marker pre-icon-input"></i>
                                    <autocomplete ng-model="Diemden" autocompleterequired="required" name="Diemden" data="Diemdies" placeholder="Chọn điểm đến"></autocomplete>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="col-sm-4">
                        <div class="col-sm-8">
                            <input type="Text" ng-model="Ngaydi" tabindex="3" name="Ngaydi" class="btn form-control ngaydi datepicker" />
                            <i class="input-icon fa fa-calendar"></i>
                        </div>
                        <div class="col-sm-4">
                            <button class="btn btn-datve" tabindex="4" type="submit" ng-disabled="loading" ng-class="loading?'disabled':''"><span ng-hide="loading"><i class="fa fa-ticket"></i>Tìm vé</span><span ng-show="loading">Đang tìm <i class="fa fa-spinner fa-pulse fa-fw"></i></span></button>
                        </div>
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
                                            <div class="pull-left">
                                                <p class="title-xe">&nbsp;{{item.NhaXe.Tennhaxe}}</p>
                                                <p class="title-chuyen">({{item.Xe.Tenxe}})</p>
                                                <span class="link-cx"><a href="#">Lịch trình</a> | <a href="#">Hình ảnh</a> | <a href="#">Tiện ích</a></span>
                                            </div>
                                        </div>
                                        <div class="col-sm-3" id="c2">
                                            <p class="title-xe">{{item.Giokhoihanh}} <i class="fa fa-long-arrow-right"></i> {{item.Giotoi}}</p>
                                            <p>Thời gian: <b>{{item.Thoigiandukien}}</b></p>
                                        </div>
                                        <div class="col-sm-2" id="c3"><a class="tn-title color-black" href="#" ng-click="Detail(item)">Chi tiết</a></div>
                                        <div class="col-sm-3" id="c4">
                                            <p><span class="gia-ve">{{item.GiaThuong | currency :"": 0}} đ</span></p>
                                            <button class="btn btn-datve btn-dv1" ng-show="item.VeVipConLai==0 && item.VeThuongConLai==0" ng-disabled="true" ng-class="item.VeVipConLai==0 && item.VeThuongConLai==0?'hetve':''" ng-click="DatVe(item)"><i class="fa fa-car"></i>&nbsp;Hết vé</button>
                                            <button class="btn btn-datve btn-dv1" ng-hide="item.VeVipConLai==0 && item.VeThuongConLai==0" ng-disabled="false" ng-class="item.VeVipConLai==0 && item.VeThuongConLai==0?'hetve':''" ng-click="DatVe(item)"><i class="fa fa-car"></i>&nbsp;Đặt vé</button>
                                        </div>
                                    </div>
                                    <div class="col-sm-12 displaynone br1" id="row-{{item.MaChuyenXe}}" ng-show="item ===Selected">
                                        <div class="row">
                                            <div class="col-sm-12">
                                                <div class="row">
                                                    <div class="vbody">
                                                        <div class="row">
                                                            <div class="col-sm-6">
                                                                <table class="table">
                                                                    <tr>
                                                                        <td class="text-bold">Hãng xe: </td>
                                                                        <td class="text-bold gia-ve">{{Selected.NhaXe.Tennhaxe}}</td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td class="text-bold">Giờ xuất bến: </td>
                                                                        <td class="text-bold">{{Selected.Giokhoihanh}}</td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td class="text-bold">Giờ tới bến: </td>
                                                                        <td>{{Selected.Giotoi}}</td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td class="text-bold">SĐT Lái xe: </td>
                                                                        <td>{{Selected.SDT}}</td>
                                                                    </tr>
                                                                </table>
                                                            </div>
                                                            <div class="col-sm-6">
                                                                <table class="table">
                                                                    <tr>
                                                                        <td class="text-bold">Số chỗ: </td>
                                                                        <td class="text-bold">{{Selected.TongVe}}</td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td class="text-bold">Tiện ích xe: </td>
                                                                        <td class="text-bold">{{Selected.Mota}}</td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td class="text-bold">Giá niêm yết: </td>
                                                                        <td class=text-bold">{{Selected.GiaThuong | currency:"":0}} đ</td>
                                                                    </tr>
                                                                    <tr ng-show="Selected.KhuyenMai>0">
                                                                        <td class="text-bold">Khuyến mãi: </td>
                                                                        <td class="color-green">{{Selected.KhuyenMai}} %</td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td class="text-bold">Tổng tiền: </td>
                                                                        <td class="gia-ve">{{(Selected.GiaThuong-(Selected.GiaThuong*Selected.KhuyenMai/100))|currency:"":0}} đ</td>
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
                <asp:Literal ID="ltrAdvertisment" runat="server" />
            </div>
        </div>
    </div>
</div>

