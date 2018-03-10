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

public partial class UserControl_UserTree : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            BindTree();
        }
    }

    private void BindTree()
    {
        IList<Branch> branchLists = BranchManager.GetAllBranch();
        //循环添加机构
        foreach (Branch branch in branchLists)
        {
            TreeNode branchNode = new TreeNode(branch.BranchName, "", "~/images/menuclose.gif");

            IList<Depart> departLists = DepartInfoManager.GetDeparByBranchId(branch.BranchId);
            //循环添加部门
            foreach (Depart depart in departLists)
            {
                TreeNode departNode = new TreeNode(depart.DepartName, "", "~/images/CloseTree.gif");
                IList<User> userLists = UserManager.GetUseryDepartId(depart.DepartId);
                //循环添加用户
                foreach (User user in userLists)
                {
                    TreeNode userNode = new TreeNode(user.UserName, user.UserId, "~/images/person.gif");
                    departNode.ChildNodes.Add(userNode);
                }
                
                branchNode.ChildNodes.Add(departNode);
            }

            this.tvUser.Nodes.Add(branchNode);
        }
    }


   
}
