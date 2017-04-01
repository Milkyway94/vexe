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
                    <div class="text-center" style="min-height: 350px;">
                        <h1>Hệ thống quản trị Website <a href="http://gosmac.vn"><b class="text-danger">SMACCMS</b></a> Cho <a href="http://Vexedientu.vn">Vexedientu.vn</a></h1>
                    </div>
                    <div style="padding: 5px;">
                        <a href="tel:0988945306" class="as"><i class="fa fa-question-circle-o fa-lg"></i>Bạn muốn hỗ trợ?</a>
                    </div>
                    <div class="version">
                        <p class="text">
                            ©2016 GoMAC Software Solutions<br />
                            Website: <a class="as" style="color: Green;" href="http://www.Gosmac.vn" target="_blank">http://www.Gosmac.vn</a><br />
                            Email: info@gosmac.vn<br />
                            HotLine: <a href="tel:0988945306" class="as"><i class="fa fa-phone fa-lg"></i>0988945306</a>
                        </p>
                    </div>
                </div>
            </div>
        </div>
</asp:Content>
