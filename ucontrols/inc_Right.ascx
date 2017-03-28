<%@ Control Language="C#" AutoEventWireup="true" CodeFile="inc_Right.ascx.cs" Inherits="ucontrols_inc_Right" %>
<div class="col-xs-12 col-md-3">
    <div class="video">
        <div class="video-title">Video <span class="fa fa-angle-double-right"></span></div>
        <asp:Literal ID="ltrVideo" runat="server"></asp:Literal>
    </div>
    <div class="thuvien">
        <div class="thuvien-title"><span><%=SMAC.CMSfunc._Title("thu-vien-anh")%></span></div>
        <asp:Literal ID="ltrThuvien" runat="server"></asp:Literal>
    </div>    
    <%--<div class="sanpham">
        <div class="sanpham-title"><span><%=SMAC.CMSfunc._Title("san-pham-nkt")%></span></div>
        <asp:Literal ID="ltrSanpham" runat="server"></asp:Literal>
    </div>--%>
    <%--<div class="box border support">
        <h3><span>Hỗ trợ trực tuyến</span></h3>
        <asp:Literal ID="ltSupport" runat="server"></asp:Literal>
    </div>--%>
    <%--<div class="tinmoi">
        <div class="tinmoi-title"><%=SMAC.CMSfunc._Title("Tin-moi-nhat")%></div>
        <asp:Literal ID="ltrBaimoi" runat="server"></asp:Literal>
    </div>--%>
    <%=SMAC.CMSfunc.LoadOther("Facebook")%>
    <div class="adv-left"><%=SMAC.CMSfunc.LoadSkin("adv-right",0)%></div>
</div>