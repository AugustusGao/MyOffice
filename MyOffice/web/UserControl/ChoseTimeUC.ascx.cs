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

public partial class UserControl_ChoseTimeUC : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {

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
}
