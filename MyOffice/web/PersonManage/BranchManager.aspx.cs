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

public partial class PersonManage_BranchManager : System.Web.UI.Page
{
    /// <summary>
    /// 窗体加载事件
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            BindBranchInfo();
        }
    }
    /// <summary>
    /// 绑定部门显示信息
    /// </summary>
    private void BindBranchInfo()
    {
        this.gvBranchList.DataSource = BranchManager.GetAllBranch();
        this.gvBranchList.DataBind();
    }
    /// <summary>
    /// 添加按钮
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnAdd_Click(object sender, EventArgs e)
    {
        if (IsValid)
        {
            Branch branch = new Branch();
            branch.BranchName = this.txtBranchName.Text;
            branch.BranchShortName = this.txtBranchShortName.Text;
            branch=BranchManager.AddBranch(branch);
            
            BindBranchInfo();
            txtBranchShortName.Text = "";
            txtBranchName.Text = "";
        }
    }
    /// <summary>
    /// 修改、删除部门信息
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void gvBranchList_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName=="Delete")
        {
            try
            {
                int branchId = Convert.ToInt32(e.CommandArgument.ToString());
                BranchManager.DeleteBranchById(branchId);
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "key", "alert('请先删除外键中的数据！')", true);
            }
            BindBranchInfo();
        }
        if (e.CommandName == "Update")
        {
            
            int id = Convert.ToInt32(e.CommandArgument.ToString());
            ViewState["BranchId"]=id;
            this.btnAdd.Enabled = false;
            this.btnUpdate.Enabled = true;
            Branch branch = BranchManager.GetBranchById(UpdateBranchId);
            this.txtBranchName.Text = branch.BranchName;
            txtBranchShortName.Text = branch.BranchShortName;
        }
    }
   /// <summary>
   /// 删除触发事件
   /// </summary>
   /// <param name="sender"></param>
   /// <param name="e"></param>
    protected void gvBranchList_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {

    }
    /// <summary>
    /// 图片按钮“修改“的事件
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        if (IsValid)
        {
            Branch item = new Branch();
            item.BranchName = this.txtBranchName.Text;
            item.BranchShortName = this.txtBranchShortName.Text;
            item.BranchId = UpdateBranchId;
            int count=BranchManager.UpdateBranch(item);
            if (count > 0)
            {
                txtBranchName.Text = "";
                txtBranchShortName.Text = "";
                this.btnAdd.Enabled = true;
                this.btnUpdate.Enabled = false;
            }
            BindBranchInfo();
        }
    }
    /// <summary>
    /// 光棒效果
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void gvBranchList_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            e.Row.Attributes.Add("onmouseover", "currentcolor=this.style.backgroundColor;this.style.backgroundColor='#6699ff'");
            e.Row.Attributes.Add("onmouseout", "this.style.backgroundColor=currentcolor");
        }
    }
    /// <summary>
    /// 保存部门Id
    /// </summary>
    public int UpdateBranchId
    {
        get { return Convert.ToInt32(ViewState["BranchId"]); }
        set { ViewState["BranchId"] = value; }
    }
    /// <summary>
    /// 修改触发事件
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void gvBranchList_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {

    }
    /// <summary>
    /// 分页
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void gvBranchList_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        this.gvBranchList.PageIndex = e.NewPageIndex;
        BindBranchInfo();
    }
}
