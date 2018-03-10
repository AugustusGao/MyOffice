<%@ Page Language="C#" AutoEventWireup="true" CodeFile="PersonNote.aspx.cs" Inherits="ScheduleManage_PersonNote_PersonNote" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>个人便签</title>
    
    <link href="../../Css/Style.css" rel="stylesheet" type="text/css" />
    <style type="text/css">
    A:link {
	color: #000000; text-decoration: none;
	}
   A:visited {
	color: #000000;text-decoration: none;
	}
    </style>
</head>
<body>
    <form id="myform" runat="server">
   

        <div style="z-index: 101; left: 379px; width: 182px; position: absolute; top: 34px;
            height: 19px;text-align:center;">
          <b>我的便签</b>
        </div>
        <br />
        <br />
  
       <hr  size="1" style="width: 90%; text-align: center; color:gray;" />

        <div style="z-index: 102; left: 776px; width: 166px; position: absolute; top: 66px;
            height: 12px">
            <h4>新增便签<a href="AddNote.aspx"><asp:Image  ID="imgShow" ImageUrl="~/Images/write.gif" runat="server"/></a>
         
        </h4>
         
        </div>
        <br />
        <asp:DataList ID="dlMyNote" runat="server" RepeatColumns="3" RepeatDirection="Horizontal" Height="60px" Width="763px">
            <ItemTemplate>
              <div style="background-color:Silver; font-size:12px;">
                <img src="../../Images/add_Schedule.gif" alt="" />
                <a href="AddNote.aspx?noteId=<%#Eval("NoteId") %>"><asp:Label ID="NoteTitleLabel" runat="server" Text='<%# GetCut(Eval("NoteTitle"),14)%>'></asp:Label></a>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<br />
               </div>
            </ItemTemplate>
            <AlternatingItemTemplate>
            <div style="font-size:12px;">
             <img src="../../Images/add_Schedule.gif" alt="" />
                <a href="AddNote.aspx?noteId=<%#Eval("NoteId") %>"><asp:Label ID="NoteTitleLabel" runat="server" Text='<%# GetCut(Eval("NoteTitle"),14)%>'></asp:Label></a>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<br />
            </div>
            </AlternatingItemTemplate>
        </asp:DataList>&nbsp;
            
    </form>
</body>
</html>
