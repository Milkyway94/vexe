<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/AdminMasterPage.master" AutoEventWireup="true" CodeFile="Vexe.aspx.cs" Inherits="Admin_Modules_Order_Vexe" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Main" runat="Server">
    <div class="container" ng-controller="VeXeController">
        <div class="order-content">
            <div class="container">
                <div class="row">
                    <h3 class="text-center admin-title">THỐNG KÊ VÉ XE</h3>
                </div>
                <hr />
                <div class="row">
                    <div class="col-sm-6" style="padding-bottom: 0px; padding-left: 15px;">
                        <div class="w20">
                            <input type="text" class="form-control input-sm" placeholder="Lọc theo Mã Vé" ng-model="maVe" required />
                        </div>
                        <div class="w20">
                            <input type="datetime" class="form-control input-sm datepicker" placeholder="Lọc Từ ngày" ng-model="startDate" required />
                        </div>
                        <div class="w20">
                            <input type="datetime" class="form-control input-sm datepicker" placeholder="Lọc Đến ngày" ng-model="endDate" required />
                        </div>
                        <button class="btn btn-flat btn-danger btn-sm" ng-click="Search()" type="button"><i class="fa fa-search"></i>&nbsp;&nbsp;Lọc <i class="fa fa-spinner fa-spin" ng-show="loading"></i></button>
                        <button class="btn btn-success btn-flat btn-sm" ng-click="exportData()" type="button">
                            <span class="glyphicon glyphicon-share"></span>
                            Export to Excel</button>
                    </div>
                    <div class="col-sm-4 col-sm-offset-2" style="padding-right: 15px; padding-bottom: 0px; padding-left: 0;">
                        <div class="w100">
                            <input type="text" class="form-control input-sm" ng-model="SearchKey" placeholder="Nhập từ khóa tìm kiếm" />
                        </div>
                    </div>
                </div>
                <div class="fw">
                    <div id="exportable">
                        <table class="table" id="exportData">
                            <tr>
                                <td style="padding: 0">
                                    <table class="table table-bordered table-striped table-hover">
                                        <thead>
                                            <tr class="table-header">
                                                <th>STT</th>
                                                <th><i class="fa fa-ticket"></i>&nbsp;Mã số vé</th>
                                                <th><i class="fa fa-share"></i>&nbsp;Chuyến đi</th>
                                                <th><i class="fa fa-car"></i>&nbsp;Hãng xe</th>
                                                <th><i class="fa fa-calendar"></i>&nbsp;Ngày mua</th>
                                                <th><i class="fa fa-clock-o"></i>&nbsp;Thời gian đi</th>
                                                <th><i class="fa fa-money"></i>&nbsp;Giá vé (VNĐ)</th>
                                                <th><i class="fa fa-credit-card"></i>&nbsp;Loại vé</th>
                                                <th>Tùy chọn</th>
                                            </tr>
                                        </thead>
                                        <tbody>
                                            <tr ng-repeat="o in lstOrder.slice(((currentPage-1)*itemsPerPage), ((currentPage)*itemsPerPage)) | filter : SearchKey">
                                                <td>{{ lstOrder.indexOf(o)+1 }}</td>
                                                <td>{{ o.MaVe }}</td>
                                                <td>{{ o.Diemdi }} <i class="fa fa-long-arrow-right fa-current"></i>{{ o.Diemden }} </td>
                                                <td>{{ o.Tennhaxe }}</td>
                                                <td>{{ o.Order_CreatedDate | date:'dd-MM-yyyy' }}</td>
                                                <td>{{ o.Order_CompleteDate | date:'dd-MM-yyyy HH:mm:ss' }}</td>
                                                <td>{{ o.UnitPrice | number}}</td>
                                                <td>{{ o.Type=="V"?"VIP":"Thường" }}</td>
                                                <td>
                                                    <button type="button" class="btn btn-warning btn-flat btn-sm" ng-click="view(o)"><i class="fa fa-eye"></i></button>
                                                </td>
                                            </tr>
                                        </tbody>
                                    </table>
                                </td>
                            </tr>
                        </table>
                        <%--Hiển thị
                        <select ng-model="viewby" ng-change="setItemsPerPage(viewby)">
                            <option value="1">1</option>
                            <option value="2">2</option>
                            <option value="5">5</option>
                            <option value="10">10</option>
                            <option value="20">20</option>
                            <option value="30">30</option>
                            <option value="40">40</option>
                            <option value="50">50</option>
                        </select>
                        Dòng--%>
                        <div class="pull-right">
                            <pagination total-items="totalItems" ng-model="currentPage" max-size="maxSize" class="pagination-sm" boundary-links="true"
                                rotate="false" num-pages="numPages" items-per-page="itemsPerPage"></pagination>
                        </div>
                        <%--<pre>Trang: {{currentPage}} / {{numPages}}</pre>--%>
                    </div>
                </div>
            </div>
        </div>
        <div id="myModal" class="modal fade" role="dialog">
            <div class="modal-dialog modal-lg">
                <!-- Modal content-->
                <div class="modal-content">
                    <div class="modal-header">
                        <button type="button" class="close" data-dismiss="modal">&times;</button>
                        <h2 class="modal-title">CHI TIẾT ĐƠN HÀNG</h2>
                    </div>
                    <div class="modal-body" id="modal-body">
                        <table class="table" id="exportPDF">
                            <tr>
                                <td colspan="2">
                                    <h3 class="text-center">THÔNG TIN VÉ</h3>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <table class="table table-info table-bordered">
                                        <tr>
                                            <td><b>Mã số vé</b></td>
                                            <td>{{ CodeTicket }}</td>
                                            <td><b>Điện thoại</b></td>
                                            <td>{{ Phone }}</td>
                                        </tr>
                                        <tr>
                                            <td><b>Họ tên</b></td>
                                            <td>{{ HoTen }}</td>
                                            <td><b>Địa chỉ</b></td>
                                            <td>{{ DiaChi }}</td>
                                        </tr>
                                        <tr>
                                            <td><b>Ngày mua</b></td>
                                            <td>{{ NgayTao | date:'dd-MM-yyyy'}}</td>
                                            <td><b>Thời gian đi</b></td>
                                            <td>{{ NgayDi | date:'dd-MM-yyyy HH:mm:ss'}}</td>
                                        </tr>
                                        <tr>
                                            <td><b>Hãng xe</b></td>
                                            <td>{{ NhaXe }}</td>
                                            <td><b>Loại Vé</b></td>
                                            <td>{{ TicketType=="TH"?"Thường":"VIP" }}</td>
                                        </tr>
                                        <tr>
                                            <td><b>Chuyến đi</b></td>
                                            <td>{{ Diemdi }} <i class="fa fa-long-arrow-right fa-current"></i>{{ Diemden}}</td>
                                            <td class="text-current"><b>Giá (VNĐ)</b></td>
                                            <td class="text-bold">{{ Price | number}} đ</td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                        </table>
                    </div>
                    <div class="modal-footer">
                        <button type="button" class="btn btn-success btn-flat btn-sm" ng-click="exportPDF()">
                            <span class="glyphicon glyphicon-share"></span>
                            Export to Excel
                        </button>
                        <button type="button" class="btn btn-default" data-dismiss="modal">Đóng</button>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
