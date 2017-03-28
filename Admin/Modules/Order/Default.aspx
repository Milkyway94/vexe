<%@ Page Language="C#" MasterPageFile="~/Admin/AdminMasterPage.master" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="Admin_Modules_Order_Default" %>

<asp:Content ContentPlaceHolderID="main" runat="server">
    <script type="text/jscript">
        $(document).ready(function () {
            //=========================Check all===============================
            $('#ckpf').click(function (event) {  //on click
                if (this.checked) { // check select status
                    $('.ckpf').each(function () { //loop through each checkbox
                        this.checked = true;  //select all checkboxes with class "checkbox1"
                    });
                } else {
                    $('.ckpf').each(function () { //loop through each checkbox
                        this.checked = false; //deselect all checkboxes with class "checkbox1"
                    });
                }
            });
            //=========================Delete All================================
            $("#delete").click(function () {
                var selectedIDs = new Array();
                var searchIDs = $('input:checked').map(function () {
                    selectedIDs.push($(this).val());
                });
                var str = "{\"IDS\":[";
                for (var i = 0; i < selectedIDs.length; i++) {
                    if (i != selectedIDs.length - 1) {
                        str += selectedIDs[i] + ",";
                    }
                    else {
                        str += selectedIDs[i]
                    }
                }
                str += "]}";
                var options = {};
                options.url = '<%=ResolveUrl("~/ucontrols/subcontrol/OrderInfo.aspx/RemovePFs")%>';
                options.type = "POST";
                options.data = str;
                options.contentType = "application/json";
                options.dataType = "json";
                options.success = function (data) {
                    for (var i = 0; i < selectedIDs.length; i++) {
                        $("#pftr_" + selectedIDs[i]).remove();
                    }
                };
                if (confirm("Bạn có thực sự muốn xóa những sản phẩm  đã chọn không?")) {
                    $.ajax(options);
                }
            });
        });

       
        
        function StartProduce(oid) {
            jQuery.ajax({
                url: '<%=ResolveUrl("~/ucontrols/subcontrol/OrderInfo.aspx/StartProduce")%>',
                type: "POST",
                data: "{'oid':" + oid + "}",
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (data) {
                    console.log(data.d);
                }
            });
        }
        function ApproveOrder(oid) {
            jQuery.ajax({
                url: '<%=ResolveUrl("~/ucontrols/subcontrol/OrderInfo.aspx/ApproveOrder")%>',
                type: "POST",
                data: "{'oid':" + oid + "}",
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (data) {
                    console.log(data.d);
                }
            });
        }
        function DismissOrder(oid) {
            if (confirm("Bạn có thực sự muốn bỏ qua đơn hàng này không? Nếu bạn quyết định bỏ, Bạn sẽ không bao giờ thấy nó ở trang này nữa, Bạn có chắc chắn? ")) {
                jQuery.ajax({
                    url: '<%=ResolveUrl("~/ucontrols/subcontrol/OrderInfo.aspx/DismissOrder")%>',
                    type: "POST",
                    data: "{'oid':" + oid + "}",
                    contentType: "application/json; charset=utf-8",
                    dataType: "json",
                    success: function (data) {
                        console.log(data.d);
                    }
                });
            }
        }
        function VertifyOrder(oid) {
            jQuery.ajax({
                url: '<%=ResolveUrl("~/ucontrols/subcontrol/OrderInfo.aspx/VertifyOrder")%>',
                type: "POST",
                data: "{'oid':" + oid + "}",
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (data) {
                    console.log(data.d);
                }
            });
        }
        function CompleteOrder(oid) {
            jQuery.ajax({
                url: '<%=ResolveUrl("~/ucontrols/subcontrol/OrderInfo.aspx/CompleteOrder")%>',
                type: "POST",
                data: "{'oid':" + oid + "}",
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (data) {
                    console.log(data.d);
                }
            });
        }
        function SeeOrderDetail(oid) {
            jQuery.ajax({
                url: '<%=ResolveUrl("~/ucontrols/subcontrol/OrderInfo.aspx/SeeOrderDetail1")%>',
                type: "POST",
                data: "{'oid':" + oid + "}",
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (data) {
                    console.log(data);
                    var dt = JSON.parse(data.d);
                    var str = "";
                    str += "<div class=\"row\">";
                    str += "<div class=\"col-sm-3 suggess\">Họ tên:</div>";
                    str += "<div class=\"col-sm-3 o-content\">" + dt.TenKH + "</div>";
                    str += "<div class=\"col-sm-3 suggess\">Số điện thoại:</div>";
                    str += "<div class=\"col-sm-3 o-content\">" + dt.SDT + "</div>";
                    str += "</div>";
                    str += " <div class=\"row\">";
                    str += "<div class=\"col-sm-3 suggess\">Địa chỉ:</div>";
                    str += "<div class=\"col-sm-3 o-content\">" + dt.DC + "</div>";
                    str += "<div class=\"col-sm-3 suggess\">Email:</div>";
                    str += "<div class=\"col-sm-3 o-content\">" + dt.Email + "</div>";
                    str += "</div>";
                    str += "<div class=\"row\">";
                    str += "<div class=\"col-sm-3 suggess\">Ngày đặt hàng:</div>";
                    str += "<div class=\"col-sm-3 o-content\">" + dt.NgayTao + "</div>";
                    str += "<div class=\"col-sm-3 suggess\">Loại đơn hàng:</div>";
                    str += "<div class=\"col-sm-3 o-content\">" + dt.LoaiDH + "</div>";
                    str += "</div>";
                    if (dt.IDLoaiDH == "1") {
                        str += "<div class=\"row\">";
                        str += " <div class=\"col-sm-12 suggess\">Nôi dung đặt hàng: </div>";
                        str += "<div class=\"col-sm-12 o-content\"> &nbsp;&nbsp;<p>" + dt.NDYC + "</p></div>";
                        str += "</div>";
                        str += "<div class=\"row\">";
                        str += "<div class=\"col-sm-3 suggess\">File yêu cầu đặt hàng</div>";
                        str += "<div class=\"col-sm-9 o-content\"><a href=\"/" + dt.File + "\">Download</a></div>";
                        str += "</div>";
                    }
                    if (dt.IDLoaiDH == "2") {
                        str += "<div class=\"table-responsive\"><br>";
                        str += " <table class=\"table table-bordered\">";
                        str += "<tr>";
                        str += "<th>Mã sản phẩm</th>";
                        str += "<th>Tên sản phẩm</th>";
                        str += "<th>Giá bán</th>";
                        str += "<th>Số lượng</th>";
                        str += "<th>Thành tiền</th>";
                        str += "</tr>";
                        for (var i = 0; i < dt.ChiTiet.length; i++) {
                            str += "<tr>";
                            str += "<td>" + dt.ChiTiet[i].MaSP + "</td>";
                            str += "<td>" + dt.ChiTiet[i].TenSP + "</td>";
                            str += "<td>" + dt.ChiTiet[i].Gia.toString().replace(/(\d)(?=(\d\d\d)+(?!\d))/g, "$1,") + "đ</td>";
                            str += "<td>" + dt.ChiTiet[i].SoLuong + "</td>";
                            str += "<td>" + dt.ChiTiet[i].ThanhTien.toString().replace(/(\d)(?=(\d\d\d)+(?!\d))/g, "$1,") + "đ</td>";
                            str += "</tr>";
                        }
                        str += "<tr>";
                        str += "<td colspan=3>&nbsp;</td>";
                        str += "<td>Tổng tiền:</td>";
                        str += "<td>" + dt.TongTien.toString().replace(/(\d)(?=(\d\d\d)+(?!\d))/g, "$1,") + "đ</td>";
                        str += "</tr>";
                        str += "<tr>";
                        str += "<td colspan=3>&nbsp;</td>";
                        str += "<td>Giảm giá:</td>";
                        str += "<td>" + dt.Giamgia.toString().replace(/(\d)(?=(\d\d\d)+(?!\d))/g, "$1,") + "đ</td>";
                        str += "</tr>";
                        str += "<tr>";
                        str += "<td colspan=3>&nbsp;</td>";
                        str += "<td>Còn lại:</td>";
                        str += "<td>" + dt.Conlai.toString().replace(/(\d)(?=(\d\d\d)+(?!\d))/g, "$1,") + "đ</td>";
                        str += "</tr>";
                        str += "</table>";
                    }
                    str += "<div class=\"col-sm-12 suggess\">Trạng thái đơn hàng:<span class=\"o-content\"> " + dt.STATUS + "</span></div>";
                    $(".modal-body").html(str);
                    var atr = "<button type=\"button\" class=\"btn btn-danger\" data-dismiss=\"modal\"><i class=\"fa fa-remove\"></i>Đóng</button>";
                    atr += "<button class=\"btn btn-warning\" onclick=\"DismissOrder(" + dt.ID + ")\"><i class=\"fa fa-stop-circle\"></i>Bỏ qua</button>";
                    atr += "<button class=\"btn btn-primary\" onclick=\"ApproveOrder(" + dt.ID + ")\"><i class=\"fa fa-check\"></i>Duyệt</button>";
                    $(".modal-footer").html(atr);
                }
            });
        }
    </script>
    <style>
        .suggess {
            font-weight: bold;
            font-size: 14px;
        }

        .o-content {
            color: orangered;
            font-weight: 600;
        }

        .admin-title {
            font-weight: bold;
        }
        .w80{width: 80%; float: left;}
        .w20{width: 20%;float: left;}
    </style>
    <div class="container">
        <div class="order-content">
            <div class="container">
                <div class="row">
                    <h1 class="text-center admin-title">QUẢN LÝ ĐƠN HÀNG</h1>
                </div>
                <hr />
                <div class="row">
                    <div class="col-sm-6" style="padding-bottom: 0px; padding-left: 15px;">
                        <div class="w20"><asp:TextBox ID="txtd1" CssClass="form-control input-sm datepicker" data-inputmask="'alias': 'mm/dd/yyyy'" data-mask ClientIDMode="Static" runat="server" placeholder="Lọc Từ ngày"></asp:TextBox></div>
                        <div class="w20"><asp:TextBox ID="txtd2" CssClass="form-control input-sm datepicker" data-inputmask="'alias': 'mm/dd/yyyy'" data-mask runat="server" placeholder="Lọc Đến ngày"></asp:TextBox></div>
                        <asp:Button ID="btnExport" CssClass="btn btn-success btn-sm btn-flat" OnClick="btnExport_Click" Text="Xuất ra excel" runat="server" />
                    </div>
                    <div class="col-sm-4 col-sm-offset-2" style="padding-right: 15px; padding-bottom: 0px; padding-left: 0;">
                        <div class="w80"><asp:TextBox ID="txtordersearch" CssClass="form-control input-sm"  runat="server"></asp:TextBox></div>
                        <div class="w20"><asp:Button ID="Button1" CssClass="btn btn-success btn-block btn-sm btn-flat pull-right" OnClick="btnOrderSearch_Click" Text="Tìm kiếm" runat="server" /></div>
                    </div>
                    <div class="table-responsive col-sm-12">
                        <table class="table table-bodered table-stripped">
                            <thead style="height: 44px !important">
                                <tr>
                                    <th>STT</th>
                                    <th>Tên khách hàng</th>
                                    <th>Số điện thoại</th>
                                    <th>Loại đơn hàng</th>
                                    <th>Ngày tạo</th>
                                    <th>Trạng thái</th>
                                    <th>Tùy chọn</th>
                                </tr>
                            </thead>
                            <%--<tbody>
                                <% int i = 1;
                                    foreach (var item in ) //LoadOrderList())
                                    {

                                %>
                                <tr>
                                    <td><%=i %></td>
                                    <td><%=item.Order_Ten %></td>
                                    <td><%=item.Order_Tel %></td>
                                    <td><%=//SMAC.OrderControls.GetOrderTypeByID(item.Order_Type).OrderType_Name %></td>
                                    <td><%=item.Order_CreatedDate.Value.ToShortDateString() %></td>
                                    <td id="status_<%=item.Order_ID %>" style="color: red;"><%=GetStatus(item.Order_Status.ToString())%></td>
                                    <td>
                                        <%
                                            switch (item.Order_Status)
                                            {
                                                case 1:
                                        %>
                                        <button class="btn btn-primary" data-toggle="modal" data-target="#myModal" type="button" onclick="SeeOrderDetail(<%=item.Order_ID %>)" id="btnSee">Xem</button>
                                        <%
                                                break;
                                            case 2:%>
                                        <button class="btn btn-primary" onclick="StartProduce(<%=item.Order_ID %>)" id="btnSee">Nhận giao</button>
                                        <%
                                                break;
                                            case 3:%>
                                        <button class="btn btn-warning" onclick="VertifyOrder(<%=item.Order_ID %>)" id="btnVer">Xác nhận đã giao</button>
                                        <%break;
                                            case 4:%>
                                        <button class="btn btn-success" type="submit" onclick="CompleteOrder(<%=item.Order_ID %>)" id="btnCom">Hoàn thành</button>
                                        <%break;
                                            case 5: %>
                                        <h5 style="color: green">Đã hoàn thành</h5>
                                        <%     
                                                    break;
                                                default:
                                                    break;
                                            }
                                        %>
                                    </td>
                                </tr>
                                <%
                                        i++;
                                    } %>
                                <tr></tr>
                            </tbody>--%>
                        </table>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <script type="text/javascript">
        function OpenPopup(id, act) {
            window.open("PopupWin.aspx?act=" + act + "&id=" + id + "&page=Order", "List", "toolbar=no, location=no,status=yes,menubar=no,scrollbars=yes,resizable=no, width=900,height=500,left=430,top=100");
            return false;
        }
    </script>
    <div id="myModal" class="modal fade" role="dialog">
        <div class="modal-dialog modal-lg">
            ">
        <!-- Modal content-->
            <div class="modal-content">
                <div class="modal-header">
                    <button type="button" class="close" data-dismiss="modal">&times;</button>
                    <h2 class="modal-title">CHI TIẾT ĐƠN HÀNG</h2>
                </div>
                <div class="modal-body">
                </div>
                <div class="modal-footer">
                </div>
            </div>

        </div>
    </div>
</asp:Content>
