<%@ Page Language="C#" AutoEventWireup="true" CodeFile="SaveMySchedule.aspx.cs" Inherits="ScheduleManage_PersonSchedule_SaveMySchedule" %>

<%@ Register Src="../../UserControl/UserTree.ascx" TagName="UserTree" TagPrefix="uc1" %>


<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>我的日程安排</title>
    <script type="text/javascript" src="../../My97DatePicker/WdatePicker.js"></script>
    <style type="text/css">
      .btn
    {
    font-family: "Tahoma", "宋体";
    font-size: 9pt; color: #003399;
    color:white; 
    height:20px;
    background-image:url(../../Images/headlistbutton.gif);
    background-color:blue;
    font-style: normal ;
    margin:0px;
    padding:0px;
    }
.input
  {
 border-right:DodgerBlue 1px solid; 
 border-top: DodgerBlue 1px solid; 
 border-left:DodgerBlue 1px solid; 
 border-bottom:DodgerBlue 1px solid;
 height:18px; 
 color:#000000; 
 padding-left: 2px; 
 padding-right: 2px;
 }
 .time
 {
  border-right:DodgerBlue 1px solid; 
 border-top: DodgerBlue 1px solid; 
 border-left:DodgerBlue 1px solid; 
 border-bottom:DodgerBlue 1px solid;
 height:18px; 
 color:#000000; 
 padding-left: 2px; 
 padding-right: 2px;
 cursor:pointer;
 }
.lblUser
{
 border-right:DodgerBlue 1px solid; 
 border-top: DodgerBlue 1px solid; 
 border-left:DodgerBlue 1px solid; 
 border-bottom:DodgerBlue 1px solid;
 color:blue;
 background-color:white;
  }
    </style>
