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
using System.Collections.Generic;

public partial class ManualSign_ManualSign : System.Web.UI.Page
{

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            InitInterface();
            //先隐藏divExit  下面会有方法带它做判断的
            this.divExit.Visible = false;
        }
    }
    protected void InitInterface()
    {
        txtSignTime.Text = DateTime.Now.ToShortDateString();
        // txtSignDesc.Text = "";
        User u = Session["Login"] as User;
        //是否已经当天签退
        if (ManualSignManager.GetManualSignState(false, u.UserId) == 1)
        {
            btnSignIn.Enabled = true;
            btnSignOut.Enabled = false;
        }//是否已签到
        else if (ManualSignManager.GetManualSignState(true, u.UserId) == 1)
        {
            btnSignIn.Enabled = false;
            btnSignOut.Enabled = true;

        }
        else
        {
            btnSignIn.Enabled = true;
            btnSignOut.Enabled = false;
        }

        if (Session["Login"] != null)
        {
            IList<ManualSign> msList =
                ManualSignManager.
                SearchManualSignByCondition
                (string.Format("{0:yyyy-MM-dd 0:00:00}", DateTime.Now), string.Format("{0:yyyy-MM-dd 23:59:59}",
                DateTime.Now), null, u.DepartId.ToString(), u.UserId, null);
            if (msList.Count > 0)
            {
                FillManual(0, msList[0]);
                divExit.Visible = true;
            }
        }

    }
    /// <summary>
    /// 保存考勤信息
    /// </summary>
    /// <param name="fag">0签到 1签退</param>
    /// <returns></returns>
    private ManualSign Save(int fag)
    {
        ManualSign ms = new ManualSign();
        ms.User = (Session["Login"] as User);
        ms.SignTime = DateTime.Parse(DateTime.Now.ToString());
        ms.SignTag = fag;
        ms.SignDesc = txtSignDesc.Text.Trim();
        ms = ManualSignManager.AddManualSign(ms);

        FillManual(fag, ms);

        return ms;
    }

    private void FillManual(int fag, ManualSign ms)
    {
        //初始化签到签退信息
        string line = "----";
        sign.Text = (fag == 0) ? "签到" : "签退";
        txtUserId.Text = line + ms.User.UserId;
        txtUserName.Text = line + ms.User.UserName;
        Depart depart = DepartInfoManager.GetDepartGetById(ms.User.DepartId);
        txtDepart.Text = line + depart.DepartName.Trim();
        txtBranch.Text = line + depart.Branch.BranchName;
        txtSignInDesc.Text = line + ms.SignDesc;
        txtSignTimeInfo.Text = line + ms.SignTime.ToString();
    }
    //签到
    protected void SignIn_Click(object sender, EventArgs e)
    {
        int count = ManualSignManager.GetManualSignState(true, (Session["Login"] as User).UserId);
        if (count < 1)
        {
            ManualSign ms = Save(0);
            if (ms != null)
            {
                divExit.Visible = true;
                //直接进行相应的按钮显隐藏就行了；  不用再调用判断的InitInterface方法了；
                this.btnSignIn.Enabled = false;
                this.btnSignOut.Enabled = true;
            }
        }
        else
        {
            ScriptManager.RegisterStartupScript(this, GetType(), "key", "alert('您今天已经签过到了！签到信息如下：')", true);
            //调用判断的InitInterface方法了；
            InitInterface();

        }

    }
    //签退
    protected void SignOut_Click(object sender, EventArgs e)
    {
        int count = ManualSignManager.GetManualSignState(false, (Session["Login"] as User).UserId);
        if (count < 1)
        {
            ManualSign ms = Save(1);
            if (ms != null)
            {
                divExit.Visible = true;
                //直接进行相应的按钮显隐藏就行了；  不用再调用判断的InitInterface方法了；
                this.btnSignOut.Enabled = false;
                this.btnSignIn.Enabled = true;
            }
        }
    }
}

