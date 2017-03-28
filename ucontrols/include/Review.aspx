<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Review.aspx.cs" Inherits="ucontrols_include_Review" %>


 <link href="<%=uRoot%>resources/css/review.css" rel="stylesheet" type="text/css" />
 <script src="<%=uRoot%>resources/js/jquery-2.2.0.min.js"></script>
 <script src="<%=uRoot%>resources/js/jquery.raty.min.js"></script>
 <script src="<%=uRoot%>resources/js/routereview.js"></script>
<script type="text/javascript">
        $(document).ready(function () {

            var language = 'vi';
            if (!language || language == '')
                language = "vi";
            
            //Khởi tạo các thuộc tính popup
            initReviewPopup();
        });
    </script>

<div class="fw kiemtrave">
    <div class="container">
        <ul class="uk-breadcrumb hi-padding">
            <asp:Literal ID="lbnav" runat="server" Text=""></asp:Literal>
        </ul>
        <!-- Begin -->
        <div class="wrapper-pop">
           <div class="title-pop">
              <img src="<%=uRoot%>resources/images/pop-ico-pen.jpg" alt="">
              Viết đánh giá
           </div>
           <div class="pop-content">
              <!-- <form id="busrating" name="busrating" method="post" action="/Review/CreateRouteReview"> -->
              <form id="busrating" class="form-horizontal" method="post" role="form" action="/Review?Create=1">
                  <asp:literal ID="ltriph" runat="server"></asp:literal>
                 <div class="left-col">
                    <div class="nhaxe clearfix">
                       <p>Nhà xe :<b> <asp:label runat="server" id="namenhaxe"></asp:label> </b> </p>
                       
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
                    <div class="alert-text">( Vui lòng bấm <img src="<%=uRoot%>resources/images/pop-star-silver.png" alt=""> để đánh giá)</div>
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
        <!-- #end -->
</div>
