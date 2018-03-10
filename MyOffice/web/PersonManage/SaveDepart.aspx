<%@ Page Language="C#" AutoEventWireup="true" CodeFile="SaveDepart.aspx.cs" Inherits="PersonManage_SaveDepart" %>

<%@ Register Src="../UserControl/UserTree.ascx" TagName="UserTree" TagPrefix="uc1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title>保存部门信息</title>
     <link href="~/Css/Style.css" rel="stylesheet" type="text/css" />
    <link href="~/App_Themes/MasterBg/master.css" type="text/css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
   <div style="text-align: center">
        <b>
            <div style="text-align: center">
                <b>
                    <div style="text-align: center">
                        <b> 保 存 部 门 信 息</b></div>
                    <hr color="gray" size="1" style="width: 90%; text-align: center" />
                    <br />
                    <div style="float: left; width: 35%; text-align: left">
                    </div>
                    <div style="float: left; width: 39%; text-align: left">
        部门名称：<br />
                        <asp:TextBox ID="txtDepartName" runat="server" CssClass="inputCss" Width="240px"></asp:TextBox><br />
                        &nbsp;<asp:RequiredFieldValidator ID="rfvDepartName"
                                runat="server" ControlToValidate="txtDepartName" ErrorMessage="部门名称不能为空！" Display="Dynamic"></asp:RequiredFieldValidator><br />
        所属机构：<br />
                        <asp:DropDownList ID="ddlBranch" runat="server" CssClass="ddlCss" style="WIDTH: 231px; POSITION: relative; left: 3px; top: -2px;" DataSourceID="odsBranch"
                            DataTextField="BranchName" DataValueField="BranchId">
                        </asp:DropDownList><asp:ObjectDataSource ID="odsBranch" runat="server" SelectMethod="GetAllBranch"
                            TypeName="MyOffice.BLL.BranchManager"></asp:ObjectDataSource>
                        <br />
        部门负责人：<br />
                        <asp:TextBox ID="txtPricipalUser" runat="server" CssClass="inputCss" Width="126px" ReadOnly="True"></asp:TextBox>
                        <img alt="请点击选择用户" border="0" name="Image1" onclick="tree.style.display='';" src="../images/admin2.gif"
                            style="cursor: hand" />
                        <asp:RequiredFieldValidator ID="rfvPricipalUser" runat="server" ControlToValidate="txtPricipalUser"
                            ErrorMessage="部门负责人不能为空！" Display="Dynamic"></asp:RequiredFieldValidator><br />
                        <asp:HiddenField ID="hfUserId" runat="server" />
                        <br />
        联系电话：<br />
                        <asp:TextBox ID="txtConnectTelNo" runat="server" CssClass="inputCss" Width="240px"></asp:TextBox>
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="txtConnectTelNo"
                            Display="Dynamic" ErrorMessage="联系电话必须为数字！" ValidationExpression="^(\(\d{3,4}\)|\d{3,4}-)?\d{7,8}$"></asp:RegularExpressionValidator><br />
        移动电话：<br />
                        <asp:TextBox ID="txtMobileTelNo" runat="server" CssClass="inputCss" Width="240px"></asp:TextBox>
                        <br />
        传真：<br />
        <asp:TextBox ID="txtFaxes" runat="server" CssClass="inputCss" Width="240px"></asp:TextBox>
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" ControlToValidate="txtConnectTelNo"
                            Display="Dynamic" ErrorMessage="传真必须是数字！" ValidationExpression="^\d+$"></asp:RegularExpressionValidator><br />
                        <br />
                        &nbsp; &nbsp;
                        <asp:Button ID="btnSave" runat="server" CssClass="buttonCss" Height="22px" style="height: 23px"   Text="保存部门信息" OnClick="btnSave_Click"/>
                        &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&nbsp;
                        <input class="buttonCss" name="btnReturn"
                            onclick="location.href='DepartManage.aspx';" style="left: 0px; width: 98px; position: relative;
                            height: 23px" type="button" value="返回" /><br />
                        <br />
                        <br />
                    </div>  
                    <div id="divUsers" style="float: left; visibility: visible;overflow: auto; width: 25%;   text-align: left">
                        <div id="tree" style="display:none;border-left-color: transparent; border-bottom-color: transparent;clip: rect(0px 0px 0px 0px); border-top-color: transparent; background-color: #66ccff; border-right-&nbsp; " >
                            <uc1:UserTree ID="UserTree1" runat="server" />
                            &nbsp;</div>
                    </div>
                </b>
            </div>
        </b>
        </div> 
    </form>
</body>
</html>
