<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ConfigFrm.ascx.cs" Inherits="Admin_Modules_Config_Controls_ConfigFrm" %>
<link rel="stylesheet" href="<%=sRootAppPath %>css/Style.css" type="text/css" />

<table id="toolbar" cellspacing="0">
    <tr>
        <td style="width: 149px">
            <table cellspacing="0">
                <tr>
                    <td class="toolBarButton" id="btnCreate">
                        <img src="<%=sRootAppPath %>Themes/save.png" align="absmiddle" width="16" height="20">&nbsp;<asp:LinkButton
                            ID="lbtUpdate" runat="server" OnClick="lbtUpdate_Click">Cập nhật</asp:LinkButton></td>
                    <td class="toolBarButton" id="btnCancel" onclick="javascript:window.close();">
                        <img src="<%=sRootAppPath %>Themes/cancel.gif" align="absmiddle" width="16" height="20">&nbsp;Huỷ bỏ</td>
                </tr>
            </table>
        </td>
    </tr>
</table>

<table class="controlbox" width="100%">
    <tr>
        <td valign="top">
            <table class="fieldbox" width="100%" cellspacing="4">
                <tr>
                    <td valign="top" style="position: relative; top: 3px; width: 100px; height: 26px;">Cấu hình:</td>
                    <td>
                        <asp:TextBox ID="txtName" Width="250px" runat="server"></asp:TextBox></td>
                </tr>
                <tr>
                    <td>Mã nhận biết:</td>
                    <td>
                        <asp:TextBox ID="txtCode" Width="250px" runat="server"></asp:TextBox></td>
                </tr>
                <tr>
                    <td>Giá trị:</td>
                    <td>
                        <asp:TextBox ID="txtValues" Width="250px" runat="server"></asp:TextBox></td>
                </tr>
                <tr>
                    <td>Tình trạng:</td>
                    <td>
                        <asp:CheckBox ID="cbIsUse" runat="server"></asp:CheckBox></td>
                </tr>
            </table>
        </td>
    </tr>
</table>
