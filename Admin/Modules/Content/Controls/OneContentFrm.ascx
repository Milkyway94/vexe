<%@ Control Language="C#" AutoEventWireup="true" CodeFile="OneContentFrm.ascx.cs" Inherits="Admin_Modules_Content_Controls_NewsFrm" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc2" %>
<%@ Register Assembly="CKEditor.NET" Namespace="CKEditor.NET" TagPrefix="CKEditor" %>
<link rel="stylesheet" href="<%=sRootAppPath %>css/Style.css" type="text/css" />
<script type="text/javascript" src="/Scripts/jquery-1.7.1.min.js"></script>
<script type="text/javascript" src="/Scripts/ckeditor/ckeditor.js"></script>
<script type="text/javascript" src="/Scripts/ckfinder/ckfinder.js"></script>
<table id="toolbar" cellspacing="0">
<tr> 
	<td style="width: 149px"> 
		<table cellspacing="0">
			<tr> 
				<td class="toolBarButton"><img src="<%=sRootAppPath %>Themes/save.png" align="absmiddle" width="16" height="20">&nbsp;<asp:LinkButton
                        ID="lbtUpdate" runat="server" OnClick="lbtUpdate_Click">Cập nhật</asp:LinkButton></td>
				<td class="toolBarButton" onclick="javascript:window.close();"><img src="<%=sRootAppPath %>Themes/cancel.gif" align="absmiddle" width="16" height="20">&nbsp;Huỷ bỏ</td>
			</tr>
		</table>
	</td>
</tr>
</table>
<table class="controlbox" width="100%" cellspacing="2" cellpadding="2">
    <tr> 		                        			
		<td style="width:130px;">Tiêu đề:&nbsp;</td>
		<td colspan="3"><asp:textbox id="txtName" Width="650" runat="server"></asp:textbox></td>
    </tr>
	<tr>
		<td>Đề mục</td>
		<td colspan="3"><asp:DropDownList ID="ddlModID" runat="server"></asp:DropDownList></td>						
	</tr>
	<tr> 		                        			
		<td>Đường dẫn</td>
		<td colspan="3"><asp:textbox id="txtURL" Width="650" runat="server"></asp:textbox></td>
	</tr>
	<tr> 		                        			 
		<td>Ảnh</td>
		<td colspan="3">
            <asp:textbox id="txtImg" ClientIDMode="Static" Width="650" runat="server"></asp:textbox>
            <input id="browseServer" onclick="BrowseServer('txtImg');"  type="button" value="Tải ảnh" />
             <script type="text/javascript">
                 function BrowseServer(field) {
                     var finder = new CKFinder();
                     finder.selectActionFunction = function (fileUrl) {
                         document.getElementById(field).value = fileUrl;
                     };
                     finder.popup();
                 }
            </script> 
		</td>						
	</tr>								
	<tr>
        <td>Vị trí</td>
		<td colspan="3"><asp:textbox id="txtPos" Width="250" runat="server"></asp:textbox>
            <asp:checkbox id="cbIsUse" runat="server"></asp:checkbox> Kích hoạt</td>						
	</tr>		
    <tr>
        <td colspan="4">
            <cc2:TabContainer ID="TabContainer1" CssClass="ajax__tab_yuitabview-theme" runat="server">
                <cc2:TabPanel ID="tbContent" runat="server" HeaderText="Chi tiết">
                    <ContentTemplate>
                          <CKEditor:CKEditorControl ID="CKContent" Height="300" CustomConfig="/Scripts/ckeditor/article.js" runat="server"></CKEditor:CKEditorControl>
                    </ContentTemplate>
                </cc2:TabPanel>
                <cc2:TabPanel ID="TabPanel1" runat="server" HeaderText="For SEO">
                    <ContentTemplate>
                        <div>&nbsp;</div>
                        <div class="i-form">
		                    <span>Title page</span> <asp:textbox id="txtTitle" Width="500" runat="server"></asp:textbox>
	                    </div>
	                    <div class="i-form">
		                    <span>Keywords</span> <asp:textbox id="txtKey" Width="500" runat="server"></asp:textbox>
	                    </div>
	                    <div class="i-form">
		                    <span>Meta descripton</span> <asp:textbox id="txtMeta" TextMode="MultiLine" Width="500" Height="100" runat="server"></asp:textbox>
	                    </div>
                        <div class="i-form">
		                    <span>Tags</span> <asp:textbox id="txtTag" Width="500" runat="server"></asp:textbox>
	                    </div>
                    </ContentTemplate>
                </cc2:TabPanel>
            </cc2:TabContainer>
        </td>
    </tr>
</table>