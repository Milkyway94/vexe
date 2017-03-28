<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Transaction.ascx.cs" Inherits="ucontrols_include_Transaction" %>
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
    <div class="message container" ng-controller="TransactionController">
        <h1 class="text-center">GIAO DỊCH</h1>
        <div class="form-group">
            <div class="row">
                <div class="col-sm-6 col-sm-offset-3">
                    <div class="uk-alert-{{alertType}}" ng-show="showerror" uk-alert>
                        <a class="uk-alert-close" ng-click="showerror=false"></a>
                        <p>{{message}}</p>
                    </div>
                </div>
                <div class="col-sm-5 col-sm-offset-3">
                    <input class="form-control" ng-model="Mathe" type="text" placeholder="Nhập mã thẻ giao dịch" />
                </div>
                <div class="col-sm-1">
                    <button class="btn btn-success" ng-click="CreateTransaction()"><span ng-hide="loadding">Tạo giao dịch</span><span ng-show="loadding">Đang thực hiện... <i class="fa fa-spinner fa-pulse fa-fw"></i></span></button>
                </div>
            </div>
        </div>
    </div>
</div>
