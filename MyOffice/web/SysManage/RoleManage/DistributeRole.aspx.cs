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

public partial class SysManage_RoleManage_DistributeRole : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
       
        BindPage();
    }

    private void BindPage()
    {
        int roleId = Convert.ToInt32(Request.QueryString["roleId"]);
        IList<SysFun> parentLists = SysFunManager.GetParentNodeByRoleId(roleId);
        IList<SysFun> sysLists = SysFunManager.GetAllParentSys();
        ArrayList currentSysLists = new ArrayList();
        foreach (SysFun currentSys in parentLists)
        {
            currentSysLists.Add(currentSys.NodeId.ToString());
        }
        foreach (SysFun sys in sysLists)
        {
           RoleUserControl ruc= LoadControl("~/UserControl/RoleUserControl.ascx") as RoleUserControl;
           
            //父节点
           CheckBox parentcb = ruc.FindControl("chkParentMenu") as CheckBox;
           ruc.RoleId = roleId;
           ruc.ParentNodeId = sys.NodeId;
           parentcb.Text = sys.DisplayName;
            //因为JS通过控件ID控制复选框的原因  不能为下面的控件设ID
          // parentcb.ID = sys.NodeId.ToString();
           if (currentSysLists.Contains(sys.NodeId.ToString()))
           {
               parentcb.Checked = true;
           }

           this.phRoleDistribute.Controls.Add(ruc);
        }
    }

    //保存
    protected void btnSave_Click(object sender, EventArgs e)
    {

        try
        {
            int roleId = Convert.ToInt32(Request.QueryString["roleId"]);
            RoleRightManager.delRoleRightByRoleId(roleId);
            ArrayList selectedSysLists = new ArrayList();
            foreach (Control cn in this.phRoleDistribute.Controls)
            {
                RoleUserControl ruc = cn as RoleUserControl;
                CheckBox parentcb = ruc.FindControl("chkParentMenu") as CheckBox;
                if (parentcb.Checked)
                {
                    selectedSysLists.Add(ruc.ParentNodeId);
                }
                CheckBoxList cbl = ruc.FindControl("chklstChildMenu") as CheckBoxList;
                foreach (ListItem li in cbl.Items)
                {
                    if (li.Selected)
                    {
                        selectedSysLists.Add(li.Value);
                    }
                }
            }


            foreach (object nodeIdObj in selectedSysLists)
            {
                int nodeId = Convert.ToInt32(nodeIdObj);
                RoleRightManager.AddRight(roleId, nodeId);
            }
            this.Page.ClientScript.RegisterStartupScript(this.GetType(), "", "<script>alert('修改成功！');location='RoleManage.aspx'</script>");
            
        }
        catch (Exception ex)
        {

            this.Page.ClientScript.RegisterStartupScript(this.GetType(), "", "<script>alert('修改失败！');location='RoleManage.aspx'</script>");
        }
      
    }
}
