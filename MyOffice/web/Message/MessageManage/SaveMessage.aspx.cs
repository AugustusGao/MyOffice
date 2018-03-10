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
using MyOffice.DAL;
using MyOffice.Models;
using MyOffice.BLL;
using System.Collections.Generic;
using AjaxControlToolkit;

public partial class Message_MessageManage_SaveMessage : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            ShowManager();
            SetEnabled();
        }
    }
    /// <summary>
    /// 显示修改信息
    /// </summary>
    private void ShowManager()
    {
        if (Request.QueryString["messageId"] != null)
        {
            int messageId = Convert.ToInt32(Request.QueryString["messageId"]);
            Message item = MessageService.GetMessageById(messageId);
            this.ddlMessageType.SelectedValue = item.Type.MessageTypeId.ToString();
            this.txtBeginTime.Text =item.BeginTime.ToString();
            this.txtEndTime.Text = item.EndTime.ToString();
            this.txtTitle.Text = item.Title;
            this.txtContent.Text = item.Content;
            hfCount.Value = item.MessageId.ToString();
            rdoSendObj.Enabled = false;
            pnlSelect.Visible = false;
           
        }

    }
    /// <summary>
    /// 发送对象单选集合
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void rdoSendObj_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (rdoSendObj.SelectedValue == "0")
        {
            pnlSelect.Visible = false;
        }
        else
        {
            pnlSelect.Visible = true;
        }
    }

    protected void chklstSelect_SelectedIndexChanged(object sender, EventArgs e)
    {
        SetEnabled();
    }

    /// <summary>
    /// 根据复选框事件所得到的值来控制相关控件的显隐藏
    /// </summary>
    private void SetEnabled()
    {
        try
        {
            string selectText = CheckBoxListState(chklstSelect);
            //当机构被选择时
            if (selectText.IndexOf("0") >= 0)
            {
                CascadingDropDownBranch.Enabled = true;
                ddlBranchs.Enabled = true;
                if (selectText.IndexOf("0") < 0)
                {
                    chklstSelect.Items[0].Selected = true;
                    selectText = CheckBoxListState(chklstSelect).Trim();
                }
            }
            else
            {

                CascadingDropDownBranch.Enabled = false;
                ddlBranchs.Enabled = false;
            }
            //当部门被选择
            if (selectText.IndexOf("1") >= 0)
            {
                CascadingDropDownDepart.Enabled = true;
                ddlDeparts.Enabled = true;
                if (selectText.IndexOf("0") < 0)
                {
                    chklstSelect.Items[0].Selected = true;
                    selectText = CheckBoxListState(chklstSelect).Trim();
                }
                //当机构被选择时
                if (selectText.IndexOf("0") >= 0)
                {
                    CascadingDropDownBranch.Enabled = true;
                    ddlBranchs.Enabled = true;
                    if (selectText.IndexOf("0") < 0)
                    {
                        chklstSelect.Items[0].Selected = true;
                        selectText = CheckBoxListState(chklstSelect).Trim();
                    }
                }
                else
                {

                    CascadingDropDownBranch.Enabled = false;
                    ddlBranchs.Enabled = false;
                }

            }
            else
            {

                CascadingDropDownDepart.Enabled = false;
                ddlDeparts.Enabled = false;
            }


            //当按员工号被选择时
            if (selectText.IndexOf("2") >= 0)
                txtUserId.Enabled = true;
            else
            {
                txtUserId.Text = "";
                txtUserId.Enabled = false;
            }

            //当按姓名被选择时
            if (selectText.IndexOf("3") >= 0)
                txtUserName.Enabled = true;
            else
            {
                txtUserName.Text = "";
                txtUserName.Enabled = false;
            }
        }
        catch
        {
            CascadingDropDownBranch.Enabled = false;
            ddlBranchs.Enabled = false;
            CascadingDropDownDepart.Enabled = false;
            ddlDeparts.Enabled = false;
            txtUserId.Enabled = false;
            txtUserName.Enabled = false;
        }


    }
    /// <summary>
    /// 返回复选框备选状态
    /// </summary>
    /// <returns></returns>
    private string CheckBoxListState(CheckBoxList cblObj)
    {
        string selectText = null;
        for (int i = 0; i < cblObj.Items.Count; i++)
        {
            if (cblObj.Items[i].Selected)
            {
                selectText += cblObj.Items[i].Value + " ";
            }
        }
        return selectText.Trim();
    }

    /// <summary>
    /// “确定范围”按钮
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnsearch_Click(object sender, EventArgs e)
    {
        IList<User> userList = UserManager.SearchUserByItem(ddlBranchs.SelectedValue, ddlDeparts.SelectedValue, txtUserId.Text.Trim(), txtUserName.Text.Trim());
        if (userList != null && userList.Count > 0)
        {
            hfCount.Value = userList.Count.ToString();
            chklstSelectUser.DataSource = userList;
            chklstSelectUser.DataBind();
            chklstSelectUser.DataTextField = "UserName";
            chklstSelectUser.DataValueField = "UserId";
            fild2.Style.Add("display", "block");
        }
        else
        {
            fild2.Style.Add("display", "none");
        }
    }
    /// <summary>
    /// “保存”按钮
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnSave_Click(object sender, EventArgs e)
    {

        if (Request.QueryString["MessageId"] != null)
        {
            //修改
            int messageId = Convert.ToInt32(Request.QueryString["MessageId"]);

            Message message = MessageManager.GetMessageById(messageId);
            message.Title = txtTitle.Text.ToString();
            message.Content = txtContent.Text.ToString();
            message.BeginTime = Convert.ToDateTime(txtBeginTime.Text);
            message.EndTime = Convert.ToDateTime(txtEndTime.Text);
            int typeId = Convert.ToInt32(ddlMessageType.SelectedValue);
            message.Type = MessageTypeManager.GetMessageTypeById(typeId);
            MessageManager.UpdateMessage(message);
            Response.Redirect("MessageManage.aspx");
        }
        else
        {
            try
            {
                //添加
                User user = (User)Session["Login"];
                Message item = new Message();
                item.Title = txtTitle.Text;
                item.BeginTime = Convert.ToDateTime(txtBeginTime.Text);
                item.EndTime = Convert.ToDateTime(txtEndTime.Text);
                item.Type.MessageTypeId = Convert.ToInt32(ddlMessageType.SelectedValue);
                item.Content = txtContent.Text;
                item.FromUser.UserId = user.UserId;
                item.RecordTime = DateTime.Now;
                item.IfPublish = 0;
                item.IfDelete = 0;
                item.IfDeleteTo = 0;
                int messageId = MessageManager.AddMessage(item);
                if (messageId > 0)
                {
                    if (rdoSendObj.SelectedValue == "0") //公共消息
                    {
                        MessageToUser messageToUser = new MessageToUser();
                        messageToUser.Message.MessageId = messageId;
                        messageToUser.ToUser.UserId = "0";
                        messageToUser.IfRead = 0;
                        bool result = MessageToUserManager.AddMessageToUser(messageToUser);
                        if (result)
                        {
                            Response.Redirect("MessageManage.aspx");
                        }
                    }
                    else if (rdoSendObj.SelectedValue == "1")   //添加特定对象消息
                    {
                        foreach (ListItem li in chklstSelectUser.Items) //循环特定的对象
                        {
                            if (li.Selected)
                            {
                                MessageToUser messageToUser = new MessageToUser();
                                messageToUser.Message.MessageId = messageId;
                                messageToUser.IfRead = 0;
                                messageToUser.ToUser.UserId = li.Value;
                                bool result = MessageToUserManager.AddMessageToUser(messageToUser);
                            }
                             
                        }
                        Response.Redirect("MessageManage.aspx");
                    }
                }
            }
            catch (Exception ex)
            {
            }
            
        }
    }
}
