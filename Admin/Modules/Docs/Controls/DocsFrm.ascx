<%@ Control Language="C#" AutoEventWireup="true" CodeFile="DocsFrm.ascx.cs" Inherits="Docs_FunFrm" %>
<%@ Register Assembly="CKEditor.NET" Namespace="CKEditor.NET" TagPrefix="CKEditor" %>
<link rel="stylesheet" href="<%=sRootAppPath %>css/ADCStyle.css" type="text/css" />
<link href="../../../../resources/css/bootstrap.min.css" rel="stylesheet" />
<link href="../../../css/StyleSheet.css" rel="stylesheet" />
<script type="text/javascript" src="/Scripts/jquery-1.7.1.min.js"></script>
<script src="../../../../Scripts/ckeditor/ckeditor.js"></script>
<script src="../../../../Scripts/ckfinder/ckfinder.js"></script>
<table class="controlbox" width="100%">	
<tr> 
	<td valign="top">
		
		<table class="table" style="padding-right: 15px;">	
            <caption style="font-size: 26px; color: black; font-weight: bold; text-transform:uppercase; text-align:center">Thông tin tài liệu</caption>	   
			<tr> 
				<td>Chọn Loại Tài Liệu:</td>
				<td><asp:DropDownList ID="ddlGroup" CssClass="form-control" runat="server"></asp:DropDownList></td>
			</tr>
            <tr> 		                        			
    			<td>Số hiệu tài liệu: </td>
				<td><asp:textbox id="txtCode" CssClass="form-control" runat="server"></asp:textbox></td>						
			</tr>	
			<tr> 		                        			
    			<td>Tên Tài liệu: </td>
				<td><asp:textbox id="txtName" CssClass="form-control" runat="server"></asp:textbox></td>						
			</tr>	
			<tr> 		                        			
    			<td>File: </td>
                <td>
                    <table>
                        <tr>
                            <td style="width: 90%;"><asp:textbox id="txtPath" CssClass="form-control" ClientIDMode="Static" runat="server"></asp:textbox></td>
                            <td><input id="browseServer" class="btn btn-primary" onclick="BrowseServer('txtPath');"  type="button" value="Tải file" /></td>
                        </tr>
                    </table>
                </td>
			</tr>					
			<tr> 		                        			
    			<td>Mô tả tài liệu: </td>
				<td><CKEditor:CKEditorControl ID="CKTeaser" Height="200" Width="100%" CustomConfig="/Scripts/ckeditor/article.js" runat="server" Toolbar="Source|Bold|Italic|Underline|Strike|Indent/Styles|Format|Font|FontSize|TextColor|BGColor"></CKEditor:CKEditorControl></td>						
			</tr>
			<tr> 		                        			
    			<td>Vị trí</td>
				<td>
                   <asp:textbox id="txtPos" CssClass="form-control" runat="server"></asp:textbox>
                </td>						
			</tr>	
            <tr>
                <td>&nbsp;</td>
                <td>
                    </asp:textbox> Cho phép hoạt động: <asp:checkbox id="cbIsUse" runat="server"></asp:checkbox></asp:textbox>
                </td>
            </tr>		
		</table>
	</td>
</tr>
</table>
<div class="row">
    <div class="text-center">
        <asp:LinkButton ID="lbtUpdate" runat="server" CssClass="btn btn-success" OnClick="lbtUpdate_Click">Cập nhật</asp:LinkButton>
        <button class="btn btn-danger" onclick="javascript:window.close();">Hủy bỏ</button>
    </div>
</div>
<script type="text/javascript">
    function BrowseServer(field) {
        var finder = new CKFinder();
        finder.selectActionFunction = function (fileUrl) {
            document.getElementById(field).value = fileUrl;
        };
        finder.popup();
    }
</script>