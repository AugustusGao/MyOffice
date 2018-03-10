<%@ Page Language="C#" AutoEventWireup="true" CodeFile="MenuAdjust.aspx.cs" Inherits="SysManage_MenuAdjust" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>无标题页</title>
     <link href="~/Css/Style.css" rel="stylesheet" type="text/css" />
    <link href="~/App_Themes/MasterBg/master.css" type="text/css" rel="stylesheet" />    
    <script type="text/javascript" src="../Css/Date.js"></script>
    <script type="text/javascript" src="../../My97DatePicker/WdatePicker.js"></script>
    
    <style type="text/css">
        .td a{padding-left:14px; background-image: url(../Images/left_arrow.gif);
	background-repeat: no-repeat;
	background-position: left top;}
    </style>
</head>
<body style="overflow-y:auto;overflow-x:auto;" >

    <form id="form1" runat="server">
    
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
       
    <div>
    
    <div  style="margin-left:30px;overflow-y:auto;overflow-x:auto;">
    <div  align="right" style="margin-right:30px;">
    <b>菜&nbsp;&nbsp;单&nbsp;&nbsp;排&nbsp;&nbsp;序</b>
    </div>
    <hr />
     <asp:Button ID="btnUp" CssClass="buttonCss" runat="server" style="width: 56px; height: 20px" Text="上移" OnClick="btnUp_Click"  />
     &nbsp; &nbsp; &nbsp;<asp:Button ID="btnDown" runat="server" CssClass="buttonCss" style="width: 52px; height: 19px"   Text="下移" OnClick="btnDown_Click" />
        <asp:TreeView ID="tvMyOffice" runat="server"  CssClass="dtree" Font-Size="Small" CollapseImageUrl="~/Images/menuopen.gif" ExpandImageUrl="~/Images/menuclose.gif" NodeIndent="10" OnSelectedNodeChanged="tvMyOffice_SelectedNodeChanged">
        </asp:TreeView>
        &nbsp; &nbsp;&nbsp; &nbsp;&nbsp;</div>
    
    
    </div>
    </ContentTemplate>
        </asp:UpdatePanel>
     
    </form>
</body>
</html>
