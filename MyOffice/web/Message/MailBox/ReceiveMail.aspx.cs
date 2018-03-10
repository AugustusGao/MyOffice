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

public partial class Message_MailBox_ReceiveMail : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void gvPersonMessageInfo_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            e.Row.Attributes.Add("onmouseover", "currentcolor=this.style.backgroundColor;this.style.backgroundColor='#6699ff'");
            e.Row.Attributes.Add("onmouseout", "this.style.backgroundColor=currentcolor");
            Message msg = (Message)gvPersonMessageInfo.DataKeys[e.Row.RowIndex].Value;

            for (int i = 1; i < e.Row.Cells.Count; i++)
            {
                e.Row.Cells[i].Attributes.Add("onclick", "ScanSendMessageDetail('" + msg.MessageId + "')");
            }
            string what = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "Message.Type.MessageTypeName"));

            if (what.Equals("紧急消息"))
            {
                e.Row.Cells[4].Style.Add("color", "red");
            }
            MessageToUser toUser = MessageToUserManager.GetMessageToUserByMessageId(msg.MessageId);
            if (toUser.IfRead == 0)
            {
                Image img = new Image();
                img.ImageUrl = "../../Images/new.gif";
                e.Row.Cells[2].Controls.Add(img);
            }
        }

    }
    /// <summary>
    /// 删除
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnDelete_ServerClick(object sender, EventArgs e)
    {
        User user = (User)Session["Login"];
        foreach (GridViewRow gvr in gvPersonMessageInfo.Rows)
        {
            CheckBox chkSelect = (CheckBox)gvr.FindControl("chkSelect");
            //如果选中了则删除
            if (chkSelect.Enabled == true && chkSelect.Checked == true)
            {
                Message msg = (Message)gvPersonMessageInfo.DataKeys[gvr.RowIndex].Value;
                MessageManager.UpdateDeleteMessage(msg.MessageId, false);
            }
        }
    }

}
