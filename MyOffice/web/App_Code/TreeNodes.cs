using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
  public class TreeNodes
    {
        /// <summary>
        /// 把子节点添加到父节点当中
        /// </summary>
        /// <param name="fatherNode">父节点</param>
        /// <param name="childNode">字节点</param>
        public static void AddTree(TreeNode fatherNode, TreeNode childNode)
        {
            fatherNode.ChildNodes.Add(childNode);
        }

        /// <summary>
        /// 创建一个树节点,返回一个树节点对象
        /// </summary>
        /// <param name="strText">节点名称</param>
        /// <param name="strId">节点ID</param>
        /// <param name="strUrl">链接地址</param>
        /// <param name="strImg">表示不可展开时的图片（TreeView1.NoExpandImageUrl = "~/Images/CloseTree.gif";)</param>
        /// <param name="imgToolTip">获取或设置在节点旁边显示图片的工具提示文本</param>
        /// <param name="toolTip">获取或设置节点的工具提示文本</param>
        /// <returns></returns>
        public static TreeNode CreateTreeNode(string strText, string strId, string strUrl, string strImg,string imgToolTip,string toolTip)
        {
            TreeNode newNode = new TreeNode();
            newNode.Text = strText;
            newNode.Value = strId;
            newNode.NavigateUrl = strUrl;
            newNode.ImageUrl = strImg;
            newNode.ImageToolTip= imgToolTip;
            newNode.ToolTip = toolTip;
            return newNode;
        }
    }
