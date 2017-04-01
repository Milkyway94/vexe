<%@ Control Language="C#" AutoEventWireup="true" CodeFile="RightAccess.ascx.cs" Inherits="Admin_Modules_Function_Controls_RightAccess" %>
<link rel="stylesheet" href="<%=sRootAppPath %>css/Style.css" type="text/css" />
<script language="javascript" type="text/javascript">
function window.onload(){			
	doCheckItem();
}
function doCheckGroup(){
	var oSrcCheck=window.event.srcElement;
	var cAtt=oSrcCheck.id;
	var oCheck=document.getElementsByName("chkID");
	var sAtt=""
	for (ck=0;ck<oCheck.length;ck++){
		sAtt=oCheck[ck].getAttribute("c");
		if(sAtt==cAtt) oCheck[ck].checked=oSrcCheck.checked;
	}			
}
function doCheckItem(){			
	var oSrcCheck=window.event.srcElement;
	var sGroupID;
	var chkStatus;
	var oAllCheck;
	var sAtt;
	var bBool;			
	if (oSrcCheck)
	{				
		sGroupID=oSrcCheck.getAttribute("c");
		chkStatus=document.getElementById(sGroupID).checked;
		oAllCheck=document.getElementsByName("chkID");
		sAtt=""	
		bBool=true;			
		for (ik=0;ik<oAllCheck.length;ik++){
			sAtt=oAllCheck[ik].getAttribute("c");
			if(sAtt==sGroupID) {
				bBool=bBool&&oAllCheck[ik].checked;	
				if (bBool==false) break;
			}
		}
		document.getElementById(sGroupID).checked=bBool;
	}
	else
	{	
		var oAllSourceCheck=document.getElementsByName("chkIDGroup");				
		for (ag=0;ag<oAllSourceCheck.length;ag++){					
			oSrcCheck=oAllSourceCheck[ag];					
			sGroupID=oAllSourceCheck[ag].id;					
			chkStatus=document.getElementById(sGroupID).checked;					
			oAllCheck=document.getElementsByName("chkID");					
			sAtt=""	
			bBool=true;
			for (ik=0;ik<oAllCheck.length;ik++){
				sAtt=oAllCheck[ik].getAttribute("c");						
				if(sAtt==sGroupID) {
					bBool=bBool&&oAllCheck[ik].checked;	
					if (bBool==false) break;
				}
			}
			document.getElementById(sGroupID).checked=bBool;					
		}
	}
}
</script>
<table id="toolbar" cellspacing="0">
<tr> 
	<td style="width:149px;"> 
		<table cellspacing="0">
			<tr> 
				<td class="toolBarButton"><img alt="" src="<%=sRootAppPath %>Themes/save.png" align="absmiddle" /> <asp:LinkButton ID="lbtUpdate" runat="server" OnClick="lbtUpdate_Click">Cập nhật</asp:LinkButton></td>
				<td class="toolBarButton" onclick="javascript:window.close();"><img alt="" src="<%=sRootAppPath %>Themes/cancel.gif" align="absmiddle" /> Huỷ bỏ</td>
			</tr>
		</table>
	</td>
</tr>
</table>

<table class="controlbox" width="100%">	
<tr> 
	<td valign="top">
		<fieldset> 
		<legend>Danh mục các chức năng của hệ thống:</legend>
		<table class="fieldbox" width="100%" cellspacing="4">
			<tr>                       			 			
				<td style="padding:10px;">
				    <div style="background:#ffffff; width: 380; height: 290; overflow-y:auto; overflow-x:hidden; border: solid 2px inset;">
                    <asp:CheckBoxList ID="cblRight" runat="server">
                    </asp:CheckBoxList></div>
                </td>
			</tr>
		</table>
		</fieldset>
	</td>
</tr>
</table>