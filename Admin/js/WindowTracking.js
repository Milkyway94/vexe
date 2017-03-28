	function erase(pos) { if (pos>=0) this.splice(pos,1); else this.splice(0,this.length); return this; }
	Array.prototype.erase = erase;

	function urlIncQuerystring(str)
	{
		tmp=str.toString(); tmp=tmp.toLowerCase();
		ePos=str.indexOf(".asp"); sPos=str.lastIndexOf("/",ePos);
		if (ePos && sPos) str=tmp.substring(sPos+1, tmp.length);
		return unescape(str);
	}

	function getTFarray()
	{
		//if ((top.opener) && (top.opener.top.frames["ADCFrame"])) tFrame=top.opener.top.frames["ADCFrame"].frames["topFrame"];
		if ((top.frames) && (top.frames["ADCFrame"])) tFrame=top.frames["ADCFrame"].frames["topFrame"];
		if ((window.dialogArguments) && (window.dialogArguments.top.frames["ADCFrame"])) tFrame=window.dialogArguments.top.frames["ADCFrame"].frames["topFrame"];		
		if (window.tFrame) return tFrame.popupArray;
		else return false;
	}

	var aWin=new Array();
	function launchWin(w, h, srcURL, sizable, obj, scrollbar, toolbar, statusbar, menubar, locbar)
	{	
		aTPWin=getTFarray();

		for (i=0;i<aWin.length;i++)
		{
			if ((aWin[i]) && (!aWin[i].closed))
			{
				winURL=urlIncQuerystring(aWin[i].document.URL);
				newURL=urlIncQuerystring(srcURL);

				if (winURL.indexOf(newURL)>-1) { aWin[i].focus(); return false; }
			}
		}

		if (aTPWin!=null)
		{
			for (i=0;i<aTPWin.length;i++)
			{
				if ((aTPWin[i]) && (!aTPWin[i].closed))
				{
					winURL=urlIncQuerystring(aTPWin[i].document.URL);
					newURL=urlIncQuerystring(srcURL);
	
					if (winURL.indexOf(newURL)>-1) { aTPWin[i].focus(); return false; }
				}
			}
		}	

		if (scrollbar=="") scrollbar=0;
		aPos=aWin.length;
		lPos = (screen.width) ? (screen.width-w)/2 : 0; tPos = (screen.height) ? (screen.height-h)/2 : 0;
		aWin[aPos] = window.open(srcURL, "", "height="+h+", width="+w+", left="+lPos+", top="+tPos+", toolbar="+toolbar+", location="+locbar+", directories=0, status="+statusbar+", menubar="+menubar+", scrollbars="+scrollbar+",resizable="+sizable);		
		aWin[aPos].opener=obj;				
		aWin[aPos].focus();
		aWin[aPos].owner=document.location.href;
		processBarred(aPos);
	}

	function processBarred(pos)
	{
		aTPWin=getTFarray();
		if ((aTPWin!=null) && (barr.length>0))
		{
			for (b=0;b<barr.length;b++) 
			{
				if ((aWin[pos]) && ((!aWin[pos].closed) && (aWin[pos].document.URL.toLowerCase().indexOf(barr[b].toLowerCase())>-1)))
				{
					aTPWin[aTPWin.length]=aWin[pos]; aWin[pos]=null; break;
				}
			}
		}
	}

	function nullOpeners()
	{
		aTPWin=getTFarray();
		if (aTPWin!=null)
		{
			for (i=0;i<aTPWin.length;i++)
			{
				if ((aTPWin[i]) && (!aTPWin[i].closed))
				{
					if (aTPWin[i].owner==document.URL) { aTPWin[i].opener=null; aTPWin[i].owner=null; }
				}
			}
		}
	}

	function closeWins()
	{
		if (aWin.length>0)
		{
			nullOpeners();
			for (a=0;a<aWin.length;a++) 
			{ 
				if ((aWin[a]) && (!aWin[a].closed)) aWin[a].close();
			}
		}
	}