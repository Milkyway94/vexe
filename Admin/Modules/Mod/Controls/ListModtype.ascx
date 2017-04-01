<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ListModtype.ascx.cs" Inherits="Adadmin_Modules_Mess_Controls_ToUser" %>
<link rel="stylesheet" href="<%=sRootAppPath %>css/Style.css" type="text/css">
<script type="text/javascript" language="javascript">
function window.onload(){			
	doCheckItem();
}
function PopupWin(url,w,h)
{
    window.open(url, '_blank', 'resizable=yes,width='+w+',height='+h+',left=270,top=80,scrollbars=0,menubar=0,status=0,derectories=0,toolbar=0,location=0,resizable=0');
}
function doCheckGroup()
{
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

<table id=toolbar cellspacing="0">
<tr> 
	<td style="width: 149px"> 
		<table cellspacing="0">
			<tr> 				
				<td class="toolBarButton" id="btnCancel" onclick="javascript:window.close();"><img src="<%=sRootAppPath %>Images/icons/button_cancel.gif" align="absmiddle" width="16" height="20">&nbsp;Huỷ bỏ</td>
			</tr>
		</table>
	</td>
</tr>
</table>

<table class="controlbox" width="100%">	
<tr> 
	<td valign="top">
		<table class="fieldbox" width="100%" cellspacing="0">
			<tr>                       			 			
				<td>
				    <div style="background:#ffffff; width: 380; height: 240; overflow-y:auto; overflow-x:hidden; border: solid 2px inset;">
                    <asp:DataGrid ID="dgrModtype" runat="server" AllowPaging="True" AutoGenerateColumns="False"
                    CellPadding="1" OnItemCommand="dgrModtype_ItemCommand" OnItemDataBound="dgrModtype_ItemDataBound"
                    PageSize="20" Width="100%" BackColor="White" BorderColor="#E7E7FF" BorderStyle="None" BorderWidth="1px" GridLines="Horizontal" OnPageIndexChanged="dgrModtype_PageIndexChanged">
                    <Columns>
                        <asp:TemplateColumn HeaderText="Check">
                            <HeaderTemplate>
                                <input id="cbAll" type="checkbox" onclick="AllSelect(this)" />
                            </HeaderTemplate>
                            <ItemTemplate>
                                <asp:CheckBox ID="cbItem" runat="server" />
                            </ItemTemplate>
                        </asp:TemplateColumn>
                        <asp:TemplateColumn HeaderText="Tiêu đề">
                            <ItemTemplate>
                                <asp:HyperLink ID="hplName" runat="server"></asp:HyperLink>
                            </ItemTemplate>
                        </asp:TemplateColumn>
                        <asp:TemplateColumn HeaderText="Trạng thái">
                            <HeaderStyle HorizontalAlign="Center" />
                            <ItemStyle HorizontalAlign="Center" Width="80px" />
                            <ItemTemplate>
                                <asp:ImageButton ID="imgIsUse" CommandName="isUse" runat="server" ImageUrl="../../Images/icons/icon_important.gif" />
                            </ItemTemplate>
                        </asp:TemplateColumn>
                        <asp:TemplateColumn HeaderText="Option">
                            <HeaderStyle HorizontalAlign="Center" />
                            <ItemStyle HorizontalAlign="Center" Width="60px" />
                            <ItemTemplate>
                                <asp:Image ID="imgEdit" CssClass="Img" runat="server" ImageUrl="../../../Images/icon_edit.gif" />
                                &nbsp;&nbsp;&nbsp;
                                <asp:LinkButton ID="lbtDel" runat="server" CommandName="del">Xoá</asp:LinkButton>
                            </ItemTemplate>
                        </asp:TemplateColumn>
                    </Columns>
                    <PagerStyle HorizontalAlign="Center" Mode="NumericPages" BackColor="#E7E7FF" ForeColor="#4A3C8C" />
                    <FooterStyle BackColor="#B5C7DE" ForeColor="#4A3C8C" />
                    <SelectedItemStyle BackColor="#738A9C" Font-Bold="True" ForeColor="#F7F7F7" />
                    <AlternatingItemStyle BackColor="#F7F7F7" />
                    <ItemStyle BackColor="#F7F7FF" ForeColor="#4A3C8C" />
                    <HeaderStyle BackColor="#E1F0F5" Font-Bold="True" ForeColor="Black" />
                </asp:DataGrid>
                    </div>
                </td>
			</tr>
		</table>
	</td>
</tr>
</table>