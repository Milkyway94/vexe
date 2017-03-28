
    var iIcon          = tp+'Tree/I.png';
    var lIcon          = tp+'Tree/L.png';
    var lMinusIcon     = tp+'Tree/Lminus.png';
    var lPlusIcon      = tp+'Tree/Lplus.png';
    var tIcon          = tp+'Tree/T.png';
    var tMinusIcon     = tp+'Tree/Tminus.png';
    var tPlusIcon      = tp+'Tree/Tplus.png';
    var blankIcon      = tp+'Tree/blank.png';

    var defaultText    = 'Tree Item';
    var defaultAction  = 'javascript:processClick();';
    

    var selectedObj = null;

    var ADCTreeHandler = {
	    idCounter : 0,
	    idPrefix  : "---USERSLOCTREE---", 
	    all       : {},
	    behavior  : 'classic',
	    getId     : function () { return this.idPrefix + this.idCounter++; },
	    toggle    : function (oItem) { this.all[oItem.id.replace('-plus','')].toggle(); },
	    select    : function (oItem) { this.all[oItem.id.replace('-icon','')].select(); },
	    focus     : function (oItem) { this.all[oItem.id.replace('-anchor','')].focus(); },
	    blur      : function (oItem) { this.all[oItem.id.replace('-anchor','')].blur(); }
    };

    

    function  clearCookie()
    {
	    document.cookie = "";
    }

    function setCookie(key, value) 
    {
	    document.cookie = key + "=" + escape(value);
    }

    function getCookie(key) 
    {	
	    if (document.cookie.length) {
		    var cookies = ' ' + document.cookie;
		    var start = cookies.indexOf(' ' + key + '=');
		    if (start == -1) { return null; }
		    var end = cookies.indexOf(";", start);
		    if (end == -1) { end = cookies.length; }
		    end -= start;
		    var cookie = cookies.substr(start,end);
		    return unescape(cookie.substr(cookie.indexOf('=') + 1, cookie.length - cookie.indexOf('=') + 1));
	    }
	    else { return null; }
    }

	function ADCTree(sText, sFileIcon, sContextFunction, iType) 
	{
		this._subItems = [];
		if (iType || iType!=0) this.type=iType; else this.type = 0;
		this.id        = ADCTreeHandler.getId();
		this.text      = sText || defaultText;
		//this.action    = defaultAction;
		this.action     = 'javascript:processClick('+iType+');';
		this._wasLast  = false; 
		this.open      = (getCookie(this.id.substr(18,this.id.length - 18)) == '0')?false:true;
		this.icon      = sFileIcon;
		this.openIcon  = sFileIcon;
		this.context   = sContextFunction;
		ADCTreeHandler.behavior =  'classic';
		ADCTreeHandler.all[this.id] = this;
	}
	
	ADCTree.prototype.setBehavior = function (sBehavior) {
		ADCTreeHandler.behavior =  sBehavior;
	};
	
	ADCTree.prototype.getBehavior = function (sBehavior) {
		return ADCTreeHandler.behavior;
	};
	
	ADCTree.prototype.add = function (treeItem) {
		treeItem.parent = this;
		this._subItems[this._subItems.length] = treeItem;
	};
	
	ADCTree.prototype.toString = function () {
		var str = "<div id=\"" + this.id + "\" ondblclick=\"ADCTreeHandler.toggle(this);\" class=\"ADC-tree-item\" oncontextmenu=\""+this.context+"\"><nobr>";
		str += "<img id=\"" + this.id + "-icon\" src=\"" + ((ADCTreeHandler.behavior == 'classic' && this.open)?this.openIcon:this.icon) + "\" onclick=\"ADCTreeHandler.select(this);\"><a href=\"" + this.action + "\" id=\"" + this.id + "-anchor\" onfocus=\"ADCTreeHandler.focus(this);\">" + this.text + "</a></div>";
		str += "<div id=\"" + this.id + "-cont\" class=\"ADC-tree-container\" style=\"display: " + ((this.open) ? 'block' : 'block') + ";\">";
		for (var i = 0; i < this._subItems.length; i++) {
			str += this._subItems[i].toString(i,this._subItems.length);
		}
		str += "</nobr></div>";	
		return str;
	};
	
	ADCTree.prototype.getSelected = function () {
		if (selectedObj) { return selectedObj.id; }
		else { return null; }
	}
	
	ADCTree.prototype.toggle = function () {
		if (this.open) { this.collapse(); }
		else { this.expand(); }
	}
	
	ADCTree.prototype.select = function () {
		document.getElementById(this.id + '-anchor').focus();
	}
	
	ADCTree.prototype.focus = function () {
		if (selectedObj) { selectedObj.blur(); }
		selectedObj = this;
		if ((this.openIcon) && (ADCTreeHandler.behavior != 'classic')) { document.getElementById(this.id + '-icon').src = this.openIcon; }
		document.getElementById(this.id + '-anchor').style.backgroundColor = highlight;
		document.getElementById(this.id + '-anchor').style.color = 'black';
		document.getElementById(this.id + '-anchor').style.border = '1px solid gray';
	}
	
	ADCTree.prototype.blur = function () {
		if ((this.openIcon) && (ADCTreeHandler.behavior != 'classic')) { document.getElementById(this.id + '-icon').src = this.icon; }
		document.getElementById(this.id + '-anchor').style.backgroundColor = 'window';
		document.getElementById(this.id + '-anchor').style.color = 'menutext';
		document.getElementById(this.id + '-anchor').style.border = '0px';
	}
	
	ADCTree.prototype.expand = function () {
		if (ADCTreeHandler.behavior == 'classic') {
			document.getElementById(this.id + '-icon').src = this.openIcon;
		}
		document.getElementById(this.id + '-cont').style.display = 'block';
		this.open = true;
		setCookie(this.id.substr(18,this.id.length - 18), '1');
	}
	
	ADCTree.prototype.collapse = function () {
		if (ADCTreeHandler.behavior == 'classic') {
			document.getElementById(this.id + '-icon').src = this.icon;
		}
		document.getElementById(this.id + '-cont').style.display = 'none';
		this.open = false;
		setCookie(this.id.substr(18,this.id.length - 18), '0');
	}
	
	ADCTree.prototype.expandAll = function () {
		this.expandChildren();
		this.expand();
	}
	
	ADCTree.prototype.expandChildren = function () {
		for (var i = 0; i < this._subItems.length; i++) {
			this._subItems[i].expandAll();
		}
	}
	
	ADCTree.prototype.collapseAll = function () {
		this.collapse();
		this.collapseChildren();
	}
	
	ADCTree.prototype.collapseChildren = function () {
		for (var i = 0; i < this._subItems.length; i++) {
			this._subItems[i].collapseAll();
		}
	}
	
	function ADCTreeItem(sText, iType, iRecord, sFileIcon, sContextFunction, lang) 
	{
		this._subItems  = [];
		this._wasLast   = false;
		this.text       = sText || defaultText;
		this.type		= iType;
		this.record	    = iRecord; 
		
		this.fileicon   = sFileIcon;
		//this.action     = defaultAction;
		this.action     = 'javascript:processClick('+iType+','+iRecord+',' + lang + ');';
		this.id         = ADCTreeHandler.getId();
		this.open		= (getCookie(this.id.substr(18,this.id.length - 18)) == '1')?true:false;
		this.highlight  = false;
		this.context	= sContextFunction
		ADCTreeHandler.all[this.id] = this;
	};
	
	ADCTreeItem.prototype.add = function (treeItem) {
		treeItem.parent = this;
		this._subItems[this._subItems.length] = treeItem;
	};
	
	ADCTreeItem.prototype.toggle = function () {
		if (this.open) { this.collapse(); }
		else { this.expand(); }
	}
	
	ADCTreeItem.prototype.select = function () {
		document.getElementById(this.id + '-anchor').focus();
	}
	
	ADCTreeItem.prototype.focus = function () {
		if (selectedObj) { selectedObj.blur(); }
		selectedObj = this;
		if ((this.openIcon) && (ADCTreeHandler.behavior != 'classic')) { document.getElementById(this.id + '-icon').src = this.openIcon; }
		document.getElementById(this.id + '-anchor').style.backgroundColor = highlight;
		document.getElementById(this.id + '-anchor').style.color = 'black';
		document.getElementById(this.id + '-anchor').style.border = '1px solid gray';
	}
	
	ADCTreeItem.prototype.blur = function () {
		if ((this.openIcon) && (ADCTreeHandler.behavior != 'classic')) { document.getElementById(this.id + '-icon').src = this.icon; }
		document.getElementById(this.id + '-anchor').style.backgroundColor = 'window';
		document.getElementById(this.id + '-anchor').style.color = 'menutext';
		document.getElementById(this.id + '-anchor').style.border = '0px';
	}
	
	ADCTreeItem.prototype.expand = function () {
		if (this._subItems.length > 0) { 
			document.getElementById(this.id + '-cont').style.display = 'block';
		}
		if (ADCTreeHandler.behavior == 'classic') {
			document.getElementById(this.id + '-icon').src = this.openIcon;
		}
		document.getElementById(this.id + '-plus').src = this.minusIcon;
		this.open = true;
		setCookie(this.id.substr(18,this.id.length - 18), '1');
	}
	
	ADCTreeItem.prototype.collapse = function () {
		if (this._subItems.length > 0) {
			document.getElementById(this.id + '-cont').style.display = 'none';
		}
		if (ADCTreeHandler.behavior == 'classic') {
			document.getElementById(this.id + '-icon').src = this.icon;
		}
		document.getElementById(this.id + '-plus').src = this.plusIcon;
		this.open = false;
		setCookie(this.id.substr(18,this.id.length - 18), '0');
	}
	
	ADCTreeItem.prototype.expandAll = function () {
		this.expandChildren();
		this.expand();
	}
	
	ADCTreeItem.prototype.expandChildren = function () {
		for (var i = 0; i < this._subItems.length; i++) {
			this._subItems[i].expandAll();
		}
	}
	
	ADCTreeItem.prototype.collapseAll = function () {
		this.collapse();
		this.collapseChildren();
	}
	
	ADCTreeItem.prototype.collapseChildren = function () {
		for (var i = 0; i < this._subItems.length; i++) {
			this._subItems[i].collapseAll();
		}
	}
	
	ADCTreeItem.prototype.toString = function (nItem,nItemCount) {
		var foo = this.parent;
		var indent = '';
		if (nItem + 1 == nItemCount) { this.parent._wasLast = true; }
		
		var count=0;
		while (foo.parent) 
		{
			count++;
			foo = foo.parent;
			indent = "<img src=\"" + ((foo._wasLast)?blankIcon:iIcon) + "\">" + indent;
		}
	
		this.icon=this.openIcon=this.fileicon;
		
		if (this._subItems.length) { this.folder = 1; }
		if (this.folder) 
		{
			var str = "<div id=\"" + this.id + "\" ondblclick=\"ADCTreeHandler.toggle(this);\" class=\"ADC-tree-item\" oncontextmenu=\""+this.context+"\"><nobr>";
			str += indent;
			str += "<img width=19 height=16 id=\"" + this.id + "-plus\" src=\"" + ((this.open)?((this.parent._wasLast)?lMinusIcon:tMinusIcon):((this.parent._wasLast)?lPlusIcon:tPlusIcon)) + "\" onclick=\"ADCTreeHandler.toggle(this);\">"
			str += "<img width=16 height=16 id=\"" + this.id + "-icon\" src=\"" + ((ADCTreeHandler.behavior == 'classic' && this.open)?this.openIcon:this.icon) + "\" onclick=\"ADCTreeHandler.select(this);\"><a href=\"" + this.action + "\" id=\"" + this.id + "-anchor\" onfocus=\"ADCTreeHandler.focus(this);\">" + this.text + "</a></div>";
			str += "<div id=\"" + this.id + "-cont\" class=\"ADC-tree-container\" style=\"display: " + ((this.open)?'block':'none') + ";\">";
			for (var i = 0; i < this._subItems.length; i++) {
				str += this._subItems[i].toString(i,this._subItems.length);
			}
			str += "</nobr></div>";
		}
		else 
		{
			var str = "<div id=\"" + this.id + "\" class=\"ADC-tree-item\" oncontextmenu=\""+this.context+"\"><nobr>";
			str += indent;
			str += "<img width=19 height=16 id=\"" + this.id + "-plus\" src=\"" + ((this.parent._wasLast)?lIcon:tIcon) + "\">"
			
			if(this.highlight==true) 
			{
				selectedObj = this;
				str += "<img width=16 height=16 id=\"" + this.id + "-icon\" src=\"" + this.icon + "\" onclick=\"ADCTreeHandler.select(this);\"><a class=\"ADC-tree-item-on\" href=\"" + this.action + "\" id=\"" + this.id + "-anchor\" onfocus=\"ADCTreeHandler.focus(this);\">" + this.text + "</a></nobr></div>";
			}
			else str += "<img width=16 height=16 id=\"" + this.id + "-icon\" src=\"" + this.icon + "\" onclick=\"ADCTreeHandler.select(this);\"><a href=\"" + this.action + "\" id=\"" + this.id + "-anchor\" onfocus=\"ADCTreeHandler.focus(this);\">" + this.text + "</a></nobr></div>";
	
		}
		
		this.plusIcon = ((this.parent._wasLast)?lPlusIcon:tPlusIcon);
		this.minusIcon = ((this.parent._wasLast)?lMinusIcon:tMinusIcon);
		
		return str;
	}
	