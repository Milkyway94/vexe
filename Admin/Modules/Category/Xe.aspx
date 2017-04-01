<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Admin/AdminMasterPage.master" CodeFile="Xe.aspx.cs" Inherits="Admin_Modules_Category_Xe" %>
<asp:content contentplaceholderid="main" runat="server">
    <div class="box box-primary box-solid" id="QLXeController" ng-controller="QLXeController">
        <div class="box-header with-border">
            <h3 class="text-center"><b>QUẢN LÝ XE</b></h3>
        </div>
        <div class="box-body">
                <div class="col-sm-2" id="left-bar">
                    <h3>Danh sách nhà xe</h3>
                    <ul class="dsNhaXe">
                        <%foreach (var item in this.lstNhaXe)
                            {%>
                            <li><a ng-click="LoadXe(<%=item.ID %>)" href="javascript:void(0)"><%=item.Tennhaxe %></a></li>
                          <%  } %>
                       
                    </ul>
                </div>
                <div class="col-sm-10">
                    <div class="form-group">
                <button class="btn btn-flat btn-success btn-sm" id="btnadd" onclick="$('#add-modal').modal({backdrop: 'static'});$('#updateframe').prop('src', 'Create/ThemXe.aspx')" type="button"><i class="fa fa-plus"></i>Thêm mới</button>
            </div>
            <div class="table-responsive">
                <div class="text-center" ng-show="loadData">
                    <i class="fa fa-spinner fa-pulse fa-3x fa-fw"></i> Đang tải dữ liệu...
                </div>
                <div id="grid1" ui-grid="gridOptions" ui-grid-auto-resize ui-grid-move-columns ui-grid-pagination ui-grid-selection ui-grid-exporter ui-grid-edit ui-grid-cellNav class="grid"></div>
            </div>

            <div class="modal fade modal-primary" id="add-modal" role="dialog">
                <div class="modal-dialog modal-lg" id="modalCT">
                    <div class="modal-content">
                        <a class="pull-right" style="padding: 5px;" onclick="$('#add-modal').modal('hide');"><i class="glyphicon glyphicon-remove"></i></a>&nbsp;&nbsp;
                        <a class="pull-right" style="padding: 5px;" onclick="$('#modalCT').toggleClass('fullscreen');"><i class="glyphicon glyphicon-fullscreen"></i></a>&nbsp;&nbsp;
                        <iframe id="updateframe" style="width: 100%; height: 560px; border: none; border-radius: 4px" allowfullscreen></iframe>
                    </div>
                    <!-- /.modal-content -->
                </div>
                <!-- /.modal-dialog -->
            </div>
            <!-- /.modal -->
                </div>
            </div>
    </div>
</asp:content>
