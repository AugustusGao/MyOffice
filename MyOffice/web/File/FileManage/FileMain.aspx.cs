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
using System.IO;
using System.Collections.Generic;


public partial class File_FileManage_FileMain : System.Web.UI.Page
{
    /// <summary>
    /// 本页面对应上级文件夹的fileId
    /// </summary>
    public string Page_FileId = "";


    protected void Page_Load(object sender, EventArgs e)
    {

        try
        {

            string fileIdStr = Convert.ToString(Request.QueryString["fileId"]);

            Page_FileId = fileIdStr;

            int fileId = int.Parse(fileIdStr);
            if (fileId == 0)
            {
                this.txtFolderPath.Text = "文件管理" + "\\";
                this.imgbtnUp.Enabled = false;
            }
            else
            {
                this.imgbtnUp.Enabled = true;
                //找到页面所对应的上级文件夹对象  得到本页面的上一级文件夹ID  并为界面中“上一级”按钮赋URL
                MyOffice.Models.FileInfo file = FileInfoManager.GetFileByFileId(fileId);
                this.imgbtnUp.PostBackUrl = "FileMain.aspx?fileId=" + file.ParentId + "&fileTypeId=1";


                if (file == null)
                {
                    this.txtFolderPath.Text = "文件管理" + "\\";
                }
                else
                {
                    this.txtFolderPath.Text = file.FilePath + "\\";
                }
            }
            //没有修改当前文件路径的情况下 禁用转到按钮
            this.imgbtnGoto.Enabled = false;

        }
        catch (Exception ex)
        {

            if (!IsPostBack)
            {
                Response.Redirect("FileMain.aspx?fileId=0&fileTypeId=1");
            }
        }

        //给更改当前所在界面所需的树绑定事件
        (this.FolderTree1.FindControl("tvFolder") as TreeView).SelectedNodeChanged += new EventHandler(ChangeFileTree);

        if (!IsPostBack)
        {
            BindTV();
        }



    }


    /// <summary>
    /// 递归添加节点（只添加文件夹）
    /// </summary>
    /// <param name="parentId">父节点ID</param>
    /// <param name="treeNodeCollection">需要被添加节点的节点</param>
    private void CreateNode(int parentId, TreeNodeCollection treeNodeCollection)
    {
        IList<MyOffice.Models.FileInfo> lists = FileInfoManager.GetFolderByParentId(parentId);
        foreach (MyOffice.Models.FileInfo fileInfo in lists)
        {
            //生成树的节点
            TreeNode tn = new TreeNode(fileInfo.FileName, fileInfo.FileId.ToString(), fileInfo.FileType.FileTypeImage.Replace("../../", "~/"));
            CreateNode(fileInfo.FileId, tn.ChildNodes);
            treeNodeCollection.Add(tn);
        }
    }


    /// <summary>
    /// 绑定移动文件的TreeView
    /// </summary>

    private void BindTV()
    {

        int a = tvMove.Nodes.Count;
        TreeNode tn = new TreeNode("文件管理", "0", "~/images/folder.gif");

        this.tvMove.Nodes.Add(tn);
        int parentId = 0;
        CreateNode(parentId, tn.ChildNodes);

    }









