<%@ Page Language="C#" AutoEventWireup="true" CodeFile="FileTree.aspx.cs" Inherits="File_FileManage_FileTree" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>无标题页</title>
    <style type="text/css">
     a {
   color: #000000;
	text-decoration: none;
}
a:visited {
	color: #000000;
	text-decoration: none;
}
    </style>
</head>
<body style="margin:0px; padding:0px;">
    <form id="form1" runat="server">
    <div >
    <div style="float: left; width: 160px; height:537px; text-align: left;
                    background-color: #6DC7FC;  overflow-y:auto; overflow-x:auto;margin-left: 1px;">
     <asp:TreeView ID="tvFile" runat="server"  ExpandDepth="1" ShowLines="True" Font-Size="Small" Target="ManagerFrame"  >
           
        </asp:TreeView>
        
        </div>
    </div>
    </form>
</body>
</html>
