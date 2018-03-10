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

public partial class ScheduleManage_PersonNote_PersonNote : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack) 
        {
            User user = (User)Session["Login"];
            if (user != null)
            {
                this.dlMyNote.DataSource = MyNoteManager.GetAllMyNotes(user.UserId);
                this.dlMyNote.DataBind();
            }
            else 
            {
                Response.Redirect("~/Login.aspx");
            }
        }
    }

    public string GetCut(object obj, int num)
    {
        return StringHandler.CutString(obj.ToString(), num);
    }

}
