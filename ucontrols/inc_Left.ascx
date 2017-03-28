<%@ Control Language="C#" AutoEventWireup="true" CodeFile="inc_Left.ascx.cs" Inherits="ucontrols_inc_Left" %>
<div class="col-xs-12 col-md-3 no-padding">
    <div class="mainContentLeft">
        <%--<div class="menu-title">Menu</div>--%>
        <asp:Literal ID="ltrMenu" runat="server"></asp:Literal>
    </div>
    <%--<div class="video">
        <div class="video-title">Video <span class="fa fa-angle-double-right"></span></div>
        <asp:Literal ID="Literal1" runat="server"></asp:Literal>
    </div>
    <div class="thuvien">
        <div class="thuvien-title"><span><%=SMAC.CMSfunc._Title("thu-vien-anh")%></span></div>
        <asp:Literal ID="ltrThuvien" runat="server"></asp:Literal>
    </div>    
    <div class="sanpham">
        <div class="sanpham-title"><span><%=SMAC.CMSfunc._Title("san-pham-nkt")%></span></div>
        <asp:Literal ID="ltrSanpham" runat="server"></asp:Literal>
    </div>--%>
    <div class="weblink">
        <h3><%=SMAC.CMSfunc._Title("lien-ket-website")%></h3>
        <asp:Literal ID="ltrWeblink" runat="server"></asp:Literal>
    </div>
    <%--<div class="adv-left"><%=SMAC.CMSfunc.LoadSkin("Adv-left", -1)%></div>--%>
</div>