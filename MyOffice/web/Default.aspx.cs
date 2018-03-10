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
using System.IO;
using System.Text.RegularExpressions;
public partial class _Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        IniFile.IniWriteValue("admin","F:\\testdfqqqqq\\");
       Response.Write(IniFile.IniReadValue("admin"));
        //string a = "asdf\\daf\\test";
        //Response.Write(a.Substring(a.LastIndexOf('\\')+1));
        //Directory.CreateDirectory("d:\\test\\a");
        //File.Move("d:\\t.txt", "e:\\t.txt");
       // FolderBrowserDialog fbd = new FolderBrowserDialog(); 
       // string aaa = "";
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
       // this.Page.ClientScript.RegisterStartupScript(this.GetType(), "", "<script>alert('移动失败！');location='Default.aspx?fileId=" + Request.QueryString["fileId"] + "'</script>");
        string mastr1 = @"^(?<Drive>([a-zA-Z]:\\)|(\\{2}\w+)\$?)((([^/\\\?\*])(\\?))*)$";
        string mastr2 = @"^(([a-zA-Z]:\\)|(\\{2}\w+)\$?)((([^/\\\?\*])(\\?))*)$";
        string mastr3 = "(^\\.|^/|^[a-zA-Z])?:?/.+(/$)? ";
        string path = this.TextBox1.Text;
        Regex re = new Regex(mastr3, RegexOptions.IgnoreCase);
        Match m = re.Match(path);

        string a=m.Success.ToString();
        Response.Write(a);
    }
}
