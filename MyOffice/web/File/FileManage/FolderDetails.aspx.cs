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
using System.IO;
using System.Collections.Generic;

public partial class File_FileManage_FolderDetails : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {

            try
            {
                string fileIdStr = Request.QueryString["fileId"];
                //当前页面功能为显示文件夹信息
                if (fileIdStr != "" && fileIdStr != null)
                {
                    MyOffice.Models.FileInfo file = FileInfoManager.GetFileByFileId(Convert.ToInt32(fileIdStr));
                 //   this.imgbtnUp.PostBackUrl = "FileMain.aspx?fileId=" + file.ParentId + "&fileTypeId=1";
                    BindPage();
                }
                //当前页面功能为新增文件
                else
                {
                  //  this.imgbtnUp.PostBackUrl = "FileMain.aspx?fileId=" + Request.QueryString["parentId"] + "&fileTypeId=1";
                    this.btnExit.PostBackUrl = "FileMain.aspx?fileId=" + Request.QueryString["parentId"] + "&fileTypeId=1";
                    //获得当前文件的上级目录（文件夹）ID
                    int parentId = Convert.ToInt32(Request.QueryString["parentId"]);
                    //上级目录不是根目录  可以从数据库中查找
                    if (parentId != 0)
                    {
                        MyOffice.Models.FileInfo file = FileInfoManager.GetFileByFileId(parentId);
                        this.lblFilePath.Text = IniFile.IniReadValue(((User)Session["Login"]).UserId) + file.FilePath + "\\";
                    }
                    //上级目录是根目录   数据库中没有根目录的数据记录
                    else
                    {
                        this.lblFilePath.Text = IniFile.IniReadValue(((User)Session["Login"]).UserId);

                    }

                    this.lblFileOwer.Text = ((User)Session["Login"]).UserName;
                    this.lblCreateTime.Text = DateTime.Now.ToString();
                    //显示添加按钮隐藏修改按钮
                    this.imgbtnSave.Visible = true;
                    this.imgbtnSave.Enabled = true;
                    this.imgbtnUpdate.Visible = false;
                    this.imgbtnUpdate.Enabled = false;
                   
                }
            }
            catch (Exception ex)
            {

                Response.Redirect("~/index.aspx");
            }

        }
    }

 

    private void BindPage()
    {
        string fileIdStr = Request.QueryString["fileId"];
        MyOffice.Models.FileInfo file = FileInfoManager.GetFileByFileId(Convert.ToInt32(fileIdStr));
        this.txtFileName.Text = file.FileName;
        this.txtRemark.Text = file.Remark;
        this.lblCreateTime.Text = file.CreateDate.ToString();
        this.lblFileOwer.Text = file.FileOwner.UserName;
        this.lblFilePath.Text = IniFile.IniReadValue(((User)Session["Login"]).UserId) + file.FilePath;
        //显示修改按钮隐藏添加按钮
        this.imgbtnSave.Visible = false;
        this.imgbtnSave.Enabled = false;
        this.imgbtnUpdate.Visible = true;
        this.imgbtnUpdate.Enabled = true;
    }
    protected void imgbtnSave_Click(object sender, ImageClickEventArgs e)
    {
        try
        {
            //获得文件正确的地址
            string fullPath = this.lblFilePath.Text.ToString().Trim().Replace("/", Path.AltDirectorySeparatorChar.ToString())+this.txtFileName.Text;

            if (!Directory.Exists(fullPath))
            {
                Directory.CreateDirectory(fullPath);
            }
            string filePath = fullPath.Replace(IniFile.IniReadValue(((User)Session["Login"]).UserId), "") ;
            MyOffice.Models.FileInfo file = new MyOffice.Models.FileInfo();
            file.FileName = this.txtFileName.Text;
            file.IfDelete = 0;
            file.FileType.FileTypeId =1;
            file.FileOwner = ((User)Session["Login"]);
            file.Remark = this.txtRemark.Text;
            file.CreateDate = DateTime.Now;
            file.ParentId = Convert.ToInt32(Request.QueryString["parentId"]);
            file.FilePath = filePath;

            FileInfoManager.AddFile(file);

            this.Page.ClientScript.RegisterStartupScript(this.GetType(), "", "<script>alert('添加成功！');location='FileMain.aspx?fileId=" + Request.QueryString["parentId"] + "';</script>");
        }
        catch (Exception ex)
        {

            this.Page.ClientScript.RegisterStartupScript(this.GetType(), "", "<script>alert('添加失败！');location='FileMain.aspx?fileId=" + Request.QueryString["parentId"] + "';</script>");
        }
    }
    protected void imgbtnUpdate_Click(object sender, ImageClickEventArgs e)
    {
        MyOffice.Models.FileInfo file = FileInfoManager.GetFileByFileId(Convert.ToInt32(Request.QueryString["fileId"]));
        try
        {

            file.FileName = this.txtFileName.Text;
            file.FileType.FileTypeId = 1;
            file.Remark = this.txtRemark.Text;
          
            FileInfoManager.UpdateFile(file);
            this.Page.ClientScript.RegisterStartupScript(this.GetType(), "", "<script>alert('修改成功！');location='FolderDetails.aspx?fileId=" + file.FileId + "';</script>");
        }
        catch (Exception ex)
        {

            this.Page.ClientScript.RegisterStartupScript(this.GetType(), "", "<script>alert('修改失败！');location='FolderDetails.aspx?fileId=" + file.FileId + "';</script>");
        }
    }
    protected void imgbtnUp_Click(object sender, ImageClickEventArgs e)
    {
        this.txtFileName.Text = "-----";
        this.txtRemark.Text = "------";
    }
    protected void btnExit_Click1(object sender, ImageClickEventArgs e)
    {
        try
        {
            int fileId = Convert.ToInt32(Request.QueryString["fileId"]);
            MyOffice.Models.FileInfo file = FileInfoManager.GetFileByFileId(fileId);
            if (Directory.Exists(this.lblFilePath.Text))
            {
                Directory.Delete(this.lblFilePath.Text, true);
            }
            IList<int> childFileLists = new List<int>();
            FileInfoManager.GetAllChildByFileId(childFileLists, Convert.ToInt32(Request.QueryString["fileId"]));
            foreach (int delfileId in childFileLists)
            {
                FileInfoManager.DelFileById(delfileId);
            }
            FileInfoManager.DelFileById(Convert.ToInt32(Request.QueryString["fileId"]));
           
            Response.Redirect("FileMain.aspx?fileId=" + file.ParentId + "&fileTypeId=1");
        }
        catch (Exception ex)
        {
            
            throw;
        }
    }
}
