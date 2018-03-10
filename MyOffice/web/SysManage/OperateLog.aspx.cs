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
using MyOffice.Models;

public partial class SysManage_OperateLog : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (IsPostBack) 
        {
            //Button btnDel = this.FindControl("btnDelete") as Button;
            //btnDel.Attributes.Add("onclick", "return confirm('确定要删除吗？')");
            User user = (User)Session["Login"];
            if (user == null)
            {
                Response.Redirect("~/Login.aspx");
            }
        }
    }
    protected void imgbtnSearch_Click(object sender, ImageClickEventArgs e)
    {
        ShowOperateLog();
    }

    private void ShowOperateLog()
    {
        TextBox txtBeginTime = this.ChoseTimeUC1.FindControl("txtBeginTime") as TextBox;
        TextBox txtEndTime = this.ChoseTimeUC1.FindControl("txtEndTime") as TextBox;
        this.gvOperateLog.DataSource = OperateLogManager.GetAllOperateLogsByTime(txtBeginTime.Text.Trim(), txtEndTime.Text.Trim());
        this.gvOperateLog.DataBind();
    }
    protected void gvOperateLog_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        this.gvOperateLog.PageIndex = e.NewPageIndex;
        ShowOperateLog();
    }
    protected void btnDelete_Click(object sender, EventArgs e)
    {
        try
        {
            for (int i = 1; i <= this.gvOperateLog.Rows.Count; i++)
            {
                CheckBox cboName = this.gvOperateLog.Controls[0].Controls[i].FindControl("cboName") as CheckBox;
                if (cboName.Checked == true)
                {
                    Label lblId = this.gvOperateLog.Controls[0].Controls[i].FindControl("Label1") as Label;

                    int num = OperateLogManager.DeleteOperateLogById(Convert.ToInt32(lblId.Text));

                }

            }
            Response.Write("<script>alert('删除成功！');</script>");
        }
        catch (Exception)
        {

            Response.Write("<script>alert('删除失败！');</script>");
        }
        ShowOperateLog();
    }
}
