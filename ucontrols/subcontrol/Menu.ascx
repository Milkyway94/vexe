<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Menu.ascx.cs" Inherits="ucontrols_subcontrol_Menu" %>
<nav class="navbar navbar-inverse hi-navbar">
  <div class="container">
    <div class="navbar-header">
      <button type="button" class="navbar-toggle" data-toggle="collapse" data-target="#myNavbar">
        <span class="icon-bar"></span>
        <span class="icon-bar"></span>
        <span class="icon-bar"></span> 
      </button>
      <a class="navbar-brand hidden-xs" href="/">
          <asp:Literal runat="server" ID="Logo"/>
      </a>
    </div>
    <div class="collapse navbar-collapse" id="myNavbar">
      <ul class="nav navbar-nav navbar-right">
          <asp:Literal ID="MainMenu" runat="server" />
      </ul>
    </div>
  </div>
</nav>