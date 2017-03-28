<%@ Control Language="C#" AutoEventWireup="true" CodeFile="FAQsFrm.ascx.cs" Inherits="Admin_Modules_Content_Controls_ProductsFrm" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc2" %>
<%@ Register Assembly="CKEditor.NET" Namespace="CKEditor.NET" TagPrefix="CKEditor" %>
<link rel="stylesheet" href="<%=sRootAppPath %>css/ADCStyle.css" type="text/css" />
<script type="text/javascript" src="/Scripts/jquery-1.7.1.min.js"></script>
<script type="text/javascript" src="/Scripts/ckeditor/ckeditor.js"></script>
<script type="text/javascript" src="/Scripts/ckfinder/ckfinder.js"></script>
<table id="toolbar" cellspacing="0">
<tr> 
	<td style="width: 149px;"> 
		<table cellspacing="0">
			<tr> 
				<td class="toolBarButton" id="btnCreate"><img alt="" src="<%=sRootAppPath %>Themes/save.png" align="absmiddle" />&nbsp;<asp:LinkButton
                        ID="lbtUpdate" runat="server" OnClick="lbtUpdate_Click">Cập nhật</asp:LinkButton></td>
				<td class="toolBarButton" id="btnCancel" onclick="javascript:window.close();"><img alt="" src="<%=sRootAppPath %>Themes/cancel.gif" align="absmiddle" />&nbsp;Huỷ bỏ</td>
			</tr>
		</table>
	</td>
</tr>
</table>
<table class="controlbox" width="100%" cellspacing="2" cellpadding="2">  
    <tr>
        <td style="width:120px;">Họ tên</td>
        <td><asp:textbox id="txtName" runat="server"></asp:textbox></td>
        <td>Điện thoại</td>
        <td><asp:textbox id="txtTel" runat="server"></asp:textbox></td>
    </tr>	
    <tr>
        <td>Chuyên mục</td>
        <td><asp:DropDownList ID="ddlChuyenmuc" runat="server"></asp:DropDownList></td>
        <td>Chuyên khoa</td>   
		<td><asp:DropDownList ID="ddlChuyenkhoa" runat="server"></asp:DropDownList></td>
	</tr>
    <tr>
       <%-- <td>Email</td>
        <td><asp:textbox id="txtEmail" runat="server"></asp:textbox></td>--%>
        <td>Tiêu đề</td>   
		<td colspan="3"><asp:textbox id="txtTile" runat="server" Width="650"></asp:textbox></td>
	</tr>	
    <tr>
        <td>Liên quan</td>
        <td><asp:textbox id="txtCode" runat="server"></asp:textbox></td>
        <td>Tiêu đề</td>   
		<td> <asp:checkbox id="cbIsUse" runat="server"></asp:checkbox> Kích hoạt</td>
	</tr>		
    <tr>
        <td colspan="4">
            <cc2:TabContainer ID="TabContainer1" CssClass="ajax__tab_yuitabview-theme" runat="server">
                <cc2:TabPanel ID="tbTeaser" runat="server" HeaderText="Câu hỏi">
                    <ContentTemplate>
                        <CKEditor:CKEditorControl ID="CKTeaser" Height="300" CustomConfig="/Scripts/ckeditor/article.js" runat="server"></CKEditor:CKEditorControl>
                    </ContentTemplate>
                </cc2:TabPanel>
                <cc2:TabPanel ID="tbContent" runat="server" HeaderText="Trả lời">
                    <ContentTemplate>
                        <CKEditor:CKEditorControl ID="CKContent" Height="300" CustomConfig="/Scripts/ckeditor/article.js" runat="server"></CKEditor:CKEditorControl>
                    </ContentTemplate>
                </cc2:TabPanel>
                <cc2:TabPanel ID="tabSEO" runat="server" HeaderText="SEO Tools">
                    <ContentTemplate>
                        <div>&nbsp;</div>
                        <div style="margin:5px 0 5px 10px;font-weight:bold">Title page<br /><asp:textbox id="txtTitle" Width="650" runat="server"></asp:textbox></div>
                        <div style="margin:5px 0 5px 10px;font-weight:bold">Keywords<br /><asp:textbox id="txtKey" Width="650" runat="server"></asp:textbox></div>
                        <div style="margin:5px 0 5px 10px;font-weight:bold">Meta descripton<br /><asp:textbox id="txtMeta" Width="650" runat="server"></asp:textbox></div>
                        <div style="margin:5px 0 5px 10px;font-weight:bold">Tags cloud<br /><asp:textbox id="txtTags" Width="650" runat="server"></asp:textbox></div>
                        <div>&nbsp;</div>
                    </ContentTemplate>
                </cc2:TabPanel>
            </cc2:TabContainer>
        </td>
    </tr>
</table>