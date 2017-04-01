<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<%@ Register TagPrefix="uc" TagName="footer" Src="~/ucontrols/inc_Footer.ascx" %>
<%@ Register TagPrefix="uc" TagName="header" Src="~/ucontrols/inc_Top.ascx" %>
<%@ Register TagPrefix="uc" TagName="shopcart" Src="~/ucontrols/subcontrol/ShoppingCart.ascx" %>
<!--ĐƯỢC THIẾT KẾ BỞI CÔNG TY CÔNG NGHỆ VÀ GIẢI PHÁP GOSMAC VIỆT NAM-->
<!DOCTYPE html>
<html lang="en">
<head>
    <meta charset="utf-8">
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <meta name="viewport" content="width=device-width, initial-scale=1">
    <title>
        <asp:Literal ID="ltrTitle" runat="server"></asp:Literal>
    </title>
    <asp:Literal ID="ltrHeadTags" runat="server"></asp:Literal>
    <asp:Literal ID="canonical" runat="server"></asp:Literal>
    <!-- Bootstrap -->
    <link rel="shortcut icon" href="<%=uRoot%>resources/favicon.ico" />
    <link href="<%=uRoot%>resources/css/bootstrap-datepicker3.min.css" rel="stylesheet" type="text/css" />
    <link href="<%=uRoot%>resources/css/font-awesome.min.css" rel="stylesheet" type="text/css" />
    <link href="<%=uRoot%>resources/plugins/jquery-ui-1.11.4/jquery-ui.min.css" rel="stylesheet" />
    <link href="<%=uRoot%>resources/plugins/jquery-ui-1.11.4/jquery-ui.theme.min.css" rel="stylesheet" />
    <link href="<%=uRoot%>resources/plugins/select2/dist/css/select2.min.css" rel="stylesheet" />
    <link href="<%=uRoot%>resources/css/bootstrap.min.css" rel="stylesheet" type="text/css" />
    <link href="<%=uRoot%>resources/css/baocss.css" rel="stylesheet" />
    <link href="<%=uRoot%>resources/css/style.css" rel="stylesheet" type="text/css" />
    <link href="<%=uRoot%>resources/css/uikit.css" rel="stylesheet" type="text/css" />
    <link href="<%=uRoot%>resources/css/custom.css" rel="stylesheet" type="text/css" />
</head>
<body ng-app="App">
    <!--
  ______  _____  ______   _______       ________         __         __ __       ___
 |  ____||     \_/     |(`  ______`)  (  _______)       |  |       /  ||    \   |  |
 | |____ |  | \___/ |  |(  (     | |  (  |               \  \     /  / |  |\ \  |  |
 |____  ||  |       |  |(  (     | |  (  |                \  \   /  /  |  | \ \ |  |
  ____| ||  |       |  |(  (,____| |_ (  |______            \ \_/  /   |  |  \ \|  |
 |______||__|       |__|(,_______,__/ ( ,______,)  (_)       \____/    |__|   \____|-->
    <uc:header runat="server" ID="inc_Top" />
    <section>
        <div id="OperationCell" runat="server"></div>
    </section>
    <uc:footer runat="server" ID="Footer" />
    <script src="<%=uRoot%>resources/js/jquery-2.2.4.min.js"></script>
    <script src="<%=uRoot%>resources/js/bootstrap.min.js"></script>
    <script src="<%=uRoot%>resources/plugins/jquery-ui-1.11.4/jquery-ui.min.js"></script>
    <script src="<%=uRoot%>resources/plugins/select2/dist/js/select2.min.js"></script>
     <script src="<%=uRoot%>resources/js/uikit.min.js"></script>
    <script src="<%=uRoot%>bower_components/bootstrap-timepicker/js/bootstrap-timepicker.js"></script>
    <script src="<%=uRoot%>resources/js/AngularJs.js"></script>
    <script src="<%=uRoot%>resources/js/Main/angular-filter.js"></script>
    <script src="<%=uRoot%>resources/js/Main/app.js"></script>
    <script src="<%=uRoot%>resources/js/Main/Services/service.js"></script>
    <script src="<%=uRoot%>resources/js/Main/ngAutocomplete.js"></script>
    <script src="<%=uRoot%>resources/js/script.js"></script>
    <%--<link href="https://fonts.googleapis.com/css?family=Roboto+Condensed:300,300i,400,400i,700,700i" rel="stylesheet">
    <link href="https://fonts.googleapis.com/css?family=Roboto:400,400i,500,500i,700,700i" rel="stylesheet">--%>
</body>
</html>
