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
using System.Collections.Generic;
using MyOffice.Models;
using MyOffice.BLL;
using System.Text;
using System.IO;

public partial class ManualSign_Search_SignStatistic : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

        try
        {
            this.lblReportTime.Text = "上报日期:" + DateTime.Now.ToShortDateString();
            this.lblReportUser.Text = "制表人:" + (Session["Login"] as User).UserName;
        }
        catch
        {

        }
    }
    
    protected void btnCount_Click(object sender, EventArgs e)
    {
        BindGridView();
    }

    private void BindGridView()
    {
        TextBox txtBeginTime = this.ChoseTimeUC1.FindControl("txtBeginTime") as TextBox;
        TextBox txtEndTime = this.ChoseTimeUC1.FindControl("txtEndTime") as TextBox;
        DropDownList ddlBranchs = this.BranchDepartDdlUC1.FindControl("ddlBranchs") as DropDownList;
        DropDownList ddlDeparts = this.BranchDepartDdlUC1.FindControl("ddlDeparts") as DropDownList;
        IList<ManualSign> msList = ManualSignManager.SearchManualSignByCondition(
        txtBeginTime.Text.Trim(), txtEndTime.Text.Trim(), ddlBranchs.SelectedValue,
        ddlDeparts.SelectedValue, null, null);
        if (msList != null)
        {
            if (msList.Count > 0)
            {
                IList<ManualSign> list = ManualSignManager.GetManualSignCountInfo(msList, txtBeginTime.Text.Trim(), txtEndTime.Text.Trim());
                gvSignInfoStatistic.DataSource = list;
                gvSignInfoStatistic.DataBind();
                info.Visible = true;
                btnExport.Enabled = true;
                ViewState["list"] = list;
            }
            else
            {
                info.Visible = false;
                btnExport.Enabled = false;
            }
        }
    }
    protected void btnExport_Click(object sender, EventArgs e)
    {
        string eclfileName = "GridViewToExcel" + DateTime.Now.ToString() + ".xls";
        //到Excel
        GridViewToExcel(this.gvSignInfoStatistic, "application/ms-excel", eclfileName);

       
    }
    public void GridViewToExcel(Control ctrl, string FileType, string FileName)
    {
        HttpContext.Current.Response.Charset = "GB2312";
        HttpContext.Current.Response.ContentEncoding = Encoding.Default;//注意编码
        HttpContext.Current.Response.AppendHeader("Content-Disposition",
            "attachment;filename=" + HttpUtility.UrlEncode(FileName, Encoding.Default).ToString());
        HttpContext.Current.Response.ContentType = FileType;//image/JPEG;text/HTML;image/GIF;vnd.ms-excel/msword
        ctrl.Page.EnableViewState = false;
        //  ctrl.All
        StringWriter tw = new StringWriter();
        HtmlTextWriter hw = new HtmlTextWriter(tw);
       ctrl.RenderControl(hw);
        HttpContext.Current.Response.Write(tw.ToString());
        HttpContext.Current.Response.End();
    }
    protected void btnExport_Load(object sender, EventArgs e)
    {
        btnExport.Attributes.Add("onclick", "return confirm('您确定要导出Excel吗？')");
    }

    //必须这么写，不然导入Excel会    
    //类型“GridView”的控件“gvUser”必须放在具有 runat=server 的窗体标记内。 
    public override void VerifyRenderingInServerForm(Control control)
    {
        // base.VerifyRenderingInServerForm(control);
    }

    protected void gvSignInfoStatistic_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        this.gvSignInfoStatistic.PageIndex = e.NewPageIndex;
        BindGridView();
    }
}
