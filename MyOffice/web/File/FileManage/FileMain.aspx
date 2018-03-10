<%@ Page Language="C#" AutoEventWireup="true" EnableEventValidation="false" CodeFile="FileMain.aspx.cs" Inherits="File_FileManage_FileMain" %>

<%@ Register Src="../../UserControl/FolderTree.ascx" TagName="FolderTree" TagPrefix="uc1" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>无标题页</title>
    <style type="text/css">
    .gvCss{
    margin-left:5px;
    }
   a {
   color: #000000;
	text-decoration: none;
}
a:visited {
	color: #000000;
	text-decoration: none;
}
    </style>

    <script type="text/javascript">
    function IEback(){
         history.go(-1);
    }
function imgDrive_onclick() {
var divChange=document.getElementById("divChange");
if(divChange.style.display=='none'){
divChange.style.display='block';
}
else{
divChange.style.display='none';
}

}

            function DisplayMove(rowIndex){
                var divMove=document.getElementById("divMove");
                if(divMove.style.display=='none'){
                     divMove.style.display='block';
                     divMove.style.left=400;
                    divMove.style.top=100+rowIndex*25;
                }
              else{
                    divMove.style.display='none';
                    
                }
                
               
              
            }

function fileSearch(){
parent.location.href='FileSearch.aspx';
}

    </script>

