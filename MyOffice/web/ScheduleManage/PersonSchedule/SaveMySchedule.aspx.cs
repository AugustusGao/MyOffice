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

public partial class ScheduleManage_PersonSchedule_SaveMySchedule : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        TreeView tv = this.utShow.FindControl("tvUser") as TreeView;
        tv.SelectedNodeChanged += new EventHandler(tv_SelectedNodeChanged);
        if (!IsPostBack)
        {
         
            User u = (User)Session["Login"];
            if (u == null)
            {
                Response.Redirect("~/Login.aspx");
            }
            else
            {
               
                //查看我的日程他人的日程信息
                if (Request.QueryString["scheduleId"] != null)
                {
                    this.btnDelete.Enabled = false;
                    this.btnSave.Enabled = false;
                    Schedule sch = ScheduleManager.GetScheduleById(Convert.ToInt32(Request.QueryString["scheduleId"]));
                    ShowSchedule(sch);

                }

                this.lblTime.Text = Request.QueryString["today"].ToString();
                if (Request.QueryString["userId"] == null)
                {
                    this.lblUserName.Text = u.UserName;
                }
                else
                {
                    User user = UserManager.GetUserById(Request.QueryString["userId"]);
                    this.lblUserName.Text = user.UserName;
                }
                if (Request.QueryString["userId"] != null && Request.QueryString["scheduleId"] == null)
                {
                    this.lblTime.Text = Convert.ToString(Request.QueryString["today"]);
                    User user = UserManager.GetUserById(Convert.ToString(Request.QueryString["userId"]));
                    this.lblUserName.Text = Convert.ToString(Request.QueryString["userId"]);
                    IList<Schedule> schedules = ScheduleManager.SearchSchedule(lblTime.Text, -1, user.UserName, false);
                    if (schedules.Count != 0)
                    {
                        this.btnDelete.Enabled = true;
                        foreach (Schedule schedule in schedules)
                        {
                            ShowSchedule(schedule);

                        }
                    }
                }

               
            }
          
        }

    }

    void tv_SelectedNodeChanged(object sender, EventArgs e)
    {
        TreeView tv = this.utShow.FindControl("tvUser") as TreeView;
        if (tv.SelectedNode.Depth != 2)
        {
            ScriptManager.RegisterStartupScript(this, GetType(), "key", "alert('您选择的不是人员，请重新选择 ！')", true);
        }
        else
        {
            string usName = tv.SelectedNode.Parent.Text + "-" + tv.SelectedNode.Text;
            ListItem list = new ListItem(usName, tv.SelectedNode.Value);

            if (lbUserName.Items.Count == 0)
            {
                this.lbUserName.Items.Insert(0, list);
                this.div1.Style.Add("display", "none");

            }
            else
            {
                bool flag = false;

                foreach (ListItem li in lbUserName.Items)
                {

                    if (li.Value == list.Value)
                    {
                        flag = false;

                        ScriptManager.RegisterStartupScript(this, GetType(), "key", "alert('已有请重新选择 ！')", true);

                        return;
                    }
                    else
                    {

                        flag = true;

                    }

                }
                if (flag == true)
                {
                    this.lbUserName.Items.Insert(0, list);
                    this.div1.Style.Add("display", "none");
                }
            }
           
        }
    }
    /// <summary>
    /// 显示日程信息
    /// </summary>
    /// <param name="schedule"></param>
    private void ShowSchedule(Schedule schedule)
    {
        this.txtTitle.Text = schedule.Title;
        this.txtAddress.Text = schedule.SchContent;
        this.txtBeginTime.Text = string.Format("{0:yyyy-MM-dd HH:mm:ss}", schedule.BeginTime);
        this.txtEndTime.Text = string.Format("{0:yyyy-MM-dd HH:mm:ss}", schedule.EndTime);
        this.txtContent.Text = schedule.SchContent;
        this.lblUserName.Text = schedule.CreateUser.UserName;
        IList<PreContract> preContracts = PreContractManager.GetPreContractByScheduleId(schedule.ScheduleId);

        if (preContracts.Count != 0)
        {
            foreach (PreContract pre in preContracts)
            {
                User us = UserManager.GetUserById(pre.UserId);
                Depart depart = DepartInfoManager.GetDepartGetById(us.DepartId);
                ListItem item = new ListItem(depart.DepartName + "-" + us.UserName, us.UserId);
                this.lbUserName.Items.Add(item);
            }
        }
        if (schedule.IfPrivate == 1)
        {
            this.cboPrivate.Checked = true;
        }
        else
        {
            this.cboPrivate.Checked = false;
        }
        this.ddlType.SelectedValue = schedule.Meeting.MeetingId.ToString();
    }
    
    
    /// <summary>
    /// 退出
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnExit_Click(object sender, EventArgs e)
    {
        if (Request.QueryString["scheduleId"] == null)
        {
            Response.Redirect("PersonSchedule.aspx");
        }
        else
        {
            Response.Redirect("~/ScheduleManage/DepartSchedule/DepartSchedule.aspx");
        }
    }
  
    /// <summary>
    /// 日程添加
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnSave_Click(object sender, EventArgs e)
    {
        if (Page.IsValid)
        {
            TreeView tv = this.utShow.FindControl("tvUser") as TreeView;
            string time = Convert.ToString(Request.QueryString["today"]);
            User user =(User)Session["Login"]; //UserManager.GetUserById(Convert.ToString(Request.QueryString["userId"]));
            IList<Schedule> schedules = ScheduleManager.SearchSchedule(time, -1, user.UserName, false);
            if (schedules.Count == 0)
            {
                AddSchedule(user);
            }
            else
            {
                ModifySchedule(user, schedules);
              
              
            }
        }
    }


    /// <summary>
    /// 修改日程信息
    /// </summary>
    /// <param name="user"></param>
    /// <param name="schedules"></param>
    private void ModifySchedule(User user, IList<Schedule> schedules)
    {
        int scheduleId = 0;
        foreach (Schedule sch in schedules)
        {
            scheduleId = sch.ScheduleId;
        }
        Schedule schedule = new Schedule();
        schedule.Title = this.txtTitle.Text.Trim();
        schedule.Address = this.txtAddress.Text.Trim();
        schedule.BeginTime = Convert.ToDateTime(this.txtBeginTime.Text.Trim());
        schedule.EndTime = Convert.ToDateTime(this.txtEndTime.Text.Trim());
        schedule.CreateTime = Convert.ToDateTime(this.lblTime.Text.Trim());
        schedule.CreateUser.UserId = user.UserId;
        schedule.SchContent = this.txtContent.Text.Trim();
        schedule.Meeting.MeetingId = Convert.ToInt32(this.ddlType.SelectedValue);
        schedule.ScheduleId = scheduleId;
        if (this.cboPrivate.Checked == true)
        {
            schedule.IfPrivate = 1;
        }
        else
        {
            schedule.IfPrivate = 0;
        }
        int i = ScheduleManager.ModifyScheduleById(schedule);

        if (i != 0)
        {
            if (lbUserName.Items.Count > 0)
            {
                PreContract p = new PreContract();
                p.Schedule = ScheduleManager.GetScheduleById(scheduleId);
                int count = PreContractManager.DeletePreContractById(p.Schedule.ScheduleId);
                if (count > 0)
                {
                    foreach (ListItem li in lbUserName.Items)
                    {
                        PreContract pre = new PreContract();
                        pre.Schedule.ScheduleId = scheduleId;
                        pre.UserId = li.Value;
                        int num = PreContractManager.AddPreContract(pre);
                        if (num == 0)
                        {
                            ScriptManager.RegisterStartupScript(this, GetType(), "key", "alert('修改失败！')", true);
                            break;
                        }

                    }
                    Response.Redirect("PersonSchedule.aspx");

                }
                else
                {
                    Response.Redirect("PersonSchedule.aspx");
                }
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "key", "alert('修改失败！')", true);
            }
        }
        else
        {
            ScriptManager.RegisterStartupScript(this, GetType(), "key", "alert('修改失败！')", true);
        }
    }

    /// <summary>
    /// 添加日程信息
    /// </summary>
    /// <param name="user"></param>
    private void AddSchedule(User user)
    {
        Schedule schedule = GiveSchedule(user);

        int i = ScheduleManager.AddSchedule(schedule);

        if (i != 0)
        {
            if (this.lbUserName.Items.Count > 0)
            {

                foreach (ListItem li in lbUserName.Items)
                {
                    PreContract preContract = new PreContract();
                    preContract.Schedule.ScheduleId = i;
                    preContract.UserId = li.Value;
                    int count = PreContractManager.AddPreContract(preContract);
                    if (count == 0)
                    {
                        ScriptManager.RegisterStartupScript(this, GetType(), "key", "alert('添加失败！')", true);
                        break;
                    }

                }

                Response.Redirect("PersonSchedule.aspx");
            }
            else
            {
                Response.Redirect("PersonSchedule.aspx");
            }

        }
        else
        {
            ScriptManager.RegisterStartupScript(this, GetType(), "key", "alert('添加失败！')", true);
        }
    }

    /// <summary>
    /// 赋值
    /// </summary>
    /// <param name="user"></param>
    /// <returns></returns>
    private Schedule GiveSchedule(User user)
    {
        Schedule schedule = new Schedule();
        schedule.Title = this.txtTitle.Text.Trim();
        schedule.Address = this.txtAddress.Text.Trim();
        schedule.BeginTime = Convert.ToDateTime(this.txtBeginTime.Text.Trim());
        schedule.EndTime = Convert.ToDateTime(this.txtEndTime.Text.Trim());
        schedule.CreateTime = Convert.ToDateTime(Request.QueryString["today"]);
        schedule.CreateUser.UserId = user.UserId;
        schedule.SchContent = this.txtContent.Text.Trim();
        schedule.Meeting.MeetingId = Convert.ToInt32(this.ddlType.SelectedValue);
        if (this.cboPrivate.Checked == true)
        {
            schedule.IfPrivate = 1;
        }
        else
        {
            schedule.IfPrivate = 0;
        }
        return schedule;
    }

    /// <summary>
    /// 移除预约人
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnDeletePreContract_Click(object sender, EventArgs e)
    {
        if (lbUserName.SelectedItem != null)
        {
            this.lbUserName.Items.Remove(this.lbUserName.SelectedItem);

        }
        else 
        {
            ScriptManager.RegisterStartupScript(this, GetType(), "key", "alert('请选择要删除预约人！')", true);
            
        }
    }

    /// <summary>
    /// 删除日程
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnDelete_Click(object sender, EventArgs e)
    {
        this.lblTime.Text = Convert.ToString(Request.QueryString["today"]);
        User user = UserManager.GetUserById(Convert.ToString(Request.QueryString["userId"]));
        IList<Schedule> schedules = ScheduleManager.SearchSchedule(lblTime.Text, -1, user.UserName, false);
        if (schedules.Count != 0)
        {
            int scheduleId = 0;
            foreach (Schedule schedule in schedules)
            {
                scheduleId = schedule.ScheduleId;
                int i = ScheduleManager.DeleteScheduleById(scheduleId);
                if (i > 0)
                {
                    Response.Redirect("PersonSchedule.aspx");
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "key", "alert('删除失败！')", true);
                }
            }
        }
    }
    protected void imgbtnShow_Click(object sender, ImageClickEventArgs e)
    {
        this.div1.Style.Add("display", "");
    }
}
