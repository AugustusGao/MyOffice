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
using System.Collections.Generic;
using MyOffice.Models;
//using MyOffice.Utils;

public partial class Templates_File : System.Web.UI.MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if(!IsPostBack){
      //  DisplayDirectoryInfo();
        }
    }

    protected void DisplayDirectoryInfo()
    {
        //GenerateTree.LoadFileMenus(tvDirectory,true);
    }
}