    /// <summary>
    /// 在磁盘中移动文件
    /// </summary>
    /// <param name="filePath">文件的源路径</param>
    /// <param name="moveToPath">目标路径</param>
    private void MoveFile(string filePath, string moveToPath)
    {
        try
        {
            Directory.CreateDirectory(moveToPath);
            if (File.Exists(moveToPath + Path.DirectorySeparatorChar + Path.GetFileName(filePath)))
            {
                File.Delete(moveToPath + Path.DirectorySeparatorChar + Path.GetFileName(filePath));
            }
            File.Move(filePath, moveToPath + Path.DirectorySeparatorChar + Path.GetFileName(filePath));
        }
        catch (Exception ex)
        {

            throw;
        }
    }
    /// <summary>
    /// 在磁盘中移动文件夹
    /// </summary>
    /// <param name="filePath">文件夹的源路径</param>
    /// <param name="moveToPath">目标路径</param>
    private bool MoveFolder(string filePath, string moveToPath)
    {
        try
        {
            Directory.CreateDirectory(moveToPath);

            //下面所有的代码都是在路径正确的情况下(即盘符路径间的分隔符为"\")
            string filename = Path.GetFileName(filePath); //获得要移动的文件夹名(将在目标路径创建个此名字命名的文件夹)
            //判断路径结尾是否是"\"  没有就加上去  path为处理过的正确的目标路径
            string path = (moveToPath.LastIndexOf(Path.DirectorySeparatorChar) == moveToPath.Length - 1) ? moveToPath : moveToPath + Path.DirectorySeparatorChar;
            if (Path.GetPathRoot(filePath) == Path.GetPathRoot(moveToPath))
            {
                if (Directory.Exists(path + filename))
                {
                    Directory.Delete(path + filename, true);
                }
                Directory.Move(filePath, path + filename);
            }
            else
            {
                string parent = Path.GetDirectoryName(filePath);
                Directory.CreateDirectory(path + Path.GetFileName(filePath));
                DirectoryInfo dir = new DirectoryInfo((filePath.LastIndexOf(Path.DirectorySeparatorChar) == filePath.Length - 1) ? filePath : filePath + Path.DirectorySeparatorChar);
                FileSystemInfo[] fileArr = dir.GetFileSystemInfos();
                Queue<FileSystemInfo> Folders = new Queue<FileSystemInfo>(dir.GetFileSystemInfos());
                //循环源路径下的所有文件
                while (Folders.Count > 0)
                {
                    FileSystemInfo tmp = Folders.Dequeue();
                    //转换为文件
                    System.IO.FileInfo f = tmp as System.IO.FileInfo;
                    //为空即是文件夹  创建文件夹
                    if (f == null)
                    {
                        DirectoryInfo d = tmp as DirectoryInfo;
                        DirectoryInfo dpath = new DirectoryInfo(d.FullName.Replace((parent.LastIndexOf(Path.DirectorySeparatorChar) == parent.Length - 1) ? parent : parent + Path.DirectorySeparatorChar, path));
                        dpath.Create();
                        foreach (FileSystemInfo fi in d.GetFileSystemInfos())
                        {
                            Folders.Enqueue(fi);
                        }
                    }
                    //否则移动文件
                    else
                    {
                        f.MoveTo(f.FullName.Replace(parent, path));
                    }
                }
                //最后清空源路径的文件夹
                Directory.Delete(filePath, true);
            }
            return true;
        }
        catch (Exception ex)
        {

            return false;
        }
    }


