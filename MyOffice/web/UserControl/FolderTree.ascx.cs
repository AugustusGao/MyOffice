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

public partial class UserControl_FolderTree : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            TreeNode tn = new TreeNode("文件管理", "0", "~/images/folder.gif");
           
            this.tvFolder.Nodes.Add(tn);
            int parentId = 0;
            CreateNode(parentId, tn.ChildNodes);
        }
    }

    /// <summary>
    /// 递归添加节点（只添加文件夹）
    /// </summary>
    /// <param name="parentId">父节点ID</param>
    /// <param name="treeNodeCollection">需要被添加节点的节点</param>
    private void CreateNode(int parentId, TreeNodeCollection treeNodeCollection)
    {
        IList<FileInfo> lists = FileInfoManager.GetFolderByParentId(parentId);
        foreach (FileInfo fileInfo in lists)
        {
            //生成树的节点
            TreeNode tn = new TreeNode(fileInfo.FileName, fileInfo.FileId.ToString(), fileInfo.FileType.FileTypeImage.Replace("../../","~/"));
            CreateNode(fileInfo.FileId, tn.ChildNodes);
            treeNodeCollection.Add(tn);
        }
    }
}
