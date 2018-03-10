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
using MyOffice.BLL;
using System.Collections.Generic;

public partial class Templates_MasterPage : System.Web.UI.MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {      
        //Common.CheckUserIsExits();
        ////获得登录用户信息
        //if (!Page.IsPostBack) {
        //    User user= Session["Login"] as User;
        //    GenerateTree.LoadRoleMenus(user.UserId, tvMyOffice, true);
        //    GetNewMessageNum();

        //    if(Cache["depart"]==null) Cache["depart"]=DepartManager.GetDepartInfoByDepartId(user.DepartId).DepartName;

        //    lblUserName.Text = user.UserName;
        //    lblRoleName.Text = user.Role.RoleName;
        //    lblDepartName.Text = Cache["depart"].ToString();
        //}
    }

    //获得新邮件数量
    protected void Timer1_Tick(object sender, EventArgs e)
    {
        //GetNewMessageNum();
    }

    protected void GetNewMessageNum()
    {
        //int count=MessageManager.GetNewMailInfo((Session["Login"] as User));
        //if (count > 0)
        //{
        //    imgbtnMessage.Visible = true;
        //    lblMessageCount.Text = count.ToString();
        //}
        //else {
        //    imgbtnMessage.Visible =false;
        //    lblMessageCount.Text ="0";
        //}

    }
    protected void imgBtnReLogin_Click(object sender, ImageClickEventArgs e)
    {
        //User user = Session["Login"] as User;
        //MyOffice.Models.LoginLog log = MyOffice.BLL.LoginLogManager.GetLoginLogByLoginId(user.LoginId);
        //log.ExitTime = DateTime.Now; log.LoginDesc += "并且成功退出";
        //MyOffice.BLL.LoginLogManager.AddLoginLog(log);
        //Session.Clear();
        //Session.Abandon();
        //Response.Redirect("~/Login.aspx");
    }
    protected void imgBtnPassWord_Click(object sender, ImageClickEventArgs e)
    {
       // Server.Transfer("~/SysManage/CreateUser.aspx?userId="+(Session["Login"] as User).UserId,false );
    }
    protected void imgbtnMessage_Click(object sender, ImageClickEventArgs e)
    {
       // Response.Redirect("~/Message/MailBox/ReceiveMail.aspx", false);
    }
}
