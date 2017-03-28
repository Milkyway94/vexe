function PopupWin(url,w,h)
{
    window.open(url, '_blank', 'resizable=yes,width='+w+',height='+h+',left=270,top=80,scrollbars=0,menubar=0,status=0,derectories=0,toolbar=0,location=0,resizable=0');
}
function AllSelect(theBox)
{	
	xState=theBox.checked;    
    elm=theBox.form.elements;
    for(i=0;i<elm.length;i++)
    if(elm[i].type=="checkbox" && elm[i].id!=theBox.id)
    {
        if(elm[i].checked!=xState)
        elm[i].click();
    }
}
function Search_Onclick(txt , objid)
{
    var obj = document.getElementById(objid);	
    if(window.event.keyCode == 13)
    {
	    if(txt.value != '')	{ obj.click();window.event.returnValue = false; }
    }
}