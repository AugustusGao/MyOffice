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

public partial class File_FileManage_FileTree : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            TreeNode tn = new TreeNode("文件管理", "0", "~/images/folder.gif");
            tn.NavigateUrl = "FileMain.aspx?fileId=0&fileTypeId=1";
            this.tvFile.Nodes.Add(tn);
            int parentId = 0;
            CreateNode(parentId, tn.ChildNodes);
        }
    }

    /// <summary>
    /// 递归添加节点
    /// </summary>
    /// <param name="parentId">父节点ID</param>
    /// <param name="treeNodeCollection">需要被添加节点的节点</param>
    private void CreateNode(int parentId, TreeNodeCollection treeNodeCollection)
    {
        IList<FileInfo> lists = FileInfoManager.GetFileByParentId(parentId);
        foreach (FileInfo fileInfo in lists)
        {
            //生成树的节点
            TreeNode tn = new TreeNode(fileInfo.FileName, fileInfo.FileId.ToString(), fileInfo.FileType.FileTypeImage);
            if (fileInfo.FileType.FileTypeId == 1)
            {
                //链接到文件夹显示界面
                tn.NavigateUrl = "FileMain.aspx?fileId=" + fileInfo.FileId + "&fileTypeId=1";
            }
            else
            {
                //跳转到文件详细页面
                tn.NavigateUrl = "FileDetails.aspx?fileId=" + fileInfo.FileId;
            }
            CreateNode(fileInfo.FileId, tn.ChildNodes);
            treeNodeCollection.Add(tn);
        }
    }



   
}
