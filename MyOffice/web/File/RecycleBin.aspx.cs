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

public partial class File_RecycleBin : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        
    }
    protected void gvFileDelete_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName=="revert")
        {
            int fileId = Convert.ToInt32(e.CommandArgument);
            FileInfoManager.revert_IfDelete_ByFileId(fileId);
            this.gvFileDelete.DataBind();
        }
        else if (e.CommandName == "del")
        {
            try
            {
                int fileId = Convert.ToInt32(e.CommandArgument);
                FileInfo file = FileInfoManager.GetFileByFileId(fileId);
                //从本地删除文件(夹)
                if (file.FileType.FileTypeId==1)
                {
                    System.IO.Directory.Delete(IniFile.IniReadValue(((MyOffice.Models.User)Session["Login"]).UserId) + file.FilePath, true);
                }
                else
                {
                    System.IO.File.Delete(IniFile.IniReadValue(((MyOffice.Models.User)Session["Login"]).UserId)+file.FilePath);
                }
                //将要删除的子(子)文件集合   如果被删除的是文件  delLists.count为0
                IList<int> delLists = new List<int>();
                FileInfoManager.GetAllChildByFileId(delLists, fileId);
                //先删除本文件(夹)
                FileInfoManager.DelFileById(fileId);
                //如果是文件夹则要删除其下所有文件(夹)
                foreach (int delFileId in delLists)
                {
                    FileInfoManager.DelFileById(delFileId);
                }
                this.Page.ClientScript.RegisterStartupScript(this.GetType(), "", "<script>alert('删除成功！');location='RecycleBin.aspx'</script>");
            }
            catch
            {

                this.Page.ClientScript.RegisterStartupScript(this.GetType(), "", "<script>alert('删除失败！');location='RecycleBin.aspx'</script>");
            }
        }
    }
    
    protected void gvFileDelete_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType==DataControlRowType.DataRow)
        {
              ImageButton imgbtn = e.Row.FindControl("imgbtnDelete") as ImageButton;
        imgbtn.Attributes.Add("onclick", "return confirm('您确定要删除吗?')");
        }
    }
}
