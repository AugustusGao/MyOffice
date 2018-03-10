<%@ Page Language="C#" AutoEventWireup="true" CodeFile="SendMail.aspx.cs" Inherits="Message_MailBox_SendMail" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>已发送信箱</title>
    <link href="../../Css/Style.css" rel="stylesheet" type="text/css" />
    <script language="javascript" type="text/javascript">
	
	   function  ScanSendMessageDetail(messageId)
    {
    if(window.showModalDialog("ReceiveMailDetail.aspx?id="+messageId+"&type=2","","status=no;dialogWidth=700px;dialogHeight=600px;menu=no;resizeable=yes;scroll=yes;center=yes;edge=raise")=="OK")
    {			
	    document.location.href = "SendMail.aspx";			
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
    <div style="text-align: center"><b> 发 送 箱 </b></div>
        <hr color="gray" size="1" style="width: 90%; text-align: center" />
                <table cellSpacing="0" cellPadding="0" width="98%" align="center" border="0">
						<tr>
							<td align="left">&nbsp;&nbsp;&nbsp;&nbsp;
							<input type="checkbox" id="btnSelectAll" runat="server"  onclick="GetAllCheckBox(this);"/>全选</td>
							<td colSpan="4"></td>
						</tr>
						<tr>
							<td vAlign="top" align="right" colSpan="4" height="100%">
						<asp:GridView ID="gvPersonMessageInfo" Width="96%" runat="server" DataKeyNames="MessageId"  AutoGenerateColumns="False" CellPadding="2" BackColor="#e8f4ff" CssClass="gvCss" OnRowDataBound="gvPersonMessageInfo_RowDataBound" DataSourceID="obs">
						 <RowStyle HorizontalAlign="Center"  BackColor="WHite" />					
						  <HeaderStyle HorizontalAlign="Center" />
                         <Columns>  
                        <asp:TemplateField HeaderText="删除(√)">
                                <ItemTemplate>
                                    <asp:CheckBox ID="chkSelect" runat="server" />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="收件人" >
                                <ItemTemplate>
                                    <asp:Label ID="Label1" runat="server" Text='<%# CheckUser(Eval("MessageId")) %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="主题" SortExpression="Message">
                                <EditItemTemplate>
                                    <asp:TextBox ID="TextBox2" runat="server" Text='<%# Bind("Title") %>'></asp:TextBox>
                                </EditItemTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="Label2" runat="server" Text='<%# Eval("Title") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="发送时间" SortExpression="Message">
                                <EditItemTemplate>
                                    <asp:TextBox ID="TextBox3" runat="server" Text='<%# Bind("RecordTime") %>'></asp:TextBox>
                                </EditItemTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="Label3" runat="server" Text='<%# Bind("RecordTime","{0:yy-/MM-/dd HH:mm:ss}") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="紧急程度" SortExpression="Message">
                                <EditItemTemplate>
                                    <asp:TextBox ID="TextBox4" runat="server" Text='<%# Bind("Type") %>'></asp:TextBox>
                                </EditItemTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="Label4" runat="server" Text='<%# Eval("Type.MessageTypeName","***{0}***") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            
                          </Columns>
                          
                    
                      </asp:GridView>							
                                <asp:ObjectDataSource ID="obs" runat="server" SelectMethod="SearchMessageByCondition"
                                    TypeName="MyOffice.BLL.MessageManager">
                                    <SelectParameters>
                                        <asp:SessionParameter Name="user" SessionField="Login" Type="Object" />
                                        <asp:Parameter DefaultValue="1" Name="ifPublish" Type="Int32" />
                                        <asp:Parameter DefaultValue="0" Name="ifDelete" Type="Int32" />
                                        <asp:Parameter DefaultValue="0" Name="ifDeleteTo" Type="Int32" />
                                    </SelectParameters>
                                </asp:ObjectDataSource>
									
							</td>
						</tr>
						<tr>
							<td align="left" style="height: 23px">&nbsp;&nbsp;&nbsp;&nbsp;
							 <input id="btnDelete" onclick="return selectDelMessage();"  class="buttonCss" type="submit" value="删除选定项" runat="server" style="height: 24px" onserverclick="btnDelete_ServerClick"/>
							&nbsp;&nbsp;&nbsp;&nbsp;
							<input id="btnReturn" style="WIDTH: 88px; HEIGHT: 24px" class="buttonCss" type="submit" value="返回" name="Submit1" Runat="server" onserverclick="btnReturn_ServerClick"></td>
							<td colSpan="4" style="height: 23px"></td>
						</tr>
				</table>
    </div>
    </form>
</body>

</html>
