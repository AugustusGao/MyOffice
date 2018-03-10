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

public partial class Message_MailBox_ReceiveMailDetail : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            ShowMessage(Convert.ToInt32(Request.QueryString["id"]),Convert.ToInt32(Request.QueryString["type"]));
        }
    }

    private void ShowMessage(int messageId,int type)
    {
        int id = Convert.ToInt32(Request.QueryString["id"]);
        Message msg = MessageManager.GetMessageById(id);
        if (msg != null)
        {
            if (type == 1)
            {
                lblText.Text = "发件人：";
                lblFromUser.Text = msg.FromUser.UserName;
                ReadCommonMessageManager.UpdateReadCommonMessage(msg.MessageId, ((Session["Login"] as User).UserId));

            }
            if (type == 2)
            {
                lblText.Text = "收件人：";
                IList<MessageToUser> mtu = MessageToUserManager.GetAllMessageToUserByMessageId(id);
                foreach (MessageToUser m in mtu)
                {
                    lblFromUser.Text += "  " + m.ToUser.UserName;
                }
            }
            else
            {
                lblText.Text = "作  者：";
                lblTime.Text = "删除时间";
                lblFromUser.Text = msg.FromUser.UserName;
            }
            lblTitle.Text = msg.Title;
            lblType.Text = "***" + msg.Type.MessageTypeName + "***";
            txtContent.Text = msg.Content;
            lblSendTime.Text = string.Format("{0:yyyy-MM-dd HH:mm:ss}", msg.RecordTime);
        }
    }
}