    void ChangeFileTree(object sender, EventArgs e)
    {
        TreeView tv = (this.FolderTree1.FindControl("tvFolder") as TreeView);
        int fileId = Convert.ToInt32(tv.SelectedValue);
        //获得选中文件夹对象
        MyOffice.Models.FileInfo file = FileInfoManager.GetFileByFileId(fileId);
        if (file == null)
        {
            this.txtFolderPath.Text = "文件管理" + "\\";
        }
        else
        {
            this.txtFolderPath.Text = file.FilePath + "\\";
        }
        //启用转到按钮
        this.imgbtnGoto.Enabled = true;
        this.imgbtnGoto.PostBackUrl = "FileMain.aspx?fileId=" + file.FileId;
    }
    protected void gvFile_RowDataBound(object sender, GridViewRowEventArgs e)
    {


        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            int fileTypeId = Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "FileType.fileTypeId").ToString());
            int fileId = Convert.ToInt32(this.gvFile.DataKeys[e.Row.RowIndex].Value.ToString());
            HyperLink hlFile = e.Row.FindControl("hlFileName") as HyperLink;
            //如果此行显示的是文件夹则“名称”的超链接连接到此文件夹下的目录
            if (fileTypeId == 1)
            {


                hlFile.NavigateUrl = "FileMain.aspx?fileId=" + fileId + "&fileTypeId=" + fileTypeId;
            }
            //如果是文件则连接到文件详细界面
            else
            {
                hlFile.NavigateUrl = "FileDetails.aspx?fileId=" + fileId;
            }

            ImageButton delbtn = e.Row.FindControl("ImageButton3") as ImageButton;
            delbtn.Attributes.Add("onclick", "return confirm('确定要删除吗？')");
        }

    }
    protected void gvFile_RowCommand(object sender, GridViewCommandEventArgs e)
    {



        int a = this.gvFile.SelectedIndex;

        if (e.CommandName == "details")
        {
            int fileId = Convert.ToInt32(e.CommandArgument.ToString());
            MyOffice.Models.FileInfo file = FileInfoManager.GetFileByFileId(fileId);
            //判断是链接到文件详细还是文件夹详细
            if (file.FileType.FileTypeId == 1)
            {
                Response.Redirect("FolderDetails.aspx?fileId=" + file.FileId);
            }
            else
            {
                Response.Redirect("FileDetails.aspx?fileId=" + file.FileId);
            }
        }
        else if (e.CommandName=="del")
        {
            int fileId = Convert.ToInt32(e.CommandArgument.ToString());
            FileInfoManager.update_IfDelete_ByFileId(fileId);
            this.gvFile.DataBind();
        }
    }

    protected void imgbtnNewFile_Click(object sender, ImageClickEventArgs e)
    {

        Response.Redirect("FileDetails.aspx?parentId=" + Page_FileId);
    }
    protected void imgbtnUp_Click(object sender, ImageClickEventArgs e)
    {

    }

    protected void imgbtnMove_ServerClick(object sender, ImageClickEventArgs e)
    {


        HtmlInputImage imgbtnMove = sender as HtmlInputImage;
        ViewState["Move_FileId"] =
            this.gvFile.DataKeys[Convert.ToInt32(imgbtnMove.Value) - 1].Value.ToString();

        MyOffice.Models.FileInfo file = FileInfoManager.GetFileByFileId(Convert.ToInt32(this.gvFile.DataKeys[Convert.ToInt32(imgbtnMove.Value) - 1].Value));
        this.txtMoveFileName.Text = file.FileName;

    }




    protected void tvMove_SelectedNodeChanged(object sender, EventArgs e)
    {
        int fileId = Convert.ToInt32(this.tvMove.SelectedValue);
        MyOffice.Models.FileInfo file = FileInfoManager.GetFileByFileId(fileId);

        if (file == null)
        {
            this.txtMove.Text = "文件管理" + "\\";
        }
        else
        {
            this.txtMove.Text = file.FilePath + "\\";
        }
        this.btnMove.Enabled = true;
        ViewState["moveTo_FileId"] = fileId;
    }
    //移动
    protected void btnMove_Click(object sender, EventArgs e)
    {
        try
        {
            //被移动的文件夹
            MyOffice.Models.FileInfo move_File = FileInfoManager.GetFileByFileId(Convert.ToInt32(ViewState["Move_FileId"]));
            if (!ViewState["Move_FileId"].ToString().Equals(ViewState["moveTo_FileId"].ToString()))
            {
                IList<int> childFileLists = new List<int>();
                FileInfoManager.GetAllChildByFileId(childFileLists, move_File.FileId);
                if (!childFileLists.Contains(Convert.ToInt32(ViewState["moveTo_FileId"])))
                {
                    //移动到的文件夹
                    MyOffice.Models.FileInfo moveTo_File = FileInfoManager.GetFileByFileId(Convert.ToInt32(ViewState["moveTo_FileId"]));

                    //移动磁盘中的文件或文件夹
                    if (move_File.FileType.FileTypeId == 1)
                    {
                        MoveFolder(IniFile.IniReadValue(((MyOffice.Models.User)Session["Login"]).UserId) + move_File.FilePath, IniFile.IniReadValue(((MyOffice.Models.User)Session["Login"]).UserId) + moveTo_File.FilePath);
                    }
                    else
                    {
                        MoveFile(IniFile.IniReadValue(((MyOffice.Models.User)Session["Login"]).UserId) + move_File.FilePath, IniFile.IniReadValue(((MyOffice.Models.User)Session["Login"]).UserId) + moveTo_File.FilePath);
                    }

                    //判断是否是根目录  
                    string fileName = move_File.FilePath.Substring(move_File.FilePath.LastIndexOf("\\") + 1);
                    if (moveTo_File == null)
                    {
                        move_File.ParentId = 0;
                        move_File.FilePath = fileName;
                    }
                    else
                    {
                        move_File.ParentId = moveTo_File.FileId;
                        move_File.FilePath = moveTo_File.FilePath + "\\" + fileName;
                    }

                    //移动文件 即修改文件的父ID 和FilePath
                    FileInfoManager.MoveFile(move_File);
                    ViewState["Move_FileId"] = null;
                    ViewState["moveTo_FileId"] = null;
                    this.txtMove.Text = "";
                    this.txtMoveFileName.Text = "";
                    this.btnMove.Enabled = false;
                    this.gvFile.DataBind();
                    this.Page.ClientScript.RegisterStartupScript(this.GetType(), "", "<script>alert('移动成功！');location='FileMain.aspx?fileId=" + Request.QueryString["fileId"] + "'</script>");
                }
                else
                {
                    this.Page.ClientScript.RegisterStartupScript(this.GetType(), "", "<script>alert('移动失败：目标文件是源文件夹的子文件夹！');location='FileMain.aspx?fileId=" + Request.QueryString["fileId"] + "'</script>");
                }
            }
            else
            {
                this.Page.ClientScript.RegisterStartupScript(this.GetType(), "", "<script>alert('移动失败：目标文件和源文件夹相同！');location='FileMain.aspx?fileId=" + Request.QueryString["fileId"] + "'</script>");
            }
        }
        catch (Exception ex)
        {
            this.Page.ClientScript.RegisterStartupScript(this.GetType(), "", "<script>alert('移动失败！');location='FileMain.aspx?fileId=" + Request.QueryString["fileId"] + "'</script>");
        }
    }
    protected void imgbtnNewFolder_Click(object sender, ImageClickEventArgs e)
    {
        Response.Redirect("FolderDetails.aspx?parentId=" + Page_FileId);
    }
}
