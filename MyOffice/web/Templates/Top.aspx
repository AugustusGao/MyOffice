<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Top.aspx.cs" Inherits="Templates_Top" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title>头部</title>
     <meta http-equiv="Content-Type" content="text/html; charset=Gb2312" />   
    <link href="~/Css/Style.css" rel="stylesheet" type="text/css" />
    <link href="~/App_Themes/MasterBg/master.css" type="text/css" rel="stylesheet" />    
    <script type="text/javascript" src="../Css/Date.js"></script>
    <script type="text/javascript" src="../../My97DatePicker/WdatePicker.js"></script>
</head>
<body style="margin:0px; padding:0px;">
    <form id="form1" runat="server">
<div id="divMainContent" style="height: 100%" align="center">
                    <div id="divChildRow1" style="width:100%; height: 25px; padding-top: 0px">
                        <div class="TopLine">
                        </div>
                        <div class="NoticeLine">
                            <div style=" text-align:left; float: left; width: 60%; height: 22px"> <a id="HyperLink2" runat="server" href="~/ScheduleManage/PersonNote/PersonNote.aspx">
                            <a href="../Welcome.aspx"  target="mainFrame"><img  alt="" id="Image6" runat="server" src="~/Images/home.jpg"  style="height: 21px; width: 44px; border-width: 0px;" /></a>
                                </a>
<a href="javaScript:parent.location='../Login.aspx'" ><img src="../Images/Relogin.jpg" style="border:0px" alt="" /></a>
 <a href="../SysManage/CreateUser.aspx?UserId=<%=id %>"  target="mainFrame">
                                <img src="../Images/modifypass.jpg" style="border:0px;" alt="" /></a>
                            </div>
                            <div style="float: left; width: 8%; height: 22px">
                            </div>
                            <div style="float: left; width: 20%; height: 22px" align="left">
                                <img id="Image5" runat="server" src="~/Images/smile.gif" style="border-width: 0px;" />&nbsp;<span
                                    id="lblNow" style="display:inline-block; color: #C0FFFF; width: 180px;">今天是：
                                    <script type="text/javascript">					 
					                    document.write(new Date().format("yyyy-MM-dd"));
					                    var s="日一二三四五六";
					                    document.write(" 星期"+s.charAt(new Date().getDay()));
                                    </script>

                                </span>
                            </div>
                        </div>     
                            <div style="width: 99%; height: 30px; text-align: left">                
                            <div style="left: 7px; width: 488px; position: relative; top:0px; height: 1px; z-index: 101;">
                                <asp:SiteMapPath ID="SiteMapPath1" runat="server" PathSeparator="：">
                                </asp:SiteMapPath>
                                <asp:SiteMapDataSource ID="SiteMapDataSource1" runat="server" />    
                            </div>               
                           </div> 
                    </div>
                </div>
                <div id="divRow2" class="TopLine">
                </div>
    </form>
</body>
</html>
