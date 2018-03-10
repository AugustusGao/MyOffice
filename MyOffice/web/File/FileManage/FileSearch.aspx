<%@ Page Language="C#" AutoEventWireup="true" CodeFile="FileSearch.aspx.cs" Inherits="File_FileManage_FileSearch" %>

<%@ Register Src="../../UserControl/ChoseTimeUC.ascx" TagName="ChoseTimeUC" TagPrefix="uc1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>文件搜索</title>
    
<%--    <link href="../../Css/Style.css" rel="stylesheet" type="text/css" />--%>
    <script type="text/javascript" src="../../My97DatePicker/WdatePicker.js"></script>
</head>
<body>
    <form id="myform" runat="server">
         <div id="divMainContent" align="center" style="height: 100%">
            <div style="margin: 5px; text-align: left">
                <div style="text-align: center">
                    <b>文 件 搜 索</b></div>
                <hr size="1" style="width: 90%; text-align: center;color:Gray;" />
                <div align="center" style="width: 99%">       
                    <asp:ScriptManager ID="ScriptManager1" runat="server">
                    </asp:ScriptManager>
          <asp:UpdatePanel ID="UpdatePanel13" runat="server" UpdateMode="Always">
          <ContentTemplate>
<div style="FLOAT: left; WIDTH: 22%"><div style="BORDER-RIGHT: #6dc7fc 1px solid; BORDER-TOP: #6dc7fc 1px solid; BORDER-LEFT: #6dc7fc 1px solid; BORDER-BOTTOM: #6dc7fc 1px solid" id="ctl00_ContentPlaceHolder1_pnlSearch"><div style="WIDTH: 100%; PADDING-TOP: 11px; HEIGHT: 22px; TEXT-ALIGN: left"><img alt="" style="BORDER-TOP-WIDTH: 0px; BORDER-LEFT-WIDTH: 0px; BORDER-BOTTOM-WIDTH: 0px; BORDER-RIGHT-WIDTH: 0px" id="img1" src="../../images/search2.gif" />文件搜索 </div><div style="WIDTH: 100%; PADDING-TOP: 20px; HEIGHT: 40px; TEXT-ALIGN: left">要搜索的文件名：<br /><asp:TextBox id="txtFileName" runat="server"></asp:TextBox> </div><div style="WIDTH: 100%; PADDING-TOP: 20px; HEIGHT: 40px; TEXT-ALIGN: left">创建者姓名：<br /><asp:TextBox id="txtCreateUser" runat="server"></asp:TextBox> </div><div style="WIDTH: 100%; PADDING-TOP: 20px; HEIGHT: 40px; TEXT-ALIGN: left"><asp:ImageButton style="BORDER-TOP-WIDTH: 0px; BORDER-LEFT-WIDTH: 0px; BORDER-BOTTOM-WIDTH: 0px; WIDTH: 64px; HEIGHT: 20px; BORDER-RIGHT-WIDTH: 0px; TEXT-DECORATION: underline" id="imgbtnSearch" onclick="imgbtnSearch_Click" runat="server" ImageUrl="../../images/file/bseach.gif"></asp:ImageButton> <asp:ImageButton style="BORDER-TOP-WIDTH: 0px; BORDER-LEFT-WIDTH: 0px; BORDER-BOTTOM-WIDTH: 0px; WIDTH: 40px; COLOR: #000000; HEIGHT: 20px; BORDER-RIGHT-WIDTH: 0px" id="imgbtnExit" onclick="imgbtnExit_Click" runat="server" ImageUrl="../../images/file/exit.gif"></asp:ImageButton> </div><div style="WIDTH: 100%; PADDING-TOP: 11px; HEIGHT: 22px; TEXT-ALIGN: left"><a id="lnkbtnOption" href="javascript:showopt();"><span style="COLOR: #000000">搜索选项 &lt;&lt;</SPAN></A> </div><div style="BORDER-RIGHT: gray 1px solid; BORDER-TOP: gray 1px solid; DISPLAY: none; BORDER-LEFT: gray 1px solid; BORDER-BOTTOM: gray 1px solid" id="pnlOption"  runat="server">介于：<asp:TextBox style="POSITION: relative" id="txtBeginTime" onfocus="new WdatePicker(this,'%Y-%M-%D %h:%m:%s',true,'whyGreen')" runat="server" CssClass="Wdate" Width="150px"></asp:TextBox> <br /><br />---------<asp:TextBox style="POSITION: relative" id="txtEndTime" onfocus="new WdatePicker(this,'%Y-%M-%D %h:%m:%s',true,'whyGreen')" runat="server" CssClass="Wdate" Width="150px"></asp:TextBox> <asp:CompareValidator id="cvDate" runat="server" Operator="GreaterThanEqual" ErrorMessage="无效范围" ControlToValidate="txtEndTime" ControlToCompare="txtBeginTime"></asp:CompareValidator>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:RadioButtonList id="rdlDate" runat="server" Width="161px" RepeatLayout="Flow" RepeatDirection="Horizontal" OnSelectedIndexChanged="rdlDate_SelectedIndexChanged" AutoPostBack="True">
                                <asp:ListItem Value="thisDay">本日</asp:ListItem>
                                <asp:ListItem Value="thisWeek">本周</asp:ListItem>
                                <asp:ListItem Value="thisMonth">本月</asp:ListItem>
                                </asp:RadioButtonList> </div></div></div><div style="FLOAT: left; WIDTH: 77%" id="info" runat="server" visible="false"><div>
                                <asp:GridView id="gvFileSearch" runat="server" ForeColor="Transparent" CssClass="gvCss" Width="100%" OnRowDataBound="gvFileSearch_RowDataBound" BorderColor="White" AllowPaging="True" DataKeyNames="FileId" AutoGenerateColumns="False" OnPageIndexChanging="gvFileSearch_PageIndexChanging"><Columns>
