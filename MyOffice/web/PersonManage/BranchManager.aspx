<%@ Page Language="C#" AutoEventWireup="true" CodeFile="BranchManager.aspx.cs" Inherits="PersonManage_BranchManager" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title>机构管理</title>
    <meta http-equiv="Content-Type" content="text/html; charset=Gb2312" />   
    <link href="~/Css/Style.css" rel="stylesheet" type="text/css" />
    <link href="~/App_Themes/MasterBg/master.css" type="text/css" rel="stylesheet" />  
</head>
<body>
    <form id="form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
            </asp:ScriptManager>
            
    <div style="text-align:center">
        <b>
            机 构 管 理</b>
    </div>
    <hr style="width:90%; text-align:center; color:Gray" />
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
    <ContentTemplate>
    <div style="width:90%; height:35px; text-align:center">机构名称：
        <asp:TextBox ID="txtBranchName" runat="server"></asp:TextBox>&nbsp;&nbsp;<asp:RequiredFieldValidator
            ID="rfvBranchName" runat="server" ErrorMessage="机构名称不能为空！" ControlToValidate="txtBranchName" Display="Dynamic">*</asp:RequiredFieldValidator>&nbsp;&nbsp;
        机构简称：<asp:TextBox
            ID="txtBranchShortName" runat="server"></asp:TextBox>
        <asp:RequiredFieldValidator ID="rfvBranchShortName" runat="server" ErrorMessage="机构简称不能为空！" 
        ControlToValidate="txtBranchShortName" >*</asp:RequiredFieldValidator>&nbsp;&nbsp;
        <asp:Button ID="btnAdd" runat="server" Text="添 加" CssClass="buttonCss" OnClick="btnAdd_Click" />&nbsp;
        <asp:ValidationSummary ID="ValidationSummary1" runat="server" ShowMessageBox="True"
            ShowSummary="False" />
        <asp:Button ID="btnUpdate" runat="server" Text="保存修改" CssClass="buttonCss" Enabled="False" OnClick="btnUpdate_Click" /></div>
        <div style="WIDTH: 99%" id="div1" align="center"><div>&nbsp;</div>
            <asp:GridView ID="gvBranchList" runat="server"  BackColor="aliceblue" AutoGenerateColumns="False"
                Height="100%" Width="100%" OnRowCommand="gvBranchList_RowCommand" OnRowDeleting="gvBranchList_RowDeleting" OnRowDataBound="gvBranchList_RowDataBound" OnRowUpdating="gvBranchList_RowUpdating" AllowPaging="True" OnPageIndexChanging="gvBranchList_PageIndexChanging" CssClass="gvCss">
                <RowStyle  BackColor="white"/>
                <Columns>
                    <asp:BoundField DataField="BranchName" HeaderText="机构名称" SortExpression="BranchName" />
                    <asp:BoundField DataField="BranchShortName" HeaderText="机构简称" SortExpression="BranchShortName" />
                    <asp:TemplateField HeaderText="修改">
                        <ItemTemplate>
                            &nbsp;<asp:ImageButton ID="imgBtnUpdate" runat="server" CommandArgument='<%# Eval("BranchId") %>'
                                CommandName="Update" ImageUrl="~/Images/edit.gif" CausesValidation="false" />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="删除">
                        <ItemTemplate>
                            <asp:ImageButton ID="ImageButton2" runat="server" CommandArgument='<%# Eval("BranchId") %>'
                                CommandName="Delete" ImageUrl="~/Images/delete.gif" CausesValidation="False" OnClientClick='return confirm("你确定要删除此信息吗？")' />
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
                <PagerSettings FirstPageText=" 首 页 " LastPageText=" 尾 页 " Mode="NextPreviousFirstLast"
                    NextPageText=" 下一页 " PreviousPageText=" 上一页 " />
                <PagerStyle BackColor="AliceBlue" />
            </asp:GridView>&nbsp;
        </div>
        </ContentTemplate>
            </asp:UpdatePanel>
    </form>
</body>
</html>
