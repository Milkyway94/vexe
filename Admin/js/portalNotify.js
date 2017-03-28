	function eventHandle()
	{
		var eObj=window.event.srcElement;
		if (eObj.id==objName)
		{
			window.event.returnValue=false;
			if (waitingWin!=null) waitingWin.close();
			eObj.detachEvent(dEventName, eventHandle)
		}
	}

	var sDialogReturn
	function PortalAlert(dialogPath,strMsgKey, bReturn)
	{	
		var width=380; 
		var height=200;
		lPos = (screen.width)/2 -(width/2);
		tPos = (screen.height)/2 -(height/2);
		var AlertModel=window.showModalDialog(dialogPath+"SystemDialog.asp?msgKey="+strMsgKey,window,"dialogLeft:"+lPos+";dialogTop:"+tPos+"; dialogHeight: "+height +"px; dialogWidth: "+width+"px; edge: Raised; center: Yes; help: no; resizable: no; status: no;");

		if (!AlertModel) { if (sDialogReturn && bReturn) return sDialogReturn; }
	}

	var waitingWin;	
	var objName;
	var dEventName;

	function waitingDlg(dialogPath, strMsgKey, sCloseEvent, objID)
	{	
		objName=objID; 
		dEventName=sCloseEvent;		
		var obj=document.getElementById(objID);
		if (obj!=null) obj.attachEvent(sCloseEvent, eventHandle);		
		var width=380;
		var height=200;
		lPos = (screen.width)/2 -(width/2);
		tPos = (screen.height)/2 -(height/2);		
		waitingWin=window.showModelessDialog(dialogPath+"loading.aspx?msgKey="+strMsgKey,window,"dialogLeft:"+lPos+";dialogTop:"+tPos+"; dialogHeight: "+height +"px; dialogWidth: "+width+"px; edge: Raised; center: Yes; help: no; resizable: no; status: no;");		
		return waitingWin;
	}
	function closeWait()
	{
		if (waitingWin!=null) waitingWin.close();
	}