<asp:TemplateField SortExpression="FileName" HeaderText="文件名称"><EditItemTemplate>
                                        <asp:TextBox ID="TextBox3" runat="server" Text='<%# Bind("FileName") %>'></asp:TextBox>
                                    
</EditItemTemplate>
<ItemTemplate>
                                        <asp:LinkButton ID="LinkButton1" runat="server" CommandArgument='<%# Eval("FileId") %>'
                                            OnClick="LinkButton1_Click" Text='<%# Eval("FileName") %>'></asp:LinkButton>
                                    
</ItemTemplate>
</asp:TemplateField>
<asp:BoundField DataField="FilePath" SortExpression="FilePath" HeaderText="所在文件夹"></asp:BoundField>
<asp:TemplateField SortExpression="FileType" HeaderText="类型"><EditItemTemplate>
                                        <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("FileType") %>'></asp:TextBox>
                                    
</EditItemTemplate>
<ItemTemplate>
                                        <asp:Image ID="Image1" runat="server" ImageUrl='<%# Eval("FileType.fileTypeImage") %>' />
                                    
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField SortExpression="FileOwner" HeaderText="所有者"><EditItemTemplate>
                                        <asp:TextBox ID="TextBox2" runat="server" Text='<%# Bind("FileOwner") %>'></asp:TextBox>
                                    
</EditItemTemplate>
<ItemTemplate>
                                        <asp:Label ID="Label2" runat="server" Text='<%# Eval("FileOwner.UserName") %>'></asp:Label>
                                    
</ItemTemplate>
</asp:TemplateField>
<asp:BoundField DataField="CreateDate" SortExpression="CreateDate" HeaderText="创建日期"></asp:BoundField>
</Columns>

<RowStyle Font-Size="Smaller"></RowStyle>

<HeaderStyle BackColor="DeepSkyBlue" Font-Size="Smaller" Font-Bold="True"></HeaderStyle>
</asp:GridView> <asp:ObjectDataSource id="odsSearch" runat="server" TypeName="MyOffice.BLL.FileManager" SelectMethod="SearchByCondition">
                                <SelectParameters>
                                    <asp:ControlParameter ControlID="txtFileName" Name="fileName" PropertyName="Text"
                                        Type="String" />
                                   
                                    <asp:ControlParameter ControlID="txtCreateUser" Name="fileOwner" PropertyName="Text"
                                        Type="String" />
                                    <asp:ControlParameter ControlID="txtBeginTime" Name="beginTime" PropertyName="Text"
                                        Type="String" />
                                    <asp:ControlParameter ControlID="txtEndTime" Name="endTime" PropertyName="Text" Type="String" />
                                </SelectParameters>
                            </asp:ObjectDataSource> </DIV></div>
</ContentTemplate>
          </asp:UpdatePanel>                   

            </div>
        </div>
        </div>          
      <script type="text/javascript" language="javascript">
            function showopt(){
                var div=document.getElementById("pnlOption");
                var link=document.getElementById("lnkbtnOption");
                if(div.style.display==""){
                    div.style.display="none";
                    link.innerText="搜索选项 <<";
                }
                else{
                    div.style.display="";
                    link.innerText="搜索选项 >>";
                }
            }
        </script>          
                   
    </form>
</body>
</html>
