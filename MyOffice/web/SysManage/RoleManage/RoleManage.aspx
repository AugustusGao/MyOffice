<%@ Page Language="C#" AutoEventWireup="true" CodeFile="RoleManage.aspx.cs" Inherits="SysManage_RoleManage_RoleManage" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>无标题页</title>
         <link href="../../Css/Style.css"type="text/css" />
    <link href="../../App_Themes/MasterBg/master.css"type="text/css" rel="stylesheet" />    
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
     <div style="width: 99%">
                <div style="float: left; background-image: url(../../images/headlistbutton.gif);
                    width: 112px; color: #ffffff; height: 24px">
                    &nbsp;角色功能设置</div>
            </div>
            <hr color="gray" size="1" style="width: 99%; text-align: center" />
            <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Always">
            <ContentTemplate>   
            <div style="width: 49%; text-align: left">
                角色名称：<br />
                <asp:TextBox ID="txtRoleName"  CssClass="inputCss"  runat="server" style="width: 240px" />
                <asp:RequiredFieldValidator ID="rfvRoleName" runat="server" ControlToValidate="txtRoleName"
                    ErrorMessage="角色名称不能为空"></asp:RequiredFieldValidator>&nbsp;<br />
                角色说明：<br />
                <asp:TextBox ID="txtRoleDesc" CssClass="inputCss" style="width: 240px; height: 45px" TextMode="MultiLine" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="rfvRoleDesc" runat="server" ControlToValidate="txtRoleDesc"
                    ErrorMessage="描述内容不能为空"></asp:RequiredFieldValidator><br />
                <asp:HiddenField ID="hfRoleId" runat="server" EnableViewState="False" />
                <br />
                <asp:Button ID="btnAdd" style="width: 54px; height: 22px"  CssClass="buttonCss" runat="server" Text="添 加"  />
                &nbsp;
                <asp:Button ID="btnSave" CssClass="buttonCss" Enabled="false" height="22px" 
                    style="height: 23px" Text="保存修改" width="54px" runat="server" />
            </div>
            &nbsp;
            <div style="width: 99%">
                <div>
                    &nbsp;</div>
                <asp:GridView ID="gvRoleInfo" runat="server" AutoGenerateColumns="False" CssClass="gvCss" DataSourceID="odsRole" Width="100%"  AllowPaging="True" DataKeyNames="RoleId" OnRowCommand="gvRoleInfo_RowCommand">
                    <Columns>
                        <asp:BoundField DataField="RoleName" HeaderText="角色名称" SortExpression="RoleName" />
                        <asp:BoundField DataField="RoleDesc" HeaderText="角色说明" SortExpression="RoleDesc" />
                        <asp:TemplateField HeaderText="修改">
                            <ItemTemplate>
                                <asp:ImageButton ID="imgBtnUpdate" runat="server" CommandArgument='<%# Eval("RoleId") %>'
                                    ImageUrl="~/Images/edit.gif" CausesValidation="False"  />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="删除">
                            <ItemTemplate>
                                <asp:ImageButton ID="imgBtnDelete" runat="server" CommandArgument='<%# Eval("RoleId") %>'   CommandName="Delete"                                  ImageUrl="~/Images/delete.gif" Height="15px" Width="16px" CausesValidation="False" />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="分配角色权限">
                            <ItemTemplate>
                                <asp:LinkButton ID="lbdisRole" runat="server" CausesValidation="False" CommandArgument='<%# Eval("RoleId") %>'  ForeColor="Blue" CommandName="DistributeRole">分配角色</asp:LinkButton>
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
                
                <br>
                <asp:ObjectDataSource ID="odsRole" runat="server" SelectMethod="GetAllRole" TypeName="MyOffice.BLL.RoleManager">
                </asp:ObjectDataSource>
            </div>
            </ContentTemplate>
            </asp:UpdatePanel>
    </div>
    </form>
</body>
</html>
