using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Text;
using System.Runtime.InteropServices;
using System.IO;




/// <summary>
/// IniFile 的摘要说明
/// </summary>
public class IniFile
{
    //ini文件的绝对路径
     private static string Path = "D:\\Y2\\ASP.NET\\MyOffice\\OA\\MyOffice\\web\\FilePath.ini";

    //ini文件中的段落名称
    private static string FilePathSection = "FilePath";

   //默认地址
    private static string DefaultValue = "D:\\文件管理\\";

    #region   声明读写INI文件的API函数

    [DllImport("kernel32")]
    private static extern long WritePrivateProfileString(string section, string key, string val, string filePath);

    [DllImport("kernel32")]
    private static extern int GetPrivateProfileString(string section, string key, string defVal, StringBuilder retVal, int size, string filePath);

    [DllImport("kernel32")]
    private static extern int GetPrivateProfileString(string section, string key, string defVal, Byte[] retVal, int size, string filePath);

    #endregion


    //// <summary>
    /// 写INI文件
    /// </summary>
    /// <param name="key">键</param>
    /// <param name="iValue">值</param>
    public static void IniWriteValue( string key, string iValue)
    {
        WritePrivateProfileString(FilePathSection, key, iValue, Path);

         

    }

    //// <summary>
    /// 写INI文件(插入默认值)
    /// </summary>
    /// <param name="key">键</param>
    public static void IniWriteValue(string key)
    {
        WritePrivateProfileString(FilePathSection, key, DefaultValue, Path);



    }



    /**/
    /// <summary>
    /// 读取INI文件
    /// </summary>
    /// <param name="key">键</param>
    /// <returns>返回的键值</returns>
    public static string IniReadValue( string key)
    {

        StringBuilder temp = new StringBuilder(255);
        int i = GetPrivateProfileString(FilePathSection, key, DefaultValue, temp, 255, Path);
        return temp.ToString().Replace("/",System.IO.Path.DirectorySeparatorChar.ToString());
    }

    /// <summary>
    /// 指定键 删除键值  
    /// </summary>
    /// <param name="section"></param>
    /// <param name="key"></param>
    public static void DelValueByKey( string key)
    {  
        WritePrivateProfileString(FilePathSection, key, null, Path);
    }
}
