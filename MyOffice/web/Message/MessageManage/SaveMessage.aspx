<%@ Page Language="C#" AutoEventWireup="true" EnableEventValidation="false" CodeFile="SaveMessage.aspx.cs" Inherits="Message_MessageManage_SaveMessage" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title>添加消息</title>
    <link href="~/Css/Style.css" rel="stylesheet" type="text/css" />
    <script language="javascript" src="../../My97DatePicker/WdatePicker.js"></script>
    <script type="text/javascript">
    function SetAllSelect(current){
          var id=document.getElementById("<%=hfCount.ClientID %>");
          if(id.value>0){
               for( i=0;i<id.value;i++){
               document.getElementById("<%=chklstSelectUser.ClientID %>_"+i).checked=current.checked;   
               }
           }
    } 
function IMG1_onclick() {

}

    </script>
</head>
<body>
    <form id="form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
         <fieldset id="fid1" runat="server" ><legend> 消息填写区 </legend>
    <div>
         <p></p>
        <table cellpadding="0" cellspacing="0" width="70%">
            <tr>
                <td >
   
           </td>
            </tr>
            <tr>
                <td >
                    <b>消息标题：</b>
                </td>
                <td >
                    <asp:TextBox ID="txtTitle" runat="server" CssClass="inputCss" Width="480px"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtTitle"
                        Display="Dynamic" ErrorMessage="请输入消息标题！" SetFocusOnError="True">*</asp:RequiredFieldValidator></td>
            </tr>
            <tr>
                <td >
                
                </td>
            </tr>
            <tr>
                <td valign="top" style="height: 66px;" >
                    消息类型：</td>
                <td valign="top" style="height: 66px">
                    <asp:DropDownList ID="ddlMessageType" runat="server" CssClass="ddlCss" Width="148px" DataSourceID="odsMessageType" DataTextField="MessageTypeName" DataValueField="MessageTypeId">
                    </asp:DropDownList><asp:ObjectDataSource ID="odsMessageType" runat="server" SelectMethod="GetAllMessageType"
                        TypeName="MyOffice.BLL.MessageTypeManager"></asp:ObjectDataSource>
                </td>
            </tr>
            <tr>
                <td height="8"  >
                </td>
            </tr>
            <tr>
                <td valign="top"  >
                    开始有效时间：</td>
                <td valign="top">
                    <asp:TextBox ID="txtBeginTime" onfocus="new WdatePicker(this,'%Y-%M-%D %h:%m:%s',true,'whyGreen')"  runat="server" CssClass="Wdate" TabIndex="1"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtBeginTime"
                        Display="Dynamic" ErrorMessage="请选择开始时间！" SetFocusOnError="True">*</asp:RequiredFieldValidator></td>
            </tr>
            <tr>
                <td height="8" >
              
                </td>
            </tr>
            <tr>
                <td valign="top"  >
                    结束有效时间：</td>
                <td valign="top" >
                    <asp:TextBox ID="txtEndTime" style="cursor:pointer" runat="server" CssClass="Wdate" onfocus="new WdatePicker(this,'%Y-%M-%D %h:%m:%s',true,'whyGreen')" TabIndex="2" ></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtEndTime"
                        Display="Dynamic" ErrorMessage="请选择结束时间！" SetFocusOnError="True">*</asp:RequiredFieldValidator>
                    <asp:CompareValidator ID="CompareValidator1" runat="server" ControlToCompare="txtBeginTime"
                        ControlToValidate="txtEndTime" Display="Dynamic" ErrorMessage="结束时间必须大于开始时间！"
                        SetFocusOnError="True" Operator="GreaterThanEqual"></asp:CompareValidator></td>
            </tr>
            <tr>
                <td colspan="2" height="8">
                </td>
            </tr>
            <tr>
                <td colspan="2" >
                    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                        <ContentTemplate>
                         <div id="upMessage">
                            <table>
                            <tr>
                                <td style="height: 16px" valign="top" width="16%">
                                    发送对象：</td>
                                <td align="left" style="height: 16px; width: 84%;" valign="top">
                                    &nbsp; &nbsp; <asp:RadioButtonList ID="rdoSendObj" runat="server" AutoPostBack="True" Height="20px"
                                        RepeatDirection="Horizontal" RepeatLayout="Flow" Width="200px" OnSelectedIndexChanged="rdoSendObj_SelectedIndexChanged">
                                        <asp:ListItem Value="0">所有人</asp:ListItem>
                                        <asp:ListItem Selected="True" Value="1">选择特定对象</asp:ListItem>
                                    </asp:RadioButtonList></td>
                            </tr>
                             <tr>
                                <td id="tb1" colspan="2">
                                    <asp:Panel ID="pnlSelect" runat="server"  Width="100%">
                                         <table bgcolor="#ece9d8"  cellpadding="0" cellspacing="0" width="100%">
                                            <tr>
                                                <td style="width: 103%">
                                                    <fieldset id="fild1" style="width: 105%; background-color:aliceblue;" title="gvCss">
                                                        <legend>
                                                            <img alt="" src="../../images/search2.gif" id="IMG1" onclick="return IMG1_onclick()" />筛选范围：</legend>
                                                        <table cellpadding="0" cellspacing="0" style="width: 107%; height: 169px;">
                                                            <tr>
                                                                <td colspan="2" style="width: 298px; height: 30px" valign="bottom">
                                                                    <asp:CheckBoxList ID="chklstSelect" runat="server" AutoPostBack="True" RepeatDirection="Horizontal" Width="311px" OnSelectedIndexChanged="chklstSelect_SelectedIndexChanged">
                                                                        <asp:ListItem Value="0">按机构</asp:ListItem>
                                                                        <asp:ListItem Value="1">按部门</asp:ListItem>
                                                                        <asp:ListItem Value="2">按员工号</asp:ListItem>
                                                                        <asp:ListItem Selected="True" Value="3">按姓名</asp:ListItem>
                                                                    </asp:CheckBoxList></td>
                                                            </tr>
                                                            <tr>
                                                                <td colspan="2" style="height: 73px; background-color: transparent;" width="100%">
                                                                    机构:<asp:DropDownList ID="ddlBranchs" runat="server" Width="135px" style="left: -4px; position: relative; top: 0px" BackColor="WhiteSmoke" CssClass="ddlCss" Enabled="False">
                                                                    </asp:DropDownList> 部门:<asp:DropDownList ID="ddlDeparts" runat="server" BackColor="WhiteSmoke" CssClass="ddlCss" Width="135px" Enabled="False">
                                                                    </asp:DropDownList>
                                                                    <cc1:CascadingDropDown ID="CascadingDropDownBranch" runat="server"
                                                                        TargetControlID="ddlBranchs"
                                                                        PromptText="请选一个机构"
                                                                        ServicePath="../../System/DataService.asmx"
                                                                        ServiceMethod="GetBranchs"    
                                                                        Category="BranchId" />
                                                                     <cc1:CascadingDropDown ID="CascadingDropDownDepart"  runat="server"
                                                                        TargetControlID="ddlDeparts"
                                                                        ParentControlID="ddlBranchs"
                                                                        PromptText="请选择一个部门"
                                                                        ServicePath="../../System/DataService.asmx"     
                                                                        ServiceMethod="GetDeparts"
                                                                        Category="DepartId"
                                                                        />
                                                                    
                                                                   员工号:<asp:TextBox ID="txtUserId" runat="server" CssClass="inputCss" Width="80px" Enabled="False"></asp:TextBox>
                                                                    姓名:<asp:TextBox ID="txtUserName" runat="server" CssClass="inputCss" Width="82px"></asp:TextBox>
                                                                    <br />
                                                                    <cc1:AutoCompleteExtender ID="AutoCompleteExtender1" runat="server"
                                                                     TargetControlID="txtUserName"
                                                                     ServicePath="../../System/DataService.asmx" 
                                                                     ServiceMethod="GetSearchNameByKeyWords"
                                                                     CompletionSetCount="10" 
                                                                     CompletionInterval="1000" 
                                                                     EnableCaching="true" 
                                                                     MinimumPrefixLength="1">
                                                                    </cc1:AutoCompleteExtender>
                                                                     <br />
                                                                    <asp:Button ID="btnsearch" runat="server" CssClass="buttonCss" Text="确定选择范围"  style="width: 94px; height: 25px; left: 303px; position: relative; top: 0px;" OnClick="btnsearch_Click" CausesValidation="False" />
                                                                    <fieldset id="fild2" runat="server" style="display: none; width: 100%; background-color: transparent;">
                                                                        <legend>请选择发送对象</legend>
                                                                        <table cellpadding="0" cellspacing="0" width="100%">
                                                                            <tr>
                                                                                <td align="left" valign="center" style="height: 81px; width: 21%;">
                                                                                  
                                                                                        <asp:CheckBox ID="chkSelectAll" runat="server"  Text="全选" AutoPostBack="True"  onclick="SetAllSelect(this)"/>
                                                                                 
                                                                                </td>
                                                                                <td valign="bottom" style="height: 81px; width: 502px;">
                                                                                    <asp:CheckBoxList ID="chklstSelectUser" runat="server" RepeatColumns="5" RepeatDirection="Horizontal" DataTextField="UserName" DataValueField="UserId" AutoPostBack="True">
                                                                                    </asp:CheckBoxList>
                                                                                    &nbsp;
                                                                                </td>
                                                                            </tr>
                                                                        </table>
                                                                        <asp:HiddenField ID="hfCount" runat="server" />
                                                                    </fieldset>
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </fieldset>
                                                </td>
                                            </tr>
                                           
                                        </table>
                                    </asp:Panel>
                                </td>
                              </tr>
                            </table>
                         </div>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </td>
            </tr>
            <tr>
                <td colspan="2" style="height: 4px">
                </td>
            </tr>
            <tr>
                <td valign="top" >
                    <b>消息内容：</b></td>
                <td>
                    <asp:TextBox ID="txtContent" runat="server" CssClass="inputCss" Height="176px" TextMode="MultiLine"
                        Width="500px" TabIndex="3"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txtContent"
                         ErrorMessage="消息内容不能为空！" SetFocusOnError="True">*</asp:RequiredFieldValidator></td>
            </tr>
            <tr>
                <td align="middle" colspan="2" style="height: 26px">
                    &nbsp;<asp:Button ID="btnSave" runat="server" CssClass="buttonCss" Height="26px"
                        Text="保存信息" Width="83px" OnClick="btnSave_Click" />
                    &nbsp; &nbsp; &nbsp; &nbsp;<input id="btnReturn" class="buttonCss" onclick="location.href='MessageManage.aspx';"
                        style="width: 83px; height: 26px" type="button" value="返  回" />
                    <asp:ValidationSummary ID="ValidationSummary1" runat="server" EnableTheming="True"
                        ShowSummary="False" ShowMessageBox="True" />
                          <br />
                </td>
            </tr>
        </table>
      
    </div>
 <br />

  </fieldset>
 
    </form>
</body>
</html>
