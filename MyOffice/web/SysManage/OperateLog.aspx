<%@ Page Language="C#" AutoEventWireup="true" CodeFile="OperateLog.aspx.cs" Inherits="SysManage_OperateLog" %>

<%@ Register Src="../UserControl/ChoseTimeUC.ascx" TagName="ChoseTimeUC" TagPrefix="uc1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>操作日志</title>
    <script type="text/javascript" src="../My97DatePicker/WdatePicker.js"></script>
    <link href="../Css/Style.css" rel="stylesheet" type="text/css" />
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
            操 作 日 志</div>
        <br />
   <hr  size="1" style="width: 90%; text-align: center; color:gray;" />
        <uc1:ChoseTimeUC ID="ChoseTimeUC1" runat="server" />
        <br />
        <br />
        <asp:ImageButton ID="imgbtnSearch" runat="server" ImageUrl="~/Images/search.gif"
            OnClick="imgbtnSearch_Click" />
        <br />
        <div style="z-index: 102; left: 569px; width: 100px; position: absolute; top: 135px;
            height: 24px">
            <asp:Button ID="btnDelete" runat="server" Text="删除选定项" OnClick="btnDelete_Click" OnClientClick="return confirm('确定删除吗？')" /></div>
        <br />
        <input id="cboLoginLog" type="checkbox" onclick="checkId(this)"/>
        <asp:Label ID="Label1" runat="server" Text="全选"></asp:Label><br />
        <asp:GridView ID="gvOperateLog" runat="server" AllowPaging="True" AutoGenerateColumns="False" CssClass="gvCss" OnPageIndexChanging="gvOperateLog_PageIndexChanging">
            <Columns>
                <asp:TemplateField HeaderText="选定(√)" SortExpression="OperateId">
                    <EditItemTemplate>
                        <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("OperateId") %>'></asp:TextBox>
                    </EditItemTemplate>
                    <ItemTemplate>
                         <div style="text-align:center;"><asp:CheckBox ID="cboName" runat="server" /></div>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="操作Id" SortExpression="OperateId" Visible="False">
                    <EditItemTemplate>
                        <asp:TextBox ID="TextBox7" runat="server" Text='<%# Bind("OperateId") %>'></asp:TextBox>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="Label1" runat="server" Text='<%# Bind("OperateId") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="序号" SortExpression="OperateId">
                    <EditItemTemplate>
                        <asp:TextBox ID="TextBox2" runat="server" Text='<%# Bind("OperateId") %>'></asp:TextBox>
                    </EditItemTemplate>
                    <ItemTemplate>
                           <div style="text-align:center;"> <%#  this.gvOperateLog.PageSize*this.gvOperateLog.PageIndex+this.gvOperateLog.Rows.Count+1 %></div>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="操作用户" SortExpression="User">
                    <EditItemTemplate>
                        <asp:TextBox ID="TextBox3" runat="server" Text='<%# Bind("User") %>'></asp:TextBox>
                    </EditItemTemplate>
                    <ItemTemplate>
                           <div style="text-align:center;"><asp:Label ID="Label2" runat="server" Text='<%# Eval("User.userName") %>'></asp:Label></div>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="事件" SortExpression="OperateName">
                    <EditItemTemplate>
                        <asp:TextBox ID="TextBox4" runat="server" Text='<%# Bind("OperateName") %>'></asp:TextBox>
                    </EditItemTemplate>
                    <ItemTemplate>
                           <div style="text-align:center;"><asp:Label ID="Label3" runat="server" Text='<%# Bind("OperateName") %>'></asp:Label></div>                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="操作描述" SortExpression="OperateDesc">
                    <EditItemTemplate>
                        <asp:TextBox ID="TextBox5" runat="server" Text='<%# Bind("OperateDesc") %>'></asp:TextBox>
                    </EditItemTemplate>
                    <ItemTemplate>
                           <div style="text-align:center;"><asp:Label ID="Label4" runat="server" Text='<%# Bind("OperateDesc") %>'></asp:Label></div>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="操作时间" SortExpression="OperateTime">
                    <EditItemTemplate>
                        <asp:TextBox ID="TextBox6" runat="server" Text='<%# Bind("OperateTime") %>'></asp:TextBox>
                    </EditItemTemplate>
                    <ItemTemplate>
                           <div style="text-align:center;"><asp:Label ID="Label5" runat="server" Text='<%# Bind("OperateTime") %>'></asp:Label></div>
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
        <asp:ObjectDataSource ID="odsOperateLog" runat="server" SelectMethod="GetAllOperateLogsByTime" TypeName="MyOffice.BLL.OperateLogManager">
            <SelectParameters>
                <asp:Parameter Name="beginTime" Type="String" />
                <asp:Parameter Name="endTime" Type="String" />
            </SelectParameters>
        </asp:ObjectDataSource>
    </form>
</body>
</html>
