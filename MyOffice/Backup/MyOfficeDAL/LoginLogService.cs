using System;
using System.Collections.Generic;
using System.Text;
using MyOffice.Models;
using System.Data;
using System.Data.SqlClient;

namespace MyOffice.DAL
{
   public class LoginLogService
    {
       /// <summary>
       /// 通过Id删除登陆日志信息
       /// </summary>
       /// <param name="id"></param>
       /// <returns></returns>
       public static int DeleteLoginLogById(int id) 
       {
           string sql = "delete from LoginLog where LoginId="+id;
           return DBHelper.ExecuteCommand(sql);
       }
       /// <summary>
       /// 通过时间段查询所有的登录日志信息
       /// </summary>
       /// <param name="beginTime"></param>
       /// <param name="endTime"></param>
       /// <returns></returns>
       public static IList<LoginLog> GetAllLoginLogsByTime(string beginTime, string endTime) 
       {
           string sql = "select * from LoginLog where LoginTime between '"+string.Format("{0:yyyy-MM-dd 00:00:00}",DateTime.Parse(beginTime))+"' and '"+string.Format("{0:yyyy-MM-dd 23:59:59}",DateTime.Parse(endTime))+"'";
           return GetAllLoginLogs(sql);
       }
       

       /// <summary>
       /// 通过sql语句查询登陆日志的信息
       /// </summary>
       /// <param name="sql"></param>
       /// <returns></returns>
       private static IList<LoginLog> GetAllLoginLogs(string sql) 
       {
           IList<LoginLog> ltLoginLog = new List<LoginLog>();
           try
           {
               DataTable dt = DBHelper.GetDataSet(sql);
               foreach (DataRow row in dt.Rows)
               {
                   LoginLog loginLog = new LoginLog();
                   loginLog.LoginId = Convert.ToInt32(row["LoginId"]);
                   loginLog.User = UserService.GetUserById(row["UserId"].ToString());
                   loginLog.ExitTime = (DateTime)row["ExitTime"];
                   loginLog.LoginTime = (DateTime)row["LoginTime"];
                   loginLog.IfSuccess = Convert.ToInt32(row["ifSuccess"]);
                   loginLog.LoginUserIp = Convert.ToString(row["LoginUserIp"]);
                   loginLog.LoginDesc = Convert.ToString(row["LoginDesc"]);
                   ltLoginLog.Add(loginLog);
               }
               return ltLoginLog;
           }
           catch (Exception ex) 
           {
               Console.WriteLine(ex.Message);
               throw ex;
           }
       }
       /// <summary>
       /// 通过sql语句和参数查询登陆日志的信息
       /// </summary>
       /// <param name="sql"></param>
       /// <returns></returns>
       private static IList<LoginLog> GetAllLoginLogs(string sql,params SqlParameter [] para)
       {
           IList<LoginLog> ltLoginLog = new List<LoginLog>();
           try
           {
               DataTable dt = DBHelper.GetDataSet(sql,para);
               foreach (DataRow row in dt.Rows)
               {
                   LoginLog loginLog = new LoginLog();
                   loginLog.LoginId = Convert.ToInt32(row["LoginId"]);
                   loginLog.User = UserService.GetUserById(row["UserId"].ToString());
                   loginLog.ExitTime = (DateTime)row["ExitTime"];
                   loginLog.LoginTime = (DateTime)row["LoginTime"];
                   loginLog.IfSuccess = Convert.ToInt32(row["ifSuccess"]);
                   loginLog.LoginUserIp = Convert.ToString(row["LoginUserIp"]);
                   loginLog.LoginDesc = Convert.ToString(row["LoginDesc"]);
                   ltLoginLog.Add(loginLog);
               }
               return ltLoginLog;
           }
           catch (Exception ex)
           {
               Console.WriteLine(ex.Message);
               throw ex;
           }
       }
    }
}
