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

public partial class Templates_Left : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            BindTV();
            ShowNewMessageCount();
            User user = (User)Session["Login"];
            lblUserName.Text = user.UserName;
            lblRoleName.Text = user.Role.RoleName;
            lblDepartName.Text = user.DepartName;

        }
    }

    private void BindTV()
    {

        IList<SysFun> parentSysLists = SysFunManager.GetParentNodeByUID(((MyOffice.Models.User)Session["Login"]).UserId);
        foreach (SysFun parentSys in parentSysLists)
        {
            TreeNode parentNode = new TreeNode(parentSys.DisplayName);

            IList<SysFun> childSysLists = SysFunManager.GetNodeByParentIdAndUID("admin", parentSys.NodeId);
            foreach (SysFun childSys in childSysLists)
            {
                TreeNode childNode = new TreeNode(childSys.DisplayName, "", "../images/CloseTree.gif", "~/" + childSys.NodeURL, "mainFrame");
                parentNode.ChildNodes.Add(childNode);
            }
            this.tvMyOffice.Nodes.Add(parentNode);
        }
    }
    /// <summary>
    /// 显示新消息
    /// </summary>
    protected void ShowNewMessageCount()
    {
        int count = MessageManager.GetNewMailInfo((Session["Login"] as User));
        HtmlImage img = UpdatePanel1.FindControl("imgNewMessage") as HtmlImage;
        if (count > 0)
        {
            img.Visible = true;
            lblMessageCount.Text = count.ToString();
        }
        else
        {
            img.Visible = false;
            lblMessageCount.Text = "0";
        }
    }
    /// <summary>
    /// 时间控件
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void Timer1_Tick(object sender, EventArgs e)
    {
        ShowNewMessageCount();
    }

}
