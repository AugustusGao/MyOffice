<%@ Page Language="C#" AutoEventWireup="true" EnableEventValidation="false" CodeFile="ManualSignSearch.aspx.cs"
    Inherits="ManualSign_Search_ManualSignSearch" %>

<%@ Register Src="../../UserControl/BranchDepartDdlUC.ascx" TagName="BranchDepartDdlUC"
    TagPrefix="uc2" %>

<%@ Register Src="../../UserControl/ChoseTimeUC.ascx" TagName="ChoseTimeUC" TagPrefix="uc1" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>


<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>员 工 考 勤 历 史 记 录 查&nbsp; 询</title>
    <link href="../../Css/Style.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript">
        function ScanContent(Id)
		{
		alert("is="+Id);
		 window.showModalDialog("ShowContent.aspx?Id="+Id,"","status=no;dialogWidth=550px;dialogHeight=500px;menu=no;resizeable=yes;scroll=yes;center=yes;edge=raise")
		}
    </script>

</head>
<body>
    <form id="form1" runat="server">
        <div>
            <div style="text-align: center">
                <b>员 工 考 勤 历 史 记 录 查&nbsp; 询<asp:ScriptManager ID="ScriptManager1" runat="server">
                </asp:ScriptManager>
                </b></div>
            <table cellpadding="0" cellspacing="0">
                <tr>
                    <td colspan="2">
                       
                        <asp:UpdatePanel ID="upSearchHistory"  runat="server">
                            <ContentTemplate>
                                <table>
                                    <tr>
                                        <td colspan="2">
                                            <div>
                                                输入时间段:<uc1:ChoseTimeUC ID="ChoseTimeUC1" runat="server" />
                                            </div>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="center"colspan="2" valign="middle" style="height: 5px">
                                            <hr color="gray" size="1" width="95%" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="2" style="height: 46px">
                                            <div>
                                                <img id="img1" src="../../images/search2.gif" style="border-top-width: 0px; border-left-width: 0px;
                                                    border-bottom-width: 0px; border-right-width: 0px"  alt=""/>查找范围：
                                                <asp:CheckBoxList ID="chklstSelect" runat="server" AutoPostBack="True" OnSelectedIndexChanged="chklstSelect_SelectedIndexChanged"
                                                    RepeatDirection="Horizontal" Style="left: 89px; position: relative; top: -23px"
                                                    Width="311px">
                                                    <asp:ListItem Value="0">按机构</asp:ListItem>
                                                    <asp:ListItem Value="1">按部门</asp:ListItem>
                                                    <asp:ListItem Value="2">按员工号</asp:ListItem>
                                                    <asp:ListItem Value="3">按姓名</asp:ListItem>
                                                </asp:CheckBoxList>
                                            </div>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="middle" colspan="2" valign="center" style="height: 5px">
                                            <hr color="gray" size="1" width="95%" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="2">
                                           <uc2:BranchDepartDdlUC ID="BranchDepartDdlUC1" runat="server" />
                                            员工号:<asp:TextBox ID="txtUserId" runat="server" CssClass="inputCss" Width="48px"
                                                Enabled="False"></asp:TextBox>
                                            姓名:<asp:TextBox ID="txtUserName" runat="server" CssClass="inputCss" Width="121px" AutoPostBack="True" Enabled="False"></asp:TextBox>
                                            <cc1:AutoCompleteExtender ID="AutoCompleteExtender1" runat="server" TargetControlID="txtUserName"
                                                ServicePath="../../System/DataService.asmx" ServiceMethod="GetSearchNameByKeyWords"
                                                CompletionSetCount="10" CompletionInterval="1000" EnableCaching="true" 
                                                MinimumPrefixLength="1" />
                                            
                                            <asp:ImageButton ID="imgBtnSearch" runat="server" src="../../images/search.gif" Style="border-top-width: 0px;
                                                border-left-width: 0px; border-bottom-width: 0px; width: 100px; height: 21px;
                                                border-right-width: 0px" OnClick="imgBtnSearch_Click" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="middle" colspan="2" style="height: 100%" valign="top" width="90%">
                                            <div id="divSearch" runat="server" visible="false">
                                                <asp:GridView ID="gvSearch" runat="server" CssClass="gvCss" Width="100%" AutoGenerateColumns="False"
                                                    DataKeyNames="User" OnRowDataBound="gvSearch_RowDataBound">
                                                    <Columns>
                                                        <asp:TemplateField HeaderText="签到员工" SortExpression="User">
                                                            <EditItemTemplate>
                                                                <asp:TextBox ID="TextBox1" runat="server" Text='<%# Eval("User.UserName") %>'></asp:TextBox>
                                                            </EditItemTemplate>
                                                            <ItemTemplate>
                                                                <asp:Label ID="Label1" runat="server" Text='<%# Eval("User.UserName") %>'></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="签到时间" SortExpression="SignTime">
                                                            <EditItemTemplate>
                                                                <asp:TextBox ID="TextBox4" runat="server" Text='<%# Bind("SignTime") %>'></asp:TextBox>
                                                            </EditItemTemplate>
                                                            <ItemTemplate>
                                                                <asp:Label ID="Label2" runat="server" Text='<%# Eval("SignTime","{0:yyyy/MM/dd hh:mm:ss}") %>'></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="签卡标记" SortExpression="SignTag">
                                                            <EditItemTemplate>
                                                                <asp:TextBox ID="TextBox5" runat="server" Text='<%# Bind("SignTag") %>'></asp:TextBox>
                                                            </EditItemTemplate>
                                                            <ItemTemplate>
                                                                <asp:Label ID="Label3" runat="server" Text='<%# Bind("SignTag") %>'></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="签卡备注" SortExpression="SignDesc">
                                                            <EditItemTemplate>
                                                                <asp:TextBox ID="TextBox6" runat="server" Text='<%# Bind("SignDesc") %>'></asp:TextBox>
                                                            </EditItemTemplate>
                                                            <ItemTemplate>
                                                                <asp:Label ID="Label4" runat="server" Text='<%# Bind("SignDesc") %>'></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="所属部门" SortExpression="User">
                                                            <EditItemTemplate>
                                                                <asp:TextBox ID="TextBox2" runat="server" Text='<%# Eval("User.departName") %>'></asp:TextBox>
                                                            </EditItemTemplate>
                                                            <ItemTemplate>
                                                                <asp:Label ID="Label5" runat="server" Text='<%# Eval("User.departName") %>'></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="所属机构" SortExpression="User">
                                                            <EditItemTemplate>
                                                                <asp:TextBox ID="TextBox3" runat="server" Text='<%# Eval("User.BranchName") %>'></asp:TextBox>
                                                            </EditItemTemplate>
                                                            <ItemTemplate>
                                                                <asp:Label ID="Label6" runat="server" Text='<%# Eval("User.BranchName") %>'></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                    </Columns>
                                                </asp:GridView>
                                            </div>
                                        </td>
                                    </tr>
                                </table>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </td>
                </tr>
            </table>
        </div>
    
    </form>
</body>
</html>
