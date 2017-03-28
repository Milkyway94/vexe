<%@ Page Language="C#" MasterPageFile="~/Admin/AdminMasterPage.master" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="Box_Default" %>
<asp:Content ID="Content" ContentPlaceHolderID="Main" Runat="Server">
    <div id="parentId" style="position:absolute; width:100%; height:88%;"></div>            
    <div id="objTree"></div>
    <div id="objContent"></div>         
    <script type="text/javascript">
      var dhxLayout;          
      function doOnLoad() {            
          var dhxLayoutData = {
            parent: "parentId",
            //parent: document.body,
            pattern: "2U",
            cells: [{
                id: "a",
                text: "Vị trí hình ảnh",
                width: 250
                }, {
                id: "b",
                text: "Danh sách hình ảnh"
            }]
            };
          dhxLayout = new dhtmlXLayoutObject(dhxLayoutData);
          dhxLayout.cells("a").attachURL("Tree.aspx");
          dhxLayout.cells("b").attachURL("BoxList.aspx");
      }     
      doOnLoad();       
    </script>
</asp:Content>