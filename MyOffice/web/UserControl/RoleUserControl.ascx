<%@ Control Language="C#" AutoEventWireup="true" CodeFile="RoleUserControl.ascx.cs" Inherits="RoleUserControl" %>
<asp:CheckBox id="chkParentMenu"  onclick="CheckAll(this.id)" runat="server" />
<asp:CheckBoxList id="chklstChildMenu" Font-Bold="true" onclick="CheckOnly(this.id)" runat="server" CellPadding="0" CellSpacing="0" RepeatDirection="Horizontal"></asp:CheckBoxList>
<hr  style="color:#66CCFF"/>
