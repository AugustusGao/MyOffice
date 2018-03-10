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
using MyOffice.DAL;
using MyOffice.BLL;

public partial class PersonManage_SaveDepart : System.Web.UI.Page
{
    
    /// <summary>
    /// 窗体的加载事件
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
           
           ShowDepartInfo();
        }
        TreeView tv = this.UserTree1.FindControl("tvUser") as TreeView; //用户控件TreeView
        tv.SelectedNodeChanged += new EventHandler(tv_SelectedNodeChanged);
    }

    protected void tv_SelectedNodeChanged(object sender, EventArgs e)
    {
        TreeView tv = this.UserTree1.FindControl("tvUser") as TreeView; //用户控件TreeView
        if (tv.SelectedNode.Depth == 2)
        {
            txtPricipalUser.Text = tv.SelectedNode.Text;
            hfUserId.Value = tv.SelectedNode.ToString();
        }
        else
        {
            Page.ClientScript.RegisterStartupScript(typeof(string), "", "<script>alert('您选择的不是人员，请重新选择！')</script>");
        }
    }
    /// <summary>
    /// 修改时显示部门信息
    /// </summary>
    private void ShowDepartInfo()
    {
        if (Request.QueryString["departId"] != null)
        {
            int departId = Convert.ToInt32(Request.QueryString["departId"]);
            Depart depart = DepartInfoService.GetDepartGetById(departId);
            this.txtDepartName.Text = depart.DepartName;
            this.txtConnectTelNo.Text = depart.ConnectTelNo.ToString();
            this.txtMobileTelNo.Text = depart.ConnectMobileTelNo.ToString();
            this.txtPricipalUser.Text = depart.PrincipalUser.UserName.ToString();
            this.ddlBranch.SelectedValue = depart.Branch.BranchId.ToString();
            this.txtFaxes.Text = depart.Faxes.ToString();
        }

    }
  
    /// <summary>
    /// 保存按钮
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnSave_Click(object sender, EventArgs e)
    {
        try
        {
            if (Request.QueryString["departId"] != null)
            {
                //修改

                User user = UserManager.GetUserByUserName(this.txtPricipalUser.Text);
                Depart item = new Depart();
                item.DepartName = this.txtDepartName.Text;
                item.PrincipalUser.UserId = user.UserId.ToString();
                item.Branch.BranchId = Convert.ToInt32(this.ddlBranch.SelectedValue);
                item.ConnectMobileTelNo = long.Parse(this.txtMobileTelNo.Text);
                item.ConnectTelNo = long.Parse(this.txtConnectTelNo.Text);
                item.Faxes = long.Parse(this.txtFaxes.Text);
                item.DepartId = Convert.ToInt32(Request.QueryString["departId"]);
                DepartInfoService.UpdateDepart(item);
            }
            else
            {
                //添加

                User user = UserManager.GetUserByUserName(this.txtPricipalUser.Text);
                Depart item = new Depart();
                item.DepartName = this.txtDepartName.Text;
                item.PrincipalUser.UserId = user.UserId.ToString();
                item.Branch.BranchId = Convert.ToInt32(this.ddlBranch.SelectedValue);
                item.ConnectMobileTelNo = long.Parse(this.txtMobileTelNo.Text);
                item.ConnectTelNo = long.Parse(this.txtConnectTelNo.Text);
                item.Faxes = long.Parse(this.txtFaxes.Text);
                DepartInfoService.AddDepart(item);
            }
        }
        catch (Exception ex)
        {
            ex.Message.ToString();
        }
        finally
        {
            Response.Redirect("DepartManage.aspx");
        }
    }

}
