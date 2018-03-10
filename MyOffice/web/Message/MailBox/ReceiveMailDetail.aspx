<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ReceiveMailDetail.aspx.cs" Inherits="Message_MailBox_ReceiveMailDetail" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>消息详情</title>
    <link href="../../Css/Style.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
    <div>
     <TABLE id="Table2" cellSpacing="1" cellPadding="2" border="0" bgColor="#e6e6e6" width="85%"
				align="left">
				<TR>
					<TD bgColor="white" align="left" width="25%">消息主题：
					</TD>
					<TD bgColor="white" style="width: 549px"><asp:Label id="lblTitle" runat="server" CssClass="title"></asp:Label></TD>
				</TR>
				<TR>
					<td bgColor="white" valign="top" align="left">重要程度：</td>
					<TD bgColor="white" style="width: 549px">
						<asp:Label id="lblType" runat="server" ForeColor="Red"></asp:Label></TD>
				</TR>
				<TR>
					<td bgColor="white" valign="top" align="left" style="height: 47px">消息内容：</td>
					<TD bgColor="white" style="width: 549px; height: 47px;">
                        <asp:TextBox ID="txtContent" runat="server" Height="155px" ReadOnly="True" TextMode="MultiLine"
                            Width="449px"></asp:TextBox></TD>
				</TR>
				<TR>
					<td bgColor="white" valign="top" align="left">
                        <asp:Label ID="lblText" runat="server" Text="发件人："></asp:Label></td>
					<TD bgColor="white" style="width: 549px">
						<asp:Label id="lblFromUser" runat="server"></asp:Label></TD>
				</TR>
				<TR>
					<td bgColor="white" valign="top" align="left">
                        <asp:Label ID="lblTime" runat="server" Text="发送时间："></asp:Label></td>
					<TD bgColor="white" style="width: 549px">
						<asp:Label id="lblSendTime" runat="server"></asp:Label></TD>
				</TR>
				<TR>
					<td bgColor="white" valign="top"></td>
					<TD bgColor="white" align="center" style="width: 549px">
					<INPUT id="btnClose" style="WIDTH: 75px; HEIGHT: 22px" type="button" class="buttonCss" value="关闭" onclick="javascript:window.returnValue='OK';self.close();">&nbsp;
					</TD>
				</TR>
			</TABLE>
    </div>
    </form>
</body>
</html>
