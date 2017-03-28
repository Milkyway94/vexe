<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Service.ascx.cs" Inherits="ucontrols_include_Products" %>
<div id="main-content">
    <div class="page-wrapper regular-page wow zoomIn" data-wow-duration="2s">
        <div class="container">
            <asp:Literal ID="ltrAboutService" runat="server"></asp:Literal>
      		<div class="row mb-xlarge">
      			<div class="col-xs-12">
      				<div class="vertical-services">
      					<ul>
      						<asp:Literal ID="ltrListService" runat="server"></asp:Literal>
      					</ul>
      				</div>
      			</div>
      			<div class="col-md-4">
      				<h3>&nbsp;</h3>
      			</div>
      		</div>
      		<div class="row mb-xlarge">
      			<div class="col-md-12">
      				<div class="call-to-action">
      					<div class="row">
      						<div class="col-md-10">
      							<h2><%=SMAC.CMSfunc._Title("hay-lien-he")%></h2>
      						</div>
      						<div class="col-md-2">
      							<a class="btn btn-toranj" href="lien-he.htm"><%=SMAC.CMSfunc._Title("lien-he")%></a>
      						</div>
      					</div>
      				</div>
      			</div>
      		</div>
			<hr>
        </div>
    </div>
</div>