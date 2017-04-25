<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Admin/AdminMasterPage.master" CodeFile="CommentList.aspx.cs" Inherits="Admin_Modules_Comment_CommentList" %>

<asp:Content ContentPlaceHolderID="Main" runat="server">
    <link href="<%=uRoot%>resources/css/review.css" rel="stylesheet" type="text/css" />
    <script src="<%=uRoot%>resources/js/jquery-2.2.0.min.js"></script>
    <script src="<%=uRoot%>resources/js/jquery.raty.min.js"></script>
    <script src="<%=uRoot%>resources/js/routereview.js"></script>
    <script type="text/javascript">
        $(document).ready(function () {
            var language = 'vi';
            if (!language || language == '')
                language = "vi";
            $(".lbforcheck").click(function () {
                $(".lbforcheck").prev().prop("checked", !$(".lbforcheck").prev().prop("checked"));
                console.log($(".lbforcheck").prev().prop("checked"));
                $(".lbforcheck").toggleClass("LabelSelected");
            })
            //Khởi tạo các thuộc tính popup
            initReviewPopup();
        });

    </script>
    <div class="container" ng-controller="CommentController">
        <div class="order-content">
            <div class="container">
                <div class="row">
                    <h1 class="text-center admin-title">BÌNH LUẬN VÀ BÌNH CHỌN CHO NHÀ XE <span class="text-danger">{{Nhaxe[0].Tennhaxe}}</span></h1>
                </div>
                <hr />
                <div class="row">
                    <div class="col-sm-4 col-sm-offset-8" style="padding-right: 15px; padding-bottom: 0px; padding-left: 0;">
                        <div class="w100">
                            <input type="text" class="form-control input-sm" ng-model="SearchKey" placeholder="Nhập từ khóa tìm kiếm" />
                        </div>
                    </div>
                </div>
                <div class="fw">
                    <div id="exportable" class="table-responsive">
                        <table class="table table-bordered table-striped table-hover" id="exportData">
                            <thead>
                                <tr class="table-header">
                                    <th ng-repeat="item in fields" ng-click="sortData(item)"><i class="fa fa-address-card-o"></i>&nbsp;{{item}}<div ng-class="getSortClass(item)"></div>
                                    </th>
                                    <th>Xem/Duyệt</th>
                                </tr>
                            </thead>
                            <tbody>
                                <%--<tr class="loader" ng-show="loader"></tr>--%>
                                <tr ng-repeat="o in orders.slice(((currentPage-1)*itemsPerPage), ((currentPage)*itemsPerPage)) | filter : SearchKey | orderBy:sortColumn:reverseSort">
                                    <td ng-repeat="item in fields">{{o[item]}}</td>
                                    <td>
                                        <button type="button" class="btn btn-warning btn-flat btn-sm" ng-click="view(o)"><i class="fa fa-eye"></i></button>
                                        &nbsp;
                                        <button type="button" class="btn btn-{{o['Trạng thái']!='Đã duyệt'?'success':'danger'}} btn-flat btn-sm" ng-click="Approve(o)"><i class="fa fa-{{o['Trạng thái']!='Đã duyệt'?'check':'ban'}}"></i></button>
                                    </td>
                                </tr>
                            </tbody>
                            <tfoot>
                                <tr>
                                    <td><span class="text-danger" ng-if="orders.length==0">Không có bình luận nào với nhà xe này</span></td>
                                </tr>
                            </tfoot>
                        </table>
                        <div class="pull-right">
                            <pagination total-items="totalItems" ng-model="currentPage" max-size="maxSize" class="pagination-sm" boundary-links="true" rotate="false" num-pages="numPages" items-per-page="itemsPerPage"></pagination>
                            <%--<pre>Trang: {{currentPage}} / {{numPages}}</pre>--%>
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <div id="myModal" class="modal fade" role="dialog">
            <div class="modal-dialog modal-lg">
                ">
        <!-- Modal content-->
                <div class="modal-content">
                    <div class="modal-header">
                        <button type="button" class="close" data-dismiss="modal">&times;</button>
                        <h2 class="modal-title">CHI TIẾT ĐƠN HÀNG</h2>
                    </div>
                    <div class="modal-body" id="modal-body">
                        <div class="wrapper-pop">
                            <div class="title-pop">
                                <img src="<%=uRoot%>resources/images/pop-ico-pen.jpg" alt="">
                                Viết đánh giá
                            </div>
                            <div class="pop-content">
                                <!-- <form id="busrating" name="busrating" method="post" action="/Review/CreateRouteReview"> -->
                                <form id="busrating" class="form-horizontal" method="post" role="form" action="/Review?Create=1">
                                    <asp:Literal ID="ltriph" runat="server"></asp:Literal>
                                    <div class="left-col">
                                        <div class="nhaxe clearfix">
                                            <p>
                                                Nhà xe :<b>
                                                    <asp:Label runat="server" ID="namenhaxe"></asp:Label>
                                                </b>
                                            </p>
                                        </div>
                                        <div class="form-nhaxe clearfix">
                                            <div class="clearfix"></div>
                                            <div class="check-input-name">
                                                <span class="fa fa-user input-icon hidden-sm"></span>

                                                <input id="firstName" name="FirstName" class="txt rating-input-item" type="text" placeholder="Họ tên *" runat="server">
                                                <span class="alert-no"></span>
                                                <span class="alert-yes"></span>
                                            </div>
                                            <div class="clearfix"></div>
                                            <div class="check-input-email">
                                                <span class="fa fa-envelope input-icon hidden-sm"></span>
                                                <input id="email" name="Email" class="txt rating-input-item" type="text" placeholder="Email: *" runat="server">
                                                <span class="alert-no"></span>
                                                <span class="alert-yes"></span>
                                            </div>
                                            <div class="clearfix"></div>
                                            <p>Viết đánh giá (tối thiểu 100 chữ)</p>
                                            <div class="check-input-cmt">
                                                <span class="fa fa-comment input-icon hidden-sm"></span>
                                                <textarea id="comment" class="rating-input-item" name="Comment" placeholder="Chia sẻ những trải nghiệm quý giá của bạn sẽ giúp cho các hành khách khác lựa chọn được chuyến đi tốt nhất."></textarea>
                                                <span class="alert-no"></span>
                                                <span class="alert-yes"></span>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="right-col">
                                        <h6 class="hidden-xs" style="text-transform: uppercase;">
                                            <img src="<%=uRoot%>resources/images/pop-ico-danhgia.png" alt="">Đánh giá:
                                        </h6>
                                        <div class="alert-text">
                                            ( Vui lòng bấm
                                <img src="<%=uRoot%>resources/images/pop-star-silver.png" alt="">
                                            để đánh giá)
                                        </div>
                                        <div class="pop-option-rate rate-chuyendi">
                                            <span class="alert-yes"></span>
                                            <span class="alert-no"></span>
                                            <p><span>Tổng quan:</span></p>
                                            <div class="pop-point-rate pop-point-rate-item" data-id="OverallRating" style="cursor: pointer; width: 140px;">
                                            </div>
                                            <p id="OverallRatingHint" class="RatingHint hidden-sm"></p>
                                            <div class="clearfix"></div>
                                        </div>
                                        <div class="pop-point-rate pop-option-rate rate-chuyendi">
                                            <span class="alert-yes"></span>
                                            <span class="alert-no"></span>
                                            <p><span>Chất lượng:</span></p>
                                            <div class="pop-point-rate pop-point-rate-item" data-id="VehicleQualityRating" style="cursor: pointer; width: 140px;">
                                            </div>
                                            <p id="VehicleQualityRatingHint" class="RatingHint hidden-sm"></p>
                                            <div class="clearfix"></div>
                                        </div>
                                        <div class="pop-option-rate">
                                            <span class="alert-yes"></span>
                                            <span class="alert-no"></span>
                                            <p><span>Đúng giờ:</span></p>
                                            <div class="pop-point-rate pop-point-rate-item" data-id="OnTimeRating" style="cursor: pointer; width: 140px;">
                                            </div>
                                            <p id="OnTimeRatingHint" class="RatingHint hidden-sm"></p>
                                            <div class="clearfix"></div>
                                        </div>
                                        <div class="pop-option-rate">
                                            <span class="alert-yes"></span>
                                            <span class="alert-no"></span>
                                            <p><span>Thái độ phục vụ:</span></p>
                                            <div class="pop-point-rate pop-point-rate-item" data-id="ServiceRating" style="cursor: pointer; width: 140px;">
                                            </div>
                                            <p id="ServiceRatingHint" class="RatingHint hidden-sm"></p>
                                            <div class="clearfix"></div>
                                        </div>
                                    </div>
                                    <div class="clearfix"></div>
                                    <div class="pop-ckb-confirm">
                                        <input class="pop-ckb CheckBoxClass" id="condition" type="checkbox">
                                        <label id="Label1" for="condition" class="CheckBoxLabelClass">&nbsp;</label>
                                        <p>Tôi xác nhận rằng đánh giá này hoàn toàn dựa trên trải nghiệm cá nhân của tôi khi đi chuyến này và tôi không có mối quan hệ cá nhân hay kinh doanh với các hãng xe.</p>
                                    </div>
                                    <a class="btn-danhgia" href="javascript:;" style="text-transform: uppercase;">Gửi Đánh giá</a>
                                </form>
                            </div>
                            <div class="vxr-loading-overlay">
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
