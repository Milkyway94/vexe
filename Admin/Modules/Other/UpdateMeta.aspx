<%@ Page Language="C#" AutoEventWireup="true"  ValidateRequest="false" CodeFile="UpdateMeta.aspx.cs" Inherits="Administrator_Modules_Weblink_Weblink" %>
<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Untitled Page</title>
</head>
<body leftmargin="0" topmargin="0">
    <form id="form1" runat="server">
    <center>
        <asp:LinkButton ID="lbtUpdate" runat="server" OnClick="lbtUpdate_Click"><b>Cập nhật</b></asp:LinkButton>
    </center>
    <table>
        <tr>
            <td>
                <div>Các thẻ trên Head</div>
                <div><asp:textbox id="HeadContent" Width="350px" Height="200" TextMode="MultiLine" runat="server"></asp:textbox></div>
            </td>
            <td>
                <div>Mã AddThis</div>
                <div><asp:textbox id="AddThis" Width="350px" Height="200" TextMode="MultiLine" runat="server"></asp:textbox></div>  
            </td>
            <td>
                <div>Mã dưới trang</div>
                <div><asp:textbox id="Adsbottom" Width="350px" Height="200" TextMode="MultiLine" runat="server"></asp:textbox></div>
            </td>
        </tr>
        <tr>
            <td>
                <div>Mã Ads trái</div>
                <div><asp:textbox id="Adsleft" Width="350px" Height="200" TextMode="MultiLine" runat="server"></asp:textbox></div>
            </td>
            <td>
                <div>Mã Ads phải</div>
                <div><asp:textbox id="Adsright" Width="350px" Height="200" TextMode="MultiLine" runat="server"></asp:textbox></div>  
            </td>
            <td>
                <div>Mã dưới bài viết</div>
                <div><asp:textbox id="Adscontent" Width="350px" Height="200" TextMode="MultiLine" runat="server"></asp:textbox></div>
            </td>
        </tr>
    </table>
    </form>
</body>
</html>
