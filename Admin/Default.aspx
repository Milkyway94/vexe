<%@ Page Language="C#" MasterPageFile="AdminMasterPage.master" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="Administrator_Default" %>

<asp:Content ID="ContentArticle" ContentPlaceHolderID="Main" runat="Server">
    <script type="text/javascript">
        function changePassword() {
            window.open("Modules/User/ChangePass.aspx", '_blank', 'resizable=yes,width=450px,height=190px,left=270,top=80,scrollbars=0,menubar=0,status=0,derectories=0,toolbar=0,location=0,resizable=0');
        }
        function writeMail() {
            window.open("Modules/User/SendMail.aspx", '_blank', 'resizable=yes,width=460px,height=280px,left=270,top=80,scrollbars=0,menubar=0,status=0,derectories=0,toolbar=0,location=0,resizable=0');
        }
        function SendReport() {
            window.open("Modules/Works/PopupWin.aspx?page=SendReport", '_blank', 'resizable=yes,width=670px,height=580px,left=270,top=80,scrollbars=0,menubar=0,status=0,derectories=0,toolbar=0,location=0,resizable=0');
        }
        function setToggleBox(strDepencyFrame) {
            var oSrc = window.event.srcElement;
            var oDep = document.getElementById(strDepencyFrame);
            if (oSrc) {
                var strSourcePath = oSrc.src;
                if (strSourcePath) {
                    var upPath = strSourcePath.substr(strSourcePath.length - 6, strSourcePath.length);
                    var downPath = strSourcePath.substr(strSourcePath.length - 8, strSourcePath.length);
                    if (upPath == 'up.gif') {
                        oSrc.src = strSourcePath.replace(upPath, 'down.gif');
                        if (oDep) oDep.style.display = "none";
                        return;
                    }
                    if (downPath == 'down.gif') {
                        oSrc.src = strSourcePath.replace(downPath, 'up.gif');
                        if (oDep) oDep.style.display = "block";
                        return;
                    }
                }
            }
        }
    </script>
    <div class="container">
        <div id="tblMain">
            <div class="col-md-12 col">
                <div class="text">
                    <marquee class="marquee" scrollamount="2" scrolldelay="1" direction="up">
		                <b>Công ty CP Giải pháp và công nghệ GoSMAC Việt Nam</b>, tên giao dịch tiếng anh là GoSMAC Solutions And Technology là đơn vị hoạt động chuyên nghiệp trong lĩnh vực Tích hợp Hệ thống, Phát triển phần mềm và Dịch vụ Công nghệ Thông tin.
		                <br/>
		                <strong>Mục tiêu của GoSMAC</strong> là hỗ trợ các đơn vị kinh tế, xã hội tham gia 
		                hoạt động tuyên truyền, quảng bá, kinh doanh trên mạng internet toàn cầu đạt 
		                hiệu quả cao nhất với mức chi phí thấp nhất.
		                <br/>
		                <p><strong>Các giải pháp</strong>
                            <li>GoSMAC.Trading: Core giao dịch trực tuyến cho cty chứng khoán</li>
                            <li>GoSMAC.Portal: Cổng thông tin điện tử</li>
                            <li>GoSMAC.Web : Website thương mại</li></p>
                        <p><strong>Các dịch vụ</strong>
                            <li>Tư vấn thiết kế phần mềm lõi, website thương mại</li>
                            <li>Social Marketing</li>
                            <li>Lập trình Core</li>
                            <li>Phát triển ứng dụng thiết bị thông minh</li></p>
		                <strong>GoSMAC xin cam kết</strong> luôn đi đầu về tích hợp hệ thống, Công nghệ mới nhất, Hỗ trợ lâu dài, Chi phí tối thiếu
		                <br>
                        <p><strong>Danh sách khách hàng:</strong> Cty CP CK Châu Á Thái Bình Dương (APEC), Cty CP DataCloud, Cty CP An Phát Sài gòn, MarukoVietNam Group, Cty Fitech, Cty CP may Bắc Giang – xí nghiệp may Lạng Giạng
Cục Thuế Hà Nội</p>
		                <p>>Mọi chi tiết xin liên hệ với chúng tôi :</p>
		                Số điện thoại : 091-5251-505
		                <p>email : support@Gosmac.vn</p>
		                <HR color="#f7f8f9" SIZE="1">
		                Hệ thống này được lập trình bởi : GoSMAC Team<br/>
		                Thiết kế giao diện : GoSMAC TT Team</marquee>
                </div>
                <div style="padding: 5px;">
                    <table cellspacing="0" cellpadding="3" width="100%" border="0">
                        <tr>
                            <td><a href="tel:0982112395" class="as"><i class="fa fa-question-circle-o fa-lg"></i>Bạn muốn hỗ trợ?</a></td>
                        </tr>
                    </table>
                </div>
                <div class="version">
                    <p class="text">
                        ©2016 GoMAC Software Solutions<br/>
                        <a class="as" style="color: Green;" href="http://www.Gosmac.vn" target="_blank">http://www.Gosmac.vn</a>
                    </p>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
