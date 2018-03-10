<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ChoseTimeUC.ascx.cs" Inherits="UserControl_ChoseTimeUC" %>
        <script language="javascript" src="../../My97DatePicker/WdatePicker.js"></script>
开始时间:<asp:TextBox ID="txtBeginTime" runat="server" CssClass="Wdate"
                                            Height="22px" onfocus="new WdatePicker(this,'%Y-%M-%D %h:%m:%s',true,'whyGreen')"
                                            Style="position: relative" Width="150px"></asp:TextBox><asp:RequiredFieldValidator
                                                ID="rfvBeginTime" runat="server" ControlToValidate="txtBeginTime" ErrorMessage="非空" Display="Dynamic">*</asp:RequiredFieldValidator>&nbsp;
                                        ----- 结束时间:<asp:TextBox ID="txtEndTime" runat="server" CssClass="Wdate" Height="22px"
                                            onfocus="new WdatePicker(this,'%Y-%M-%D %h:%m:%s',true,'whyGreen')" Style="position: relative"
                                            Width="150px"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="rfvEndTime" runat="server" ControlToValidate="txtEndTime"
                                            ErrorMessage="非空" Display="Dynamic">*</asp:RequiredFieldValidator>
                                        <asp:CompareValidator ID="cvDate" runat="server" ControlToCompare="txtBeginTime"
                                            ControlToValidate="txtEndTime" ErrorMessage="无效范围" Operator="GreaterThanEqual" Display="Dynamic"></asp:CompareValidator>
                                        <asp:RadioButtonList ID="rdlDate" runat="server" AutoPostBack="True"
                                            OnSelectedIndexChanged="rdlDate_SelectedIndexChanged" RepeatDirection="Horizontal"
                                            RepeatLayout="Flow" Width="161px">
                                            <asp:ListItem Value="thisDay">本日</asp:ListItem>
                                            <asp:ListItem Value="thisWeek">本周</asp:ListItem>
                                            <asp:ListItem Value="thisMonth">本月</asp:ListItem>
                                        </asp:RadioButtonList>
