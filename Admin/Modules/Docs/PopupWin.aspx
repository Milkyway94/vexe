<%@ Page language="c#" ValidateRequest="false" Inherits="OpenWin" CodeFile="PopupWin.aspx.cs"%>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >
    <head id="Head2" runat="server">    
		<title>Administrtor</title>
        <asp:literal id="ltJavascript" runat="server"></asp:literal>
		<script language="JavaScript">
		<!--
		function refreshParent(url) {
		window.opener.location.href = url;
		if (window.opener.progressWindow)
		{
			window.opener.progressWindow.close()
		}
		window.close();
		}
		//-->
		</script>
		<link href="../../../Admin/css/StyleSheet.css" rel="stylesheet" type="text/css" />
	</head>
	<body style="background:#EEEEEE; margin:0;">
		<form id="Form1" method="post" runat="server">
            <asp:ScriptManager ID="ScriptManager1" runat="server">
            </asp:ScriptManager>
			<div id="OperationCell" runat="server"></div>
		</form>
	</body>
</html>