</head>
<body>
    <form id="myform" runat="server">
    <div>
        <asp:Button ID="btnSchedule" runat="server" Text="我的日程安排"  CssClass="btn"  Height="25px" Width="90px" BorderStyle="None"/></div>
        <hr  size="1" style="width: 99%; text-align: center; color:gray;" />
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
        <div style="z-index: 101; left: 343px; width: 100px; position: absolute; top: 301px;
            height: 100px; display:none" runat="server" id="div1">
                            <uc1:UserTree ID="utShow" runat="server"  />
        </div>
        <table style="width: 789px; height: 390px">
            <tr>
                <td colspan="4" style="width: 761px">
                    <asp:Label ID="Label1" runat="server" Text="主题：" ></asp:Label><asp:TextBox ID="txtTitle" runat="server" CssClass="input" Width="495px"></asp:TextBox>&nbsp;
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtTitle"
                        Display="Dynamic" ErrorMessage="主题不能为空！" SetFocusOnError="True"></asp:RequiredFieldValidator></td>
            </tr>
            <tr style="color: #000000">
                <td colspan="4" style="width: 761px" >
                    <asp:Label ID="Label2" runat="server" Text="地点："></asp:Label><asp:TextBox ID="txtAddress" runat="server" CssClass="input"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtAddress"
                        Display="Dynamic" ErrorMessage="地点不能为空！" SetFocusOnError="True"></asp:RequiredFieldValidator>
                    <asp:Label ID="Label5" runat="server" Text="会议类型："></asp:Label><asp:DropDownList ID="ddlType" runat="server" DataSourceID="odsType" DataTextField="MeetingName" DataValueField="MeetingId">
                    </asp:DropDownList>&nbsp;
                    <asp:ObjectDataSource ID="odsType" runat="server" SelectMethod="GetAllMeetings" TypeName="MyOffice.DAL.MeetingService"></asp:ObjectDataSource>
                    &nbsp;
                </td>
            </tr>
            <tr>
                <td colspan="4" style="width: 761px">
                    <asp:Label ID="Label3" runat="server" Text="开始时间：..."></asp:Label><asp:TextBox ID="txtBeginTime" runat="server" CssClass="time" onFocus="new WdatePicker(this,'%Y-%M-%D %h:%m:%s',true,'whyGreen')"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtBeginTime"
                        Display="Dynamic" ErrorMessage="开始时间不能为空！" SetFocusOnError="True"></asp:RequiredFieldValidator></td>
            </tr>
            <tr>
                <td colspan="4" style="width: 761px">
                    <asp:Label ID="Label4" runat="server" Text="结束时间：..." ></asp:Label><asp:TextBox ID="txtEndTime" runat="server" CssClass="time" onFocus="new WdatePicker(this,'%Y-%M-%D %h:%m:%s',true,'whyGreen')"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txtEndTime"
                        Display="Dynamic" ErrorMessage="结束时间不能为空！" SetFocusOnError="True"></asp:RequiredFieldValidator>
                    <asp:CompareValidator ID="CompareValidator1" runat="server" ControlToCompare="txtBeginTime"
                        ControlToValidate="txtEndTime" Display="Dynamic" ErrorMessage="结束时间必须大于开始时间！"
                        Operator="GreaterThanEqual" SetFocusOnError="True"></asp:CompareValidator></td>
            </tr>
            <tr>
                <td colspan="4" style="width: 761px">
                    <asp:Label ID="Label6" runat="server" Text="日程内容：" ></asp:Label>
                </td>
            </tr>
            <tr>
                <td colspan="4" style="width: 761px; height: 50px;">
                    <asp:TextBox ID="txtContent" runat="server" TextMode="MultiLine" CssClass="input" Height="41px" Width="550px"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="txtContent"
                        Display="Dynamic" ErrorMessage="日程内容不能为空！" SetFocusOnError="True"></asp:RequiredFieldValidator></td>
            </tr>
            <tr>
                <td colspan="4" style="width: 761px; height: 26px;">
                    <asp:Label ID="Label7" runat="server" Text="预约人："></asp:Label>&nbsp;&nbsp;
                    <asp:ImageButton ID="imgbtnShow" runat="server" ImageUrl="~/Images/admin2.gif" OnClick="imgbtnShow_Click" CausesValidation="False" /></td>
            </tr>
            <tr>
                <td colspan="4" style="width: 761px">
                    <asp:ListBox ID="lbUserName" runat="server" BackColor="DeepSkyBlue" Width="104px"></asp:ListBox><asp:Button ID="btnDeletePreContract" runat="server" Text="删除选定预约人"  CssClass="lblUser" OnClick="btnDeletePreContract_Click" CausesValidation="False"/></td>
            </tr>
            <tr>
                <td colspan="4" style="width: 761px">
                    <asp:Label ID="Label8" runat="server" Text="选择："></asp:Label>
                    <asp:CheckBox ID="cboPrivate" runat="server" Text="是否公开" CssClass="lblUser"/>&nbsp;
                    <asp:Label ID="Label9" runat="server" Text="创建者："></asp:Label>
                    <asp:Label ID="lblUserName" runat="server"></asp:Label>&nbsp;
                    <asp:Label ID="Label11" runat="server" Text="创建时间："></asp:Label><asp:Label ID="lblTime" runat="server"></asp:Label></td>
            </tr>
            <tr>
                <td colspan="4" style="width: 761px" >
                    <asp:Button ID="btnSave" runat="server" Text="保存退出"  CssClass="lblUser" OnClick="btnSave_Click"/>&nbsp;
                    <asp:Button ID="btnDelete" runat="server" Text="删除"  CssClass="lblUser" OnClick="btnDelete_Click"/>&nbsp;<asp:Button ID="btnExit" runat="server" Text="退出"  CssClass="lblUser" OnClick="btnExit_Click" CausesValidation="False"/></td>
            </tr>
        </table>
            </ContentTemplate>
            
        </asp:UpdatePanel>
        &nbsp;
        &nbsp;&nbsp;
    </form>
</body>
</html>
