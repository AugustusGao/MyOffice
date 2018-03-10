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
using System.Collections.Generic;
using MyOffice.BLL;
using System.Drawing;

public partial class SysManage_MenuAdjust : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            BindTV();


        }
    }



    private void BindTV()
    {
        this.tvMyOffice.Nodes.Clear();
        CreateTreeNode(this.tvMyOffice.Nodes, 0);
        this.tvMyOffice.DataBind();
    }

    /// <summary>
    /// 递归添加节点
    /// </summary>
    /// <param name="treeNodeCollection">父级节点</param>
    /// <param name="nodeId">SysFun表中的父ID</param>
    private void CreateTreeNode(TreeNodeCollection treeNodeCollection, int nodeId)
    {
        IList<SysFun> lists = SysFunManager.GetNodeByParentId(nodeId);
        foreach (SysFun sys in lists)
        {
            TreeNode tn = null;
            if (nodeId == 0)
            {
                tn = new TreeNode(sys.DisplayName, sys.NodeId.ToString());
            }
            else
            {
                tn = new TreeNode(sys.DisplayName, sys.NodeId.ToString(), "~/images/CloseTree.gif");
            }
            if (tn.Value.Equals( ViewState["nodeId"] ))
            {
                tn.Selected = true;
                
            }
            treeNodeCollection.Add(tn);

            CreateTreeNode(tn.ChildNodes, sys.NodeId);


        }




    }







    protected void tvMyOffice_SelectedNodeChanged(object sender, EventArgs e)
    {

        this.tvMyOffice.SelectedNodeStyle.CssClass = "td";
        ViewState["nodeId"] = this.tvMyOffice.SelectedValue.ToString();
    }

    //上移
    protected void btnUp_Click(object sender, EventArgs e)
    {
        if (ViewState["nodeId"] != null && !"".Equals(ViewState["nodeId"]))
        {
            bool flag = SysFunManager.UpNode(Convert.ToInt32(ViewState["nodeId"]));
            BindTV();
        }
    }
    //下移
    protected void btnDown_Click(object sender, EventArgs e)
    {
        if (ViewState["nodeId"] != null && !"".Equals(ViewState["nodeId"]))
        {
           bool flag= SysFunManager.DownNode(Convert.ToInt32(ViewState["nodeId"]));
           BindTV();
        }
    }
}
