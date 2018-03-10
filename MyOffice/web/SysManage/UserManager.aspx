<%@ Page Language="C#" AutoEventWireup="true" CodeFile="UserManager.aspx.cs" Inherits="SysManage_UserManager" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>用户管理</title>
    <link href="~/Css/Style.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
        <div style="width: 100%; height: 10px; text-align: center">
            <b>用 户 管 理<asp:ScriptManager ID="ScriptManager1" runat="server">
            </asp:ScriptManager>
                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                    <ContentTemplate>
                        <div style="width: 90%; padding-top: 6px; height: 26px; text-align: right">
                            <asp:Button ID="btnAddUser" runat="server" CssClass="buttonCss" Height="20px" Text="添加用户"
                                OnClick="btnAddUser_Click" />
                        </div>
                        <div style="width: 100%;" align="center">
                            <asp:GridView ID="gvUserInfo" runat="server"  BackColor="aliceblue" AutoGenerateColumns="False" Height="100%"
                                Width="100%" Font-Bold="False" OnRowCommand="gvUserInfo_RowCommand" OnRowDataBound="gvUserInfo_RowDataBound"
                                OnRowDeleting="gvUserInfo_RowDeleting" AllowPaging="True" OnPageIndexChanging="gvUserInfo_PageIndexChanging"
                                PageSize="5" CssClass="gvCss">
                               <RowStyle  BackColor="white"/>
                                <Columns>
                                    <asp:BoundField DataField="UserId" HeaderText="用户ID" SortExpression="UserId" />
                                    <asp:BoundField DataField="UserName" HeaderText="姓名" SortExpression="UserName" />
                                    <asp:BoundField DataField="Password" HeaderText="密码" SortExpression="Password" />
                                    <asp:TemplateField HeaderText="角色" SortExpression="Role">
                                        <EditItemTemplate>
                                            <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("Role") %>'></asp:TextBox>
                                        </EditItemTemplate>
                                        <ItemTemplate>
                                            <asp:Label ID="Label1" runat="server" Text='<%# Eval("Role.roleName") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="用户详情">
                                        <ItemTemplate>
                                            <asp:LinkButton ID="lnkBtnDetail" runat="server" CommandArgument='<%# Eval("UserId") %>'
                                                CommandName="Detail">详情</asp:LinkButton>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="修改">
                                        <ItemTemplate>
                                            <asp:ImageButton ID="ImageButton1" runat="server" CommandArgument='<%# Eval("UserId") %>'
                                                ImageUrl="~/Images/edit.gif" CommandName="Update" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="删除">
                                        <ItemTemplate>
                                            <asp:ImageButton ID="ImageButton2" runat="server" CommandArgument='<%# Eval("UserId") %>'
                                                ImageUrl="~/Images/delete.gif" CommandName="Delete" OnClientClick='return confirm("你确定要删除此信息吗？")' />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                </Columns>
                                <PagerSettings FirstPageText=" 首 页 " LastPageText=" 尾 页 " Mode="NextPreviousFirstLast"
                                    NextPageText=" 下一页 " PreviousPageText=" 上一页 " />
                                <PagerStyle BackColor="AliceBlue" />
                            </asp:GridView>
                        </div>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </b>
        </div>
    </form>
</body>
</html>
