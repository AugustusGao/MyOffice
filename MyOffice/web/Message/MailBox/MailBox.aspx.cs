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
using MyOffice.DAL;
using MyOffice.BLL;

public partial class Message_MailBox_MailBox : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            ShowMessageCount();
        }
    }

    private void ShowMessageCount()
    {
        BoxMessageCount msgCount = MessageManager.GetNumber((User)Session["Login"]);
        lblInbox.Text = msgCount.InboxTotal.ToString();
        lblItNotRead.Text = msgCount.ItNotRead.ToString();
        lblDraftFiles.Text = msgCount.DraftTotal.ToString();
        lblSend.Text = msgCount.SendedTotal.ToString();
        lblDeletedFiles.Text = msgCount.GarbageTotal.ToString();
    }
}
