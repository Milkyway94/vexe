<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Search.aspx.cs" Inherits="_Default" %>
<%@ Register Src="~/ucontrols/inc_Right.ascx" TagPrefix="uc1" TagName="inc_Right" %>
<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml" class="no-js">
<head>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <link href="<%=uRoot%>favicon.ico" rel="shortcut icon" type="image/x-icon" />
    <meta http-equiv="content-language" content="vi" />
    <meta name="viewport" content="width=device-width, user-scalable=no, initial-scale=1.0, maximum-scale=1.0, minimum-scale=1.0" />
    <title><asp:Literal ID="ltrTitle" runat="server"></asp:Literal></title>
    <asp:Literal ID="ltrHeadTags" runat="server"></asp:Literal>
    <asp:Literal ID="canonical" runat="server"></asp:Literal>
    <meta name="robots" content="noodp,index,follow" />
    <meta name="revisit-after" content="1 days" />
    <!--Open CSS -->
    <link href="<%=uRoot%>css/bootstrap.css" rel="stylesheet" />
    <link href="<%=uRoot%>css/font-awesome.min.css" rel="stylesheet" />
    <link href="<%=uRoot%>css/animate.min.css" rel="stylesheet" />
    <%--<link rel="stylesheet" id="custom-google-fonts-css" href="http://fonts.googleapis.com/css?family=Roboto%3A100%2C200%2C300%2C400%2C500%2C600%2C700%2C800&amp;subset=latin%2Ccyrillic-ext%2Ccyrillic%2Cgreek-ext%2Cvietnamese%2Clatin-ext" type="text/css" media="all" />--%>
    <link href="<%=uRoot%>css/layout.css" rel="stylesheet" />
    <link href="<%=uRoot%>fancybox/jquery.fancybox.css" rel="stylesheet" />
    <link href="<%=uRoot%>css/bootstrap-datetimepicker.min.css" rel="stylesheet" />
    <!--End CSS -->
    <!--Open JavaScript Top -->
    <%--<script src="<%=uRoot%>js/jquery-1.11.1.min.js"></script>--%>
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/1.11.3/jquery.min.js"></script>
    <script src="<%=uRoot%>js/html5shiv.min.js"></script>
    <script src="<%=uRoot%>fancybox/jquery.fancybox.js"></script>
    <script src="<%=uRoot%>js/moment.js"></script>
    <script src="<%=uRoot%>js/bootstrap-datetimepicker.min.js"></script>
    <script src="<%=uRoot%>js/time.js"></script>
    <!--End JavaScript Top -->
    <!--[if lt IE 9]>
        <script src="js/html5shiv.min.js"></script>
    <![endif]-->
    <!--[if (gte IE 6)&(lte IE 8)]>
      <script type="text/javascript" src="/js/selectivizr-min.js"></script>
      <noscript><link rel="stylesheet" href="css/style.css" /></noscript>
    <![endif]-->
    <%=SMAC.CMSfunc.LoadOther("adword-top")%>
