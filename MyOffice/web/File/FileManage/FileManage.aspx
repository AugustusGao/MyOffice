<%@ Page Language="C#" AutoEventWireup="true" CodeFile="FileManage.aspx.cs" Inherits="File_FileManage_FileManage" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>无标题页</title>
</head>



    
    <frameset rows="*" cols="160,*" framespacing="0" frameborder="no" border="0">
  <frame src="FileTree.aspx" name="TreeFrame" scrolling="No" noresize="noresize" id="TreeFrame" title="文档树形菜单" />
  <frame src="FileMain.aspx" name="ManagerFrame" id="ManagerFrame" title="文档管理" />
</frameset>
    





</html>
