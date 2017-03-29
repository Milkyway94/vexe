﻿<%@ Page Language="C#" AutoEventWireup="true" CodeFile="NhaXe.aspx.cs" MasterPageFile="~/Admin/AdminMasterPage.master" Inherits="Admin_Modules_Category_NhaXe" %>

<asp:Content ContentPlaceHolderID="main" runat="server">
    <div class="box box-primary box-solid" ng-controller="NhaXeController">
        <div class="box-header with-border">
            <h3 class="text-center"><b>QUẢN LÝ NHÀ XE</b></h3>
        </div>
        <div class="box-body">
            <div class="form-group">
                <button class="btn btn-flat btn-success btn-sm" id="btnadd" ng-click="OpenUpdateForm('add')" type="button"><i class="fa fa-plus"></i>Thêm mới</button>
                <button class="btn btn-flat btn-default btn-sm" type="button" ng-click="OpenDetail()"><i class="fa fa-eye"></i>Xem chi tiết</button>
                <button class="btn btn-flat btn-warning btn-sm" type="button" ng-click="OpenUpdateForm('edit')"><i class="fa fa-edit"></i>Sửa</button>
                <button class="btn btn-flat btn-danger btn-sm" type="button" ng-click="Delete(selected)"><i class="fa fa-trash"></i>Xóa</button>
                <button class="btn btn-success btn-flat btn-sm" type="button" ng-click="ExportToExcel()"><i class="fa fa-table"></i>Xuất ra excel </button>
                <div class="pull-right">
                    <input type="text" class="form-control" ng-model="SearchKey" placeholder="Nhập từ khóa tìm kiếm" />
                </div>
            </div>
            <table class="table table-bordered table-stripped table-condensed" id="ungtuyen">
                <thead>
                    <tr>
                        <th>STT</th>
                        <th>Tên nhà xe</th>
                        <th>Số điện thoại</th>
                        <th>Trụ sở chính</th>
                        <th>Số xe</th>
                    </tr>
                </thead>
                <tbody>
                    <tr ng-repeat="item in nhaxes | filter: {Tennhaxe: SearchKey}" ng-click="Select(item)" ng-class="{selectedrow: item === selected}">
                        <td>{{nhaxes.indexOf(item)+1}}</td>
                        <td>{{item.Tennhaxe}}</td>
                        <td>{{item.Sodienthoai}}</td>
                        <td>{{item.Trusochinh}}</td>
                        <td>{{item.Soluongxe}}</td>
                    </tr>
                </tbody>
            </table>
            <div class="modal fade modal-primary" id="add-modal" role="dialog">
                <div class="modal-dialog">
                    <div class="modal-content">
                        <div class="modal-header">
                            <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                                <span aria-hidden="true">×</span></button>
                            <h2 class="modal-title text-bold">Thêm mới nhà xe</h2>
                        </div>
                        <div class="modal-body">
                            <div class="form-group">
                                <label>Tên nhà xe(*)</label>
                                <input type="text" ng-model="Tennhaxe" class="form-control" required />
                                <span ng-show="Tennhaxe.$touched && Tennhaxe.$invalid" class="alert alert-danger">Bạn phải nhập tên nhà xe.</span>
                            </div>
                            <div class="form-group">
                                <label>Trụ sở chính</label>
                                <input type="text" ng-model="Trusochinh" class="form-control" />
                            </div>
                            <div class="form-group">
                                <label>Số điện thoại (*)</label>
                                <input type="text" ng-model="Sodienthoai" class="form-control" required />
                                <span ng-show="Tennhaxe.$touched && Tennhaxe.$invalid" class="alert alert-danger">Bạn phải nhập số điện thoại.</span>
                            </div>
                            <div class="form-group">
                                <label>Số lượng xe</label>
                                <input type="number" ng-model="Soluongxe" class="form-control" />
                            </div>
                            <div class="form-group">
                                <label>Tên Người đại diện</label>
                                <input type="text" ng-model="Nguoidaidien" class="form-control" />
                            </div>
                            <div class="form-group">
                                <h3>Giới thiệu</h3>
                                <div class="nav-tabs-custom">
                                    <ul class="nav nav-tabs">
                                        <li class="active"><a href="#tab_1" data-toggle="tab" aria-expanded="true">Giới thiệu ngắn</a></li>
                                        <li><a href="#tab_2" data-toggle="tab" aria-expanded="false">Chi tiết</a></li>
                                    </ul>
                                    <div class="tab-content">
                                        <div class="tab-pane" id="tab_1">
                                            <textarea class="form-control" ng-model="Gioithieungan"></textarea>
                                        </div>
                                        <!-- /.tab-pane -->
                                        <div class="tab-pane active" id="tab_2">
                                            <textarea class="form-control" ng-model="Gioithieuchitiet"></textarea>
                                        </div>
                                        <!-- /.tab-pane -->
                                    </div>
                                    <!-- /.tab-content -->
                                </div>
                            </div>
                        </div>
                        <div class="modal-footer">
                            <button type="button" class="btn btn-flat btn-warning pull-left" data-dismiss="modal">Hủy</button>
                            <button type="button" class="btn btn-flat btn-success" type="button" ng-click="Save()"><i class="fa fa-spin" ng-show="loading"></i><i class="fa fa-save"></i>&nbsp;Lưu</button>
                        </div>
                    </div>
                    <!-- /.modal-content -->
                </div>
                <!-- /.modal-dialog -->
            </div>
            <div class="modal fade modal-primary" id="detail-modal" role="dialog">
                <div class="modal-dialog">
                    <div class="modal-content">
                        <div class="modal-header">
                            <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                                <span aria-hidden="true">×</span></button>
                            <h2 class="modal-title text-bold">Nhà xe {{selected.Tennhaxe}}</h2>
                        </div>
                        <div class="modal-body">
                            <div class="form-group row">
                                <label class="col-sm-2">Tên nhà xe</label>
                                <div class="col-sm-10">
                                    <strong>{{selected.Tennhaxe}}</strong>
                                </div>
                            </div>
                            <div class="form-group row">
                                <label class="col-sm-2">Trụ sở chính</label>
                                <div class="col-sm-10">
                                    <strong>{{selected.Trusochinh}}</strong>
                                </div>
                            </div>
                            <div class="form-group row">
                                <label class="col-sm-2">Số điện thoại</label>
                                <div class="col-sm-10">
                                    <strong>{{selected.Sodienthoai}}</strong>
                                </div>
                            </div>
                            <div class="form-group row">
                                <label class="col-sm-2">Số lượng xe</label>
                                <div class="col-sm-10">
                                    <strong>{{selected.Soluongxe}}</strong>
                                </div>
                            </div>
                            <div class="form-group row">
                                <label class="col-sm-2">Giới thiệu ngắn</label>
                                <div class="col-sm-10">
                                    <strong>{{selected.Gioithieungan}}</strong>
                                </div>
                            </div>
                            <div class="form-group row">
                                <label class="col-sm-2">Giới thiệu chi tiết</label>
                                <strong>{{selected.Gioithieuchitiet}}</strong>
                            </div>
                            <!-- /.tab-pane -->

                            
                        </div>
                        <div class="modal-footer">
                            <button type="button" class="btn btn-flat btn-warning pull-right" data-dismiss="modal">Đóng</button>
                        </div>
                    </div>
                    <!-- /.modal-content -->
                </div>
                <!-- /.modal-dialog -->
            </div>
            <!-- /.modal -->
        </div>
    </div>
</asp:Content>
