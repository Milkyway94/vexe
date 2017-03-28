<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ShoppingCart.ascx.cs" Inherits="ucontrols_subcontrol_ShoppingCart" %>
<div id="myModal1" class="modal fade" role="dialog">
        <div class="modal-dialog modal-lg">
            <!-- Modal content-->
            <div class="modal-content">
                <div class="modal-header">
                    <div class="title_libox">
                        <i class="fa fa-shopping-cart"></i>&nbsp;<%=Value.GetValue(Session["vlang"].ToString(), "lbCart") %>
                        <a href="#" class="btn_close_lb" data-dismiss="modal">
                            <img src="../../img/img_close.png" alt="Đóng lightbox"></a>
                    </div>
                </div>
                <div class="modal-body">
                    <div class="ct_giohang">
                        <div class="scroll_horizontal_xs width_common table-responsive" id="shopcart">
                            <table class="table table-bordered table-hover">
                                <tr>
                                    <th>Mã sp</th>
                                    <th>Tên sản phẩm</th>
                                    <th>Giá gốc</th>
                                    <th>Khuyến mãi</th>
                                    <th>Giá bán</th>
                                    <th>Số lượng</th>
                                    <th>Thành tiền</th>
                                    <th>Gỡ</th>
                                </tr>
                                <tr ng-repeat="p in Cart">
                                    <td>{{ p.SKU }}</td>
                                    <td>{{ p.Name }}</td>
                                    <td class="text-right">{{ p.Price | currency : "" : 0 }} đ</td>
                                    <td class="text-right">{{ p.Sale | currency : "" : 0 }} %</td>
                                    <td class="text-right">{{ p.SalePrice | currency : "" : 0 }} đ</td>
                                    <td>
                                        <input class="form-control" id="quantity" ng-change="change(p)" type="number" min="1" max="999" ng-blur="UpdateQuan(p.ID)" ng-model="p.Quantity" />
                                    </td>
                                    <td class="text-right">{{p.Total | currency : "" : 0 }} đ</td>
                                    <td>
                                        <button ng-click="remove(p.ID)" class="btn btn-sm btn-danger">
                                            <span class="glyphicon glyphicon-trash"></span>
                                        </button>
                                    </td>
                                </tr>
                                <tr style="background: #eee">
                                    <td class="text-right" style="font-weight: bold" colspan="6">Tổng cộng:</td>
                                    <td class="text-center" colspan="2">{{ Sum  | currency : "" : 0}} đ</td>
                                </tr>
                                <tr>
                                    <td colspan="8">
                                        <h5 class="do pull-right">**Chi phí trên chưa bao gồm phí vận chuyển (Ship)</h5>
                                    </td>
                                </tr>
                            </table>
                        </div>
                    </div>
                </div>
                <div class="modal-footer">
                    <div class="pull-left txt_tt_muahang"><i class="fa fa-angle-left"></i><a data-dismiss="modal" style="cursor: pointer;" class="txt_666"><%=Value.GetValue(Session["vlang"].ToString(), "lbContinueShop") %></a></div>
                    <a class="btn btn_site_3" href="/checkout.htm"><%=Value.GetValue(Session["vlang"].ToString(), "lbCheckout") %></a>
                </div>
            </div>
        </div>
    </div>