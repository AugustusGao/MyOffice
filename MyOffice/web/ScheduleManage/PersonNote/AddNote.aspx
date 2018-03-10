<%@ Page Language="C#" AutoEventWireup="true" CodeFile="AddNote.aspx.cs" Inherits="ScheduleManage_PersonNote_AddNote" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>新增便签</title>
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
    .btnUser
    {
     border-right:DodgerBlue 1px solid; 
     border-top: DodgerBlue 1px solid; 
     border-left:DodgerBlue 1px solid; 
     border-bottom:DodgerBlue 1px solid;
     color:blue;
     background-color:white;
    }
    .lblUser
    {
    color:blue;
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
    </style>
</head>
<body>
    <form id="myform" runat="server"> 
        <asp:Button ID="btnSet" runat="server" Text="个人便签设置"  CssClass="btn"  Height="25px" Width="90px" BorderStyle="None"/>
        <hr  size="1" style="width: 99%; text-align: center; color:gray;" />
        <br />
        <br />
       
        <div style="z-index: 101; left: 232px; width: 573px; position: absolute; top: 61px;
            height: 100px">
            <asp:ScriptManager ID="ScriptManager1" runat="server">
            </asp:ScriptManager>
            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                <ContentTemplate>
            <table>
            <tr><td>
            <asp:Label ID="lblTitle" runat="server" Text="便签标题："></asp:Label></td>
            <td style="width: 319px">
           <asp:TextBox ID="txtTitle" runat="server" CssClass="input" Width="311px"></asp:TextBox>
            </td>
            <td>
            <asp:RequiredFieldValidator ID="rfvTitle" runat="server" ControlToValidate="txtTitle"
                Display="Dynamic" ErrorMessage="便签标题不能为空！" SetFocusOnError="True"></asp:RequiredFieldValidator></td></tr>
                <tr><td>
            <asp:Label ID="lblContent" runat="server" Height="151px" Text="标签内容：" Width="82px"></asp:Label></td>
            <td colspan="2">
            <asp:TextBox ID="txtContent" runat="server" Height="149px" TextMode="MultiLine" Width="312px" CssClass="input"></asp:TextBox></td>
           </tr>
           <tr><td>
       </td>
        <td style="width: 319px">
       创建人：<asp:Label ID="lblUserId" runat="server" CssClass="lblUser"></asp:Label>
       创建时间：<asp:Label ID="lblTime" runat="server"></asp:Label>
        </td>
        <td>
            </td>
        <tr><td style="height: 26px"></td><td style="width: 319px; height: 26px"><asp:Button ID="btnSave" runat="server" Text="保存" OnClick="btnSave_Click" CssClass="btnUser" />&nbsp;
        <asp:Button ID="btnDelete" runat="server" Text="删除当前标签" OnClick="btnDelete_Click" CssClass="btnUser" OnClientClick='return confirm("确定删除吗？");'/></td><td style="height: 26px">
            <asp:Label ID="lblMessage" runat="server"></asp:Label></td></tr>
        </table>
                </ContentTemplate>
            </asp:UpdatePanel>
        </div>       &nbsp;
    </form>
</body>
</html>
