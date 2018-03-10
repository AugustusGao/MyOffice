using System;
using System.Collections.Generic;
using System.Text;
using MyOffice.Models;
using System.Data;
using System.Data.SqlClient;

namespace MyOffice.DAL
{
  public  class PreContractService
    {
      /// <summary>
        /// 获取所有预约人的信息
      /// </summary>
      /// <returns></returns>
      public static IList<PreContract> GetAllPreContracts() 
      {
          string sql = "select * from PreContract";
          return GetAllPreContractsBySql(sql);
      }

      /// <summary>
      /// 添加预约人
      /// </summary>
      /// <param name="preContract"></param>
      /// <returns></returns>
      public static int AddPreContract(PreContract preContract)
      {
          string sql = "insert into PreContract(ScheduleId,UserId) values(@ScheduleId,@UserId)";
          SqlParameter[] para = new SqlParameter[] 
          {
          new SqlParameter("@ScheduleId",preContract.Schedule.ScheduleId),
          new SqlParameter("@UserId",preContract.UserId)
          };
          return DBHelper.ExecuteCommand(sql,para);
      }

      /// <summary>
      /// 删除预约人
      /// </summary>
      /// <param name="id"></param>
      /// <returns></returns>
      public static int DeletePreContractById(int id) 
      {
          string sql = "delete from PreContract where ScheduleId="+id;
          return DBHelper.ExecuteCommand(sql);
      }

      /// <summary>
      /// 通过日程Id获得所有预约人的信息
      /// </summary>
      /// <param name="scheduleId"></param>
      /// <returns></returns>
      public static IList<PreContract> GetPreContractByScheduleId(int scheduleId) 
      {
          string sql = "select * from PreContract where ScheduleId="+scheduleId;
          return GetAllPreContractsBySql(sql);
      }
      /// <summary>
      /// 通过sql语句查询所有预约人的信息
      /// </summary>
      /// <param name="sql"></param>
      /// <returns></returns>
      private static IList<PreContract> GetAllPreContractsBySql(string sql) 
      {
          IList<PreContract> ltPreContract = new List<PreContract>();
          try {
              DataTable dt = DBHelper.GetDataSet(sql);
              foreach (DataRow row in dt.Rows) 
              {
                  PreContract preContract = new PreContract();
                  preContract.PreContractId = Convert.ToInt32(row["PreContractId"]);
                  preContract.UserId = Convert.ToString(row["UserId"]);
                  preContract.Schedule =ScheduleService.GetScheduleById(Convert.ToInt32(row["ScheduleId"]));
                  ltPreContract.Add(preContract);
              }
              return ltPreContract;
          }
          catch (Exception ex) 
          {
              Console.WriteLine(ex.Message);
              throw ex;
          }
      }
      /// <summary>
      /// 通过sql语句和参数查询所有预约人的信息
      /// </summary>
      /// <param name="sql"></param>
      /// <returns></returns>
      private static IList<PreContract> GetAllPreContractsBySql(string sql,params SqlParameter [] values)
      {
          IList<PreContract> ltPreContract = new List<PreContract>();
          try
          {
              DataTable dt = DBHelper.GetDataSet(sql,values);
              foreach (DataRow row in dt.Rows)
              {
                  PreContract preContract = new PreContract();
                  preContract.PreContractId = Convert.ToInt32(row["PreContractId"]);
                  preContract.UserId = Convert.ToString(row["UserId"]);
                  preContract.Schedule = ScheduleService.GetScheduleById(Convert.ToInt32(row["ScheduleId"]));
                  ltPreContract.Add(preContract);
              }
              return ltPreContract;
          }
          catch (Exception ex)
          {
              Console.WriteLine(ex.Message);
              throw ex;
          }
      }
  
    }
}
