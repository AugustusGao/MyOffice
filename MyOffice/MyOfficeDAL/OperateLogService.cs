using System;
using System.Collections.Generic;
using System.Text;
using MyOffice.Models;
using System.Data;
using System.Data.SqlClient;

namespace MyOffice.DAL
{
   public class OperateLogService
    {
       /// <summary>
       /// 通过Id删除操作日志的信息
       /// </summary>
       /// <param name="id"></param>
       /// <returns></returns>
       public static int DeleteOperateLogById(int id) 
       {
           string sql = "delete from OperateLog where OperateId="+id;
           return DBHelper.ExecuteCommand(sql);
       }
       /// <summary>
       /// 通过时间段查询操作日志的信息
       /// </summary>
       /// <param name="beginTime"></param>
       /// <param name="endTime"></param>
       /// <returns></returns>
       public static IList<OperateLog> GetAllOperateLogsByTime(string beginTime, string endTime) 
       {
           string sql = "select * from OperateLog where OperateTime between '"+string.Format("{0:yyyy-MM-dd 00:00:00}",DateTime.Parse(beginTime))+"' and '"+string.Format("{0:yyyy-MM-dd 23:59:59}",DateTime.Parse(endTime))+"'";
           return GetAllOperateLogsBySql(sql);
       }
       /// <summary>
       /// 通过sql语句查询操作日志信息
       /// </summary>
       /// <param name="sql"></param>
       /// <returns></returns>
       private static IList<OperateLog> GetAllOperateLogsBySql(string sql) 
       {
           IList<OperateLog> ltOperateLog = new List<OperateLog>();
           try
           {
               DataTable dt = DBHelper.GetDataSet(sql);
               foreach (DataRow row in dt.Rows)
               {
                   OperateLog operateLog = new OperateLog();
                   operateLog.OperateId = Convert.ToInt32(row["OperateId"]);
                   operateLog.User=UserService.GetUserById(row["UserId"].ToString());
                   operateLog.OperateName = Convert.ToString(row["OperateName"]);
                   operateLog.ObjectId = Convert.ToString(row["ObjectId"]);
                   operateLog.OperateDesc = Convert.ToString(row["OperateDesc"]);
                   operateLog.OperateTime = (DateTime)row["OperateTime"];
                   ltOperateLog.Add(operateLog);
               }
               return ltOperateLog;
           }
           catch (Exception ex) 
           {
               Console.WriteLine(ex.Message);
               throw ex;
           }

       }
       /// <summary>
       /// 通过sql语句和参数查询操作日志信息
       /// </summary>
       /// <param name="sql"></param>
       /// <returns></returns>
       private static IList<OperateLog> GetAllOperateLogsBySql(string sql,params SqlParameter [] para)
       {
           IList<OperateLog> ltOperateLog = new List<OperateLog>();
           try
           {
               DataTable dt = DBHelper.GetDataSet(sql,para);
               foreach (DataRow row in dt.Rows)
               {
                   OperateLog operateLog = new OperateLog();
                   operateLog.OperateId = Convert.ToInt32(row["OperateId"]);
                   operateLog.User = UserService.GetUserById(row["UserId"].ToString());
                   operateLog.OperateName = Convert.ToString(row["OperateName"]);
                   operateLog.ObjectId = Convert.ToString(row["ObjectId"]);
                   operateLog.OperateDesc = Convert.ToString(row["OperateDesc"]);
                   operateLog.OperateTime = (DateTime)row["OperateTime"];
                   ltOperateLog.Add(operateLog);
               }
               return ltOperateLog;
           }
           catch (Exception ex)
           {
               Console.WriteLine(ex.Message);
               throw ex;
           }

       }
    }
}