</head>
<body style="margin: 0px; padding: 0px; background-color: #a5cfe8">
    <form id="form1" runat="server">
        <div>
            <asp:ScriptManager ID="ScriptManager1" runat="server">
            </asp:ScriptManager>
            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                <ContentTemplate>
                    <div>
                        <table bgcolor="#a5cfe8" border="0" bordercolor="#cccccc" cellpadding="0" cellspacing="0"
                            class="" width="100%">
                            <tr>
                                <td nowrap="nowrap" width="1" style="height: 21px">
                                    <asp:ImageButton ID="imgbtnBack" align="absBottom" runat="server" onmouseout="this.src='../../images/file/fmback.gif';"
                                        onmouseover="this.src='../../images/file/fmback1.gif';" ImageUrl="../../images/file/fmback.gif"
                                        Style="border-top-width: 0px; border-left-width: 0px; border-bottom-width: 0px;
                                        width: 56px; height: 20px; border-right-width: 0px" title="后退一步" OnClientClick="IEback()" />
                                </td>
                                <td nowrap="nowrap" width="1" style="height: 21px">
                                    <asp:ImageButton ID="imgbtnUp" align="absBottom" runat="server" onmouseout="this.src='../../images/file/fmup.gif';"
                                        onmouseover="this.src='../../images/file/fmup1.gif';" ImageUrl="../../images/file/fmup.gif"
                                        Style="border-top-width: 0px; border-left-width: 0px; border-bottom-width: 0px;
                                        width: 31px; height: 20px; border-right-width: 0px" title="向上一级" OnClick="imgbtnUp_Click" /></td>
                                <td nowrap="nowrap" width="1" style="height: 21px">
                                     <input   type="image" ID="imgbtnSeach" runat="server"  onmouseout="this.src='../../images/file/fmseach.gif';"
                                        onmouseover="this.src='../../images/file/fmseach1.gif';"  src="../../images/file/fmseach.gif"
                                        Style="border-top-width: 0px; border-left-width: 0px; border-bottom-width: 0px;
                                        width: 58px; height: 20px; border-right-width: 0px" title="搜索文件或文件夹"   onclick="fileSearch()" /></td>
                                <td width="33" style="height: 21px">
                                    <asp:ImageButton ID="imgbtnFolderShow" runat="server" align="absBottom" ImageUrl="../../images/file/fmfoldershow1.gif"
                                        Style="border-top-width: 0px; border-left-width: 0px; border-bottom-width: 0px;
                                        width: 67px; height: 22px; border-right-width: 0px" onmouseout="this.src='../../images/file/fmfoldershow1.gif';"
                                        onmouseover="this.src='../../images/file/fmfoldershow2.gif';" /></td>
                                <td width="33" style="height: 21px">
                                    <asp:ImageButton ID="imgbtnNewFolder" runat="server" align="absBottom" onmouseout="this.src='../../images/file/fmnewfolder.gif';"
                                        onmouseover="this.src='../../images/file/fmnewfolder1.gif';" ImageUrl="../../images/file/fmnewfolder.gif"
                                        Style="border-top-width: 0px; border-left-width: 0px; border-bottom-width: 0px;
                                        width: 22px; height: 20px; border-right-width: 0px" title="新增文件夹" OnClick="imgbtnNewFolder_Click" /></td>
                                <td nowrap="nowrap" style="height: 21px; width: 1px;">
                                    <asp:ImageButton ID="imgbtnNewFile" align="absBottom" runat="server" onmouseout="this.src='../../images/file/fmnewfile.gif';"
                                        onmouseover="this.src='../../images/file/fmnewfile1.gif';" ImageUrl="../../images/file/fmnewfile.gif"
                                        Style="border-top-width: 0px; border-left-width: 0px; border-bottom-width: 0px;
                                        width: 22px; height: 20px; border-right-width: 0px" title="新增文件" OnClick="imgbtnNewFile_Click" /></td>
                                <td nowrap="nowrap" style="height: 21px">
                                </td>
                                <td nowrap="nowrap" style="width: 91%; height: 21px;">
                                </td>
                            </tr>
                        </table>
                        <div style="vertical-align: middle; margin-top: 15px;">
                            <span id="lblAddress" style="display: inline; width: 56px; height: 22px">&nbsp;地址：&nbsp;</span>
                            <asp:TextBox  ID="txtFolderPath" runat="server" ReadOnly="True" Width="275px"></asp:TextBox>
                             <span style="vertical-align: middle;">
                                <img id="imgDrive" src="../../images/file/img-folder.gif" style="border-top-width: 0px;
                                    border-left-width: 0px; border-bottom-width: 0px; border-right-width: 0px; vertical-align: middle;"
                                    onclick="return imgDrive_onclick()" />
                            </span>&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <span style="vertical-align: middle;">
                                <asp:ImageButton ID="imgbtnGoto" runat="server" align="absBottom" ImageUrl="../../images/file/fmgoto.gif"
                                    Style="border-top-width: 0px; border-left-width: 0px; border-bottom-width: 0px;
                                    width: 51px; height: 20px; border-right-width: 0px;" />
                            </span>
                            <br />
                             <span id="Span1" style="display: inline; width: 56px; height: 22px">&nbsp;移动：&nbsp;&nbsp;<asp:TextBox
                                 ID="txtMoveFileName" runat="server" Width="106px"></asp:TextBox>&nbsp;&nbsp;到：</span><asp:TextBox  ID="txtMove" runat="server" ReadOnly="True" Width="275px"></asp:TextBox>
                        <asp:Button ID="btnMove" runat="server" Enabled="False" Text="移动" OnClientClick="return confirm('确定要移动吗？')" OnClick="btnMove_Click" />
                           
                        </div>
                        <br />
                        <!-- 更改当前所在所需的树 -->
                        <div id="divChange" style="position: absolute; top: 63px; left: 390px; display: none;">
                            <uc1:FolderTree ID="FolderTree1" runat="server" />
                        </div>
                        <asp:GridView ID="gvFile" runat="server" AutoGenerateColumns="False" DataSourceID="odsFile"
                            Font-Size="Small" Width="680px" CssClass="gvCss" DataKeyNames="FileId" OnRowDataBound="gvFile_RowDataBound"
                            OnRowCommand="gvFile_RowCommand">
                            <Columns>
                                <asp:TemplateField HeaderText="图标">
                                    <ItemTemplate>
                                        <asp:Image ID="Image1" runat="server" ImageUrl='<%# Eval("FileType.FileTypeImage") %>' />
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="Center" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="名称" SortExpression="FileName">
                                    <EditItemTemplate>
                                        <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("FileName") %>'></asp:TextBox>
                                    </EditItemTemplate>
                                    <ItemTemplate>
                                        &nbsp;<asp:HyperLink ID="hlFileName" runat="server" Text='<%# Bind("FileName") %>'></asp:HyperLink>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="类型">
                                    <ItemTemplate>
                                        <asp:Label ID="Label1" runat="server" Text='<%# Eval("FileType.FileTypeName") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:BoundField DataField="Remark" HeaderText="备注" SortExpression="Remark" />
                                <asp:TemplateField HeaderText="所有者">
                                    <ItemTemplate>
                                        <asp:Label ID="Label2" runat="server" Text='<%# Eval("FileOwner.UserName") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:BoundField DataField="CreateDate" HeaderText="创建日期" SortExpression="CreateDate" />
                                <asp:TemplateField HeaderText="详细">
                                    <ItemTemplate>
                                        <asp:ImageButton ID="ImageButton1" runat="server" ImageUrl="~/Images/file/detail.gif"
                                            CommandArgument='<%# Eval("FileId") %>' CommandName="details" />
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="Center" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="移动">
                                    <ItemTemplate>
                                        <input   type="image" value="<%# gvFile.Rows.Count+1  %>" src="../../Images/file/fmmove.gif" 
                                            onclick="DisplayMove(this.value)" runat="server" id="imgbtnMove" onserverclick="imgbtnMove_ServerClick" />&nbsp;
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="Center" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="删除">
                                    <ItemTemplate>
                                        <asp:ImageButton  ID="ImageButton3" runat="server" ImageUrl="~/Images/file/delete.gif" CommandArgument='<%# Eval("FileId") %>' CommandName="del" />
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="Center" />
                                </asp:TemplateField>
                            </Columns>
                        </asp:GridView>
                        <br />
                        <asp:ObjectDataSource ID="odsFile" runat="server" SelectMethod="GetFileByParentId"
                            TypeName="MyOffice.BLL.FileInfoManager">
                            <SelectParameters>
                                <asp:QueryStringParameter Name="parentId" QueryStringField="fileId" Type="Int32" />
                            </SelectParameters>
                        </asp:ObjectDataSource>
                        &nbsp; &nbsp;&nbsp;
                    </div>
                     
                </ContentTemplate>
            </asp:UpdatePanel>
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <!--移动文件所需的树  -->
                <div id="divMove" style=" display:none; position: absolute;background-color: #6DC7FC;" runat="server">
                <div style="float: left; z-index:10; overflow-y: auto; overflow-x: auto; vertical-align: middle margin:0px;
                    padding: 0px; width: 204px; height: 295px; background-color: #6DC7FC">
                  <asp:TreeView ID="tvMove" runat="server"  Font-Size="Small" ShowLines="True" style="vertical-align: middle" OnSelectedNodeChanged="tvMove_SelectedNodeChanged">
</asp:TreeView>
                  
               </div>
            </div>
         
        </div>
    </form>
</body>
</html>
