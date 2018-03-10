<%@ Page Language="C#" AutoEventWireup="true" CodeFile="LoginLog.aspx.cs" Inherits="SysManage_LoginLog" %>

<%@ Register Src="../UserControl/ChoseTimeUC.ascx" TagName="ChoseTimeUC" TagPrefix="uc1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>登陆日志</title>
    <link href="../Css/Style.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript" src="../My97DatePicker/WdatePicker.js"></script>
    <script type="text/javascript">
    function checkId(logId)
    {
       var items = document.getElementsByTagName("input");     
     for(i=0; i<items.length;i++)
     {       
       if(logId.checked)
       {
         if(items[i].type=="checkbox")
          {
           items[i].checked = true;
          }
       }
       else
       {
          if(items[i].type=="checkbox")
          {
           items[i].checked = false;
          }
       }
     }
  }
    </script>
</head>
<body>
    <form id="myform" runat="server">
        <div style="z-index: 101; left: 315px; width: 100px; position: absolute; top: 12px;
            height: 26px">
            登 陆 日 志</div>
        <br />
   <hr  size="1" style="width: 90%; text-align: center; color:gray;" />
        <uc1:ChoseTimeUC ID="ChoseTimeUC1" runat="server" />
        &nbsp;<br />
        <br />
        <asp:ImageButton ID="imgbtnSearch" runat="server" ImageUrl="~/Images/search.gif"
            OnClick="imgbtnSearch_Click" />&nbsp;
        <div style="z-index: 102; left: 557px; width: 120px; position: absolute; top: 129px;
            height: 26px">
        <asp:Button ID="btnDelete" runat="server" Text="删除选定项" OnClick="btnDelete_Click" CausesValidation="False" OnClientClick="return confirm('确定删除吗？')" /></div>
        <br />
        <br />
        <input id="cboOperateLog" type="checkbox" onclick="checkId(this)"/>
        <asp:Label ID="Label2" runat="server" Text="全选"></asp:Label><br />
        <asp:GridView ID="gvLoginLog" runat="server" AllowPaging="True" AutoGenerateColumns="False" CssClass="gvCss" OnPageIndexChanging="gvLoginLog_PageIndexChanging" PageSize="5">
            <Columns>
                <asp:TemplateField HeaderText="选定(√)">
                    <EditItemTemplate>
                        <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
                    </EditItemTemplate>
                    <ItemTemplate>
                       <div style="text-align:center;">
                        <asp:Label ID="Label2" runat="server"></asp:Label>
                        <asp:CheckBox ID="cboName" runat="server"  />
                        </div>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="用户Id" SortExpression="LoginId" Visible="False">
                    <EditItemTemplate>
                        <asp:TextBox ID="TextBox8" runat="server" Text='<%# Bind("LoginId") %>'></asp:TextBox>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="Label8" runat="server" Text='<%# Bind("LoginId") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="序号" SortExpression="LoginId">
                    <EditItemTemplate>
                        <asp:TextBox ID="TextBox9" runat="server" Text='<%# Bind("LoginId") %>'></asp:TextBox>
                    </EditItemTemplate>
                    <ItemTemplate>
                    <div style="text-align:center;">
                        <%#  this.gvLoginLog.PageSize*this.gvLoginLog.PageIndex+this.gvLoginLog.Rows.Count+1 %>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="登陆用户" SortExpression="LoginId">
                    <EditItemTemplate>
                        <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("LoginId") %>'></asp:TextBox>
                    </EditItemTemplate>
                    <ItemTemplate>
                    <div style="text-align:center;">
                        <asp:Label ID="Label1" runat="server" Text='<%# Eval("user.UserName") %>'></asp:Label></div>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="登陆时间" SortExpression="LoginTime">
                    <EditItemTemplate>
                        <asp:TextBox ID="TextBox3" runat="server" Text='<%# Bind("LoginTime") %>'></asp:TextBox>
                    </EditItemTemplate>
                    <ItemTemplate>
                       <div style="text-align:center;">
                        <asp:Label ID="Label3" runat="server" Text='<%# Bind("LoginTime") %>'></asp:Label></div>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="退出时间" SortExpression="ExitTime">
                    <EditItemTemplate>
                        <asp:TextBox ID="TextBox4" runat="server" Text='<%# Bind("ExitTime") %>'></asp:TextBox>
                    </EditItemTemplate>
                    <ItemTemplate>
                       <div style="text-align:center;">
                        <asp:Label ID="Label4" runat="server" Text='<%# Bind("ExitTime") %>'></asp:Label></div>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Ip地址" SortExpression="LoginUserIp">
                    <EditItemTemplate>
                        <asp:TextBox ID="TextBox5" runat="server" Text='<%# Bind("LoginUserIp") %>'></asp:TextBox>
                    </EditItemTemplate>
                    <ItemTemplate>
                       <div style="text-align:center;">
                        <asp:Label ID="Label5" runat="server" Text='<%# Bind("LoginUserIp") %>'></asp:Label></div>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="是否成功" SortExpression="IfSuccess">
                    <EditItemTemplate>
                        <asp:TextBox ID="TextBox6" runat="server" Text='<%# Bind("IfSuccess") %>'></asp:TextBox>
                    </EditItemTemplate>
                    <ItemTemplate>
                       <div style="text-align:center;">
                        <asp:Label ID="Label6" runat="server" Text='<%# Bind("IfSuccess") %>'></asp:Label></div>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="登陆备注" SortExpression="LoginDesc">
                    <EditItemTemplate>
                        <asp:TextBox ID="TextBox7" runat="server" Text='<%# Bind("LoginDesc") %>'></asp:TextBox>
                    </EditItemTemplate>
                    <ItemTemplate>
                       <div style="text-align:center;">
                        <asp:Label ID="Label7" runat="server" Text='<%# Bind("LoginDesc") %>'></asp:Label></div>
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
        <asp:ObjectDataSource ID="odsLoginLog" runat="server" SelectMethod="GetAllLoginLogsByTime" TypeName="MyOffice.BLL.LoginLogManager">
            <SelectParameters>
                <asp:Parameter Name="beginTime" Type="String" />
                <asp:Parameter Name="endTime" Type="String" />
            </SelectParameters>
        </asp:ObjectDataSource>
   
    </form>
</body>
</html>
