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

public partial class SysManage_LoginLog : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack) 
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
        ShowLoginLog();
       
    }

    private void ShowLoginLog()
    {
        TextBox txtBeginTime = this.ChoseTimeUC1.FindControl("txtBeginTime") as TextBox;
        TextBox txtEndTime = this.ChoseTimeUC1.FindControl("txtEndTime") as TextBox;
        this.gvLoginLog.DataSource = LoginLogManager.GetAllLoginLogsByTime(txtBeginTime.Text.Trim(), txtEndTime.Text.Trim());
        this.gvLoginLog.DataBind();
    }
    protected void gvLoginLog_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        this.gvLoginLog.PageIndex = e.NewPageIndex ;
       
        ShowLoginLog();
        
    }
    protected void btnDelete_Click(object sender, EventArgs e)
    {

        try
        {
            for (int i = 1; i <= this.gvLoginLog.Rows.Count; i++)
            {
                CheckBox cboName = this.gvLoginLog.Controls[0].Controls[i].FindControl("cboName") as CheckBox;
                if (cboName.Checked == true)
                {
                    Label lblId = this.gvLoginLog.Controls[0].Controls[i].FindControl("Label8") as Label;

                    int num = LoginLogManager.DeleteLoginLogById(Convert.ToInt32(lblId.Text));
                   
                }

            }
            Response.Write("<script>alert('删除成功！');</script>");
        }
        catch (Exception)
        {
            Response.Write("<script>alert('删除失败！');</script>");
            throw;
        }
        ShowLoginLog();
      

    }
}
