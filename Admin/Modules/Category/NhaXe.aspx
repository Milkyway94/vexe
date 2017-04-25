<%@ Page Language="C#" AutoEventWireup="true" CodeFile="NhaXe.aspx.cs" MasterPageFile="~/Admin/AdminMasterPage.master" Inherits="Admin_Modules_Category_NhaXe" %>

<asp:Content ContentPlaceHolderID="main" runat="server">
    <div class="box box-primary container box-solid" ng-controller="NhaXeController">
        <div class="box-header with-border">
            <h3 class="text-center"><b>QUẢN LÝ NHÀ XE</b></h3>
        </div>
        <div class="box-body">
            <div class="form-group">
                <button class="btn btn-flat btn-success btn-sm" id="btnadd" ng-click="OpenUpdateForm('add')" type="button"><i class="fa fa-plus"></i>Thêm mới</button>
                <div class="pull-right">
                    <input type="text" class="form-control" ng-model="SearchKey" placeholder="Nhập từ khóa tìm kiếm" />
                </div>
            </div>
            <table class="table table-bordered table-stripped table-hover" id="ungtuyen">
                <thead>
                    <tr class="table-header">
                        <th>Thực hiện</th>
                        <th>STT</th>
                        <th>Tên nhà xe</th>
                        <th>Số điện thoại</th>
                        <th>Trụ sở chính</th>
                        <th>Số xe</th>
                    </tr>
                </thead>
                <tbody>
                    <tr ng-repeat="item in nhaxes | filter: {Tennhaxe: SearchKey}" ng-click="Select(item)" style="height: 41px; vertical-align: middle" ng-class="{selectedrow: item === selected}">
                        <td>
                            <div class="dropdown tbl-option" style="padding-left: 2px !important; padding-top: 0px !important; position: relative !important">
                                <button class="btn btn-primary dropdown-toggle" type="button" data-toggle="dropdown"><span class="caret"></span></button>
                                <ul class="dropdown-menu">
                                    <li>
                                        <a href="javascript:void(0)" ng-click="OpenDetail()"><i class="fa fa-eye"></i>Xem chi tiết</a>
                                    </li>
                                    <li>
                                        <a ng-click="OpenUpdateForm('edit')" href="javascript:void(0)"><i class="fa fa-edit"></i>Sửa</a></li>
                                    <li>
                                        <a href="javascript:void(0)" ng-click="Delete(selected)"><i class="fa fa-trash"></i>Xóa</a>
                                    </li>
                                    <li>
                                        <a href="/Admin/Modules/Content/CommentList.aspx?nx={{selected.ID}}"><i class="fa fa-trash"></i>Vote&Comment</a>
                                    </li>
                                </u>
                            </div>

                        </td>
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
                        <form ng-submit="Save()">
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
                                    <label>Địa chỉ ở tỉnh?</label>
                                    <select ng-model="Tinh" class="form-control select2">
                                        <option ng-repeat="tinh in Tinhs" ng-value="tinh.MaTinh">{{tinh.TenTinh}}</option>
                                    </select>
                                </div>
                                <div class="form-group">
                                    <label>Địa chỉ trụ sở chính</label>
                                    <textarea ng-model="Trusochinh" class="form-control"></textarea>
                                </div>
                                <div class="form-group">
                                    <label class="col-sm-12">Ảnh</label>
                                    <div class="col-sm-10">
                                        <input type="text" id="txtImg" ng-model="Anh" class="form-control" required />
                                    </div>
                                    <div class="col-sm-2">
                                        <input id="browseServer" class="btn btn-warning" onclick="BrowseServer('txtImg');" type="button" value="Tải ảnh" />
                                    </div>
                                </div>
                                <div class="form-group">
                                    <br />
                                    <img class="img-responsive" id="catimg" />
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
                                    <h3>Giới thiệu ngắn</h3>
                                    <textarea class="form-control" ng-model="Gioithieungan"></textarea>
                                </div>
                                <div class="form-group" id="tab_2">
                                    <label>Giới thiệu chi tiết</label>
                                    <textarea ui-tinymce="tinymceOptions" class="form-control" ng-model="Gioithieuchitiet"></textarea>
                                </div>
                            </div>
                            <div class="modal-footer">
                                <button type="reset" class="btn btn-flat btn-warning pull-left" data-dismiss="modal">Hủy</button>
                                <button type="button" class="btn btn-flat btn-success" ng-click="Save()"><i class="fa fa-spin" ng-show="loading"></i><i class="fa fa-save"></i>&nbsp;Lưu</button>
                            </div>
                        </form>
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

