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
using System.Drawing;

public partial class Message_MessageManage_MessageManage : System.Web.UI.Page
{
    /// <summary>
    /// 窗体加载
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            BindMessageInfo();
        }
    }

    protected bool CheckShow(object ifRead)
    {
        int pub = Convert.ToInt32(ifRead);
        if (pub == 0)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
    protected string CheckText(object ifRead)
    {
        int pub = Convert.ToInt32(ifRead);
        if (pub == 0)
        {
            return " 发 布 ";
        }
        else
        {
            return "已发布";
        }
    }
    /// <summary>
    /// 绑定数据
    /// </summary>
    private void BindMessageInfo()
    {
        TextBox beginTime= this.ChoseTime.FindControl("txtBeginTime") as TextBox;
        TextBox endTime = this.ChoseTime.FindControl("txtEndTime") as TextBox;
        User user = new User();
        User userInfo=(User)Session["Login"];
        this.gvMessage.DataSource = MessageManager.GetMessageByDate(beginTime.Text.Trim(), endTime.Text.Trim(), userInfo);
        this.gvMessage.DataBind();
    }

    /// <summary>
    /// 截取消息内容的字符串
    /// </summary>
    /// <param name="obj"></param>
    /// <returns></returns>
    protected static string GetContent(object obj)
    {
        string contents = "";
        if (obj.ToString().Length > 7)
        {
            contents = obj.ToString().Substring(0, 6) + "...";
        }
        else
        {
            contents = obj.ToString();
        }
        return contents;
    }
    /// <summary>
    /// 光棒效果
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void gvMessage_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            e.Row.Attributes.Add("onmouseover", "currentcolor=this.style.backgroundColor;this.style.backgroundColor='#6699ff'");
            e.Row.Attributes.Add("onmouseout", "this.style.backgroundColor=currentcolor");
            HyperLink hl = e.Row.FindControl("hlSendObject") as HyperLink;
            MessageToUser item = MessageToUserManager.GetMessageToUserByMessageId(Convert.ToInt32(hl.Text.Trim()));
            //给消息类型加色
            string what = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "Type.MessageTypeName"));
            if (what.Equals("紧急消息"))
            {
                e.Row.Cells[1].Style.Add("color", "red");
            }
            if (item.ToUser == null)
            {
                hl.Text = "所有用户";
            }
            else
            {
                hl.NavigateUrl = "javascript:ScanReceiveUsers(" + hl.Text.Trim() + ")";
                hl.Text = "查看发送用户名";
            }
            int ifPublish = Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "IfPublish"));
            if (ifPublish==1)
            {
                ImageButton imgBtnUpdate =e.Row.FindControl("imgBtnUpdate") as ImageButton;
                //e.Row.Cells[8].Style.Add("background-color", "#999999");
                imgBtnUpdate.BackColor = Color.Gray; 
            }
        }
    }
    /// <summary>
    /// 分页
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void gvMessage_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        this.gvMessage.PageIndex = e.NewPageIndex;
        BindMessageInfo();
    }
    /// <summary>
    /// 搜索
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void imgBtnSearch_Click(object sender, ImageClickEventArgs e)
    {
        BindMessageInfo();
    }
    /// <summary>
    /// 修改、删除
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void gvMessage_RowCommand(object sender, GridViewCommandEventArgs e)
    {

        if (e.CommandName == "Delete")
        {
            try
            {
                int messageId = Convert.ToInt32(e.CommandArgument.ToString());
                MessageManager.UpdateDeleteMessage(messageId,true);
                BindMessageInfo();
            }
            catch (Exception ex)
            {
                throw new ApplicationException(ex.Message);
                ScriptManager.RegisterStartupScript(this, GetType(), "key", "alert('请先删除外键信息！')", true);
            }
        }
        if (e.CommandName == "Update")
        {
            int messageId = Convert.ToInt32(e.CommandArgument.ToString());
            Response.Redirect("SaveMessage.aspx?messageId=" + messageId);
        }

    }
    /// <summary>
    /// 删除触发事件
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void gvMessage_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {

    }
    /// <summary>
    /// 发布消息
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        Button btnPublish = (Button)sender;
        Message message = 
            MessageManager.GetMessageById(Convert.ToInt32(btnPublish.CommandArgument.ToString()));
        message.IfPublish = 1;
        MessageManager.UpdateMessage(message);
        BindMessageInfo();
    }
    /// <summary>
    /// 添加消息
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void lbAdd_Click(object sender, EventArgs e)
    {
        Response.Redirect("SaveMessage.aspx");
    }
}
