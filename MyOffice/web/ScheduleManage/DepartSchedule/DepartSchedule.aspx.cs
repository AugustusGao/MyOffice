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

public partial class ScheduleManage_DepartSchedule_DepartSchedule : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack) 
        {
    
        }
    }
    //根据部门和时间或姓名和时间查找
    protected void imgbtnSearch_Click(object sender, ImageClickEventArgs e)
    {

        DropDownList ddlDepart = this.BranchDepartDdlUC1.FindControl("ddlDeparts") as DropDownList;
        IList<Schedule> schedules = null;
        if (ddlDepart.SelectedValue == "")
        {
            ddlDepart.SelectedItem.Value = "0";
        }
        string beginTime = "";
        string endTime = "";
        if (this.txtTime.Text == "") 
        {
            ScriptManager.RegisterStartupScript(this, GetType(), "key", "alert('日期不能为空 ！')", true);
            return;
        }
        if (this.txtTime.Text != "")
        {

            beginTime = this.txtTime.Text;
            DateTime d = Convert.ToDateTime(beginTime);
            string day = "";
            string year = Convert.ToString(d.Year);
            string month = Convert.ToString(d.Month);
            int dy = Convert.ToInt32(d.DayOfWeek);
            if (dy == 0)
            {
                day = Convert.ToString(CompareDay(d.Year, d.Month, d.Day + 6));// Convert.ToString(d.Day + 6);
            }
            else
            {
                int da = Convert.ToInt32(d.Day);
                if (da - 6 < 0)
                {


                    beginTime = d.Year.ToString() + "-" + d.Month.ToString() + "" + Convert.ToString(Convert.ToInt32(d.Day) - 6);

                }
                if (da - 6 == 0)
                {


                    beginTime = d.Year.ToString() + "-" + d.Month.ToString() + "-" + Convert.ToString(Convert.ToInt32(d.Day) - 6) + 1;

                }
                if (da - 6 > 0)
                {
                    beginTime = d.Year.ToString() + "-" + d.Month.ToString() + "-" + Convert.ToString(Convert.ToInt32(d.Day) - 6);
                }
                day = Convert.ToString(CompareDay(d.Year, d.Month, d.Day + 3)); //Convert.ToString(d.Day + 3);
            }
         
         
           
            endTime = year + "-" + month + "-" + day;
            User user = (User)Session["Login"];
           
            if (user != null)
            {
                if (this.txtName.Text == "")
                {
                    schedules = ScheduleManager.GetAllSchedulesByTime(beginTime, endTime, Convert.ToInt32(ddlDepart.SelectedValue),this.txtName.Text, true);

                }
                else
                {
                    schedules = ScheduleManager.GetAllSchedulesByTime(beginTime, endTime, Convert.ToInt32(ddlDepart.SelectedValue), this.txtName.Text,false);
                }

            }
            else
            {
                Response.Redirect("~/Login.aspx");
            }
        }
      
        if (schedules != null)
        {
            ViewState["schedules"] = schedules;
            this.gvSchedules.DataSource = schedules;
            this.gvSchedules.DataBind();
            this.lblTime.Text = txtTime.Text.Trim();
        }
       
    }
    //负责显示部门日程信息
    protected void ShowSchedule(int rowIndex, List<Schedule> schedules) 
    {
        string str = null;
        //从查询结果中找出每个人所有的日程按行显示
        Label lblName = gvSchedules.Controls[0].Controls[rowIndex].FindControl("lblName") as Label;
        foreach (Schedule sh in schedules) 
        {

            if (rowIndex == 1)
            {
                if (sh.CreateUser.UserName == lblName.Text)
                {
                    str = DepartSchedule(rowIndex, str, sh);
                    ViewState["a"] = lblName.Text;
                    ViewState["b"] = str;

                }
                else
                {
                    continue;
                  
                }
            }
            if (rowIndex !=1) 
            {
                string a = Convert.ToString(ViewState["a"]);
                string b = Convert.ToString(ViewState["b"]);
                if (sh.CreateUser.UserName ==a)
                {
                    if (b== sh.Title.Substring(0,3))
                    {
                        continue;
                    }
                    else 
                    {
                        lblName.Text = "";
                        continue;
                    }
                   
                }
              
                else 
                {
                    str = DepartSchedule(rowIndex, str, sh);
                }
           
            }
               
              
        }

    }

    private string DepartSchedule(int rowIndex, string str, Schedule sh)
    {
        //获得星期
        int current = Convert.ToInt32(sh.BeginTime.DayOfWeek);
        //根据星期找到显示字段
        Label lbl = this.gvSchedules.Controls[0].Controls[rowIndex].FindControl("Label" + current) as Label;
        //创建超链接
        HtmlAnchor ha = new HtmlAnchor();
        ha.Attributes.Add("style", "color:black");
        ha.HRef = "../PersonSchedule/SaveMySchedule.aspx?userId=" + sh.CreateUser.UserId + "&scheduleId=" + sh.ScheduleId + "&today=" + this.txtTime.Text;
        try
        {
            str = sh.Title.Substring(0, 3);
        }
        catch (Exception ex)
        {
            str = sh.Title.ToString();
        }
        ha.InnerHtml = "@" + sh.BeginTime.Hour.ToString() + ":" + sh.BeginTime.Minute.ToString() + str + "...";
        lbl.Controls.Add(ha);
        lbl.Controls.Add(new LiteralControl("<br>"));
        return str;
    }

    //截取字符串
    public string GetCut(object obj, int num)
    {
        return StringHandler.CutString(obj.ToString(), num);
    }
   

    protected void gvSchedules_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        //得到选择的日期
        string selectDay = txtTime.Text + " 00:00:00";
        DateTime selectTime = DateTime.Parse(selectDay);

        //判断行类型是不是标头
        if (e.Row.RowType == DataControlRowType.Header)
        {
            //循环显示一周中各天所对应的日期
            for (int i = 0; i < 7; i++)
            {
                int intWeek = i - Convert.ToInt32(selectTime.DayOfWeek);
                //一周中各天所对应的日期
                string strWeek = selectTime.AddDays(intWeek).ToString("yyyy-MM-dd");
                DateTime weekDay = DateTime.Parse(strWeek + " 00:00:00");

                if (weekDay.Month.ToString() == selectTime.Month.ToString())
                {
                    //实例化标题控件
                    Label lblWeek = (Label)e.Row.FindControl("Label" + i + "");
                    lblWeek.Text = weekDay.Day.ToString(); 
                }
            }
        }
       
        if (e.Row.RowType ==DataControlRowType.DataRow)
        {
            ShowSchedule(e.Row.RowIndex+1, ViewState["schedules"] as List<Schedule>);

        }
       }
    public int CompareDay(int year, int month, int day)
    {
        if (year % 4 == 0)
        {
            if (month == 1 || month == 3 || month == 5 || month == 7 || month == 8 || month == 10 || month == 12)
            {
                if (day > 31)
                {
                    day = 31;
                }
            }
            if (month == 2)
            {
                if (day > 29)
                {
                    day = 29;
                }
            }
            if (month == 4 || month == 6 || month == 9 || month == 11)
            {
                if (day > 30)
                {
                    day = 30;
                }
            }
        }
        else
        {
            if (month == 1 || month == 3 || month == 5 || month == 7 || month == 8 || month == 10 || month == 12)
            {
                if (day > 31)
                {
                    day = 31;
                }
            }
            if (month == 2)
            {
                if (day > 29)
                {
                    day = 28;
                }
            }
            if (month == 4 || month == 6 || month == 9 || month == 11)
            {
                if (day > 30)
                {
                    day = 30;
                }
            }
        }
        return day;
    }
            
            
        }

