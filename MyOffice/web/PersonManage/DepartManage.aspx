<%@ Page Language="C#" AutoEventWireup="true" CodeFile="DepartManage.aspx.cs" Inherits="PersonManage_DepartManage" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>部门管理</title>
    <link href="~/Css/Style.css" rel="stylesheet" type="text/css" />
    <link href="~/App_Themes/MasterBg/master.css" type="text/css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
        <div style="text-align: center">
            <b>部 门 管 理</b></div>
        <hr style="width: 90%; text-align: center; color: Gray" />
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
                <div style="width: 90%; height: 30px; text-align: right">
                    <asp:Button ID="btnAdd" runat="server" CssClass="buttonCss" Text="添加部门" OnClick="btnAdd_Click" /></div>
                <div style="width: 100%;" align="center">
                    <asp:GridView ID="gvDepartInfo" runat="server"  BackColor="aliceblue" AutoGenerateColumns="False" Height="100%"
                        Width="100%" OnRowCommand="gvDepartInfo_RowCommand" OnRowDeleting="gvDepartInfo_RowDeleting"
                        OnRowDataBound="gvDepartInfo_RowDataBound" AllowPaging="True" OnPageIndexChanging="gvDepartInfo_PageIndexChanging"
                        PageSize="5" CssClass="gvCss">
                        <RowStyle  BackColor="white"/>
                        <Columns>
                            <asp:BoundField DataField="DepartName" HeaderText="部门名称" SortExpression="DepartName" />
                            <asp:TemplateField HeaderText="机构" SortExpression="Branch">
                                <EditItemTemplate>
                                    <asp:TextBox ID="TextBox2" runat="server" Text='<%# Bind("Branch") %>'></asp:TextBox>
                                </EditItemTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="Label2" runat="server" Text='<%# Eval("Branch.BranchName") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="负责人" SortExpression="PrincipalUser">
                                <EditItemTemplate>
                                    <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("PrincipalUser") %>'></asp:TextBox>
                                </EditItemTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="Label1" runat="server" Text='<%# Eval("PrincipalUser.UserName") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:BoundField DataField="ConnectMobileTelNo" HeaderText="移动电话" SortExpression="ConnectMobileTelNo" />
                            <asp:BoundField DataField="ConnectTelNo" HeaderText="联系电话" SortExpression="ConnectTelNo" />
                            <asp:BoundField DataField="Faxes" HeaderText="传真" SortExpression="Faxes" />
                            <asp:TemplateField HeaderText="修改">
                                <ItemTemplate>
                                    <asp:ImageButton ID="ImageButton1" runat="server" CommandName="Update" ImageUrl="~/Images/edit.gif"
                                        CommandArgument='<%# Eval("DepartId") %>' />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="删除">
                                <ItemTemplate>
                                    <asp:ImageButton ID="ImageButton2" runat="server" CommandName="Delete" ImageUrl="~/Images/delete.gif"
                                        CommandArgument='<%# Eval("DepartId") %>' OnClientClick='return confirm("你确定要删除此信息吗");' />
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                        <PagerSettings FirstPageText=" 首 页 " LastPageText=" 尾 页 " Mode="NextPreviousFirstLast"
                            NextPageText=" 下一页 " PreviousPageText=" 上一页 " />
                        <PagerStyle BackColor="AliceBlue" />
                    </asp:GridView>
                    <div>
                        &nbsp; &nbsp;
                    </div>
                </div>
            </ContentTemplate>
        </asp:UpdatePanel>
    </form>
</body>
</html>
