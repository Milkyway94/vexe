<%@ Page Language="C#" EnableEventValidation="true" AutoEventWireup="true" CodeFile="NhaXe.aspx.cs" MasterPageFile="~/Admin/AdminMasterPage.master" Inherits="Admin_Modules_Category_NhaXe" %>

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
            <div>
                <asp:Label Text="" ID="MSG" ClientIDMode="Static" runat="server" />
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
                        <div class="modal-header">
                            <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                                <span aria-hidden="true">×</span></button>
                            <h2 class="modal-title text-bold">Thêm mới nhà xe</h2>
                        </div>
                        <div class="modal-body">
                            <div class="form-group">
                                <label>Mã</label>
                                <asp:TextBox runat="server" ReadOnly="true" ng-model="ID" ID="ID" CssClass="form-control" required="required" />
                            </div>
                            <div class="form-group">
                                <label>Tên nhà xe</label>
                                <asp:TextBox runat="server" ng-model="Tennhaxe" ID="Tennhaxe" CssClass="form-control" required="required" />
                            </div>
                            <div class="form-group">
                                <label>Địa chỉ ở tỉnh?</label>
                                <asp:DropDownList runat="server" ng-model="Tinh" ID="Tinh" CssClass="select2">
                                </asp:DropDownList>
                            </div>
                            <div class="form-group">
                                <label>Địa chỉ trụ sở</label>
                                <asp:TextBox runat="server" ID="Trusochinh" ng-model="Trusochinh" class="form-control" />
                            </div>
                            <div class="form-group">
                                <label class="col-sm-12">Ảnh(*) </label>
                                <div class="col-sm-10">
                                    <div class="row">
                                        <asp:TextBox runat="server" ClientIDMode="Static" ng-model="Anh" ID="txtImg" class="form-control" required />
                                    </div>

                                </div>
                                <div class="col-sm-2">
                                    <input id="browseServer" class="btn btn-warning" onclick="BrowseServer('txtImg');" type="button" value="Tải ảnh" />
                                </div>
                            </div>
                            <div class="form-group">
                                <br />
                                <img class="img-responsive" id="catimg" runat="server" />
                            </div>
                            <div class="form-group">
                                <label>Số điện thoại (*)</label>
                                <asp:TextBox runat="server" ID="Sodienthoai" ng-model="Sodienthoai" TextMode="Number" MaxLength="12" CssClass="form-control" required />
                            </div>
                            <div class="form-group">
                                <label>Số lượng xe(*) </label>
                                <asp:TextBox runat="server" ID="Soluongxe" ng-model="Soluongxe" CssClass="form-control" TextMode="Number" MaxLength="3" Text="0" required />
                            </div>
                            <div class="form-group">
                                <label>Tên Người đại diện (*)</label>
                                <asp:TextBox runat="server" ID="Nguoidaidien" ng-model="Nguoidaidien" CssClass="form-control" required />
                            </div>
                            <div class="form-group">
                                <label>Giới thiệu ngắn(*)</label>
                                <asp:TextBox runat="server" ng-model="Gioithieungan" TextMode="MultiLine" ID="Gioithieungan" CssClass="form-control" />
                            </div>
                            <div class="form-group">
                                <label>Giới thiệu chi tiết(*)</label>
                                <asp:TextBox runat="server" TextMode="MultiLine" ng-model="Gioithieuchitiet" ID="Gioithieuchitiet" CssClass="form-control editor" />
                            </div>
                        </div>
                        <div class="modal-footer">
                            <button type="reset" class="btn btn-flat btn-warning pull-left" data-dismiss="modal">Hủy</button>
                            <asp:Button Text="Lưu lại" ID="btnSave" OnClick="btnSave_Click" ng-show="act=='add'" CssClass="btn btn-flat btn-success" runat="server" />
                            <asp:Button Text="Lưu lại" ID="btnUpdate" OnClick="btnUpdate_Click" ng-show="act=='edit'" CssClass="btn btn-flat btn-success" runat="server" />
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
            <div class="modal fade modal-primary" id="edit-modal" role="dialog">
                <div class="modal-dialog">
                    <div class="modal-content">
                        <div class="modal-header">
                            <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                                <span aria-hidden="true">×</span></button>
                            <h2 class="modal-title text-bold">Thêm mới nhà xe</h2>
                        </div>
                        <div class="modal-body" style="height: 500px;">
                            <iframe id="edit-frm" src="Create/ThemNhaxe.aspx" style="width: 100%; height: 100%; border: none !important;"></iframe>
                        </div>
                    </div>
                    <!-- /.modal-content -->
                </div>
                <!-- /.modal-dialog -->
            </div>
            <!-- /.modal -->
        </div>
    </div>
    <script>
        function showMsg(msg) {
            $("#MSG").html(msg);
        }
    </script>
</asp:Content>

