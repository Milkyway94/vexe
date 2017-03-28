/*
* Check platform/browser version.  A complete reference is available at
* http://www.mozilla.org/docs/web-developer/sniffer/browser_type.html
* if this needs to be extended.
*/
var agt = navigator.userAgent.toLowerCase();
var is_mac    = (agt.indexOf("mac")!=-1);
var is_major = parseInt(navigator.appVersion);
var is_minor = parseFloat(navigator.appVersion);
var is_ie     = ((agt.indexOf("msie") != -1) && (agt.indexOf("opera") == -1));
var is_ie3    = (is_ie && (is_major < 4));
var is_ie4    = (is_ie && (is_major == 4) && (agt.indexOf("msie 4")!=-1) );
var is_ie4up  = (is_ie && (is_major >= 4));
var is_ie5    = (is_ie && (is_major == 4) && (agt.indexOf("msie 5.0")!=-1) );
var is_ie5_5  = (is_ie && (is_major == 4) && (agt.indexOf("msie 5.5") !=-1));
var is_ie5up  = (is_ie && !is_ie3 && !is_ie4);
var is_ie5_5up =(is_ie && !is_ie3 && !is_ie4 && !is_ie5);
var is_ie6    = (is_ie && (is_major == 4) && (agt.indexOf("msie 6.")!=-1) );
var is_ie6up  = (is_ie && !is_ie3 && !is_ie4 && !is_ie5 && !is_ie5_5);
var is_ie7    = (is_ie && (is_major == 4) && (agt.indexOf("msie 7.")!=-1) );
var is_ie7up  = (is_ie && !is_ie3 && !is_ie4 && !is_ie5 && !is_ie5_5 && !is_ie6);
var is_saf = (agt.indexOf("safari")!=-1);

// adds sfhover class to li on mouse over because IE doesn't support the hover class on list items.
    var level2Width = 145;
    var maxWidth = 846;
    var navL1s;
    var navL2s;
    var navL3s;
    navL1s = document.getElementById("LocalNav").childNodes;
	for (var i=0; i<navL1s.length; i++) {
		if(i==navL1s.length-1){
            navL1s[i].className+=" last";
        }    
		navL1s[i].onmouseover=function() {
	    if (is_ie)
	    {
			this.className+=" sfhover";	
		}
			 set2ndOffset(this);		
		}
		
		navL1s[i].onmouseout=function() {
				this.className=this.className.replace(new RegExp(" sfhover\\b"), "");
		}
		if (navL1s[i].firstChild && navL1s[i].firstChild.nextSibling && navL1s[i].firstChild.nextSibling.nextSibling) {
			
			navL1s[i].navL2s = navL1s[i].firstChild.nextSibling.nextSibling.childNodes;
			
			for (var j=0; j<navL1s[i].navL2s.length; j++) {

				navL1s[i].navL2s[j].onmouseover = function() {
				     
					 if (is_ie){
						this.className+=" sfhover";
					 }	
					 set3rdOffset(this);	
						
				}
				
				navL1s[i].navL2s[j].onmouseout=function() {
				    if (is_ie){
						this.className=this.className.replace(new RegExp(" sfhover\\b"), "");
					}	
				}
				
				if (navL1s[i].navL2s[j].firstChild && navL1s[i].navL2s[j].firstChild.nextSibling) {
					navL1s[i].navL2s[j].navL3s = navL1s[i].navL2s[j].firstChild.nextSibling.childNodes;
					for (var k=0; k<navL1s[i].navL2s[j].navL3s.length; k++) {
					
						navL1s[i].navL2s[j].navL3s[k].onmouseover = function() {
						    
						    if (is_ie)
								this.className+=" sfhover";
								
							
						}
						
						navL1s[i].navL2s[j].navL3s[k].onmouseout = function() {
						    if (is_ie)
								this.className=this.className.replace(new RegExp(" sfhover\\b"), "");
						}
					}
					// adds p class to parent node to notify users that it has child nodes.
					navL1s[i].navL2s[j].className += " p";
				}
						
			}
		}
	}

// Ensures the first dropdown menus stay within the width of the website so as not to force scrolling at 800x600 resolution.
function set2ndOffset(navItem) {
    
	var navOffsetConstant = document.getElementById("LocalNav").offsetLeft;
	if (navItem.offsetLeft + level2Width - maxWidth > 0) {
		var tooWideBy = navItem.offsetLeft + level2Width - maxWidth;
		//document.title=tooWideBy;
		var padding = 0-tooWideBy;
		if (is_ie && !is_ie6up) {
			padding += 2;
		} else if (is_saf) {
			padding++;
		}
		if (navItem.firstChild && navItem.firstChild.nextSibling && navItem.firstChild.nextSibling.nextSibling
			&& navItem.firstChild.nextSibling.nextSibling.style && navItem.firstChild.nextSibling.nextSibling.style.margin ) {
			navItem.firstChild.nextSibling.nextSibling.style.margin = "0px 0px 0px " + padding + "px";
		}
	} else { // checks every time in case text has been resized
		if (navItem.firstChild && navItem.firstChild.nextSibling && navItem.firstChild.nextSibling.nextSibling
			&& navItem.firstChild.nextSibling.nextSibling.style && navItem.firstChild.nextSibling.nextSibling.style.margin) {
			navItem.firstChild.nextSibling.nextSibling.style.margin = "0px 0px 0px -1px";
		}
	}
}

// Ensures the second dropdown menus stay within the width of the website so as not to force scrolling at 800x600 resolution.
function set3rdOffset(navItem) {
    //try {document.title=navItem.parentNode.parentNode.offsetLeft;}catch(e){}
	if (navItem.firstChild && navItem.firstChild.nextSibling) {
	    
		if ((navItem.parentNode.parentNode.offsetLeft + (2*level2Width))  >   maxWidth) {
			//trace(true,true);
			
			var moveMarginTo = 0-level2Width-1;
			//document.title=moveMarginTo;
			navItem.firstChild.nextSibling.style.margin = "-18px 0px 0px " + moveMarginTo + "px";
		}
	}
}