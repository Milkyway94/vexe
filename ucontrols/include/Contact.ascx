<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Contact.ascx.cs" Inherits="ucontrols_frm_frmContact" %>
<div class="content">
    <div class="container">
        <div class="row">
            <div class="col-lg-3 col-md-3 hiden-sm hidden-xs">
                <div class="sidebar">
                    <div class="w100">
                        <div class="top-sidebar">
                            <h3><span class="icon i5"></span><a href="#">Danh sách đối tác</a></h3>
                            <ul>
                               <asp:Literal ID="ltrSidebar" runat="server"></asp:Literal>
                            </ul>
                        </div>
                    </div>
                </div>
            </div>
            <div class="main-content col-md-9 col-lg-9 col-sm-12 col-xs-12">
                <div class="w100">
                    <div class="navigation">
                        <div class="breadcrumb">
                            <h2 id="crumbs"><span typeof="v:Breadcrumb"><i class="fa fa-home fa-lg"></i><i class="fa fa-angle-double-right"></i></span>&nbsp;<strong style="color: #0660ad"><asp:Label ID="LbNavigation" runat="server" Text=""></asp:Label></strong></span></h2>
                        </div>
                    </div>
                </div>
                <div class="w100 gioi-thieu">
                    <div id="content">
                        <asp:Literal ID="ltrListCustomer" runat="server"></asp:Literal>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
<%-- Khách hàng đối tác --%>
<div class="customer">
    <div class="container">
        <h3 class="notify"><span class="circle"><i class="fa fa-circle"></i><i class="fa fa-circle"></i><i class="fa fa-circle"></i></span>Khách hàng và đối tác<span class="circle"><i class="fa fa-circle"></i><i class="fa fa-circle"></i><i class="fa fa-circle"></i><spam></h3>
        <div id="AdLeftBottom">
            <div class="listadv">
                <ul class="slider">
                    <% foreach (var item in LoadCustomer())
                        {
                    %>
                    <div class="slick-slide">
                        <%--<li><a href="<%=SMAC.ProductControl.GetCateNameAsciiByCatID(item.ID)%>/<%=item.Link %>.htm" target="_blank">
                            <img alt="#" src="<%=item.Url %>" /></a>
                        </li>--%>
                    </div>
                    <%
                        }
                    %>
                </ul>

            </div>
        </div>
    </div>
</div>
            <%--<div class="main-content col-md-9 col-lg-9 col-sm-12 col-xs-12">
                <div class="w100">
                    <div class="navigation">
                        <div class="breadcrumb">
                            <h2 id="crumbs"><span typeof="v:Breadcrumb"><i class="fa fa-home fa-lg"></i><i class="fa fa-angle-double-right"></i></span>&nbsp;<strong style="color: #0660ad">Khách hàng & đối tác</strong></span></h2>
                        </div>
                    </div>
                </div>
                <div class="w100 gioi-thieu">
                    <div id="content">
                        <%=SMAC.CMSfunc.LoadOther("Contactinfo")%>
                        <div class="page-main">
                            <div id="googleMap" class="wow zoomIn">
                                <%=SMAC.CMSfunc.LoadOther("map")%>
                            </div>
                            <div class="contact-bottom">
                                <div class="contact-form row">
                                    <h5>Gửi thông tin liên hệ</h5>
                                    <form id="ContactFrm" method="post" action="<%=uRoot%>aspx/ContactProcess.aspx">
                                        <div class="form-group">
                                            <input id="name" name="name" type="text" class="form-control" placeholder="Name">
                                        </div>
                                        <div class="form-group">
                                            <input id="phone" name="phone" type="text" class="form-control" placeholder="Phone">
                                        </div>
                                        <div class="form-group">
                                            <input id="date" name="date" type="text" class="form-control" placeholder="Wedding date">
                                        </div>
                                        <div class="form-group">
                                            <textarea id="message" name="message" class="form-control" rows="5" placeholder="Message"></textarea>
                                        </div>
                                        <div class="form-group clearfix">
                                            <button type="submit" class="btn btn-sm btn-default pull-right">Send</button>
                                        </div>
                                    </form>
                                </div>
                                <div class="contact-img">
                                    <img src="<%=uRoot + SMAC.ModControl.GetModField("Img", p)%>" />
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <script src="<%=uRoot%>resources/js/form.js"></script>
    <script>
        $(document).ready(function () {
            $("#ContactFrm").ajaxForm({
                type: 'post',
                dataType: 'html',
                success: function (data, type) {
                    alert(data);
                }
            });
        });
    </script>--%>