</head>
<body>
    <div class="container">
        <div class="main-container">
            <div class="row"><%=SMAC.CMSfunc.LoadSkin("banner", 0)%></div>
            <div class="nav-res main-nav">
                <asp:Literal ID="ltrMenutop" runat="server"></asp:Literal>
            </div>
            <div class="ultility">
                <div class="dateTime" id="theClock"><script>startclock();</script></div>
                <div class="lang">
                    <ul class="list-unstyled list-inline">
                        <li><a href="#">
                            <img src="<%=uRoot%>images/lang_VN.jpg" alt="" /></a></li>
                        <li><a href="#">
                            <img src="<%=uRoot%>images/lang_EN.jpg" alt="" /></a></li>
                    </ul>
                </div>
                <div class="searchForm">
                    <form id="search" action="<%=uRoot%>Search.aspx">
                        <input type="text" value="" name="q" placeholder="<%=SMAC.CMSfunc._Title("Search")%>..." />
                        <button type="submit" class="btn btnSearchHome"><i class="fa fa-search"></i></button>
                    </form>
                </div>
                <div class="register-link"><a href="#"><i class="fa fa-user"></i> <a href="<%=ResolveUrl("~/dang-ky-hoi-vien.htm")%>"><%=SMAC.CMSfunc._Title("dang-ky-hoi-vien")%></a></div>
            </div>
            <div class="sologan"><marquee behavior="scroll" scrollamount="3" direction="left"><%=SMAC.CMSfunc._Title("sologan")%></marquee></div>
            <div class="clearfix" id="content">
                <uc1:inc_Right runat="server" ID="inc_Right" />
                <div class="col-xs-12 col-md-9">
                    <div class="bread-crumb">
                        <asp:Literal ID="lrtPath" runat="server"></asp:Literal>
                    </div>
                    <asp:Literal ID="ltrListNews" runat="server"></asp:Literal>
                    <asp:Literal ID="ltrPhantrang" runat="server"></asp:Literal>
                </div>
            </div> 
            <footer class="clearfix" id="footer">
                <div class="menuFooter">
                    <asp:Literal ID="ltrMenufooter" runat="server"></asp:Literal>
                </div>
                <div class="container">
                    <div class="row">
                        <div class="col-md-8">
                            <%=SMAC.CMSfunc.LoadOther("Footerinfo")%>
                            <%=SMAC.CMSfunc.LoadOther("Copyright")%>
                        </div>
                        <div class="col-md-4">
                            <div class="letter">
                                <h3><%=SMAC.CMSfunc._Title("dang-ky-ban-tin")%>:</h3>
                                <input id="txtEmail" type="text" class="inputEmail" placeholder="<%=SMAC.CMSfunc._Title("nhap-email")%>" />
                                <input id="SendEmail" type="button" class="btnEmail" title="" />
                            </div>
                            <div class="social"><%=SMAC.CMSfunc.Follow("", "")%></div>
                            <div class="visitor"><%=SMAC.CMSfunc._Title("Visitor")%> <strong><asp:Literal ID="ltrVisitor" runat="server"></asp:Literal></strong> - <%=SMAC.CMSfunc._Title("Online")%> <strong><asp:Literal ID="ltrOnline" runat="server"></asp:Literal></strong></div>
                        </div>
                    </div>
                </div>
            </footer>           
        </div>
        
    </div>
    <div id="fb-root"></div>
    <script type="text/javascript">
        (function (d, s, id) {
            var js, fjs = d.getElementsByTagName(s)[0];
            if (d.getElementById(id)) return;
            js = d.createElement(s); js.id = id;
            js.src = "//connect.facebook.net/vi_VN/all.js#xfbml=1";
            fjs.parentNode.insertBefore(js, fjs);
        }(document, 'script', 'facebook-jssdk'));
    </script>
    <script type="text/javascript" src="//platform.twitter.com/widgets.js"></script>
    <script type="text/javascript">
        var js, fjs = document.getElementsByTagName('script')[0];
        if (!document.getElementById('google-wjs')) {
            js = document.createElement('script');
            js.id = 'google-wjs';
            js.setAttribute('async', 'true');
            js.src = "//apis.google.com/js/plusone.js";
            js.text = "{lang: 'en-US'}";
            fjs.parentNode.insertBefore(js, fjs);
        }
    </script>
    <a href="#" id="scrollTop">&nbsp;<span class="glyphicon glyphicon-chevron-up"></span></a>
    <!--Open JavaScript Bot -->
    <%--<script src="<%=uRoot%>js/bootstrap.min.js"></script>--%>
    <%--<script src="<%=uRoot%>js/jquery.flagstrap.min.js"></script>--%>
    <%--<script src="<%=uRoot%>js/jquery.bxslider.min.js"></script>--%>
    <script src="<%=uRoot%>js/script.js"></script>
    <!--End JavaScript Bot -->
</body>
</html>
