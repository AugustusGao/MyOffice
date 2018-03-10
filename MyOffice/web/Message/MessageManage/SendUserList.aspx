<%@ Page Language="C#" AutoEventWireup="true" CodeFile="SendUserList.aspx.cs" Inherits="Message_MessageManage_SendUserList" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>查看发送人</title>
    <link href="~/Css/Style.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <table align="center" border="0" cellpadding="0" cellspacing="0" height="60%" width="60%">
            <tr>
                <td align="left" valign="top" width="90%" style="height: 189px">
                    &nbsp;&nbsp;
                    <fieldset style="border-left-color: transparent; border-bottom-color: transparent;
                        clip: rect(0px 0px 0px 0px); border-top-color: transparent; background-color: #ffffee;
                        border-right-color: transparent; height: 160px;">
                        <legend align="center">该消息的发送对象包括如下人员：</legend>&nbsp;
                        &nbsp;&nbsp; &nbsp; &nbsp;
                        &nbsp; &nbsp;<asp:DataList ID="DataList1" runat="server" DataSourceID="ObjectDataSource1" RepeatColumns="4">
                            <ItemTemplate>
                                <asp:CheckBox ID="CheckBox2" runat="server" Text='<%# Eval("ToUser.UserName") %>' Checked="true"/>
                            </ItemTemplate>
                        </asp:DataList>

                        <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" SelectMethod="GetAllMessageToUserByMessageId"
                            TypeName="MyOffice.BLL.MessageToUserManager">
                            <SelectParameters>
                                <asp:QueryStringParameter Name="messageId" QueryStringField="messageId" Type="Int32" />
                            </SelectParameters>
                        </asp:ObjectDataSource>
                        &nbsp;&nbsp;
                        <br />
                    </fieldset>
                </td>
            </tr>
            <tr>
                <td align="middle" valign="top" style="height: 37px">
                    <br />
                    <input id="btnClose" onclick="self.close();" style="width: 75px; height: 22px" type="button"
                        value="关闭" />&nbsp;
                </td>
            </tr>
        </table>
    </div>
    </form>
</body>
</html>
