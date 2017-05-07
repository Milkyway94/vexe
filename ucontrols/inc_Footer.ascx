<%@ Control Language="C#" AutoEventWireup="true" CodeFile="inc_Footer.ascx.cs" Inherits="ucontrols_inc_Footer" %>
<footer>
    <div id="goTop" class="go-to-top" style="display: block;"><a title="Go to Top"><i class="fa fa-angle-double-up"></i></a></div>
    <div class="t1">
        <div class="container">
            <div class="col-sm-3 col-xs-12">
                <div class="logo">
                    <asp:Literal Text="" ID="ltrContact" runat="server" />
                </div>
            </div>
            <div class="col-sm-3 col-xs-6 menu-title">
                <h2 class="ftmenutitle">VỀ CÔNG TY</h2>
                <asp:Literal Text="" ID="ltrAboutMenu" runat="server" />
            </div>
            <div class="col-sm-3 col-xs-6 menu-title">
                <h2 class="ftmenutitle">HỖ TRỢ</h2>
                <asp:Literal Text="" ID="ltrSupportMenu" runat="server" />
            </div>
            <div class="col-sm-3 col-xs-12 menu-title">
                <h2>ĐẶT VÉ NGAY ĐỂ NHẬN ƯU ĐÃI</h2> 
                <a href="#" class="btn btn-datve btn-block btn-muave">ĐẶT VÉ</a>
                <p class="find-title">Tìm chúng tôi trên mạng xã hội</p>
                <asp:Literal Text="" ID="ltrSocialIcon" runat="server" />
            </div>
        </div>
    </div>
    <div class="t2">
        <div class="container t2-content">
            <div class="pull-left copyright">
                <asp:Literal Text="" ID="CopyRight" runat="server" />
            </div>
            <div class="pull-right">
                <asp:Literal Text="" ID="Brand" runat="server" />
            </div>
        </div>
    </div>
</footer>
