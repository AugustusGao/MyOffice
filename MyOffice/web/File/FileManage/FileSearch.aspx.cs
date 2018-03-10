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
using System.Collections.Generic;

public partial class File_FileManage_FileSearch : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack) 
        {
            User user = (User)Session["Login"];
            if (user == null) 
            {
                Response.Redirect("~/Login.aspx");
            }
           
        }
    }
    /// <summary>
    /// 根据时间或文件名或创建者姓名查询
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void imgbtnSearch_Click(object sender, ImageClickEventArgs e)
    {

        SearchFileInfo();
      
    }

    private void SearchFileInfo()
    {
        if (txtCreateUser.Text.Trim() == "")
        {
            this.gvFileSearch.DataSource = FileInfoManager.GetFileInfoByFileName(this.txtFileName.Text.Trim(),this.txtCreateUser.Text.Trim(), this.txtBeginTime.Text.Trim(), this.txtEndTime.Text.Trim());
        }
        else
        {
            IList<User> u = UserManager.GetAllUserByUserName(this.txtCreateUser.Text.Trim());

            foreach (User us in u)
            {
                this.gvFileSearch.DataSource = FileInfoManager.GetFileInfoByFileName(this.txtFileName.Text.Trim(), us.UserId, this.txtBeginTime.Text.Trim(), this.txtEndTime.Text.Trim());
            }
        }

        this.gvFileSearch.DataBind();
        info.Visible = true;
    }
    protected void imgbtnExit_Click(object sender, ImageClickEventArgs e)
    {
        this.pnlOption.Style.Add("display","none");
        //Response.Redirect("");
    }

    protected void rdlDate_SelectedIndexChanged(object sender, EventArgs e)
    {
        string beginTime = "", endTime = "";
        switch (rdlDate.SelectedValue)
        {
            case "thisDay":
                beginTime = string.Format("{0:yyyy-MM-dd} 00:00:00", DateTime.Today);
                endTime = string.Format("{0:yyyy-MM-dd} 23:59:59", DateTime.Today);
                break;
            case "thisWeek":
                DateTime dt = ChinaDate.GetMondayDateByDate(DateTime.Today);
                beginTime = string.Format("{0:yyyy-MM-dd} 00:00:00", dt);
                endTime = string.Format("{0:yyyy-MM-dd} 23:59:59", dt.AddDays(6));
                break;
            case "thisMonth":
                beginTime = string.Format("{0:yyyy-MM}-01 00:00:00", DateTime.Today);
                endTime = string.Format("{0:yyyy-MM}-" + ChinaDate.GetDaysByMonth(DateTime.Today.Year, DateTime.Today.Month) + " 23:59:59", DateTime.Today);
                break;
        }
        txtBeginTime.Text = beginTime;
        txtEndTime.Text = endTime;
    }
    protected void LinkButton1_Click(object sender, EventArgs e)
    {
        LinkButton lb = sender as LinkButton;
        Response.Redirect("FileDetails.aspx?fileId="+lb.CommandArgument);
    }
    /// <summary>
    /// 光棒效果
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void gvFileSearch_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            e.Row.Attributes.Add("onmouseover", "currentcolor=this.style.backgroundColor;this.style.backgroundColor='#ffffc0'");
            e.Row.Attributes.Add("onmouseout", "this.style.backgroundColor=currentcolor");
        }
    }



    protected void gvFileSearch_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        this.gvFileSearch.PageIndex=e.NewPageIndex;
        SearchFileInfo();
    }

   
}
