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


public partial class Login : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
     
    }

    //登录
    protected void imgbtnLogin_Click(object sender, ImageClickEventArgs e)
    {
        MyOffice.Models.User user = null;
     
        if (UserManager.Login(txtUserId.Text.Trim(), txtPassword.Text.Trim(), out user))
        {
               
                string url = "";
                switch (user.Role.RoleId)
                {
                    case 0:

                        Response.Write("<script>alert('很抱歉，您暂时没有权限登录系统！');</script>");
                       
                        user = null;
                        return;
                   
                    default:
                        url = "~/index.aspx";
                        break;
                }
                if (user != null)
                {
                    Session.Timeout = 10;
                    Session["Login"]=user;
                    txtPassword.Text = ""; txtUserId.Text = "";
                    Response.Redirect(url);
                }

            }
          
        }

 
  
    protected void txtUserId_TextChanged(object sender, EventArgs e)
    {
     
    }
}

