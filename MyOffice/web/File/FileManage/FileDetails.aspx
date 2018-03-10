<%@ Page Language="C#" AutoEventWireup="true" CodeFile="FileDetails.aspx.cs" Inherits="File_FileManage_FileDetails" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" 
"http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>无标题页</title>
     <link href="~/Css/Style.css" rel="stylesheet" type="text/css" />
    <link href="~/App_Themes/MasterBg/master.css" type="text/css" rel="stylesheet" />    
<script type="text/javascript">
function   DisplayFileType(){
var fuFile=document.getElementById("fuFile").value;
if(fuFile==null  ||  fuFile==""){
document.getElementById("FileType").style.display='none';
}
else{
document.getElementById("FileType").style.display='block';
}
}
</script>
</head>
<body>
    <form id="form1" runat="server">
     <div style=" float:inherit;">
     
        <div style="width: 99%; ">
            <div style="float: left; background-image: url(/web/images/file/filepro.gif); width: 112px;color: #ffffff; height: 24px; background-repeat:no-repeat;">
               
                
                
                </div>
            
                <asp:ImageButton ID="imgbtnUp" align="absBottom" runat="server"  onmouseout="this.src='../../images/file/fmup.gif';"
                        onmouseover="this.src='../../images/file/fmup1.gif';"  ImageUrl="../../images/file/fmup.gif"
                        style="border-top-width: 0px; border-left-width: 0px; border-bottom-width: 0px;
                        width: 31px; height: 20px; border-right-width: 0px" title="向上一级" OnClick="imgbtnUp_Click" />
            </div>
      
                        <br />
        <div style="width: 99%;float:left;" >
            文 件 名 &nbsp;&nbsp; &nbsp; &nbsp;&nbsp;
            <asp:TextBox ID="txtFileName" runat="server" Width="250px" style="left: -3px; position: relative; top: 0px"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtFileName"
                ErrorMessage="请填写文件名！"></asp:RequiredFieldValidator><br />
            <br />
            位 &nbsp;&nbsp;&nbsp; &nbsp;置 &nbsp; &nbsp; &nbsp;&nbsp; &nbsp;&nbsp;
            <asp:Label ID="lblFilePath" runat="server" style="left: -3px; position: relative; top: 0px"></asp:Label><br />
            备 &nbsp;&nbsp;&nbsp; &nbsp;注 &nbsp; &nbsp; &nbsp;&nbsp; &nbsp;
            <asp:TextBox ID="txtRemark" runat="server" CssClass="inputCss" Style="left: 0px; position: relative; top: 16px;" TextMode="MultiLine" Height="45px" Width="262px"></asp:TextBox>&nbsp;
            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtRemark"
                ErrorMessage="请填写备注！"></asp:RequiredFieldValidator><br /><br />
            <hr  style="color:#c0c0c0; left: 0px; position: relative; top: 0px;"/>
            创建时间 &nbsp;&nbsp;&nbsp; &nbsp;&nbsp; &nbsp;<asp:Label ID="lblCreateTime" runat="server"></asp:Label>
            &nbsp; &nbsp; &nbsp; &nbsp; 所有者：
            <asp:Label ID="lblFileOwer" runat="server"></asp:Label><br />
            
            
            <div id="FileType" runat="server" style="width: 99%; padding-top: 11px; height: 22px; text-align: left">
            <table ><tr><td style="width: 106px">
                <asp:Label ID="Label1" runat="server" Text="文件图标>>"></asp:Label>
          </td>
          <td style="width: 147px" valign="middle">
              <span > 
                <asp:RadioButtonList ID="rboFileIcoList" runat="server" RepeatColumns="6" Width="344px">
                
                </asp:RadioButtonList>&nbsp;
                  <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="rboFileIcoList"
                      ErrorMessage="请选择文件类型！"></asp:RequiredFieldValidator></span></td></tr></table>
           </div>
           
           
            <hr  style="color:Blue; left: 0px; position: relative; top: -8px;" />       &nbsp; &nbsp; &nbsp;&nbsp;
            <asp:Label ID="lblMessage" runat="server" ForeColor="Turquoise">操作提示：请在文件名处单击右键，并选取“目标另存为”以下载文件！</asp:Label><br />
            <asp:FileUpload ID="fuFile" runat="server" onchange="javascript:DisplayFileType()"  />
            &nbsp;&nbsp;
            <asp:Literal ID="ltMessage" runat="server"></asp:Literal>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="fuFile"
                ErrorMessage="请选择上传文件！"></asp:RequiredFieldValidator><br />
            <br />
            <div>
            <asp:ImageButton ID="imgbtnSave" runat="server" Text="保存退出" ImageUrl="~/Images/file/saveexi.gif" style="left: 50px; position: relative; top: 0px" OnClick="imgbtnSave_Click"  />
                <asp:ImageButton ID="imgbtnUpdate" runat="server" Text="保存退出" ImageUrl="~/Images/file/saveexi.gif" style="left: 47px; position: relative; top: 0px" OnClick="imgbtnUpdate_Click" Enabled="False" Visible="False"  />
                &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&nbsp; &nbsp;<asp:ImageButton ID="btnExit" runat="server" Text="退出" ImageUrl="~/Images/file/sexit.gif" CausesValidation="False" style="left: 50px; position: relative; top: 0px" OnClick="btnExit_Click"   />
                <br />
            </div>
            <hr  style="color:Blue; left: 0px; position: relative; top: 0px;"/>          
            <br />
    </div>
</div>
    </form>
</body>
</html>
