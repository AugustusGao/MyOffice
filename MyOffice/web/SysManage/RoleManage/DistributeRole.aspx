<%@ Page Language="C#" AutoEventWireup="true" CodeFile="DistributeRole.aspx.cs" Inherits="SysManage_RoleManage_DistributeRole" %>
<%@ Register Src="~/UserControl/RoleUserControl.ascx"TagName="RoleUserControl" TagPrefix="uc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>无标题页</title>
    <script language="javascript" type="text/javascript">
        function CheckAll(paramId){
         var items=document.getElementsByTagName("input");   
         for(i=0;i<items.length;i++){
            var e=items[i];
            var eId=e.id;//获得当前控件元素的Id
            var m=eId.indexOf('_chk');
            var n=paramId.indexOf('_chk');
            //判断控件类型是checkbox，父子节点Id是否匹配，以控制只选中该父节点对应的子节点
           if(eId.substring(0,m)==paramId.substring(0,n) && e.type=='checkbox'){
             e.checked=document.getElementById(paramId).checked;
           }
         }
        }
        function CheckOnly(paramId){     
         var items=document.getElementsByTagName("input");
        for(i=0;i<items.length;i++){
           var e=items[i];
            var eId=e.id;//获得当前控件元素的Id
           var m=eId.indexOf('_chk');
          var n=paramId.indexOf('_chk');
           //判断控件类型是checkbox，父子节点Id是否匹配，以控制只选中该父节点对应的子节点
           if(eId.substring(0,m)==paramId.substring(0,n) && e.type=='checkbox'){
          if(eId.indexOf('chkParentMenu')!=-1)document.getElementById(eId).checked=true;
          }
        }
        }
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
    
      <div style=" background-color:#DAF1FC">
        <div style="width: 99%; height: 30px;"><b>分配角色权限</b></div>
        <div style="width: 99%; text-align: left">
            &nbsp;权限分配<font color="red">(选定后保存) &nbsp; &nbsp; &nbsp;</font><strong>当前角色 -&gt;</strong>
            <asp:Label ID="lblCurrentRole" runat="server"  style="display: inline-block; font-weight: bold;
                width: 125px" Text="未审批用户"></asp:Label>
        </div>
        <div style="width: 99%; background-color: #b4e5fd">
          
        <asp:PlaceHolder ID="phRoleDistribute" runat="server">
        </asp:PlaceHolder>
        </div>
        &nbsp;<br />
        <div>
            &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
            &nbsp; &nbsp;&nbsp;
            <asp:Button ID="btnSave"  CssClass="buttonCss" style="width: 74px; cursor: hand; height: 20px"  runat="server" Text="提交" OnClick="btnSave_Click"  />
            &nbsp; &nbsp; &nbsp; &nbsp;
            <input id="btnRet" class="buttonCss" runat="server" onclick="location.href='RoleManage.aspx';"
                style="width: 74px; cursor: hand; height: 19px" type="button" value="返回"  />
         </div>
    </div>
    
     &nbsp;
    </div>
    </form>
</body>
</html>
