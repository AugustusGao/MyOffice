<%@ Page Language="C#" AutoEventWireup="true" CodeFile="index.aspx.cs" Inherits="Templates_FramSet" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>MyOffice</title>
</head>

<frameset rows="*,34" cols="*" frameborder="no" border="0" framespacing="0"  >
  <frameset cols="150,*" frameborder="no" border="0" framespacing="0" >
    <frame src="Templates/left.aspx" name="leftFrame" scrolling="No" noresize="noresize" id="leftFrame" title="leftFrame" />
	<frameset rows="42,*" cols="*" frameborder="no" border="0" framespacing="0" >
	    <frame src="Templates/Top.aspx" name="topFrame" id="topFrame" title="topFrame" scrolling="No" noresize="noresize" />
			    <frame src="Welcome.aspx" name="mainFrame" id="mainFrame" title="mainFrame" />
		</frameset>
  </frameset>
  <frame src="Templates/Bottom.aspx" name="bottomFrame" scrolling="No" noresize="noresize" id="bottomFrame" title="bottomFrame" />
</frameset>

</html>
