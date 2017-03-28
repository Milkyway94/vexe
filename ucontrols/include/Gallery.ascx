<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Gallery.ascx.cs" Inherits="ucontrols_Video" %>
<div id="main-content" class="blog-grid dark" data-wow-duration="2s">
    <div class="page-wrapper">
        <div id="ajax-folio-item" style="display: block;">
            <div class="page-wrapper">

                <!-- Sidebar -->
                <div class="page-side hidden-sm hidden-xs">
                        <div class="inner-wrapper vcenter-wrapper">
                        <div class="side-content vcenter">
                            <div class="title">
                                <span><%=SMAC.ModControl.GetModField("Name", p)%></span>
                            </div>
                            <div class="grid-filters-wrapper">
                                <a href="#" class="select-filter"><i class="fa fa-filter"></i> <%=SMAC.CMSfunc._Title("bo-loc")%></a>
                                <ul class="grid-filters direct-list">
                                    <li class="active"><a href="#" data-filter="*"><%=SMAC.CMSfunc._Title("tat-ca")%></a></li>
                                    <asp:Literal ID="ltrSubmod" runat="server"></asp:Literal>
                                </ul>
                            </div>
                        </div>
                    </div>
                </div>
                <!-- /Sidebar -->
                <!-- main contents -->
                <div class="page-main blog-list">
                    <div class="inner-wrapper sync-width-parent">
                        <!-- parallax header -->
                        <div class="portfolio-md-detail visible-sm visible-xs">
                        </div>
                        <!-- the contents of the page -->
                        <div class="parallax-picture">
                            <asp:Literal ID="ltrListContent" runat="server"></asp:Literal>
                        </div>
                    </div>
                </div>
                <!-- /main contents -->
            </div>
        </div>
    </div>
</div>
<script>
    $('.blog-list').height($(window).height())
</script>