<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ShowContent.aspx.cs" Inherits="ManualSign_Search_ShowContent" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>显示消息内容</title>
    <link href="../../Css/Style.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
    <div>
      <table border="0" cellpadding="0" cellspacing="0" height="60%" width="60%" align="center">
            <tr>
                <td align="left" valign="top" width="90%">
                    <fieldset style="border-left-color: transparent; border-bottom-color: transparent;
                        width: 512px; clip: rect(0px 0px 0px 0px); border-top-color: transparent; height: 396px;
                        background-color: #ffffee; border-right-color: transparent">
                        <legend align="center">该消息基本内容如下：</legend>
                        <br />
                        <textarea id="txtContent" runat="server" class="inputCss" cols="60" rows="16" style="width: 504px;
                            height: 360px"></textarea>
                    </fieldset>
                </td>
            </tr>
            <tr>
                <td align="middle" valign="top" style="height: 45px">
                    <br />
                    <input id="btnClose" class="buttonCss" onclick="self.close();" style="width: 75px;
                        height: 22px" type="button" value="关闭" />&nbsp;
                </td>
            </tr>
        </table>
    </div>
    </form>
</body>
</html>
