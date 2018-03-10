<%@ Page Language="C#" AutoEventWireup="true" CodeFile="MailBox.aspx.cs" Inherits="Message_MailBox_MailBox" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>信箱</title>
    <link href="~/Css/Style.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
    <br /><br />
        <fieldSet id="fid1" runat="server" style=" width: 839px; height: 288px;"><legEnd>个人消息管理区：</legEnd>
        <br /><br /><br /><br /><br />
    <div>

    <table align="center" border="1" bordercolor="#ffffff" cellpadding="0" cellspacing="0" style="width: 73%; height: 168px">
            
                <tr bordercolor="gray">
                    <td bordercolor="#ffffff" style="height: 21px; width: 130px;">
                    
                    </td>
                    <td align="left" class="HeaderCenter" valign="top" style="height: 21px; width: 20%; background-color: aliceblue;">
                        本地文件夹</td>
                    <td align="left" class="HeaderCenter" valign="top" style="width: 20%; height: 21px; background-color: aliceblue;">
                        文件个数</td>
                    <td align="left" class="HeaderCenter" valign="top" width="20%" style="height: 21px; background-color: aliceblue;">
                        未读邮件</td>
                    <td bordercolor="#ffffff" style="width: 66px; height: 21px;">
                    </td>
                </tr>
                <tr bordercolor="gray" height="25" valign="center">
                    <td align="middle" bordercolor="#ffffff" rowspan="2" style="width: 130px">
                        <img id="imgMessage" src="../../images/message.gif" style="width: 47px; height: 56px" /></td>
                    <td align="middle" style="width: 20%; height: 25px">
                        <img onclick="location.href='ReceiveMail.aspx';" src="../../images/ReceiveFile.jpg"
                            style="border-top-width: 0px; border-left-width: 0px; border-bottom-width: 0px;
                            width: 65px; cursor: hand; height: 16px; border-right-width: 0px" id="IMG1" />
                    </td>
                    <td align="middle" style="width: 20%; height: 25px;">
                        <span id="lblReceiveFiles" style="color: blue">
                            <asp:Label ID="lblInbox" runat="server"></asp:Label></span></td>
                    <td align="middle" width="20%" style="height: 25px">
                        <span id="lblUnReadReceiveFiles" style="color: blue">
                            <asp:Label ID="lblItNotRead" runat="server"></asp:Label></span></td>
                </tr>
                <tr bordercolor="gray" height="25" valign="center">
                    <td align="middle" style="width: 20%; height: 26px;">
                      <img onclick="location.href='DraftMail.aspx';" src="../../images/DraftFile.JPG" style="border-top-width: 0px;
                            border-left-width: 0px; border-bottom-width: 0px; width: 65px; cursor: hand;
                            height: 16px; border-right-width: 0px" /></td>
                    <td align="middle" style="width: 20%; height: 26px;">
                        <asp:Label ID="lblDraftFiles" runat="server"></asp:Label></td>
                    <td align="middle" width="20%" style="height: 26px">
                        <span id="lblUnReadDraftFiles">0</span></td>
                </tr>
                <tr bordercolor="gray" height="25" valign="center">
                    <td bordercolor="#ffffff" style="height: 25px; width: 130px;">
                    </td>
                    <td align="middle" style="height: 25px; width: 20%;">
                        <img onclick="location.href='SendMail.aspx';" src="../../images/SendFile.jpg" style="border-top-width: 0px;
                            border-left-width: 0px; border-bottom-width: 0px; width: 65px; cursor: hand;
                            height: 16px; border-right-width: 0px" /></td>
                    <td align="middle" style="height: 25px; width: 20%;">
                            <asp:Label ID="lblSend" runat="server"></asp:Label></td>
                    <td align="middle" valign="top" width="20%" style="height: 25px">
                        <span id="lblUnReadSendFiles">0</span></td>
                </tr>
                <tr bordercolor="gray" height="25" valign="center">
                    <td bordercolor="#ffffff" style="height: 25px; width: 130px;">
                    </td>
                    <td align="middle"  style="height: 25px; width: 20%;">
                        <img onclick="location.href='GarbageMail.aspx';" src="../../images/DeletedFile.jpg" style="border-top-width: 0px;
                        border-left-width: 0px; border-bottom-width: 0px; width: 65px; cursor: hand;
                        height: 16px; border-right-width: 0px" /></td>
                    <td align="middle" style="height: 25px; width: 20%;">
                        <asp:Label ID="lblDeletedFiles" runat="server"></asp:Label></td>
                    <td align="middle" width="20%" style="height: 25px">
                        <span id="lblUnReadDeletedFiles">0</span></td>
                </tr>
                <tr><td style="width: 130px"></td></tr>
            </table>
    </div>
    <br /><br /><br /><br /><br /><br />
    </fieldSet>
    </form>
</body>
</html>
