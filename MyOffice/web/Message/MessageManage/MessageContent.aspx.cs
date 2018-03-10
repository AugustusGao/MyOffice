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

public partial class Message_MessageManage_MessageContent : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Request.QueryString["MessageId"] != null)
            {
                int messageId=Convert.ToInt32(Request.QueryString["MessageId"]);
                Message message = MessageManager.GetMessageById(messageId);
                this.txtMessageContent.Text = message.Content;
                User user = (User)Session["Login"];
                ReadCommonMessageManager.UpdateReadCommonMessage(messageId, user.UserId);
            }
        }
    }
}
