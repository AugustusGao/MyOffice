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
using System.IO;

public partial class SysManage_UserDetail : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            ShowUserInfo();
        }
    }
    /// <summary>
    /// 用户详情
    /// </summary>
    private void ShowUserInfo()
    {
        try
        {
            string userId = Request.QueryString["UserId"].ToString();
            User user = UserManager.GetUserById(userId);
            string sex = "";
            if (user.Gender == 0)
                sex = "女";
            else if (user.Gender == 1)
                sex = "男";
            this.lblUserId.Text = user.UserId;
            this.lblUserName.Text = user.UserName;
            this.lblPassword.Text = user.Password;
            this.lblGender.Text = sex;
            this.lblDepart.Text = user.DepartName;
            this.lblUserRole.Text = user.Role.RoleName;
            this.lblUserState.Text = user.UserState.UserStateName;
            string path = "~/Images/Users/" + user.UserId + ".jpg";
            if (File.Exists(Server.MapPath(path)))
                this.imgUser.Src = path;
            else
                this.imgUser.Src = "~/Images/Users/noperson.jpg";
            imgUser.Width = 150;
            imgUser.Height = 180;
        }
        catch (Exception ex)
        {
            throw new ApplicationException(ex.Message);
        }
    }
}
