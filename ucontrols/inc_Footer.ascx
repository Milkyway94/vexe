<%@ Control Language="C#" AutoEventWireup="true" CodeFile="inc_Footer.ascx.cs" Inherits="ucontrols_inc_Footer" %>
<footer>
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
                <br />
                <a href="#" class="btn btn-datve btn-block btn-muave">ĐẶT VÉ</a>
                <h2>Tìm chúng tôi trên mạng xã hội</h2>
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
