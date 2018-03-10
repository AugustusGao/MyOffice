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

public partial class Templates_Top : System.Web.UI.Page
{


    public string id = "";


    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["Login"] != null)
        {
            User us = Session["Login"] as User;
            id = us.UserId.ToString();
        }
    }
}
