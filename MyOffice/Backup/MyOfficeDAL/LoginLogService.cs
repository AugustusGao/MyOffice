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
       /// ͨ��Idɾ����½��־��Ϣ
       /// </summary>
       /// <param name="id"></param>
       /// <returns></returns>
       public static int DeleteLoginLogById(int id) 
       {
           string sql = "delete from LoginLog where LoginId="+id;
           return DBHelper.ExecuteCommand(sql);
       }
       /// <summary>
       /// ͨ��ʱ��β�ѯ���еĵ�¼��־��Ϣ
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
       /// ͨ��sql����ѯ��½��־����Ϣ
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
       /// ͨ��sql���Ͳ�����ѯ��½��־����Ϣ
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
