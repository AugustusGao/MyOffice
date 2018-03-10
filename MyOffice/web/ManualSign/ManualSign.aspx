<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ManualSign.aspx.cs" Inherits="ManualSign_ManualSign" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>员 工 签 到、签 退 </title>
    <link href="../Css/Style.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <div style="text-align: center">
            <b>
                   <div style="text-align: center">
                    <b>
                        员 工 签 到、签 退</b>
                    </div>
                        <asp:ScriptManager ID="ScriptManager1" runat="server">
                        </asp:ScriptManager>
                        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                        <ContentTemplate>
                        
                        <div id="Div2">
                    <fieldset style="height: 200px">
                        <legend>员工填写区</legend>
                        <div style="width: 90%; height: 35px; text-align: left">
                            签卡日期： &nbsp;&nbsp;
                            <asp:TextBox ID="txtSignTime" runat="server" CssClass="inputCss" ReadOnly="True"
                                Width="176px" AutoPostBack="True"></asp:TextBox>
                            &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&nbsp;<asp:Button ID="btnSignIn" runat="server"
                                CssClass="buttonCss" Height="24px" OnClick="SignIn_Click" Text="签 到" Width="56px" />
                            <asp:Button ID="btnSignOut" runat="server" CssClass="buttonCss" EnableTheming="True"
                                Height="24px" OnClick="SignOut_Click" Text="签 退" Width="56px" Enabled="False" />
                            &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&nbsp;
                        </div>
                        <div style="width: 90%; height: 60px; text-align: left">
                            <span id="Span1" style="display: inline-block; left: 0px; width: 107px; position: relative;
                                top: -83px">签卡备注：</span>
                            <asp:TextBox ID="txtSignDesc" runat="server" CssClass="textArea" Height="99px" TextMode="MultiLine"
                                Width="301px" style="left: -35px; position: relative; top: 0px"></asp:TextBox>&nbsp;
                       </div>
                    </fieldset>
                   </div>
                    <hr color="#66ccff" size="2" style="width: 96%" />
                    <div id="divExit"  runat="server" visible="false">
                        <fieldset id="Fieldset1" style="height: 200px">
                            <legend>您的信息</legend>
                                <div style="width: 90%; height: 110px; text-align: left">
                                    &nbsp;&nbsp; 用 &nbsp; &nbsp; 户 &nbsp; &nbsp;号:
                                    <asp:TextBox ID="txtUserId" runat="server" CssClass="inputCss" ReadOnly="True" Width="104px"></asp:TextBox>
                                    &nbsp; &nbsp; &nbsp; &nbsp;
                                    &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&nbsp;
                                    &nbsp; 姓 &nbsp; &nbsp;&nbsp; 名: &nbsp;<asp:TextBox ID="txtUserName" runat="server" CssClass="inputCss"
                                        ReadOnly="True" Width="106px"></asp:TextBox><br />
                                    &nbsp; 所 属 部 门: &nbsp;<asp:TextBox ID="txtDepart" runat="server" CssClass="inputCss"
                                        ReadOnly="True" Width="104px"></asp:TextBox>
                                    &nbsp; &nbsp; &nbsp;
                                    &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&nbsp; &nbsp;
                                    &nbsp;所属机构: &nbsp;<asp:TextBox ID="txtBranch" runat="server" CssClass="inputCss" ReadOnly="True"
                                        Width="190px"></asp:TextBox><br />
                                    &nbsp;您的<asp:Label ID="sign" runat="server" Text="sign"></asp:Label><span id="Span3"></span>时间: 
                                    <asp:TextBox ID="txtSignTimeInfo" runat="server" CssClass="inputCss" ReadOnly="True" Width="333px"></asp:TextBox>
                                 </div>
                                    <div style="width: 90%; height: 50px; text-align: left">
                                        <span id="Span6" style="display: inline-block; left: 3px; width: 90px; position: relative;
                                            top: -29px">签卡备注：</span>&nbsp;
                                        <asp:TextBox ID="txtSignInDesc" runat="server" CssClass="textarea" Height="50px"
                                            ReadOnly="True" Style="left: -16px; position: relative; top: 0px" TextMode="MultiLine"
                                            Width="331px"></asp:TextBox>
                                    </div>
                        </fieldset>
                    </div>
                        
                        </ContentTemplate>
                        </asp:UpdatePanel>
                    
                   
            </b>
        </div>
    </div>
    </form>
</body>
</html>
