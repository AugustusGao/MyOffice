<%@ Control Language="C#" AutoEventWireup="true" CodeFile="BranchDepartDdlUC.ascx.cs" Inherits="UserControl_BranchDepartDdlUC" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
机构: &nbsp;<asp:DropDownList ID="ddlBranchs" runat="server"
                                        BackColor="WhiteSmoke" CssClass="ddlCss" Enabled="False" Style="left: -4px; position: relative;
                                        top: 0px" Width="184px">
                                    </asp:DropDownList>&nbsp; 部门:&nbsp;<asp:DropDownList ID="ddlDeparts" runat="server"
                                        BackColor="WhiteSmoke" CssClass="ddlCss" Enabled="False" Width="184px">
                                    </asp:DropDownList>
                                    <cc1:cascadingdropdown id="CascadingDropDownBranch" runat="server" category="BranchId"
                                        prompttext="请选一个机构" servicemethod="GetBranchs" servicepath="../System/DataService.asmx"
                                        targetcontrolid="ddlBranchs"></cc1:cascadingdropdown>
                                    <cc1:cascadingdropdown id="CascadingDropDownDepart" runat="server" category="DepartId"
                                        parentcontrolid="ddlBranchs" prompttext="请选择一个部门" servicemethod="GetDeparts"
                                        servicepath="../System/DataService.asmx" targetcontrolid="ddlDeparts"></cc1:cascadingdropdown>
