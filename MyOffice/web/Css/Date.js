 Date.prototype.format   =   function(format)   
  {   
	  var   o   =   {   
		  "M+"   :   this.getMonth()+1,   //month   
		  "d+"   :   this.getDate(),         //day   
		  "h+"   :   this.getHours(),       //hour   
		  "m+"   :   this.getMinutes(),   //minute   
		  "s+"   :   this.getSeconds(),   //second   
		  "q+"   :   Math.floor((this.getMonth()+3)/3),     //quarter   
		  "S"   :   this.getMilliseconds()   //millisecond   
	  }   
	  if(/(y+)/.test(format))   format=format.replace(RegExp.$1,   
		  (this.getFullYear()+"").substr(4   -   RegExp.$1.length));   
	  for(var   k   in   o)if(new   RegExp("("+   k   +")").test(format))   
		  format   =   format.replace(RegExp.$1,   
			  RegExp.$1.length==1   ?   o[k]   :     
				  ("00"+   o[k]).substr((""+   o[k]).length));   
	  return   format;   
  };  
	function cin(){
		document.all["btnArrive"].disabled="disabled";
		document.all["btnLeave"].disabled="";
		document.all["info"].style.display="";	
		document.all["lbl1"].innerHTML="Ç©µ½";	
		document.all["lbl2"].innerHTML="Ç©µ½";					
		document.all["time"].innerHTML=new Date().format("yyyy-MM-dd hh:mm:ss");
	}
	function cout(){
		document.all["btnArrive"].disabled="";
		document.all["btnLeave"].disabled="disabled";	
		document.all["info"].style.display="";
		document.all["lbl1"].innerHTML="Ç©ÍË";
		document.all["lbl2"].innerHTML="Ç©ÍË";
		document.all["time"].innerHTML=new Date().format("yyyy-MM-dd hh:mm:ss");
	}