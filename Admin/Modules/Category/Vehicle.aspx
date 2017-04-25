<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Admin/AdminMasterPage.master" CodeFile="Vehicle.aspx.cs" Inherits="Admin_Modules_Category_Vehicle" %>

<asp:Content ContentPlaceHolderID="main" runat="server">
    <div class="box box-primary container box-solid" ng-controller="XeController">
        <div class="box-header with-border">
            <h3 class="text-center"><b>{{Mod.ModAdmin_Name}}</b></h3>
        </div>
        <div class="box-body">
            <div class="form-group">
                <button class="btn btn-flat btn-success btn-sm" id="btnadd" ng-click="OpenUpdateForm('add')" type="button"><i class="fa fa-plus"></i>Thêm mới</button>
            </div>
            <div class="form-group">
                <label>Hiện</label>
                <select ng-model="pageSize">
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
            <div class="table-responsive">
                <div class="text-center" ng-show="loadData">
                    <i class="fa fa-spinner fa-pulse fa-3x fa-fw"></i>
                </div>
                <table class="table table-bordered table-stripped table-hover table-condensed" ng-if="!loadData">
                    <thead>
                        <tr class="table-header">
                            <th style="width: 50px;">Option</th>
                            <th ng-repeat="item in grvs">
                                <a href="#" onclick="event.preventDefault();" ng-click="sortType = item.FldName;sortReverse = !sortReverse">{{item.FldLabel}} 
                                <span ng-show="sortType == item.FldName && !sortReverse" class="fa fa-caret-down"></span>
                                    <span ng-show="sortType == item.FldName && sortReverse" class="fa fa-caret-up"></span>
                                </a>
                            </th>
                        </tr>
                    </thead>
                    <tbody>
                        <tr dir-paginate="item in list | filter:  SearchKey | orderBy:sortType:sortReverse | itemsPerPage:pageSize" ng-click="Select(item)" ng-class="{selectedrow: item === selectedRow}" style="height: 45px;">
                            <td>
                                <div class="dropdown tbl-option" style="padding-left: 2px !important; padding-top: 0px !important;">
                                    <button class="btn btn-primary dropdown-toggle" type="button" data-toggle="dropdown"><span class="caret"></span></button>
                                    <ul class="dropdown-menu">
                                        <li>
                                            <a ng-click="OpenUpdateForm('edit')" href="javascript:void(0)"><i class="fa fa-edit"></i>Sửa</a></li>
                                        <li>
                                            <a ng-repeat="item in btnExec" href="javascript:void(0)" ng-click="Exec(item)"><i class="fa fa-spin" ng-show="loading"></i><i class="fa fa-{{item.Btn_faIcon}}"></i>&nbsp;{{item.Btn_Name}}</a></li>
                                    </u>
                                </div>

                            </td>
                            <td ng-repeat="i in grvs">{{item[i.FldName]}}</td>
                        </tr>
                    </tbody>
                </table>
                <div class="pull-right">
                    <dir-pagination-controls
                        max-size="5"
                        direction-links="true"
                        boundary-links="true">
                    </dir-pagination-controls>
                </div>
            </div>

            <div class="modal fade modal-primary" id="add-modal" role="dialog">
                <div class="modal-dialog">
                    <div class="modal-content">

                        <div class="modal-header">
                            <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                                <span aria-hidden="true">×</span></button>
                            <h2 class="modal-title text-bold">{{updateFormTitle}}</h2>
                        </div>
                        <div class="modal-body">
                            <div class="form-group" ng-repeat="item in updates" ng-show="!item.RO">
                                <label>{{item.FldLabel}}<span ng-show="item.FldStatus==2">(*)</span></label>
                                <div ng-switch on="item.FldType">
                                    <!--Key-->
                                    <div class="animate-switch" ng-switch-when="PK" ng-switch-when-separator="|">
                                        <input type="hidden" ng-model="formdata[item.FldName]" class="form-control" ng-required="item.FldStatus==2" />
                                    </div>
                                    <!--End Key-->

                                    <!--TEXT BOX-->
                                    <div class="animate-switch" ng-switch-when="TXT" ng-switch-when-separator="|">
                                        <input type="text" placeholder="Mời nhập {{item.FldLabel}}" ng-model="formdata[item.FldName]" class="form-control" ng-required="item.FldStatus==2" />
                                    </div>
                                    <!--END TEXT BOX-->

                                    <!--DATEPICKER-->
                                    <div class="animate-switch" ng-switch-when="DATE" ng-switch-when-separator="|">
                                        <input uib-datepicker class="form-control" ng-model="formdata[item.FldName]" class="date-of-birth" datepicker-options="options" ng-click="today(item.FldName)" ng-required="item.FldStatus==2" />
                                    </div>
                                    <!--END DATEPICKER-->

                                    <!--TEXTAREA-->
                                    <div class="animate-switch" ng-switch-when="ARE" ng-switch-when-separator="|">
                                        <textarea ng-model="formdata[item.FldName]" class="form-control datepicker" ng-required="item.FldStatus==2"></textarea>
                                    </div>
                                    <!--END TEXTAREA-->

                                    <!--HTML EDITOR-->
                                    <div class="animate-switch" ng-switch-when="HTML" ng-switch-when-separator="|">
                                        <textarea ui-tinymce="tinymceOptions" ng-model="formdata[item.FldName]" class="form-control datepicker" ng-required="item.FldStatus==2"></textarea>
                                    </div>
                                    <!--END EDITOR-->

                                    <!--COMBOBOX-->
                                    <div class="animate-switch" ng-switch-when="CCB" ng-switch-when-separator="|">
                                        <select ng-model="formdata[item.FldName]" class="form-control">
                                            <option ng-repeat="option in item.FldSource track by option.id" ng-value="option.id" ng-selected="option.id==formdata[item.FldName]">{{option.text}}</option>
                                        </select>
                                    </div>
                                    <!--END COMBOBOX-->

                                    <!--NUMBER-->
                                    <div class="animate-switch" ng-switch-when="NUM" ng-switch-when-separator="|">
                                        <input type="number" ng-model="formdata[item.FldName]" class="form-control" placeholder="Mời nhập {{item.FldLabel}}" ng-required="item.FldStatus==2" />
                                    </div>
                                    <!--END NUMBER-->
                                    <!--NUMBER-->
                                    <div class="animate-switch" ng-switch-when="FLOAT" ng-switch-when-separator="|">
                                        <input type="number" ng-model="formdata[item.FldName]" class="form-control" placeholder="Mời nhập {{item.FldLabel}}" ng-required="item.FldStatus==2" />
                                    </div>
                                    <!--END NUMBER-->
                                    <!--CHECKBOX-->
                                    <div class="animate-switch" ng-switch-when="CKB" ng-switch-when-separator="|">
                                        <input type="checkbox" ng-model="formdata[item.FldName]" placeholder="Mời nhập {{item.FldLabel}}" />
                                    </div>
                                    <!--TIMEPICKER-->
                                    <div class="animate-switch" ng-switch-when="TIME" ng-switch-when-separator="|">
                                        <%--<select ng-model="gio">
                                             <option ng-repeat="item in ['01', '02', '03','04', '05', '06', '07', '08', '09', '10', '11', '12', '13', '14', '15', '16', '17', '18', '19','20', '21', '22' ,'23' ]" ng-value="item" ng-selected="item=='01'">{{item}}</option>
                                         </select>
                                         Giờ
                                         <select ng-model="phut">
                                             <option ng-repeat="item in ['00', '10', '15', '20', '30', '40', '45', '50']" ng-value="item">{{item}}</option>
                                         </select>
                                         Phút--%>
                                        <input type="text" class="form-control" ng-model="formdata[item.FldName]" placeholder="Mời nhập {{item.FldLabel}} có định dạng hh:mm:00" />
                                    </div>
                                    <!--TIMESPANS-->
                                    <div class="animate-switch" ng-switch-when="TIMES" ng-switch-when-separator="|">
                                        <%--<select ng-model="dgio">
                                             <option ng-repeat="item in ['01', '02', '03','04', '05', '06', '07', '08', '09', '10', '11', '12', '13', '14', '15', '16', '17', '18', '19','20', '21', '22' ,'23' ]" ng-value="item" ng-selected="item=='01'">{{item}}</option>
                                         </select>
                                         Tiếng
                                         <select ng-model="dphut">
                                             <option ng-repeat="item in ['00', '10', '15', '20', '30', '40', '45', '50']" ng-value="item">{{item}}</option>
                                         </select>
                                         Phút--%>
                                        <input type="text" class="form-control" ng-model="formdata[item.FldName] " placeholder="Mời nhập {{item.FldLabel}} có định dạng hh:mm:00" />
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="modal-footer">
                            <button type="button" class="btn btn-flat btn-warning pull-left" data-dismiss="modal">Hủy</button>
                            <button type="button" ng-repeat="item in btnUpdates" class="btn btn-flat btn-success" ng-show="item.act==action" type="button" ng-click="Exec(item)"><i class="fa fa-spin" ng-show="loading"></i><i class="fa fa-save"></i>&nbsp;{{item.Btn_Name}}</button>
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
