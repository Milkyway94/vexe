<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Loading.aspx.cs" Inherits="Administrator_Loading" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Loading......</title>
    <link rel=stylesheet href="CSS/Style.css" type="text/css">
</head>
<body background="Themes/body_fill3.gif">
    <form id="form1" runat="server">
    <div>
        <table id="tblLoading" border=0 width=100% height=100% cellspacing=0 cellpadding=5>
	        <tr><td height="50%">&nbsp;</td></tr>
	        <tr><td align="center"><b>Đang thực hiện tải thông tin từ máy chủ</b></td></tr>
	        <tr> 
		        <td colspan="3" align="center" valign="middle">
			        <marquee direction="right" scrollamount="9" scrolldelay="80" width="150" style="border:1px solid green">
				        <img border=0 src="images/loadQ.gif">
			        </marquee>
		        </td>
	        </tr>
	        <tr><td align="center"><b>Xin vui lòng đợi...</b></td></tr>
	        <tr><td height="50%">&nbsp;</td></tr>
        </table>
        <script language="javascript">
	        function showWait(show)
	        {
		        if (show) {
			        tblLoading.style.display="block";
			        toolbar.style.display="none";
			        iframe1.style.display="none";
			        context.style.display="none";
			        document.getElementById("dragbar").style.display="none";
		        }
		        else 
		        {			
			        tblLoading.style.display="none";
			        toolbar.style.display="block";
			        document.getElementById("iframe1").style.display="block";
			        document.getElementById("context").style.display="block";
			        document.getElementById("dragbar").style.display="block";
		        }
		        return true;
	        }
	        function window.onload(){
        //		showWait(false);
	        }
        </script>
    </div>
    </form>
</body>
</html>
