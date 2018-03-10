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
public partial class File_FileManage_FileDetails : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

        if (!IsPostBack)
        {
           
            BindRL();
            try
            {
                string fileIdStr = Request.QueryString["fileId"];
                //当前页面功能为显示文件信息
                if (fileIdStr != "" && fileIdStr != null)
                {
                    this.FileType.Style.Add("display", "none");
                    MyOffice.Models.FileInfo file = FileInfoManager.GetFileByFileId(Convert.ToInt32(fileIdStr));
                    this.imgbtnUp.PostBackUrl = "FileMain.aspx?fileId=" + file.ParentId + "&fileTypeId=1";
                    BindPage(fileIdStr);
                }
                //当前页面功能为新增文件
                else
                {
                    this.imgbtnUp.PostBackUrl = "FileMain.aspx?fileId=" + Request.QueryString["parentId"] + "&fileTypeId=1";
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
                    //启用验证文件上传控件的控件
                    RequiredFieldValidator4.Enabled = true;
                }
            }
            catch (Exception ex)
            {

                Response.Redirect("~/index.aspx");
            }

        }

    }
   
    /// <summary>
    /// 显示文件详细信息时绑定页面的空间
    /// </summary>
    /// <param name="fileIdStr"></param>
    private void BindPage(string fileIdStr)
    {
        int fileId = Convert.ToInt32(fileIdStr);
        MyOffice.Models.FileInfo file = FileInfoManager.GetFileByFileId(fileId);
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
        //不启用验证文件上传控件的控件
        RequiredFieldValidator4.Enabled = false;

        foreach (ListItem rdo in this.rboFileIcoList.Items)
        {
            if (file.FileType.FileTypeId.ToString() == rdo.Value)
            {
                rdo.Selected = true;
            }
        }
    }


    /// <summary>
    /// 绑定文件类型的RadioButtonList
    /// </summary>
    private void BindRL()
    {
        this.rboFileIcoList.DataSource = FileTypeManager.GetAllFileType();
        this.rboFileIcoList.DataTextField = "fileTypeImage";
        this.rboFileIcoList.DataTextFormatString = "&nbsp;<img  style=' vertical-align:middle' src='{0}'/>";
        this.rboFileIcoList.DataValueField = "FileTypeId";
        this.rboFileIcoList.DataBind();
    }

    /// <summary>
    /// 保存
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void imgbtnSave_Click(object sender, ImageClickEventArgs e)
    {
        try
        {
            //获得文件正确的地址
            string fullPath = this.lblFilePath.Text.ToString().Trim().Replace("/", Path.AltDirectorySeparatorChar.ToString());

            if (!Directory.Exists(fullPath))
            {
                Directory.CreateDirectory(fullPath);
            }
            string filePath = fullPath.Replace(IniFile.IniReadValue(((User)Session["Login"]).UserId), "") + this.fuFile.FileName;
            MyOffice.Models.FileInfo file = new MyOffice.Models.FileInfo();
            file.FileName = this.txtFileName.Text;
            file.IfDelete = 0;
            file.FileType = FileTypeManager.GetFileTypeById(Convert.ToInt32(this.rboFileIcoList.SelectedValue));
            file.FileOwner = ((User)Session["Login"]);
            file.Remark = this.txtRemark.Text;
            file.CreateDate = DateTime.Now;
            file.ParentId = Convert.ToInt32(Request.QueryString["parentId"]);
            file.FilePath = filePath;

            fuFile.SaveAs(fullPath + this.fuFile.FileName);

            FileInfoManager.AddFile(file);

            this.Page.ClientScript.RegisterStartupScript(this.GetType(), "", "<script>alert('添加成功！');location='FileMain.aspx?fileId=" + Request.QueryString["parentId"] + "';</script>");
        }
        catch (Exception ex)
        {

            this.Page.ClientScript.RegisterStartupScript(this.GetType(), "", "<script>alert('添加失败！');location='FileMain.aspx?fileId=" + Request.QueryString["parentId"] + "';</script>");
        }

    }
   
    /// <summary>
    /// 修改
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void imgbtnUpdate_Click(object sender, ImageClickEventArgs e)
    {
        MyOffice.Models.FileInfo file = FileInfoManager.GetFileByFileId(Convert.ToInt32(Request.QueryString["fileId"]));
        try
        {
            
            file.FileName = this.txtFileName.Text;
            file.FileType = FileTypeManager.GetFileTypeById(Convert.ToInt32(this.rboFileIcoList.SelectedValue));
            file.Remark = this.txtRemark.Text;
            if (fuFile.FileName != null && !"".Equals(fuFile.FileName))
            {

                File.Delete(IniFile.IniReadValue(((MyOffice.Models.User)Session["Login"]).UserId) + file.FilePath);
                //获得此文件的上级文件夹   为了得到上级文件夹的路径，来保存新的文件
                MyOffice.Models.FileInfo parentFile = FileInfoManager.GetFileByFileId(file.ParentId);
                //新文件的路径  (判断上级是否为空)
                if (parentFile==null)
                {
                    file.FilePath =  this.fuFile.FileName;
                }
                else
                {
                    file.FilePath = parentFile.FilePath + "\\" + this.fuFile.FileName;
                }
                fuFile.SaveAs(IniFile.IniReadValue(((MyOffice.Models.User)Session["Login"]).UserId) + file.FilePath);
                FileInfoManager.UpdateFileAndFilePath(file);
            }
            else
            {
                FileInfoManager.UpdateFile(file);
            }
            this.Page.ClientScript.RegisterStartupScript(this.GetType(), "", "<script>alert('修改成功！');location='FileDetails.aspx?fileId=" + file.FileId + "';</script>");
        }
        catch (Exception ex)
        {

            this.Page.ClientScript.RegisterStartupScript(this.GetType(), "", "<script>alert('修改失败！');location='FileDetails.aspx?fileId=" + file.FileId + "';</script>");
        }

    }
    protected void imgbtnUp_Click(object sender, ImageClickEventArgs e)
    {

    }
    protected void btnExit_Click(object sender, ImageClickEventArgs e)
    {
        try
        {
            int fileId = Convert.ToInt32(Request.QueryString["fileId"]);
            MyOffice.Models.FileInfo file = FileInfoManager.GetFileByFileId(fileId);
            if (File.Exists(this.lblFilePath.Text))
            {
                File.Delete(this.lblFilePath.Text);
            }
            FileInfoManager.DelFileById(fileId);
            Response.Redirect("FileMain.aspx?fileId=" + file.ParentId + "&fileTypeId=1");
        }
        catch (Exception ex)
        {

            throw;
        }
    }
}
