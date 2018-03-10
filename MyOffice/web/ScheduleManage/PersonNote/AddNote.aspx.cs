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
using MyOffice.BLL;

public partial class ScheduleManage_PersonNote_AddNote : System.Web.UI.Page
{
    int noteId = 0;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            User user = (User)Session["Login"];
            if (user == null)
            {
                Response.Redirect("~/Login.aspx");
            }
            else{

                if (Request.QueryString["noteId"] != null)
                {
                    noteId = Convert.ToInt32(Request.QueryString["noteId"]);
                    MyNote myNote = MyNoteManager.GetMyNoteById(noteId);
                    this.txtTitle.Text = myNote.NoteTitle;
                    this.txtContent.Text = myNote.NoteContent;
                    this.lblUserId.Text = myNote.CreateUser.UserName;
                    this.lblTime.Text = Convert.ToString(myNote.CreateTime.ToShortDateString());
                    this.btnDelete.Enabled = true;
                }
                else
                {
                    this.btnDelete.Enabled = false;
                    this.lblUserId.Text = user.UserName;
                    this.lblTime.Text = DateTime.Now.ToShortDateString();
                }
            
            }
        }
       
    }
    /// <summary>
    /// 添加便签信息和修改便签信息
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnSave_Click(object sender, EventArgs e)
    {
      if(Page.IsValid){

          //添加便签信息
          if (Request.QueryString["noteId"]== null)
          {
              MyNote myNote = new MyNote();
              User user = (User)Session["Login"];
              myNote.NoteTitle = this.txtTitle.Text.Trim();
              myNote.NoteContent = this.txtContent.Text.Trim();
              myNote.CreateTime = Convert.ToDateTime(this.lblTime.Text);
              myNote.CreateUser.UserId = user.UserId;
              int num = MyNoteManager.AddMyNote(myNote);
              if (num > 0)
              {

                  Response.Redirect("PersonNote.aspx");
              }
              else
              {
                  this.lblMessage.Text = "保存失败！";

              }
          }
          //修改便签信息
          if (Request.QueryString["noteId"] != null)
            {
              noteId = Convert.ToInt32(Request.QueryString["noteId"]);
       
              MyNote myNote = new MyNote();
              myNote.NoteTitle = this.txtTitle.Text.Trim();
              myNote.NoteContent = this.txtContent.Text.Trim();
              myNote.NoteId = noteId;
              int count = MyNoteManager.ModifyMyNoteById(myNote);
              if (count > 0)
              {
                  this.btnDelete.Enabled = true;
                  Response.Redirect("PersonNote.aspx");
              }
              else
              {
                  this.lblMessage.Text = "修改失败！";

              }
          }
        }
    }
    /// <summary>
    /// 删除便签信息
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnDelete_Click(object sender, EventArgs e)
    {
        if (Request.QueryString["noteId"] != null)
        {
            noteId = Convert.ToInt32(Request.QueryString["noteId"]);
            int i = MyNoteManager.DeleteMyNoteById(noteId);

            if (i > 0)
            {
                Response.Redirect("PersonNote.aspx");
            }
            else
            {
                this.lblMessage.Text = "删除失败！";

            }
        }
    }
}
