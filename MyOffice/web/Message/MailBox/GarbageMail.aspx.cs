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
using System.Collections.Generic;
using MyOffice.BLL;

public partial class Message_MailBox_GarbageMail : System.Web.UI.Page
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
            string messageId = gvPersonMessageInfo.DataKeys[e.Row.RowIndex].Value.ToString();

            for (int i = 1; i < e.Row.Cells.Count; i++)
            {
                e.Row.Cells[i].Attributes.Add("onclick", "ScanSendMessageDetail('" +messageId + "')");
            }

            string what = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "Type.MessageTypeName"));

            if (what.Equals("紧急消息"))
            {
                e.Row.Cells[4].Style.Add("color", "red");
            }
        }
    }

    protected string CheckUser(object msgId)
    {
        int messageId = Convert.ToInt32(msgId);
        string users = "";
        IList<MessageToUser> mtu = MessageToUserManager.GetAllMessageToUserByMessageId(messageId);
        foreach (MessageToUser msgToUser in mtu)
        {
            if (msgToUser.ToUser == null)
            {
                users = "所有人";
            }
            else
            {
                users +=" "+msgToUser.ToUser.UserName;
            }
        }
        return users;
    }

    /// <summary>
    /// 彻底删除
    /// 
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
                try
                {
                    string messageId = gvPersonMessageInfo.DataKeys[gvr.RowIndex].Value.ToString();
                    int count = MessageManager.DeleteMessage(Convert.ToInt32(messageId));
                    if (count < 0)
                    {
                        ScriptManager.RegisterStartupScript(this, GetType(), "key", "alert('请先删除外键中的数据！')", true);
                    }
                }
                catch (Exception ex)
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "key", "alert('请先删除外键中的数据！')", true);
                }
            }
        }
    }
}
