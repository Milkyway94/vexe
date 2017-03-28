<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Tree.aspx.cs" Inherits="Mod_Tree" %>
<script type="text/javascript" language="javascript">
    var tp = '../../Themes/';
    var highlight = '#9CBEE7';
    function processClick(_type, _record)
    {	
	    switch(_type)
	    {
		    case 0: parent.dhxLayout.cells("b").attachURL("FunctionList.aspx?p=0");  break;
		    case 1:	parent.dhxLayout.cells("b").attachURL("FunctionList.aspx?p=" + _record);  break;
		    case 2: parent.dhxLayout.cells("b").attachURL("FunctionList.aspx?p=" + _record); break;
	    }
    }
</script>
<script type="text/javascript" language="javascript" src="../../../Admin/js/ADCTreeCommon.js"></script>
<link href="../../../Admin/css/Tree.css" rel="stylesheet" type="text/css" />

<div class="box-tree">
    <asp:Label ID="lbTree" runat="server" Text=""></asp:Label>
</div>