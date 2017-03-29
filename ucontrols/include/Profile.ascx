<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Profile.ascx.cs" Inherits="ucontrols_include_Profile" %>
<div class="container content">
    <div class="wrapper">
        <div class="col-sm-9">
            <p class="pad"><span class="glyphicon glyphicon-home"></span> > Lịch sử giao dịch</p>
            <p style="color:#007000; text-transform:uppercase; padding-top:30px; padding-bottom:15px; font-size:25px;">Lịch sử giao dịch</p>
            <table class="table table-bordered">
                <thead>
                    <tr>
                        <th><i class="fa fa-steam" aria-hidden="true"> Mã số vé</i></th>
                        <th><i class="fa fa-share" aria-hidden="true"> Chuyến đi</i></th>
                        <th><i class="fa fa-bus" aria-hidden="true"> Hãng xe</i></th>   
                        <th><i class="fa fa-calendar" aria-hidden="true"> Ngày mua</i></th>
                        <th><i class="fa fa-clock-o" aria-hidden="true"> Thời gian đi</i></th>
                    </tr>
                </thead>
                <tbody>
                    <tr>
                        <td>HT00576</td>
                        <td>Hà Nội <i class="fa fa-long-arrow-right" aria-hidden="true"> Sa Pa</i></td>
                        <td>Nhà xe Phương Trang</td>
                        <td>23/02/2017</td>
                        <td>07:30-23/02/2017</td>
                    </tr>
                    <tr>
                        <td>HT99854</td>
                        <td>Hà Nội <i class="fa fa-long-arrow-right" aria-hidden="true"> Thành phố Hồ Chí Minh</i></td>
                        <td>Nhà xe Hồng Thịnh</td>
                        <td>23/02/2017</td>
                        <td>8:30-23/02/2017</td>
                    </tr>
                    <tr>
                        <td>HT88597</td>
                        <td>Hà Nội <i class="fa fa-long-arrow-right" aria-hidden="true"> Hải Phòng</i></td>
                        <td>Nhà xe Bảo Yến</td>
                        <td>23/02/2017</td>
                        <td>9:30-23/02/2017</td>
                    </tr>
                    <tr>
                        <td>HT13589</td>
                        <td>Hà Nội<i class="fa fa-long-arrow-right" aria-hidden="true"> Cà Mau</i></td>
                        <td>Nhà xe Oanh Bồ</td>
                        <td>23/02/2017</td>
                        <td>10:30-23/02/2017</td>
                    </tr>
                    <tr>
                        <td>HT34587</td>
                        <td>Hà Nội <i class="fa fa-long-arrow-right" aria-hidden="true"> Lào Cai</i></td>
                        <td>Nhà xe Sơn Hưng</td>
                        <td>23/02/2017</td>
                        <td>11:30-23/02/2017</td>
                    </tr>
                    <tr>
                        <td>HT093545</td>
                        <td>Hà Nội <i class="fa fa-long-arrow-right" aria-hidden="true"> Huế</i></td>
                        <td>Nhà xe Cường An</td>
                        <td>23/02/2017</td>
                        <td>12:30-23/02/2017</td>
                    </tr>
                    <tr>
                        <td>HT924663</td>
                        <td>Hà Nội <i class="fa fa-long-arrow-right" aria-hidden="true"> Sa Pa</i></td>
                        <td>Nhà xe Quyết Hương</td>
                        <td>23/02/2017</td>
                        <td>15:30-23/02/2017</td>
                    </tr>
                </tbody>
            </table>
        </div>
        <div class="col-sm-3">
            <div class="tt">
                <p>Thông tin cá nhân</p>
                <div class="list">
                    <ul>
                        <li><i class="fa fa-user" aria-hidden="true"><a href="#">  Thông tin tài khoản</a></i></li>
                        <li><i class="fa fa-upload" aria-hidden="true"><a href="#">  Cập nhật tài khoản</a></i></li>
                        <li><img src="../../img/Vola.png" alt="Alternate Text" style="width:10%;" /><a href="#">  Nạp tiền Vola</a></i></li>
                        <li><i class="fa fa-clock-o" aria-hidden="true"><a href="#">  Lịch sử giao dịch</a></i></li>
                        <li style="border:none;"><i class="fa fa-sign-out" aria-hidden="true"><a href="#">  Đăng xuất</a></i></li>
                    </ul>
                </div>
            </div>
        </div>
    </div>
</div>