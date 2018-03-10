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
using AjaxControlToolkit;
using MyOffice.BLL;
using MyOffice.Models;
using System.Collections.Generic;

public partial class ManualSign_Search_ManualSignSearch : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

        if (!IsPostBack)
        {
            SetEnabled();
            CascadingDropDown CascadingDropDownBranch = this.BranchDepartDdlUC1.FindControl("CascadingDropDownBranch") as CascadingDropDown;
            CascadingDropDownBranch.Enabled = false;
            CascadingDropDown CascadingDropDownDepart = this.BranchDepartDdlUC1.FindControl("CascadingDropDownDepart") as CascadingDropDown;
            CascadingDropDownDepart.Enabled = false;
        }
    }
    protected void gvSearch_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            //获得("SignTag")
            int signTag = Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "SignTag"));
            e.Row.Cells[2].Text = signTag == 0 ? "签到" : "签退";
        }
    }
    #region 合并单元格
    protected void Unite(GridView gv)
    {
        string saveCell;//保存列
        int lastCell;//最终列     
        if (this.gvSearch.Rows.Count > 0)
        {
            for (int i = 0; i < 6; i++)
            {
                //排除不合并的单元格
                if (i != 1 && i != 2 && i != 3)
                {
                    Label begin = this.gvSearch.Rows[0].Cells[i].FindControl("Label" + (i + 1)) as Label;
                    saveCell = begin.Text;//获得第一行需合并数据
                    this.gvSearch.Rows[0].Cells[i].RowSpan = 1;//设初始合并值为1，每遇重复行自加并移动的新的行号获取数据
                    lastCell = 0;

                    for (int temp = 1; temp < this.gvSearch.Rows.Count; temp++)
                    {   //发现重复行将其合并
                        Label next = this.gvSearch.Rows[temp].Cells[i].FindControl("Label" + (i + 1)) as Label;
                        if (next.Text == saveCell)
                        {
                            this.gvSearch.Rows[temp].Cells[i].Visible = false;
                            this.gvSearch.Rows[lastCell].Cells[i].RowSpan++;//合并
                        }
                        else
                        {//下一条用户记录
                            saveCell = next.Text;//将其第一条记录保留，作为下一次比较用
                            lastCell = temp;//把行号保存
                            this.gvSearch.Rows[temp].Cells[i].RowSpan = 1;//开始新合并行
                        }
                    }
                }
            }
        }
    }
    #endregion
    protected void imgBtnSearch_Click(object sender, ImageClickEventArgs e)
    {
        TextBox txtBeginTime = this.ChoseTimeUC1.FindControl("txtBeginTime") as TextBox;
        TextBox txtEndTime = this.ChoseTimeUC1.FindControl("txtEndTime") as TextBox;
        DropDownList ddlBranchs = this.BranchDepartDdlUC1.FindControl("ddlBranchs") as DropDownList;
        DropDownList ddlDeparts = this.BranchDepartDdlUC1.FindControl("ddlDeparts") as DropDownList;
        string ddlBranchSelectedValue = ddlBranchs.Enabled == false ? "" : ddlBranchs.SelectedValue;
        string ddlDepartSelectedValue = ddlDeparts.Enabled == false ? "" : ddlDeparts.SelectedValue;
        IList<ManualSign> msList = ManualSignManager.SearchManualSignByCondition(
      txtBeginTime.Text.Trim(), txtEndTime.Text.Trim(), ddlBranchSelectedValue, ddlDepartSelectedValue, txtUserId.Text.Trim(), txtUserName.Text.Trim());
        if (msList != null)
        {
            if (msList.Count > 0)
            {
                ViewState["msList"] = msList;
                gvSearch.DataSource = msList;
                gvSearch.DataBind();
                Unite(gvSearch);
                divSearch.Visible = true;
            }
            else
            {
                divSearch.Visible = false;
            }

        }
    }
    /// <summary>
    /// 复选框选择事件
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void chklstSelect_SelectedIndexChanged(object sender, EventArgs e)
    {

        SetEnabled();

    }
    /// <summary>
    /// 根据复选框事件所得到的值来控制相关控件的显隐藏
    /// </summary>
    private void SetEnabled()
    {
        CascadingDropDown CascadingDropDownBranch = this.BranchDepartDdlUC1.FindControl("CascadingDropDownBranch") as CascadingDropDown;
        CascadingDropDown CascadingDropDownDepart = this.BranchDepartDdlUC1.FindControl("CascadingDropDownDepart") as CascadingDropDown;
        DropDownList ddlDeparts = this.BranchDepartDdlUC1.FindControl("ddlDeparts") as DropDownList;
        DropDownList ddlBranchs = this.BranchDepartDdlUC1.FindControl("ddlBranchs") as DropDownList;
        try
        {
            string selectText = CheckBoxListState(chklstSelect);
            int i = selectText.IndexOf("0");
            int ii = selectText.IndexOf("1");
            int iii = selectText.IndexOf("2");
            int iiii = selectText.IndexOf("3");
            //当机构被选择时
            if (selectText.IndexOf("0") >= 0)
            {
                CascadingDropDownBranch.Enabled = true;
                ddlBranchs.Enabled = true;
                if (selectText.IndexOf("0") < 0)
                {
                    chklstSelect.Items[0].Selected = true;
                    selectText = CheckBoxListState(chklstSelect).Trim();
                }
            }
            else
            {

                CascadingDropDownBranch.Enabled = false;
                ddlBranchs.Enabled = false;
            }
            //当部门被选择
            if (selectText.IndexOf("1") >= 0)
            {
                CascadingDropDownDepart.Enabled = true;
                ddlDeparts.Enabled = true;
                if (selectText.IndexOf("0") < 0)
                {
                    chklstSelect.Items[0].Selected = true;
                    selectText = CheckBoxListState(chklstSelect).Trim();
                }
                //当机构被选择时
                if (selectText.IndexOf("0") >= 0)
                {
                    CascadingDropDownBranch.Enabled = true;
                    ddlBranchs.Enabled = true;
                    if (selectText.IndexOf("0") < 0)
                    {
                        chklstSelect.Items[0].Selected = true;
                        selectText = CheckBoxListState(chklstSelect).Trim();
                    }
                }
                else
                {

                    CascadingDropDownBranch.Enabled = false;
                    ddlBranchs.Enabled = false;
                }

            }
            else
            {

                CascadingDropDownDepart.Enabled = false;
                ddlDeparts.Enabled = false;
            }


            //当按员工号被选择时
            if (selectText.IndexOf("2") >= 0)
                txtUserId.Enabled = true;
            else
            {
                txtUserId.Text = "";
                txtUserId.Enabled = false;
            }

            //当按姓名被选择时
            if (selectText.IndexOf("3") >= 0)
                txtUserName.Enabled = true;
            else
            {
                txtUserName.Text = "";
                txtUserName.Enabled = false;
            }
        }
        catch
        {
            CascadingDropDownBranch.Enabled = false;
            ddlBranchs.Enabled = false;
            CascadingDropDownDepart.Enabled = false;
            ddlDeparts.Enabled = false;
            txtUserId.Enabled = false;
            txtUserName.Enabled = false;
        }
    }
    /// <summary>
    /// 返回复选框备选状态
    /// </summary>
    /// <returns></returns>
    private string CheckBoxListState(CheckBoxList cblObj)
    {
        string selectText = null;
        for (int i = 0; i < cblObj.Items.Count; i++)
        {
            if (cblObj.Items[i].Selected)
            {
                selectText += cblObj.Items[i].Value + " ";
            }
        }
        return selectText.Trim();
    }
}
