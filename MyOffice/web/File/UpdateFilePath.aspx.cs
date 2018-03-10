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
using System.Text.RegularExpressions;

public partial class File_UpdateFilePath : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        string mastr1 = @"^(?<Drive>([a-zA-Z]:\\)|(\\{2}\w+)\$?)((([^/\\\?\*])(\\?))*)$";
        string path = this.txtFilePath.Text;
        Regex re = new Regex(mastr1, RegexOptions.IgnoreCase);
        Match m = re.Match(path);

        string result = m.Success.ToString();
        if (result=="False")
        {
            this.Page.ClientScript.RegisterStartupScript(this.GetType(), "", "<script>alert('格式错误，请重新修改！');location='UpdateFilePath.aspx';</script>");
        }
        else
        {
            string oldFilePath = IniFile.IniReadValue(((MyOffice.Models.User)Session["Login"]).UserId);
            IniFile.IniWriteValue(((MyOffice.Models.User)Session["Login"]).UserId,this.txtFilePath.Text);
           
        }
    }
}
