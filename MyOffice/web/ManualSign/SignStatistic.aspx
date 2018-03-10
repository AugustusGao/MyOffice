<%@ Page Language="C#" AutoEventWireup="true"  EnableEventValidation="false"  CodeFile="SignStatistic.aspx.cs" Inherits="ManualSign_Search_SignStatistic" %>

<%@ Register Src="../UserControl/BranchDepartDdlUC.ascx" TagName="BranchDepartDdlUC"
    TagPrefix="uc2" %>

<%@ Register Src="../UserControl/ChoseTimeUC.ascx" TagName="ChoseTimeUC" TagPrefix="uc1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>员 工 考 勤 统 计</title>
    <link href="../Css/Style.css" rel="stylesheet" type="text/css" />
     <script language="javascript" src="../My97DatePicker/WdatePicker.js"></script>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <div style="text-align: center">
            <b>
                员 工 考 勤 统 计</b></div>
            <asp:ScriptManager ID="ScriptManager1" runat="server">
                </asp:ScriptManager>
        <table cellpadding="0" cellspacing="0" datapagesize="56" width="100%">
            <tr>
                <td colspan="2" style="width: 711px">
                        <table>
                            <tr>
                                <td colspan="1">
                                    <div>
                                        输入时间段：
                                        <uc1:ChoseTimeUC ID="ChoseTimeUC1" runat="server" />
                                    </div>
                                    </td>
                            </tr>
                            <tr>
                                <td align="middle" colspan="2" style="height: 1px" valign="center">
                                    <hr color="gray" size="1" width="95%" />
                                </td>
                            </tr>
                           
                            <tr>
                                <td colspan="2" style="height: 95px">
                                    &nbsp;&nbsp;<uc2:BranchDepartDdlUC ID="BranchDepartDdlUC1" runat="server" />
                                     <asp:Button ID="btnCount"  CssClass="buttonCss"  runat="server" Text="统　计" Height="23px" Width="110px" OnClick="btnCount_Click" />
                                    &nbsp; &nbsp; &nbsp;
                                    <asp:Button ID="btnExport"  CssClass="buttonCss"  runat="server" Text="导出Excel打印" Height="23px" Width="110px" Enabled="False" OnClick="btnExport_Click" OnLoad="btnExport_Load" />
                                    &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
                                </td>
                            </tr>
                            <tr>
                                <td colspan="2" width="100%">
                                    <div id="info"  runat="server" visible="false">
                                        <table id="print" width="100%">
                                            <tr>
                                                <td align="middle" colspan="2" style="height: 92%; width: 664px;" valign="top">
                                                    <div>
                                                    
                                                        <asp:GridView ID="gvSignInfoStatistic" runat="server" CssClass="gvCss" Width="100%" AutoGenerateColumns="False" AllowPaging="True" OnPageIndexChanging="gvSignInfoStatistic_PageIndexChanging" PageSize="3" >
                                                            <Columns>
                                                                <asp:TemplateField HeaderText="姓名" SortExpression="User">
                                                                    <EditItemTemplate>
                                                                        <asp:TextBox ID="TextBox3" runat="server" Text='<%# Bind("User") %>'></asp:TextBox>
                                                                    </EditItemTemplate>
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="Label3" runat="server" Text='<%# Eval("User.UserName") %>'></asp:Label>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="出勤率(%)" >
                                                                    <EditItemTemplate>
                                                                    </EditItemTemplate>
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="Label4" runat="server" Text='<%# Eval("SignRate","{0}%") %>'></asp:Label>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="迟到次数" >
                                                                    <EditItemTemplate>
                                                                    </EditItemTemplate>
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="Label5" runat="server" Text='<%# Bind("Late") %>'></asp:Label>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="早退次数" >
                                                                    <EditItemTemplate>
                                                                    </EditItemTemplate>
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="Label6" runat="server" Text='<%# Bind("EarlyOut") %>'></asp:Label>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="矿工次数" >
                                                                    <EditItemTemplate>
                                                                    </EditItemTemplate>
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="Label7" runat="server" Text='<%# Bind("Truancy") %>'></asp:Label>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="所属部门" SortExpression="User">
                                                                    <EditItemTemplate>
                                                                        <asp:TextBox ID="TextBox2" runat="server" Text='<%# Bind("User") %>'></asp:TextBox>
                                                                    </EditItemTemplate>
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="Label2" runat="server" Text='<%# Eval("User.DepartName") %>'></asp:Label>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="所属机构" SortExpression="User">
                                                                    <EditItemTemplate>
                                                                        <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("User") %>'></asp:TextBox>
                                                                    </EditItemTemplate>
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="Label1" runat="server" Text='<%# Eval("User.BranchName") %>'></asp:Label>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                            </Columns>
                                                            <PagerSettings FirstPageText=" 首 页 " LastPageText=" 尾 页 " NextPageText=" 下一页 " PreviousPageText=" 上一页 " Mode="NextPreviousFirstLast" />
                                                            <PagerStyle BackColor="AliceBlue" BorderColor="White" />
                                                        </asp:GridView>
                                                        </div>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="middle" colspan="2" style="width: 664px; height: 20px;">
                                                    <div id="divReportUser"> &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
                                                       &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;  
                                                        &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;<asp:Label ID="lblReportUser" runat="server" style="display: inline-block;font-weight: bold; width: 88px; position: static;"></asp:Label>
                                                        &nbsp; &nbsp;&nbsp; &nbsp; &nbsp;
                                                        &nbsp;<asp:Label
                                                            ID="lblReportTime" style="display: inline-block; font-weight: bold; position: static;" runat="server" Width="149px"></asp:Label>
                                                    </div>
                                                </td>
                                            </tr>
                                        </table>
                                    </div>
                                </td>
                            </tr>
                        </table>
            
                </td>
            </tr>
        </table> 
    </div>
    </form>
</body>
</html>
