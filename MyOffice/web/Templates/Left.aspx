<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Left.aspx.cs" Inherits="Templates_Left" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
     <title>左边菜单</title>
     <meta http-equiv="Content-Type" content="text/html; charset=Gb2312" />   
    <link href="~/Css/Style.css" rel="stylesheet" type="text/css" />
    <link href="~/App_Themes/MasterBg/master.css" type="text/css" rel="stylesheet" />    
    <script type="text/javascript" src="../Css/Date.js"></script>
    <script type="text/javascript" src="../../My97DatePicker/WdatePicker.js"></script>
</head>
<body style="margin:0px; padding:0px;">
    <form id="form1" runat="server">
   <div style="width: 100%; height: 100%;">
    <asp:ScriptManager ID="ScriptManager1" runat="server"  >
        </asp:ScriptManager>
            <div id="divRow1" style="width: 100%; height: 100%;">
                <div id="divLeftMenu" style="float: left; width: 190px; height:950px; text-align: left;
                    background-color: #6DC7FC;overflow-y:auto;overflow-x:auto;">
                    <div align="center" style="width: 160px; height: 20px; background-color: #6DC7FC">
                        &nbsp;</div>
                    <div id="hidetitle" runat="server" align="center" style="width: 160px; background-color: #6DC7FC">
                        <div align="left" style="width: 150px; background-color: #7CCCFC">
                            &nbsp;&nbsp;&nbsp;欢迎：<asp:Label ID="lblUserName" runat="server" /><br />
                            &nbsp;&nbsp;&nbsp;角色：<asp:Label ID="lblRoleName" runat="server" /><br />
                            &nbsp;&nbsp;&nbsp;部门：<asp:Label ID="lblDepartName" runat="server" /><br />
                        <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
                            <ContentTemplate>
                                您共有&nbsp;<asp:Label ID="lblMessageCount" runat="server" style="font-weight: bold;"  Text="0" ForeColor="Black"></asp:Label>&nbsp;条

新消息<a href="../Message/MailBox/MailBox.aspx" target="mainFrame"><img src="../Images/new.gif" runat="server" style="height: 11px; border-width: 0px;" alt="" 

id="imgNewMessage" /></a>
                    <asp:Timer ID="Timer1" runat="server" OnTick="Timer1_Tick" Interval="10000000" ></asp:Timer>
                            </ContentTemplate>
                           
                         </asp:UpdatePanel>
                        </div>
                        <hr size="1" color="gray" />
                    </div>                    
                    <asp:UpdatePanel ID="UpdatePanel2" runat="server" UpdateMode="Always">
                        <ContentTemplate>    
                        <div id="divMenu" align="left" style="width: 138px; height:458px; background-color: #6dc7fc; overflow-y:auto;overflow-x:auto;">
                        <div style="margin-left:10px;">
                            <asp:TreeView ID="tvMyOffice" runat="server" CssClass="dtree" ExpandDepth="0" Font-Size="Small" CollapseImageUrl="~/Images/menuopen.gif" 

ExpandImageUrl="~/Images/menuclose.gif" NodeIndent="10">
                               
                            </asp:TreeView>
                       </div>
                         </div>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </div>
               
    </div>
   
    </div>
    </form>
</body>
</html>
