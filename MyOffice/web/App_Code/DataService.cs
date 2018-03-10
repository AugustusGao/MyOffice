using System;
using System.Web;
using System.Collections;
using System.Web.Services;
using System.Web.Services.Protocols;
using AjaxControlToolkit;
using MyOffice.Models;
using MyOffice.BLL;
using System.Collections.Generic;
using System.Collections.Specialized;


/// <summary>
/// DataService 的摘要说明
/// </summary>
[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
[System.Web.Script.Services.ScriptService]
public class DataService : System.Web.Services.WebService
{

    public DataService()
    {

        //如果使用设计的组件，请取消注释以下行 
        //InitializeComponent(); 
    }

    [WebMethod]
    public CascadingDropDownNameValue[] GetBranchs(string knownCategoryValues,
        string category)
    {
        IList<Branch> branchs = BranchManager.GetAllBranch();
        List<CascadingDropDownNameValue> branchList = new List<CascadingDropDownNameValue>();
        foreach (Branch bc in branchs)
        {
            branchList.Add(new CascadingDropDownNameValue(bc.BranchName, bc.BranchId.ToString()));
        }
        return branchList.ToArray();
    }
    [WebMethod]
    public CascadingDropDownNameValue[] GetDeparts(string knownCategoryValues)
    {
        StringDictionary kv = CascadingDropDown.ParseKnownCategoryValuesString(knownCategoryValues);
        int branchId;
        if (!kv.ContainsKey("BranchId") || !Int32.TryParse(kv["BranchId"], out branchId))
        {
            return null;
        }
        IList<Depart> departs = DepartInfoManager.GetDeparByBranchId(branchId);
        List<CascadingDropDownNameValue> departList = new List<CascadingDropDownNameValue>();
        foreach (Depart de in departs)
        {
           departList.Add( new CascadingDropDownNameValue(de.DepartName, de.DepartId.ToString()));
        }
        return departList.ToArray();
    }

    [WebMethod]
    public string[] GetSearchNameByKeyWords(string prefixText, int count)
    {
        return UserManager.GetNameByKeywords(prefixText, count);
    }
}


