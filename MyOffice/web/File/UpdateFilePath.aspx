<%@ Page Language="C#" AutoEventWireup="true" CodeFile="UpdateFilePath.aspx.cs" Inherits="File_UpdateFilePath" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>无标题页</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
   <div align="center"> 
    请选择您的文档根目录：<asp:TextBox id="txtFilePath" runat="server" Width="209px"></asp:TextBox>(格式如F:\admin\文档管理\)
   <br /> 
       <asp:Button ID="btnSave" runat="server" OnClick="btnSave_Click" Text="确定" /></div> 
    </div>
    </form>
</body>
</html>
