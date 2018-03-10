<%@ Page Language="C#" AutoEventWireup="true" CodeFile="DraftMail.aspx.cs" Inherits="Message_MailBox_DraftMail" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>草稿箱</title>
    <link href="~/Css/Style.css" rel="stylesheet" type="text/css" />

    <script language="javascript" type="text/javascript">
    function  ScanSendMessageDetail(messageId)
    {
    if(window.showModalDialog("ReceiveMailDetail.aspx?id="+messageId+"&type=2","","status=no;dialogWidth=700px;dialogHeight=600px;menu=no;resizeable=yes;scroll=yes;center=yes;edge=raise")=="OK")
    {			
	    document.location.href = "DraftMail.aspx";			
    }
    }
    
    function GetAllCheckBox(parentItem)
    {
     var items = document.getElementsByTagName("input"); 
     
     for(i=0; i<items.length;i++)
     {
       
       if(parentItem.checked)
       {
         if(items[i].type=="checkbox")
          {           
                items[i].checked = true;
                items[i].parentElement.parentElement.style.background="#6699ff";
                parentItem.parentElement.parentElement.style.background="#ffffff";
             
          }
       }
      else
      {
         if(items[i].type=="checkbox")
          {
           items[i].checked = false;
           items[i].parentElement.parentElement.style.background="";
          }
       }
      }
    }	
		
		
		function selectDelMessage() 
		{
			var status = "false"
			var len=document.form1.elements.length;
			var i;
			for (i=0;i<len;i++){
				if (document.form1.elements[i].type=="checkbox"){
					if(document.form1.elements[i].checked){
						status = "true";	
						break;			
					}		
				}
			}
			
			if(status =="true"){
				if(confirm("您确定要删除这些消息吗？"))
					return true;
			}
			else
			{
				alert("你至少要选择一个要删除的内容");
			} 
		
			return false;
		}
    </script>

</head>
<body>
    <form id="form1" runat="server">
        <div>
            <div style="text-align: center">
                <b>草 稿 箱 </b>
            </div>
            <hr color="gray" size="1" style="width: 90%; text-align: center" />
            <table align="center" border="0" cellpadding="0" cellspacing="0" width="100%">
                <tr style="background: none transparent scroll repeat 0% 0%">
                    <td align="left" style="width: 642px; height: 19px">
                        &nbsp; &nbsp;
                        <input id="btnSelectAll" onclick="GetAllCheckBox(this);" type="checkbox" />全选
                    </td>
                    <td colspan="4" style="height: 19px">
                    </td>
                </tr>
                <tr>
                    <td align="right" colspan="4" height="100%" valign="top">
                        <div>
                            <asp:GridView ID="gvPersonMessageInfo" runat="server" CssClass="gvCss" BackColor="#e8f4ff"
                                AutoGenerateColumns="False" DataSourceID="ods" HorizontalAlign="Center" Width="100%"
                                OnRowDataBound="gvPersonMessageInfo_RowDataBound" DataKeyNames="MessageId">
                                <RowStyle HorizontalAlign="Center" BackColor="White" />
                                <HeaderStyle HorizontalAlign="Center" />
                                <Columns>
                                    <asp:TemplateField HeaderText="删除(√)">
                                        <ItemTemplate>
                                            <asp:CheckBox ID="chkSelect" runat="server" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="收件人">
                                        <ItemTemplate>
                                            <asp:Label ID="Label1" runat="server" Text='<%# CheckUser(Eval("MessageId")) %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="主题" SortExpression="Message">
                                        <ItemTemplate>
                                            <asp:Label ID="Label2" runat="server" Text='<%# Eval("Title") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="发送时间" SortExpression="Message">
                                        <ItemTemplate>
                                            <asp:Label ID="Label3" runat="server" Text='<%# Bind("RecordTime","{0:yy-/MM-/dd HH:mm:ss}") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="紧急程度" SortExpression="Message">
                                        <ItemTemplate>
                                            <asp:Label ID="Label4" runat="server" Text='<%# Eval("Type.MessageTypeName","***{0}***") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                </Columns>
                            </asp:GridView>
                            <asp:ObjectDataSource ID="ods" runat="server" SelectMethod="SearchMessageByCondition"
                                TypeName="MyOffice.BLL.MessageManager">
                                <SelectParameters>
                                    <asp:SessionParameter Name="user" SessionField="Login" Type="Object" />
                                    <asp:Parameter DefaultValue="0" Name="ifPublish" Type="Int32" />
                                    <asp:Parameter DefaultValue="0" Name="ifDelete" Type="Int32" />
                                    <asp:Parameter DefaultValue="-1" Name="ifDeleteTo" Type="Int32" />
                                </SelectParameters>
                            </asp:ObjectDataSource>
                        </div>
                    </td>
                </tr>
                <tr>
                    <td align="left" style="height: 23px; width: 642px;">
                        &nbsp; &nbsp;<br />
                        <input id="btnDelete" onclick="return selectDelMessage();" class="buttonCss" type="submit"
                            value="删除选定项" runat="server" style="height: 24px" onserverclick="btnDelete_ServerClick" />
                        &nbsp; &nbsp;
                        <input id="btnReturn" class="buttonCss" onclick="location.href='MailBox.aspx';" style="width: 88px;
                            height: 24px" type="button" value="返回" /></td>
                </tr>
            </table>
        </div>
    </form>
</body>
</html>
