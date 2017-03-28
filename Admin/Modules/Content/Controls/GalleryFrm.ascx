<%@ Control Language="C#" AutoEventWireup="true" CodeFile="GalleryFrm.ascx.cs" Inherits="Admin_Modules_Content_Controls_GalleryFrm" %>
<link rel="stylesheet" href="<%=sRootAppPath %>css/ADCStyle.css" type="text/css" />
<script type="text/javascript" src="/Scripts/jquery-1.7.1.min.js"></script>
<script type="text/javascript" src="/Scripts/ckfinder/ckfinder.js"></script>
<table id="toolbar" cellspacing="0">
<tr> 
	<td style="width: 149px"> 
		<table cellspacing="0">
			<tr> 
				<td class="toolBarButton" id="btnCreate"><img src="<%=sRootAppPath %>Themes/save.png" align="absmiddle" width="16" height="20">&nbsp;<asp:LinkButton
                        ID="lbtUpdate" runat="server" OnClick="lbtUpdate_Click">Cập nhật</asp:LinkButton></td>
				<td class="toolBarButton" id="btnCancel" onclick="javascript:window.close();"><img src="<%=sRootAppPath %>Themes/cancel.gif" align="absmiddle" width="16" height="20">&nbsp;Huỷ bỏ</td>
			</tr>
		</table>
	</td>
</tr>
</table>

<table class="controlbox" width="100%">	
<tr> 
	<td valign="top">
		<table class="fieldbox" width="100%" cellspacing="2">
		    <tr> 		                        			
    			<td style="width:100px;">Tiêu đề:</td><td><asp:textbox id="txtName" Width="200px" runat="server"></asp:textbox></td>
            </tr>
			<tr> 
    			<td>Đề mục:</td><td><asp:DropDownList ID="ddlModID" runat="server"></asp:DropDownList></td>						
			</tr>
			<tr> 		                        			
    			<td>Ảnh nhỏ:</td>
                <td>
                    <asp:textbox id="txtAvata" ClientIDMode="Static" Width="350" runat="server"></asp:textbox>
                    <input id="browseServer" onclick="BrowseServer('txtAvata');"  type="button" value="Tải ảnh" />
                </td>									
			</tr>
			<tr> 		                        			
    			<td>Ảnh lớn:</td>
                <td>
                    <asp:textbox id="txtImg" ClientIDMode="Static" Width="350" runat="server"></asp:textbox>
                    <input id="Button1" onclick="BrowseServer('txtImg');" type="button" value="Tải ảnh" />
                     
                </td>									
			</tr>								
			<tr>
			    <td>Vị trí:</td><td><asp:textbox id="txtPos" Width="100px" runat="server"></asp:textbox>
				<asp:checkbox id="cbIsUse" runat="server"></asp:checkbox> hiển thị
				&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
				<asp:checkbox id="cbIsHot" runat="server"></asp:checkbox> nổi bật
				</td>						
			</tr>
        </table>
	</td>
</tr>
</table>
<script type="text/javascript">
    function BrowseServer(field) {
        var finder = new CKFinder();
        finder.selectActionFunction = function (fileUrl) {
            document.getElementById(field).value = fileUrl;
        };
        finder.popup();
    }
</script>