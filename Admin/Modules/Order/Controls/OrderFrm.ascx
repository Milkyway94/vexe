<%@ Control Language="C#" AutoEventWireup="true" CodeFile="OrderFrm.ascx.cs" Inherits="Admin_Modules_Other_Controls_OrderFrm" %>
<%@ Register Assembly="CKEditor.NET" Namespace="CKEditor.NET" TagPrefix="CKEditor" %>
<link rel="stylesheet" href="<%=sRootAppPath %>css/ADCStyle.css" type="text/css" />
<script type="text/javascript" src="/Scripts/jquery-1.7.1.min.js"></script>
<script type="text/javascript" src="/Scripts/ckeditor/ckeditor.js"></script>
<link rel="stylesheet" href="//code.jquery.com/ui/1.12.0/themes/base/jquery-ui.css">
  <link rel="stylesheet" href="https://jqueryui.com/resources/demos/style.css">
<script src="https://code.jquery.com/jquery-1.12.4.js"></script>
  <script src="https://code.jquery.com/ui/1.12.0/jquery-ui.js"></script>
<script>
  $( function() {
    $( ".datepicker" ).datepicker();
  } );
  </script>
<link href="<%=sRootAppPath %>css/bootstrap.css" rel="stylesheet" />
<link href="<%=sRootAppPath %>css/bootstrap.min.css" rel="stylesheet" />
<table id="toolbar" cellspacing="0">
    <tr>
        <td style="width: 149px">
            <table cellspacing="0">
                <tr>
                    <td class="toolBarButton" id="btnCreate">
                        <img src="<%=sRootAppPath %>Themes/save.png" align="absmiddle" alt="">&nbsp;<asp:LinkButton
                            ID="lbtUpdate" runat="server" OnClick="lbtUpdate_Click">Cập nhật</asp:LinkButton></td>
                    <td class="toolBarButton" id="btnCancel" onclick="javascript:window.close();">
                        <img src="<%=sRootAppPath %>Themes/cancel.gif" align="absmiddle" alt="">&nbsp;Huỷ bỏ</td>
                </tr>
            </table>
        </td>
    </tr>
</table>
<table class="controlbox table" width="100%" cellspacing="2" cellpadding="2">
    <tr>
        <td>Mã hàng</td>
        <td>
            <asp:TextBox ID="txtCode" Width="300" runat="server" required="true"></asp:TextBox></td>
        <td>Tên hàng</td>
        <td>
            <asp:TextBox ID="txtName" Width="300" runat="server" required="true"></asp:TextBox></td>
    </tr>
    <tr>
        <td>User</td>
        <td colspan="3">
            <asp:DropDownList ID="ddlUser" runat="server"></asp:DropDownList>
    </tr>
    <tr>
        <td>Tổng sản lượng</td>
        <td><asp:TextBox ID="txtTotal" Width="300" required="true" runat="server"></asp:TextBox></td>
        <td>Ngày vào chuyền</td>
        <td>
        <asp:TextBox ID="txtBeginDate" Width="300" CssClass="datepicker" runat="server"></asp:TextBox></td>
    </tr>
    <tr>
        <td>Số lượng đã giao</td>
        <td>
        <asp:TextBox ID="txtDGQ" Width="300" required="true" runat="server"></asp:TextBox></td>
    </tr>
    <tr>
        <td>Ngày dự kiến giao</td>
        <td>
            <asp:TextBox ID="txtExpectedDate" required="true" CssClass="datepicker" Width="300" runat="server"></asp:TextBox>
        </td>
    </tr>
</table>