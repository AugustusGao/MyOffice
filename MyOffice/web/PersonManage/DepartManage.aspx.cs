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
using MyOffice.DAL;

public partial class PersonManage_DepartManage : System.Web.UI.Page
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
            BindDepartInfo();
        }
    }
    /// <summary>
    /// 绑定部门显示信息
    /// </summary>
    private void BindDepartInfo()
    {
        this.gvDepartInfo.DataSource = DepartInfoManager.GetAllDepart();
        this.gvDepartInfo.DataBind();
    }
    /// <summary>
    /// 修改、删除
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void gvDepartInfo_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "Delete")
        {
            try
            {
                int departId = Convert.ToInt32(e.CommandArgument.ToString());
                DepartInfoService.DeleteDepart(departId);
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "key", "alert('请先删除外键中的数据！')", true);
            }
            BindDepartInfo();
        }
        if (e.CommandName == "Update")
        {
            int departId = Convert.ToInt32(e.CommandArgument.ToString());
            Response.Redirect("SaveDepart.aspx?departId="+departId);
        }
    }
    /// <summary>
    /// 添加按钮
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnAdd_Click(object sender, EventArgs e)
    {
        Response.Redirect("SaveDepart.aspx");
    }
    /// <summary>
    /// 删除触发事件
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void gvDepartInfo_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {

    }
    /// <summary>
    /// 光棒效果
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void gvDepartInfo_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            e.Row.Attributes.Add("onmouseover", "currentcolor=this.style.backgroundColor;this.style.backgroundColor='#6699ff'");
            e.Row.Attributes.Add("onmouseout", "this.style.backgroundColor=currentcolor");
        }
    }
    /// <summary>
    /// 分页
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>

    protected void gvDepartInfo_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        this.gvDepartInfo.PageIndex = e.NewPageIndex;
        BindDepartInfo();
    }
}
