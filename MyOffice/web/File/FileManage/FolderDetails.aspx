<%@ Page Language="C#" AutoEventWireup="true" CodeFile="FolderDetails.aspx.cs" Inherits="File_FileManage_FolderDetails" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>无标题页</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
     <div>
        <DIV style="WIDTH: 99%">
        <DIV style="FLOAT: left; BACKGROUND-IMAGE: url(../../images/file/fmfolder.gif); WIDTH: 112px; COLOR: #ffffff; BACKGROUND-REPEAT: no-repeat; HEIGHT: 24px"></DIV>
           <asp:ImageButton ID="imgbtnUp" align="absBottom" runat="server"  onmouseout="this.src='../../images/file/fmup.gif';"
                        onmouseover="this.src='../../images/file/fmup1.gif';"  ImageUrl="../../images/file/fmup.gif"
                        style="border-top-width: 0px; border-left-width: 0px; border-bottom-width: 0px;
                        width: 31px; height: 20px; border-right-width: 0px" title="向上一级" OnClick="imgbtnUp_Click"  />
             
          
           </DIV>
        
         <br /><br />
        <div style="float: left; width: 99%">
            <asp:Image ID="Image1" runat="server" ImageUrl="~/Images/file/folderbig.gif" Style="left: 3px;
                position: relative; top: 8px" />
            &nbsp;&nbsp;
            <asp:TextBox ID="txtFileName" runat="server" Width="327px" CssClass="inputCss"></asp:TextBox>
            <asp:RequiredFieldValidator ID="rfvFileName" runat="server" ControlToValidate="txtFileName"
                ErrorMessage="文件夹名称不能为空"></asp:RequiredFieldValidator>
                <br /><br />
            位置：<asp:Label ID="lblFilePath" runat="server"></asp:Label>
            <br /><br />
            备注：
            <asp:TextBox ID="txtRemark" runat="server" CssClass="inputCss" Style="left: -8px; position: relative; top: 0px;" TextMode="MultiLine" Height="45px" Width="325px"></asp:TextBox>
            <asp:RequiredFieldValidator ID="rfvRemark" runat="server" ControlToValidate="txtRemark"
                ErrorMessage="描述内容不能为空"></asp:RequiredFieldValidator>
            <br /><br />
            创建时间：<asp:Label ID="lblCreateTime" runat="server"></asp:Label>&nbsp; 所有者：<asp:Label ID="lblFileOwer" runat="server"></asp:Label><br />
            <div id="pnlOption" style="border-right: gray 1px solid; border-top: gray 1px solid;
                display: none; border-left: gray 1px solid; border-bottom: gray 1px solid">
               <br />
            </div>
            <br />
                  <hr style="left: 0px; color: blue; position: relative; top: -8px" />      
            <div id="button">
                <asp:ImageButton ID="imgbtnSave" runat="server" Text="保存退出" ImageUrl="~/Images/file/saveexi.gif" style="left: 50px; position: relative; top: 0px" OnClick="imgbtnSave_Click"   />
                <asp:ImageButton ID="imgbtnUpdate" runat="server" Text="保存退出" ImageUrl="~/Images/file/saveexi.gif" style="left: 47px; position: relative; top: 0px"  Enabled="False" Visible="False" OnClick="imgbtnUpdate_Click"  />
                &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&nbsp; &nbsp;<asp:ImageButton ID="btnExit" runat="server" Text="退出" ImageUrl="~/Images/file/sexit.gif" CausesValidation="False" style="left: 50px; position: relative; top: 0px" OnClick="btnExit_Click1"   />
                <br />
                   <br />   
            <br />
        </div>
    </div>
    </div>
    </form>
</body>
</html>
