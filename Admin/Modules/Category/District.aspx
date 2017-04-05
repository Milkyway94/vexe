<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Admin/AdminMasterPage.master" CodeFile="District.aspx.cs" Inherits="Admin_Modules_Category_District" %>

<asp:Content ContentPlaceHolderID="main" runat="server">
    <div class="box box-primary container box-solid" ng-controller="QuanHuyenController">
        <div class="box-header with-border">
            <h3 class="text-center"><b>QUẢN LÝ QUẬN HUYỆN</b></h3>
        </div>
        <div class="box-body">
            <div class="form-group">
                <button class="btn btn-flat btn-success btn-sm" id="btnadd" ng-click="OpenUpdateForm('add')" type="button"><i class="fa fa-plus"></i>Thêm mới</button>
                <button class="btn btn-flat btn-warning btn-sm" type="button" ng-click="OpenUpdateForm('edit')"><i class="fa fa-edit"></i>Sửa</button>
                <button class="btn btn-flat btn-danger btn-sm" type="button" ng-click="Delete(selected)"><i class="fa fa-trash"></i>Xóa</button>
                <button class="btn btn-success btn-flat btn-sm" type="button" ng-click="ExportToExcel()"><i class="fa fa-table"></i>Xuất ra excel </button>
            </div>
            <div class="form-group">
                <label>Hiện</label>
                <select ng-model="pageSize">
                    <option value="5">5</option>
                    <option value="10" ng-selected="true">10</option>
                    <option value="25">25</option>
                    <option value="50">50</option>
                    <option value="100">100</option>
                </select>
                <label>dòng</label>
                <div class="pull-right">
                    <input type="text" class="form-control" ng-model="SearchKey" placeholder="Nhập từ khóa tìm kiếm" />
                </div>
            </div>
            <div class="table-responsive" id="exportData">
                <table class="table table-bordered table-stripped table-condensed" id="ungtuyen">
                    <thead>
                        <tr>
                            <th>STT</th>
                            <th>
                                <a href="#" ng-click="sortType = 'TenHuyen';sortReverse = !sortReverse">Tên Quận 
                                <span ng-show="sortType == 'TenHuyen' && !sortReverse" class="fa fa-caret-down"></span>
                                    <span ng-show="sortType == 'TenHuyen' && sortReverse" class="fa fa-caret-up"></span>
                                </a>
                            </th>
                            <th>
                                <a href="#" ng-click="sortType = 'TinhThanh.TenTinh';sortReverse = !sortReverse">Thuộc tỉnh
                                <span ng-show="sortType == 'TinhThanh.TenTinh' && !sortReverse" class="fa fa-caret-down"></span>
                                    <span ng-show="sortType == 'TinhThanh.TenTinh' && sortReverse" class="fa fa-caret-up"></span>
                                </a>
                            </th>
                            <th>
                                <a href="#" ng-click="sortType = 'GiaShip';sortReverse = !sortReverse">Giá vận chuyển
                                <span ng-show="sortType == 'GiaShip' && !sortReverse" class="fa fa-caret-down"></span>
                                    <span ng-show="sortType == 'GiaShip' && sortReverse" class="fa fa-caret-up"></span>
                                </a>
                            </th>
                        </tr>
                    </thead>
                    <tbody>
                        <tr dir-paginate="item in districts | filter:  SearchKey | orderBy:sortType:sortReverse | itemsPerPage:pageSize" ng-click="Select(item)" ng-class="{selectedrow: item === selected}">
                            <td>{{districts.indexOf(item)+1}}</td>
                            <td>{{item.TenHuyen}}</td>
                            <td>{{item.TinhThanh.TenTinh}}</td>
                            <td>{{item.GiaShip}}</td>
                        </tr>
                    </tbody>
                </table>
            </div>

            <div class="pull-right">
                <dir-pagination-controls
                    max-size="5"
                    direction-links="true"
                    boundary-links="true">
                    </dir-pagination-controls>
            </div>
            <div class="modal fade modal-primary" id="add-modal" role="dialog">
                <div class="modal-dialog">
                    <div class="modal-content">
                        <form id="form-add">
                            <div class="modal-header">
                                <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                                    <span aria-hidden="true">×</span></button>
                                <h2 class="modal-title text-bold">Thêm mới Quận/Huyện</h2>
                            </div>
                            <div class="modal-body">
                                <div class="form-group">
                                    <label>Tên quận/huyện(*)</label>
                                    <input type="text" ng-model="Huyen.TenHuyen" class="form-control" required />
                                    <span ng-show="Huyen.TenHuyen.$touched && Huyen.TenHuyen.$invalid" class="alert alert-danger">Bạn phải nhập tên quận/huyện.</span>
                                </div>
                                <div class="form-group">
                                    <label>Thuộc Tỉnh/Thành</label>
                                    <select class="form-control" ng-model="Huyen.MaTinh">
                                        <option ng-repeat="item in Tinhs" ng-selected="item.MaTinh==Huyen.MaTinh" ng-value="item.MaTinh">{{item.TenTinh}}</option>
                                    </select>
                                </div>
                                <div class="form-group">
                                    <label>Phí vận chuyển</label>
                                    <input type="number"min="0" ng-value="0" ng-model="Huyen.GiaShip" class="form-control" />
                                    <span ng-show="Huyen.TenHuyen.$touched && Huyen.TenHuyen.$invalid" class="alert alert-danger">Bạn phải nhập phí vận chuyển.</span>
                                </div>
                            </div>
                            <div class="modal-footer">
                                <button type="button" class="btn btn-flat btn-warning pull-left" data-dismiss="modal">Hủy</button>
                                <button type="button" class="btn btn-flat btn-success" type="button" ng-click="Save()"><i class="fa fa-spin" ng-show="loading"></i><i class="fa fa-save"></i>&nbsp;Lưu</button>
                            </div>
                        </form>

                    </div>
                    <!-- /.modal-content -->
                </div>
                <!-- /.modal-dialog -->
            </div>
            <!-- /.modal -->
        </div>
    </div>
</asp:Content>
