<%@ Page Language="C#" AutoEventWireup="true" CodeFile="UserDetail.aspx.cs" Inherits="SysManage_UserDetail" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>用户详情</title>
    <link href="~/Css/Style.css" rel="stylesheet" type="text/css" />
    <link href="~/App_Themes/MasterBg/master.css" type="text/css" rel="stylesheet" />  
</head>
<body>
    <form id="form1" runat="server">
    <div align="center" style="left: 100px; background-image: url(../images/users/userbg.jpg);
        width: 630px; height: 450px">
        <div style="background-image: url(../images/users/thbg.gif); width: 90%; height: 30px;
            text-align: center">
            <b>用 &nbsp;户 &nbsp;详 &nbsp;细 &nbsp;信 &nbsp;息</b></div>
        <div style="float: left; width: 30%; padding-top: 40px; height: 130px; text-align: right">
            <img id="imgUser" src="../images/users/noperson.jpg" runat="server" style="border-top-width: 0px;
                border-left-width: 0px; border-bottom-width: 0px; border-right-width: 0px; width:150px; height:180px;" />
        </div>
        <div style="float: left; width: 69%; padding-top:30px; text-align: right">
            <div align="center" style="width: 90%">
                <div style="float: left; width: 40%; height: 30px; text-align: right">
                    用户号：</div>
                <div style="float: left; width: 50%; height: 30px; text-align: left">
                    &nbsp; &nbsp;&nbsp;
                    <asp:Label ID="lblUserId" runat="server" CssClass="lblCss"></asp:Label></div>
            </div>
            <div align="center" style="width: 90%">
                <div style="float: left; width: 40%; height: 30px; text-align: right">
                    姓名：</div>
                <div style="float: left; width: 50%; height: 30px; text-align: left">
                    &nbsp; &nbsp;&nbsp;
                    <asp:Label ID="lblUserName" runat="server" CssClass="lblCss"></asp:Label>
                    </div>
            </div>
            <div align="center" style="width: 90%">
                <div style="float: left; width: 40%; height: 30px; text-align: right">
                    密码：</div>
                <div style="float: left; width: 50%; height: 30px; text-align: left">
                    &nbsp; &nbsp;&nbsp;
                    <asp:Label ID="lblPassword" runat="server" CssClass="lblCss" Font-Bold="False" Font-Size="Smaller"></asp:Label></div>
            </div>
            <div align="center" style="width: 90%">
                <div style="float: left; width: 40%; height: 30px; text-align: right">
                    部门：</div>
                <div style="float: left; width: 50%; height: 30px; text-align: left">
                    &nbsp; &nbsp;&nbsp;
                    <asp:Label ID="lblDepart" runat="server" CssClass="lblCss"></asp:Label></div>
            </div>
            <div align="center" style="width: 90%">
                <div style="float: left; width: 40%; height: 30px; text-align: right">
                    性别：</div>
                <div style="float: left; width: 50%; height: 30px; text-align: left">
                    &nbsp; &nbsp;&nbsp;
                    <asp:Label ID="lblGender" runat="server" CssClass="lblCss"></asp:Label></div>
            </div>
            <div align="center" style="width: 90%">
                <div style="float: left; width: 40%; height: 30px; text-align: right">
                    角色：</div>
                <div style="float: left; width: 50%; height: 30px; text-align: left">
                    &nbsp; &nbsp;&nbsp;
                    <asp:Label ID="lblUserRole" runat="server" CssClass="lblCss"></asp:Label></div>
            </div>
            <div align="center" style="width: 90%">
                <div style="float: left; width: 40%; height: 30px; text-align: right">
                    用户状态：</div>
                <div style="float: left; width: 50%; height: 30px; text-align: left">
                    &nbsp; &nbsp;&nbsp;
                    <asp:Label ID="lblUserState" runat="server" CssClass="lblCss"></asp:Label></div>
            </div>
        </div>
        <div style="width: 90%; height: 15px">
        </div>
        <div style="width: 90%; text-align: center">
            <input id="btnReset"  class="buttonface" name="cmdcancel" onclick="location.href='UserManager.aspx';"
                style="width: 58px; cursor: hand; height: 23px" type="reset" value="返回" /></div>
    </div>
    </form>
</body>
</html>
