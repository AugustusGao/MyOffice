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

public partial class ScheduleManage_PersonSchedule_PersonSchedule : System.Web.UI.Page
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

    protected void clShowTime_DayRender(object sender, DayRenderEventArgs e)
    {

        User user = (User)Session["Login"];
        //自定义显示内容
        CalendarDay calDay = e.Day;
        //获取表示呈现在空间中的单元格
        TableCell tc = e.Cell;
        CNDate dt = ChinaDate.getChinaDate(calDay.Date);//农历转换对象
        if (calDay.IsOtherMonth)
        {
            tc.Controls.Clear();
        }
        else
        {
            try
            {
                HyperLink ahyperLink = new HyperLink();
                ahyperLink.ImageUrl = "~/Images/add_Schedule.gif";
                ahyperLink.ToolTip = "新增个人日程";
                ahyperLink.NavigateUrl = "SaveMySchedule.aspx?today=" +calDay.Date.ToShortDateString();
                tc.Controls.Add(new LiteralControl("&nbsp;"+"&nbsp;"+"&nbsp;"));
                tc.Controls.Add(ahyperLink);
                tc.Controls.Add(new LiteralControl("<br>"+dt.cnStrMonth+"月"+dt.cnStrDay));//添加农历日期
                tc.Controls.Add(new LiteralControl("<br>"+dt.cnSolarTerm));//添加农历节气
                tc.Controls.Add(new LiteralControl(dt.cnFtvl));//添加节日
                e.Cell.Attributes["onmouseover"] = "javascript:this.style.backgroundColor='#FFCCFF';cursor='hand';";
                e.Cell.Attributes["onmouseout"] = "javascript:this.style.backgroundColor='#ffffff';";
                IList<Schedule> schedules = ScheduleManager.SearchSchedule(calDay.Date.ToShortDateString(), -1, user.UserName, false);
                if (schedules != null) 
                {
                    string str = null;
                    foreach (Schedule schedule in schedules) 
                    {
                        HtmlAnchor ha = new HtmlAnchor();
                        ha.HRef = "SaveMySchedule.aspx?userId="+ user.UserId + "&today=" + calDay.Date.ToShortDateString();
                        try {
                            str = schedule.Title.Substring(0,3);
                        }
                        catch (Exception ex) 
                        {
                            str = schedule.Title;
                        }
                        ha.InnerText = "@ "+schedule.BeginTime.Hour+":"+schedule.BeginTime.Minute+str+"...";
                        //tc.Controls.Add(new LiteralControl("&nbsp;"+"&nbsp;"+"&nbsp;"));
                        //tc.Controls.Add(new LiteralControl("<br>"));
                        tc.Controls.Add(ha);
                       
                    }
                }
            }
            catch (Exception ex)
            {
           
                e.Cell.Attributes["onmouseover"]="javascript:this.style.backgroundColor='#fff7ce';cursor='hand';";
                e.Cell.Attributes["onmouseout"] = "javascript:this.style.backgroundColor='#ffffff';";
            }
        }
      
    }
}