<%@ Page Language="C#" AutoEventWireup="true" CodeFile="MessageManage.aspx.cs" Inherits="Message_MessageManage_MessageManage" %>

<%@ Register Src="../../UserControl/ChoseTimeUC.ascx" TagName="ChoseTimeUC" TagPrefix="uc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html>
<head runat="server">
    <title>消息管理</title>
    <link href="~/Css/Style.css" rel="stylesheet" type="text/css" />

    <script language="javascript" type="text/javascript">
		     
		function  ScanMessageDetail(messageId)
		{
		 window.showModalDialog("MessageContent.aspx?messageid="+messageId,"",
		 "status=no;dialogWidth=550px;dialogHeight=600px;menu=no;resizeable=yes;scroll=yes;center=yes;edge=raise")
		}	
		function  ScanReceiveUsers(messageId)
		{
		    window.showModalDialog("SendUserList.aspx?messageid="+messageId,"",
		    "status=no;dialogWidth=535px;dialogHeight=300px;menu=no;resizeable=yes;scroll=yes;center=yes;edge=raise");
		}
    </script>

</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:ScriptManager ID="ScriptManager1" runat="server">
            </asp:ScriptManager>
            <div style="height: 30px; text-align: center">
                <b>消 息 管 理</b></div>
            <hr size="1" style="width: 90%; text-align: center; color: gray;" />
            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                <ContentTemplate>
                    <div style="margin-top: 0px; width: 100%; padding-top: 0px; height: 39px; text-align: left">
                        <b>请输入填写消息的时间</b>——<img style="border-top-width: 0px; border-left-width: 0px; border-bottom-width: 0px;
                            height: 39px; border-right-width: 0px" id="imgMessage" src="../../images/message.gif" /><br />
                        &nbsp;<uc1:ChoseTimeUC ID="ChoseTime" runat="server" />
                        <asp:ImageButton Style="border-top-width: 0px; border-left-width: 0px; border-bottom-width: 0px;
                            width: 100px; height: 21px; border-right-width: 0px" ID="imgBtnSearch" runat="server"
                            ImageUrl="../../Images/search.gif" OnClick="imgBtnSearch_Click"></asp:ImageButton>&nbsp;
                    </div>
                    <br />
                    <div style="width: 100%; height: 23px; background-color: white; text-align: right">
                        <img alt="" style="border-top-width: 0px; border-left-width: 0px; border-bottom-width: 0px;
                            border-right-width: 0px; text-decoration: underline; position: relative;" src="../../Images/write.gif"
                            type="image" />
                        <asp:LinkButton ID="lbAdd" runat="server" Width="85px" CausesValidation="False" Height="9px"
                            OnClick="lbAdd_Click" Style="left: -22px; position: relative; top: 0px; color:Gray"><b>添加新消息</b></asp:LinkButton>
                    </div>
                    <asp:GridView ID="gvMessage" runat="server" CssClass="gvCss" BackColor="aliceblue" Width="100%" AllowPaging="True"
                        AutoGenerateColumns="False" OnRowDataBound="gvMessage_RowDataBound" Height="100%"
                        OnPageIndexChanging="gvMessage_PageIndexChanging" PageSize="5" OnRowCommand="gvMessage_RowCommand"
                        OnRowDeleting="gvMessage_RowDeleting">
                        <RowStyle  BackColor="white"/>
                        <HeaderStyle />
                        <Columns>
                            <asp:BoundField DataField="Title" SortExpression="Title" HeaderText="消息标题"></asp:BoundField>
                            <asp:TemplateField SortExpression="Type" HeaderText="消息类型">
                                <EditItemTemplate>
                                    &nbsp;
                                </EditItemTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="Label1" runat="server" Text='<%# Eval("Type.MessageTypeName") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField SortExpression="Content" HeaderText="消息内容">
                                <ItemTemplate>
                                    &nbsp;<asp:HyperLink ID="hlMessage" runat="server" ForeColor="Blue" Text='<%# GetContent(Eval("Content")) %>'
                                        NavigateUrl='<%# Eval("MessageId","javascript:ScanMessageDetail({0})")%>'></asp:HyperLink>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField SortExpression="FromUser" HeaderText="创造者">
                                <ItemTemplate>
                                    <asp:Label ID="Label2" runat="server" Text='<%# Eval("FromUser.UserName") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="发送对象">
                                <ItemTemplate>
                                    &nbsp;<asp:HyperLink ID="hlSendObject" runat="server" ForeColor="Blue" Text=' <%# Eval("MessageId") %> '></asp:HyperLink>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField SortExpression="BeginTime" HeaderText="开始时间">
                                <EditItemTemplate>
                                    &nbsp;
                                </EditItemTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="Label3" runat="server" Text='<%# Bind("BeginTime","{0:yy-MM-dd HH:mm:ss}") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField SortExpression="EndTime" HeaderText="结束时间">
                                <EditItemTemplate>
                                    &nbsp;
                                </EditItemTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="Label4" runat="server" Text='<%# Bind("EndTime","{0:yy-MM-dd HH:mm:ss}") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField SortExpression="RecordTime" HeaderText="创建时间">
                                <EditItemTemplate>
                                    &nbsp;
                                </EditItemTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="Label5" runat="server" Text='<%# Bind("RecordTime","{0:yy-MM-dd }") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="修改">
                                <ItemTemplate>
                                    &nbsp;<asp:ImageButton Style="position: relative" ID="imgBtnUpdate" Enabled='<%# CheckShow(Eval("IfPublish")) %>'
                                        runat="server" ImageUrl="~/Images/edit.gif" CausesValidation="False" ImageAlign="Middle"
                                        CommandArgument='<%# Eval("MessageId") %>' CommandName="Update"></asp:ImageButton>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="删除">
                                <ItemTemplate>
                                    <asp:ImageButton ID="imgBtnDelete" runat="server" ImageUrl="~/Images/delete.gif"
                                        Width="14px" Height="15px" CommandName="Delete" CommandArgument='<%# Eval("MessageId") %>'
                                        OnClientClick='return confirm("你确定要删除此信息吗？")'></asp:ImageButton>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="发布">
                                <ItemTemplate>
                                    <asp:Button ID="btnSubmit" runat="server" Text='<%# CheckText(Eval("IfPublish")) %>'
                                        Enabled='<%# CheckShow(Eval("IfPublish")) %>' CssClass="buttonCss" CausesValidation="False"
                                        CommandArgument='<%# Eval("MessageId") %>' CommandName="release" OnClick="btnSubmit_Click">
                                    </asp:Button>&nbsp;
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                        <PagerSettings FirstPageText=" 首 页 " LastPageText=" 尾 页 " Mode="NextPreviousFirstLast"
                            NextPageText=" 下一页 " PreviousPageText=" 上一页 " />
                        <PagerStyle BackColor="AliceBlue" />
                    </asp:GridView>
                    </div>
                </ContentTemplate>
            </asp:UpdatePanel>
        </div>
    </form>
</body>
</html>
