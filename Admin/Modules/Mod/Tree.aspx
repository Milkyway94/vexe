<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Tree.aspx.cs" Inherits="Mod_Tree" %>
<script type="text/javascript" language="javascript">
    var tp = '../../Themes/';
    var highlight = '#9CBEE7';
    function processClick(_type, _record)
    {
        switch (_type)
	    {
            case 0: parent.dhxLayout.cells("b").attachURL("ModList.aspx?TopicID=0"); break;
            case 1: parent.dhxLayout.cells("b").attachURL("ModList.aspx?TopicID=" + _record); break;
            case 2: parent.dhxLayout.cells("b").attachURL("ModList.aspx?TopicID=" + _record); break;
            case 3: parent.dhxLayout.cells("b").attachURL("ModList.aspx?TopicID=" + _record); break;
            case 4: parent.dhxLayout.cells("b").attachURL("ModList.aspx?TopicID=" + _record); break;
            case 5: parent.dhxLayout.cells("b").attachURL("ModtypeList.aspx"); break;
            case 6: parent.dhxLayout.cells("b").attachURL("ModtypeList.aspx"); break;
            case 7: parent.dhxLayout.cells("b").attachURL("ChuyenkhoaList.aspx"); break;
            case 8: parent.dhxLayout.cells("b").attachURL("ChuyenkhoaList.aspx"); break;
            case 9: parent.dhxLayout.cells("b").attachURL("LocationList.aspx"); break;
            case 10: parent.dhxLayout.cells("b").attachURL("LocationList.aspx?TopicID=" + _record); break;
            case 11: parent.dhxLayout.cells("b").attachURL("LocationList.aspx?TopicID=" + _record); break;
	    }
    }
</script>
<script type="text/javascript" language="javascript" src="../../../Admin/js/ADCTreeCommon.js"></script>
<link href="../../../Admin/css/Tree.css" rel="stylesheet" type="text/css" />

<div class="box-tree">
    <asp:Label ID="lbTree" runat="server" Text=""></asp:Label>
</div>