<%@ Page Language="C#" AutoEventWireup="true" CodeFile="PersonSchedule.aspx.cs" Inherits="ScheduleManage_PersonSchedule_PersonSchedule" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
<title></title> 
<link href="../../Css/Style.css" rel="stylesheet" type="text/css" />
<style type="text/css">
a:link
 {
text-decoration:none;
 }

    </style>
</head>
<body>
    <form id="myform" runat="server">
        <br />
        <div style="z-index: 101; left: 378px; width: 129px; position: absolute; top: 14px;
            height: 22px">
            <b>个人日程管理</b>
            </div>
<hr  size="1" style="width: 90%; text-align: center; color:gray; " />
           <div>
               <asp:ScriptManager ID="ScriptManager1" runat="server">
               </asp:ScriptManager>
        <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Always">
        <ContentTemplate>
            &nbsp;<div style="WIDTH: 99%" align="center">
                <asp:Calendar ID="clShowTime" runat="server" BackColor="White" BorderColor="#66CCFF"
                    BorderStyle="Solid" CellSpacing="1" Font-Names="Verdana" Font-Size="9pt" ForeColor="Black"
                    Height="250px" NextPrevFormat="ShortMonth" OnDayRender="clShowTime_DayRender"
                    Width="812px" CssClass="gvCss" ShowGridLines="True">
                    <SelectedDayStyle  ForeColor="Red"  BackColor="#FF99CC" Font-Bold="True" />
                    <TodayDayStyle  ForeColor="Red" />
                    <OtherMonthDayStyle ForeColor="Green" />
                    <DayStyle BackColor="White" />
                    <NextPrevStyle Font-Bold="False" Font-Size="8pt" />
                    <DayHeaderStyle Font-Bold="False" Font-Size="8pt" ForeColor="Black" Height="8pt" BackColor="AliceBlue" />
                    <TitleStyle BackColor="#6DC7FC"/>
                    <WeekendDayStyle ForeColor="Red" />
                    <SelectorStyle BorderColor="White" />
                </asp:Calendar>
</div>
</ContentTemplate>
       </asp:UpdatePanel>      
    </div>
    </form>
</body>
</html>
