<%@ Control Language="C#" AutoEventWireup="true" CodeFile="CheckTicket.ascx.cs" Inherits="ucontrols_include_CheckTicket" %>
<%-- Kiểm tra vé --%>
<script src='https://www.google.com/recaptcha/api.js'></script>
<div class="fw kiemtrave" ng-controller="CheckTicketController">
    <div class="container">
        <ul class="uk-breadcrumb hi-padding">
            <asp:Literal ID="lbnav" runat="server" Text=""></asp:Literal>
        </ul>
        <div class="row">
            <div class="col-sm-6 col-sm-offset-3">
                <div class="row">
                    <div class="fw check-ticket">
                        <h3 class="text-center">Kiểm tra vé</h3>
                        <form ng-submit="CheckTicket()">
                            <div class="form-group">
                                <span class="alert alert-danger" ng-show="showerror">{{msgAlert}}</span>
                            </div>
                            <div class="form-group">
                                <input type="text" class="form-control" ng-model="mave" placeholder="Mã vé xe" />
                            </div>
                            <div class="form-group">
                                <input type="text" class="form-control" ng-model="sdt" placeholder="Số điện thoại" />
                            </div>
                            <div class="col-sm-6">
                                <div class="g-recaptcha" data-sitekey="6LeLyRkUAAAAAMQfrXty1U-kwfeGn4ZmAJkCl9wn"></div>
                            </div>
                            <div class="col-sm-6">
                                <button class="btn btn-success btn-pa" ng-disabled="loadding" type="submit">
                                    <span ng-hide="loadding"><i class="fa fa-ticket"></i>Kiểm tra vé</span><span ng-show="loadding">Đang kiểm tra... <i class="fa fa-spinner fa-pulse fa-fw"></i></span>
                                </button>
                            </div>
                        </form>
                    </div>
                </div>
            </div>

        </div>
    </div>
    <div class="container">
        <div class="alert alert-danger h5" ng-show="showResult && Result.length==0">
            <h5>Không tìm thấy vé nào.</h5>
        </div>
    </div>
    <div class="container" ng-show="showResult && Result.length>0">
        
        <h3>Thông tin vé xe</h3>
        <table class="table tbl-info table-striped table-hover" style="border: 1px solid #ddd;" ng-repeat="item in Result">
            <tr style="visibility: hidden;">
                <th style="width: 200px;"></th>
                <th></th>
            </tr>
            <tr>
                <td>Mã vé:</td>
                <td class="color-green text-bold">{{item.MaVe}}</td>
            </tr>
            <tr>
                <td>Vé xe đi từ:</td>
                <td>{{item.Diemdi}} <span class="text-success"><i class="fa fa-arrow-right"></i></span>{{item.Diemden}}</td>
            </tr>
            <tr>
                <td>Tên khách hàng:</td>
                <td>{{item.Member_Name}}</td>
            </tr>
            <tr>
                <td>Số điện thoại:</td>
                <td>{{item.Member_Phone}}</td>
            </tr>
            <tr>
                <td>Hãng xe:</td>
                <td>{{item.Tennhaxe}}</td>
            </tr>
            <tr>
                <td>Đón khách tại:</td>
                <td>{{item.Diemdi}}</td>
            </tr>
            <tr>
                <td>Trả khách tại:</td>
                <td>{{item.Diemden}}</td>
            </tr>
            <tr>
                <td>Giờ khởi hành:</td>
                <td>{{item.Giokhoihanh | date : 'hh:mm' }} - {{item.Ngaydi | date : 'dd/MM/yyyy'}}</td>
            </tr>
            <tr>
                <td>Thời gian đi:</td>
                <td>{{item.Thoigiandukien}}</td>
            </tr>
            <tr>
                <td>Loại ghế:</td>
                <td>{{item.Type=='v'?'Thường' : 'Vip'}}</td>
            </tr>
            <tr>
                <td>Số lượng chỗ:</td>
                <td>01 chỗ</td>
            </tr>
            <tr>
                <td>Tiện ích:</td>
                <td>{{Mota}}</td>
            </tr>
            <tr>
                <td>Giá vé:</td>
                <td><span class="text-danger"><b>{{item.UnitPrice | currency: "":0}}</b> vnđ</span></td>
            </tr>
        </table>
    </div>
</div>

