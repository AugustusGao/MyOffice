<%@ Page Language="C#" AutoEventWireup="true" CodeFile="DepartSchedule.aspx.cs" EnableEventValidation="false"  Inherits="ScheduleManage_DepartSchedule_DepartSchedule" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<%@ Register Src="../../UserControl/BranchDepartDdlUC.ascx" TagName="BranchDepartDdlUC"
    TagPrefix="uc1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>部门日程</title>
   
   <link href="../../Css/Style.css" rel="stylesheet" type="text/css" />
      <script type="text/javascript" src="../../My97DatePicker/WdatePicker.js"></script>
      <style type="text/css">
      .headStyle{color:red;}
      .hs{color:black;}
      .bg{background-color:#6DC7FC}
<%--       .input
    {
     border-right:DodgerBlue 1px solid; 
     border-top: DodgerBlue 1px solid; 
     border-left:DodgerBlue 1px solid; 
     border-bottom:DodgerBlue 1px solid;
     height:18px; 
     color:#000000; 
     padding-left: 2px; 
     padding-right: 2px;
    }--%>
      </style>
</head>
<body>
    <form id="myform" runat="server">
          <div style="z-index: 101; left: 339px; width: 182px; position: absolute; top: 17px;
            height: 19px;text-align:center;">
          <b>部 门 日 程</b>
        </div>
        <br />
    <hr  size="1" style="width: 90%; text-align: center; color:gray;" />
        <br />
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
        <div style="width:738px;">
        <uc1:BranchDepartDdlUC ID="BranchDepartDdlUC1" runat="server"  />
            &nbsp;
        <asp:Label ID="Label1" runat="server" Text="姓名：" ></asp:Label>
        <asp:TextBox ID="txtName" runat="server" CssClass="input"></asp:TextBox>&nbsp;<cc1:AutoCompleteExtender
            ID="AutoCompleteExtender1" runat="server"
             TargetControlID="txtName"
              CompletionSetCount="3"
               EnableCaching="true"
                MinimumPrefixLength="1"
                 ServiceMethod="GetSearchNameByKeyWords"
                  ServicePath="../../System/DataService.asmx">
        </cc1:AutoCompleteExtender>
            <br />
        
            日期:
        <asp:TextBox ID="txtTime" runat="server" CssClass="Wdate" onFocus="new WdatePicker(this,'%Y-%M-%D',true,'whyGreen')" Width="173px"></asp:TextBox>
            &nbsp; &nbsp;
        <asp:ImageButton ID="imgbtnSearch" runat="server" ImageUrl="~/Images/search.gif"
            OnClick="imgbtnSearch_Click" /><br />
            <br />
         </div>
         <div style="text-align:center; width:100%;height:30px;"><asp:Label ID="lblTime" runat="server" CssClass="bg" Width="100%" Height="30px"></asp:Label></div>
         <asp:GridView ID="gvSchedules" runat="server" AutoGenerateColumns="False" OnRowDataBound="gvSchedules_RowDataBound" Width="100%"  CssClass="gvCss" HorizontalAlign="Center">
            <Columns>
             <asp:TemplateField HeaderText="人员姓名">
                <HeaderTemplate>人员姓名</HeaderTemplate>
                    <ItemTemplate>
                        <div style="text-align:center;"><asp:Label ID="lblName" runat="server"  Text='<%#Eval("CreateUser.UserName") %>'></asp:Label></div>
                    </ItemTemplate>
                 <HeaderStyle CssClass="hs" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText='星期天'>
                <HeaderTemplate>星期天 <asp:Label ID="Label0" runat="server" CssClass="hs"></asp:Label></HeaderTemplate>
                   
                   
                    <ItemTemplate>
                      <div style="text-align:center;"><asp:Label ID="Label0" runat="server"></asp:Label></div>
                    </ItemTemplate>
                    <HeaderStyle CssClass="headStyle" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="星期一">
                <HeaderTemplate>星期一 <asp:Label ID="Label1" runat="server"></asp:Label></HeaderTemplate>
                   
                    <ItemTemplate>
                      <div style="text-align:center;"><asp:Label ID="Label1" runat="server"></asp:Label></div>
                    </ItemTemplate>
                    <HeaderStyle CssClass="hs" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="星期二">
                <HeaderTemplate>星期二 <asp:Label ID="Label2" runat="server"></asp:Label></HeaderTemplate>
                    
                    <ItemTemplate>
                        <div style="text-align:center;"><asp:Label ID="Label2" runat="server"></asp:Label></div>
                    </ItemTemplate>
                    <HeaderStyle CssClass="hs" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="星期三">
                <HeaderTemplate>星期三 <asp:Label ID="Label3" runat="server"></asp:Label></HeaderTemplate>
                   
                    <ItemTemplate>
                       <div style="text-align:center;"><asp:Label ID="Label3" runat="server"></asp:Label></div>
                    </ItemTemplate>
                    <HeaderStyle CssClass="hs" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="星期四">
                <HeaderTemplate>星期四 <asp:Label ID="Label4" runat="server"></asp:Label></HeaderTemplate>
                   
                    <ItemTemplate>
                        <div style="text-align:center;"><asp:Label ID="Label4" runat="server"></asp:Label></div>
                    </ItemTemplate>
                    <HeaderStyle CssClass="hs" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="星期五">
                <HeaderTemplate>星期五 <asp:Label ID="Label5" runat="server"></asp:Label></HeaderTemplate>
                   
                    <ItemTemplate>
                        <div style="text-align:center;"><asp:Label ID="Label5" runat="server"></asp:Label></div>
                    </ItemTemplate>
                    <HeaderStyle CssClass="hs" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="星期六">
                <HeaderTemplate>星期六 <asp:Label ID="Label6" runat="server"></asp:Label></HeaderTemplate>
                   
                    <ItemTemplate>
                        <div style="text-align:center;"><asp:Label ID="Label6" runat="server" CssClass="hs"></asp:Label></div>
                    </ItemTemplate>
                    <HeaderStyle CssClass="headStyle" />
                </asp:TemplateField>
            </Columns>
             <RowStyle CssClass="gvCss" />
        </asp:GridView>
        </ContentTemplate>
        </asp:UpdatePanel>
       
    </form>
</body>
</html>
