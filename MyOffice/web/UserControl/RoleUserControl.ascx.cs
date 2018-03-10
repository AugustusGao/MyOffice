using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using MyOffice.Models;
using MyOffice.BLL;
using System.Collections.Generic;

public partial class RoleUserControl : System.Web.UI.UserControl
{
    private int parentNodeId;//父节点ID
    private int roleId;//角色ID

    public int RoleId
    {
        get { return roleId; }
        set { roleId = value; }
    }
    public int ParentNodeId
    {
        get { return parentNodeId; }
        set { parentNodeId = value; }
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack) {
            DisplayRoleRighMenu();//显示角色权限
        }
    }
    protected void DisplayRoleRighMenu() {

        ////根据角色Id和父节点Id从RoleRight表中获得当前孩子菜单拥有的权限
        //IList<RoleRight> currentRoleChildNodes = RoleRightManager.GetParentNodesByRoleIdOrParentId(this.RoleId,this.ParentNodeId);
        //ArrayList arrRoleChildNodes = new ArrayList();
        //foreach (RoleRight roleRight in currentRoleChildNodes)
        //{
        //    arrRoleChildNodes.Add(roleRight.Node.NodeId.ToString());
        //}
        ////根据父节点Id得到对应的所有子节点信息
        //IList<SysFun> sysFuns = SysFunManager.GetSysFunByParentNodeIdAndUserId(this.ParentNodeId,null);
        ////将子节点循环追加到CheckBoxList控件中
        //foreach(SysFun sf in sysFuns){
        //    ListItem li = new ListItem();
        //    li.Value = sf.NodeId.ToString();
        //    li.Text = sf.DisplayName;
        //    if(arrRoleChildNodes.Contains(li.Value)) li.Selected = true;
        //    chklstChildMenu.Items.Add(li);
        //}

      
        IList<SysFun> childLists = SysFunManager.GetNodeByParentId(parentNodeId);
        IList<SysFun> currentChildLists = SysFunManager.GetNodeByParentIdAndRoleId(roleId, parentNodeId);
        ArrayList currentSysLists = new ArrayList();
        foreach (SysFun childSys in currentChildLists)
        {
            currentSysLists.Add(childSys.NodeId.ToString());
        }

        foreach (SysFun sys in childLists)
        {
            ListItem li = new ListItem(sys.DisplayName,sys.NodeId.ToString());
            if (currentSysLists.Contains(sys.NodeId.ToString()))
            {
                li.Selected = true;
            }
            this.chklstChildMenu.Items.Add(li);
        }

    }
}
