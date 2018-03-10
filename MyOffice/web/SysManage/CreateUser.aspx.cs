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

public partial class SysManage_CreateUser : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            ShowUpdateUserInfo();
        }
    }
    /// <summary>
    /// 显示用户信息
    /// </summary>
    private void ShowUpdateUserInfo()
    {
        if (Request.QueryString["UserId"] != null)
        {
            this.txtUserId.ReadOnly = true;
            this.txtPassword.TextMode = TextBoxMode.SingleLine;
            this.txtSureword.TextMode = TextBoxMode.SingleLine;
            User user = UserManager.GetUserById(Request.QueryString["UserId"]);
            this.txtUserId.Text = user.UserId;

            this.txtPassword.Text = user.Password;
            this.txtSureword.Text = user.Password;
            this.txtRealName.Text = user.UserName;
            this.rdolstGender.SelectedValue = user.Gender.ToString();
            this.ddlDepart.SelectedValue = user.DepartId.ToString();
            string path = "~/Images/Users/" + user.UserId + ".jpg";
            if (File.Exists(Server.MapPath(path)))
                this.imgHead.Src = path;
            else
                this.imgHead.Src = "~/Images/Users/noperson.jpg";
            this.ddlUserRole.SelectedValue = user.Role.RoleId.ToString();
            this.ddlUserState.SelectedValue = user.UserState.UserStateId.ToString();
        }
        else
        {
            this.txtPassword.TextMode = TextBoxMode.Password;
            this.txtSureword.TextMode = TextBoxMode.Password;
            this.txtUserId.ReadOnly = false;
        }
    }
    /// <summary>
    /// 判断用户ID是否存在（局部刷新）
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void txtUserId_TextChanged(object sender, EventArgs e)
    {
        if (this.txtUserId.Text != null || !(this.txtUserId.Text.Equals("")))
        {
            bool exist = UserManager.UserNameExists(this.txtUserId.Text);
            if (exist)
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "",
                    "alert('用户登录名已存在，请重新输入！')", true);
                txtUserId.Text = "";
                txtUserId.Focus();
                return;
            }
        }
    }
    /// <summary>
    /// 保存在按钮（修改、添加）
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnSave_Click(object sender, EventArgs e)
    {
        try
        {
            User user = new User();
            user.UserId = this.txtUserId.Text.Trim();
            user.UserName = this.txtRealName.Text.Trim();
            user.Password = this.txtPassword.Text.Trim();
            user.Gender = Convert.ToInt32(rdolstGender.SelectedValue);
            user.Role.RoleId = Convert.ToInt32(this.ddlUserRole.SelectedValue);
            user.DepartId = Convert.ToInt32(this.ddlDepart.SelectedValue);
            user.UserState.UserStateId = Convert.ToInt32(this.ddlUserState.SelectedValue);
            if (Request.QueryString["UserId"] != null)  //修改
            {
                UserManager.UpdateUser(user);
                UpdateImage();
            }
            else
            {
                //增加
                UserManager.AddUsers(user);
                //上传图片
                UpdateImage();
                //在ini文件中添加此用户的信息
                IniFile.IniWriteValue(((MyOffice.Models.User)Session["Login"]).UserId);
            }
        }
        catch (Exception ex)
        {
            //throw new ApplicationException(ex.Message);
        }
        finally
        {
            Response.Redirect("UserManager.aspx");
        }
    }
    /// <summary>
    /// 上传图片
    /// </summary>
    private void UpdateImage()
    {

        string fileName = this.fuImage.FileName;
        string phyPath = Server.MapPath("~/Images/Users/");
        string extentionName = Path.GetExtension(this.fuImage.PostedFile.FileName);
        if (extentionName.Equals(".jpg"))
        {
            // string path = Path.Combine(phyPath, fileName);
            this.fuImage.SaveAs(phyPath + this.txtUserId.Text.Trim() + ".jpg");
            //this.imgHead.ImageUrl =

            imgHead.Src = phyPath + "/" + fileName;
        }
        else
        {
            ScriptManager.RegisterStartupScript(this, GetType(), "", "alert('上传失败！格式错误')", true);
        }

    }
}

