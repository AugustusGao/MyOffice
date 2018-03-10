<%@ Page Language="C#" AutoEventWireup="true" CodeFile="RecycleBin.aspx.cs" Inherits="File_RecycleBin" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>无标题页</title>
     <link href="../App_Themes/MasterBg/master.css"type="text/css" />
    <link href="../Css/Style.css"type="text/css" rel="stylesheet" />    
   
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
    
     <div style="text-align: center">
            <b style="font-size: large">回 收 站</b></div>
        <hr color="gray" size="1" style="width: 90%; text-align: center" />
        <div align="center" style="width: 99%">
            <div>
                &nbsp;</div>
            <asp:GridView ID="gvFileDelete" runat="server" AllowPaging="True" AutoGenerateColumns="False" CssClass="gvCss" DataKeyNames="FileId" DataSourceID="odsFileInfo" Width="100%" style="font-size: medium" OnRowCommand="gvFileDelete_RowCommand" OnRowDataBound="gvFileDelete_RowDataBound" >
                <Columns>
                    <asp:BoundField DataField="FileName" HeaderText="文件名" SortExpression="FileName" />
                    <asp:BoundField DataField="FilePath" HeaderText="所在路径" SortExpression="FilePath" />
                    <asp:TemplateField HeaderText="类型" SortExpression="FileType">
                        <EditItemTemplate>
                            <asp:TextBox ID="TextBox1" runat="server" Text='<%# Eval("FileType") %>'></asp:TextBox>
                        </EditItemTemplate>
                        <ItemTemplate>
                            <asp:Label ID="Label1" runat="server" Text='<%# Eval("FileType.FileTypeName") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="操作者" SortExpression="FileOwner">
                        <EditItemTemplate>
                            <asp:TextBox ID="TextBox2" runat="server" Text='<%# Bind("FileOwner") %>'></asp:TextBox>
                        </EditItemTemplate>
                        <ItemTemplate>
                            <asp:Label ID="Label2" runat="server" Text='<%# Eval("FileOwner.UserName") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:BoundField DataField="CreateDate" HeaderText="删除日期" SortExpression="CreateDate" />
                    <asp:TemplateField HeaderText="还原">
                        <ItemTemplate>
                            <asp:ImageButton ID="imgbtnCancel" runat="server" ImageUrl="../images/file/upcancel.gif" CommandArgument='<%# Eval("FileId") %>' CommandName="revert"  />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="永久删除">
                        <ItemTemplate>
                            <asp:ImageButton ID="imgbtnDelete" runat="server" Height="15px" ImageUrl="~/Images/delete.gif"
                                Width="16px"    CommandArgument='<%# Eval("FileId") %>' CommandName="del" />
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
                <RowStyle Font-Size="Smaller" HorizontalAlign="Center" />
                <HeaderStyle Font-Bold="True" Font-Size="Smaller" HorizontalAlign="Center" />
            </asp:GridView>
            &nbsp;
            <asp:ObjectDataSource ID="odsFileInfo" runat="server" SelectMethod="GetAllDelFileInfo" TypeName="MyOffice.BLL.FileInfoManager"></asp:ObjectDataSource>
        </div>
    
    </div>
    </form>
</body>
</html>
