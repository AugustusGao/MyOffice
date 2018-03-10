<%@ Page Language="C#" AutoEventWireup="true" CodeFile="CreateUser.aspx.cs" Inherits="SysManage_CreateUser" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title>添加用户</title>
    <link href="~/Css/Style.css" rel="stylesheet" type="text/css" />
    <link href="~/App_Themes/MasterBg/master.css" type="text/css" rel="stylesheet" />  
    <script type="text/javascript">
        function CheckImg(FileUpload)
        {
 
            var mime=FileUpload.value;
            mime=mime.toLowerCase().substr(mime.lastIndexOf("."));
            if(mime!=".jpg")
            {
                FileUpload.value="";
                alert("仅支持JPG格式！");
            }
            else
            {
                document.getElementById("imgHead").src=FileUpload.value;
            }
        }
    </script>
</head>
<body>
    <form id="form1" runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
    <div style="text-align: center">
        <b>保 存 用 户 信 息</b></div>
    <hr color="gray" size="1" style="width: 90%; text-align: center" />
    <div style="float: center; width: 51%; text-align: left; left: 102px; position: relative;
        top: -1px;">
        <div id="pnlUserInfo" style="border-right: #66ccff 1px solid; border-top: #66ccff 1px solid;
            border-left: #66ccff 1px solid; width: 99%; border-bottom: #66ccff 1px solid;
            left: 1px; position: relative; top: 3px;">
            <br />
          
            <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                <contenttemplate>  
         用户登录名：
         <asp:TextBox id="txtUserId" runat="server" OnTextChanged="txtUserId_TextChanged" AutoPostBack="True"></asp:TextBox> 
         <asp:RequiredFieldValidator style="LEFT: -4px; POSITION: relative; TOP: 0px" id="rfvUserId" runat="server" ErrorMessage="用户登录名不能为空！" ControlToValidate="txtUserId" Display="Dynamic" SetFocusOnError="True">*</asp:RequiredFieldValidator> 
           </contenttemplate>
           </asp:UpdatePanel><br />
            密 &nbsp; &nbsp; &nbsp; &nbsp;&nbsp; &nbsp;码： &nbsp;&nbsp;
            <asp:TextBox ID="txtPassword" runat="server" TextMode="Password" Style="left: -9px;
                position: relative; top: 3px"  Width="155px"></asp:TextBox>
                    
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtPassword"
                ErrorMessage="密码不能为空！" Style="left: -9px; position: relative; top: -2px" Display="Dynamic" SetFocusOnError="True">*</asp:RequiredFieldValidator><br />
            <br />
            确 认 密码：&nbsp;
            <asp:TextBox ID="txtSureword" runat="server" TextMode="Password" Width="149px" Style="left: 3px;
                position: relative; top: 1px"></asp:TextBox>
            <asp:RequiredFieldValidator ID="rfvSureword" runat="server" ControlToValidate="txtSureword"
                ErrorMessage="确认密码不能为空！" Style="left: -5px; position: relative;
                top: -2px" Display="Dynamic" SetFocusOnError="True">*</asp:RequiredFieldValidator>
            <asp:CompareValidator ID="cvSure" runat="server" ControlToCompare="txtPassword" ControlToValidate="txtSureword"
                ErrorMessage="前后输入不一致" Display="Dynamic" SetFocusOnError="True"></asp:CompareValidator><br />
            <br />
            真 实 姓名： &nbsp;
            <asp:TextBox ID="txtRealName" runat="server" Style="left: -6px; position: relative;
                top: 0px"></asp:TextBox>
            <asp:RequiredFieldValidator ID="rfvRealName1" runat="server" ControlToValidate="txtRealName"
                ErrorMessage="真实姓名不能为空！" Style="left: -8px; position: relative;
                top: -2px" SetFocusOnError="True" EnableViewState="False">*</asp:RequiredFieldValidator><br />
            <br />
            所 在 部门：<asp:DropDownList ID="ddlDepart" runat="server" 
            DataSourceID="odsDepart"
                DataTextField="DepartName" 
                DataValueField="DepartId" Style="left: 6px; position: relative;
                top: 0px" Width="104px">
            </asp:DropDownList>
            <asp:ObjectDataSource ID="odsDepart" runat="server" SelectMethod="GetAllDepart"
                TypeName="MyOffice.BLL.DepartInfoManager"></asp:ObjectDataSource>
            <br />
            <br />
            性 &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;别：<asp:RadioButtonList ID="rdolstGender" runat="server"
                RepeatDirection="Horizontal" Style="left: 107px; position: relative; top: -24px">
                <asp:ListItem Selected="True" Value="1">男</asp:ListItem>
                <asp:ListItem Value="0">女</asp:ListItem>
            </asp:RadioButtonList>
            &nbsp;<img id="imgHead" runat="server"  name="img" alt="请上传用户照片" style="float: center; left: 67px; position: relative; top: -12px;"
                border="0" src="../Images/Users/noperson.jpg" height="167" width="150"   /><br />
            &nbsp;<asp:FileUpload ID="fuImage" 
            runat="server" Style="width: 287px; cursor:pointer" BackColor="#C0FFFF"　
            onchange="CheckImg(this)" /><br />
            <br />
            角 &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; 色：
            <asp:DropDownList ID="ddlUserRole" runat="server" DataSourceID="odsUserRole" DataTextField="RoleName"
                DataValueField="RoleId">
            </asp:DropDownList><asp:ObjectDataSource ID="odsUserRole" runat="server" SelectMethod="GetAllRoleInfo"
                TypeName="MyOffice.BLL.RoleManager"></asp:ObjectDataSource>
            <br />
            <br />
            当 前 状态：
            <asp:DropDownList ID="ddlUserState" runat="server"
             DataSourceID="odsUserState" DataTextField="UserStateName"
                DataValueField="UserStateId" Style="left: 0px; position: relative; top: 0px"
                Width="84px">
            </asp:DropDownList><asp:ObjectDataSource ID="odsUserState" runat="server" SelectMethod="GetAllUserState"
                TypeName="MyOffice.BLL.UserStateManager"></asp:ObjectDataSource>
            &nbsp;&nbsp;<br />
            <asp:ValidationSummary ID="ValidationSummary1" runat="server" ShowMessageBox="True"
                ShowSummary="False" />
            <br />
            <asp:Button ID="btnSave" runat="server" Text="保存" CssClass="buttonCss"  OnClick="btnSave_Click" Width="57px" />
            &nbsp;
            <asp:Button
                ID="Reset1" runat="server" CssClass="buttonCss" Text="全部重置" />
            &nbsp; &nbsp; &nbsp;&nbsp;
            <input class="buttonCss" onclick="history.go(-1);" style="width: 59px;
                height: 24px" type="button" value="返回" /><br />
            <br />
         
        
        </div>
    </div>
    
    </form>
</body>
</html>
