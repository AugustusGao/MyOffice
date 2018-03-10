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
using MyOffice.BLL;

public partial class SysManage_UserManager : System.Web.UI.Page
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
            BindUserInfo();
        }
    }
    /// <summary>
    /// 显示用户信息
    /// </summary>
    private void BindUserInfo()
    {
        this.gvUserInfo.DataSource = UserManager.GetAllUsers();
        this.gvUserInfo.DataBind();
    }
    /// <summary>
    /// 添加按钮
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnAddUser_Click(object sender, EventArgs e)
    {
        Response.Redirect("CreateUser.aspx");
    }
    /// <summary>
    /// 光棒效果
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void gvUserInfo_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            e.Row.Attributes.Add("onmouseover", "currentcolor=this.style.backgroundColor;this.style.backgroundColor='#6699ff'");
            e.Row.Attributes.Add("onmouseout", "this.style.backgroundColor=currentcolor");
        }
    }
    /// <summary>
    /// 修改、删除
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void gvUserInfo_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "Update")
        {
            string userId = e.CommandArgument.ToString();
            Response.Redirect("CreateUser.aspx?UserId="+userId);
        }
        if (e.CommandName == "Delete")
        {
            try
            {
                string userId = e.CommandArgument.ToString();
                UserManager.DeleteUserById(userId);
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "key", "alert('请你先删除外键中的信息！')", true);
            }
            BindUserInfo();
        }
        if (e.CommandName == "Detail")
        {
            string id = e.CommandArgument.ToString();
            Response.Redirect("UserDetail.aspx?userId=" + id);
        }
    }
    /// <summary>
    /// 删除触发事件
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void gvUserInfo_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {

    }
    /// <summary>
    /// 分页
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void gvUserInfo_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        this.gvUserInfo.PageIndex = e.NewPageIndex;
        BindUserInfo();
    }
}
