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
    #region 合并单元格
    protected void Unite(GridView gv)
    {
        string saveCell;//保存列
        int lastCell;//最终列     
        if (this.gvSignInfoStatistic.Rows.Count > 0)
        {
            for (int i = 0; i < 6; i++)
            {
                //排除不合并的单元格
                if (i != 1 && i != 2 && i != 3)
                {
                    Label begin = this.gvSignInfoStatistic.Rows[0].Cells[i].FindControl("Label" + (i + 1)) as Label;
                    saveCell = begin.Text;//获得第一行需合并数据
                    this.gvSignInfoStatistic.Rows[0].Cells[i].RowSpan = 1;//设初始合并值为1，每遇重复行自加并移动的新的行号获取数据
                    lastCell = 0;

                    for (int temp = 1; temp < this.gvSignInfoStatistic.Rows.Count; temp++)
                    {   //发现重复行将其合并
                        Label next = this.gvSignInfoStatistic.Rows[temp].Cells[i].FindControl("Label" + (i + 1)) as Label;
                        if (next.Text == saveCell)
                        {
                            this.gvSignInfoStatistic.Rows[temp].Cells[i].Visible = false;
                            this.gvSignInfoStatistic.Rows[lastCell].Cells[i].RowSpan++;//合并
                        }
                        else
                        {//下一条用户记录
                            saveCell = next.Text;//将其第一条记录保留，作为下一次比较用
                            lastCell = temp;//把行号保存
                            this.gvSignInfoStatistic.Rows[temp].Cells[i].RowSpan = 1;//开始新合并行
                        }
                    }
                }
            }
        }
    }
    #endregion
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
                Unite(gvSignInfoStatistic);
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
