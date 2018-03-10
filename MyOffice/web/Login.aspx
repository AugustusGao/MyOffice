<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Login.aspx.cs"  Inherits="Login" %>
<html xmlns="http://www.w3.org/1999/xhtml" >
<head><title>
	MyOffice系统
</title>
    <link href="Css/Style.css" rel="stylesheet" type="text/css" />
<meta http-equiv="Content-Type" content="text/html; charset=utf-8" /><style type="text/css">
<!--
.bg {
	background-image: url(images/login.jpg);
	background-repeat: no-repeat;
}
-->
</style></head>
<body style="background-color:#7aa1e6;"  scroll="no">
    <form id="Form1" name="form1"  runat="server">

	<table width="100%" height="100%">
	<tr>
	<td align="center" valign="middle">
        &nbsp;<table width="516" border="0" cellpadding="0" cellspacing="0" class="bg">
      <!--DWLayoutTable-->
      <tr>
        <td width="115" style="height: 272px">&nbsp;</td>
        <td style="width: 138px; height: 272px">&nbsp;</td>
        <td width="89" style="height: 272px">&nbsp;</td>
        <td width="123" style="height: 272px">&nbsp;</td>
        <td width="65" style="height: 272px">&nbsp;</td>
      </tr>
      <tr>
        <td style="height: 20px">&nbsp;</td>
        <td valign="top" style="width: 138px; height: 20px;">
            &nbsp;<asp:TextBox ID="txtUserId" runat="server" CssClass="loinBox" AutoCompleteType="Disabled" OnTextChanged="txtUserId_TextChanged" ForeColor="White" style="position: static"></asp:TextBox></td>
        <td style="height: 20px">
            <asp:RequiredFieldValidator ID="rfvUserId" runat="server" ControlToValidate="txtUserId"
                ErrorMessage="用户名不能为空！" Style="left: 0px; position: relative" SetFocusOnError="True">*</asp:RequiredFieldValidator></td>
        <td style="height: 20px">&nbsp;</td>
        <td style="height: 20px">&nbsp;</td>
      </tr>
      <tr>
        <td style="height: 25px"></td>
        <td style="width: 138px; height: 25px">&nbsp;</td>
        <td style="height: 25px"　 ></td>
        <td style="height: 25px"　 ></td>
        <td style="height: 25px"　 ></td>
      </tr>
      <tr>
        <td style="height: 23px"></td>
        <td rowspan="2" valign="top" style="width: 138px">
            <asp:TextBox ID="txtPassword" runat="server" CssClass="loinBox" TextMode="Password" Width="131px" style="position: static">123</asp:TextBox></td>
        <td style="height: 23px">
            <asp:RequiredFieldValidator ID="rfvPassword" runat="server" ControlToValidate="txtPassword"
                ErrorMessage="密码不能为空！" SetFocusOnError="True">*</asp:RequiredFieldValidator>
            </td>
        <td style="height: 23px"></td>
        <td style="height: 23px"></td>
      </tr>
      
      
      
      <tr>
        <td style="height: 11px"></td>
        <td style="height: 11px"></td>
        <td rowspan="2" valign="top"> 
        <asp:ImageButton ID="imgbtnLogin"  ImageUrl="Images/denglu.jpg" runat="server" OnClick="imgbtnLogin_Click" />
        <td style="height: 11px"></td>
      </tr>
      <tr>
        <td style="height: 19px"></td>
        <td style="width: 138px; height: 19px" 　>
            &nbsp;</td>
        <td style="height: 19px"></td>
        <td style="height: 19px"></td>
      </tr>
      
      
      
      <tr>
        <td height="13"></td>
        <td style="width: 138px"></td>
        <td></td>
        <td></td>
        <td></td>
      </tr>
    </table>
		</td>
	</tr>
	</table>
  <asp:ValidationSummary ID="ValidationSummary1" runat="server" EnableTheming="True"
            Font-Overline="False" Font-Strikeout="False" Font-Underline="False" 

ShowMessageBox="True"
            ShowSummary="False" />
	</form>
</body>
</html>