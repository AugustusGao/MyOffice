using System;
using System.Collections.Generic;
using System.Text;
using MyOffice.Models;
using System.Data;
using System.Data.SqlClient;

namespace MyOffice.DAL
{
   public class ScheduleService
    {
      /// <summary>
      /// 根据部门和时间或姓名和时间查询日程信息
      /// </summary>
      /// <param name="beginTime"></param>
      /// <param name="departId"></param>
      /// <param name="userName"></param>
      /// <param name="ifPrivate"></param>
      /// <returns></returns>
       public static IList<Schedule> SearchSchedule(string beginTime,int departId,string userName,bool ifPrivate) 
       {
           string sql = "select * from Schedule s,UserInfo u where s.createUser=u.UserId";

           if (userName != null && !userName.Equals("")) 
           {
               if (ifPrivate)
               {
                   sql += " and u.userName like '" + userName.Trim() + "%' and ifPrivate=1";
               }
               else 
               {
                   sql += " and u.userName like '"+userName.Trim()+"%'";
               }
           }
           if (departId > 0) 
           {
               if (ifPrivate)
               {
                   sql += "and u.departId='" + departId + "' and ifPrivate=1";
               }
               else 
               {
                   sql += "and u.departId='"+departId+"'";
               }
           }
           if (beginTime != null && !beginTime.Equals(""))
           {
               sql +=" and BeginTime between '" + string.Format("{0:yyyy-MM-dd 0:00:00}", DateTime.Parse(beginTime.Trim())) + "' and '" + string.Format("{0:yyyy-MM-dd 23:59:59}", DateTime.Parse(beginTime.Trim())) + "'";
           }
           if (sql != null) 
           {
               sql += " order by s.createUser asc";
           }
           return GetAllSchedulesBySql(sql);
       }

       /// <summary>
       /// 根据部门和时间或姓名和时间查询某个时间段的日程信息
       /// </summary>
       /// <param name="beginTime"></param>
       /// <param name="endTime"></param>
       /// <param name="departId"></param>
       /// <param name="userName"></param>
       /// <param name="ifPrivate"></param>
       /// <returns></returns>
       public static IList<Schedule> GetAllSchedulesByTime(string beginTime,string endTime,int departId,string userName,bool ifPrivate) 
       {

           string sql = "select * from Schedule s,UserInfo u where s.createUser=u.UserId ";

           if (userName != null && !userName.Equals(""))
           {
               if (ifPrivate)
               {
                   sql += " and u.userName like '" + userName.Trim() + "%' and ifPrivate=1";
               }
               else
               {
                   sql += " and u.userName like '" + userName.Trim() + "%'";
               }
           }
           if (departId > 0)
           {
               if (ifPrivate)
               {
                   sql += " and u.departId='" + departId + "' and ifPrivate=1";
               }
               else
               {
                   sql += " and u.departId='" + departId + "'";
               }
           }
           if (beginTime != null && !beginTime.Equals("") && endTime != null && !endTime.Equals(""))
           {
               if (ifPrivate)
               {
                   sql += " and BeginTime between '" + string.Format("{0:yyyy-MM-dd 00:00:00}", DateTime.Parse(beginTime.Trim())) + "' and '" + string.Format("{0:yyyy-MM-dd 23:59:59}", DateTime.Parse(endTime.Trim())) + "' and ifPrivate=1";
               }
               else 
               {
                   sql += " and BeginTime between '" + string.Format("{0:yyyy-MM-dd 00:00:00}", DateTime.Parse(beginTime.Trim())) + "' and '" + string.Format("{0:yyyy-MM-dd 23:59:59}", DateTime.Parse(endTime.Trim())) + "'";
               }
           }
           if (sql != null)
           {
               sql += " order by s.createUser asc";
           }
           return GetAllSchedulesBySql(sql);        
       }

       /// <summary>
       /// 通过sql语句查询所有日程信息
       /// </summary>
       /// <param name="sql"></param>
       /// <returns></returns>
       public static IList<Schedule> GetAllSchedulesBySql(string sql) 
       {
           IList<Schedule> ltSchedule = new List<Schedule>();
           try 
           {
               DataTable dt = DBHelper.GetDataSet(sql);
               foreach (DataRow row in dt.Rows) 
               {
                   Schedule schedule = new Schedule();
                   schedule.Address = Convert.ToString(row["address"]);
                   schedule.BeginTime = (DateTime)row["beginTime"];
                   schedule.EndTime = (DateTime)row["endTime"];
                   schedule.CreateTime = (DateTime)row["createTime"];
                   schedule.IfPrivate = Convert.ToInt32(row["ifPrivate"]);
                   schedule.SchContent = Convert.ToString(row["schContent"]);
                   schedule.ScheduleId=Convert.ToInt32(row["scheduleId"]);
                   schedule.Title = Convert.ToString(row["title"]);
                   schedule.CreateUser = UserService.GetUserById(Convert.ToString(row["CreateUser"]));
                   schedule.Meeting = MeetingService.GetMeetingById(Convert.ToInt32(row["meetingId"]));
                   ltSchedule.Add(schedule);

               }
               return ltSchedule;
           }
           catch (Exception ex) 
           {
               Console.WriteLine(ex.Message);
               throw ex;
           }
       }
       /// <summary>
       /// 通过sql语句和参数查询所有日程信息
       /// </summary>
       /// <param name="sql"></param>
       /// <param name="values"></param>
       /// <returns></returns>
       public static IList<Schedule> GetAllSchedulesBySql(string sql,params SqlParameter [] values)
       {
           IList<Schedule> ItSchedule = new List<Schedule>();
           try
           {
               DataTable dt = DBHelper.GetDataSet(sql,values);
               foreach (DataRow row in dt.Rows)
               {
                   Schedule schedule = new Schedule();
                   schedule.Address = Convert.ToString(row["address"]);
                   schedule.BeginTime = (DateTime)row["beginTime"];
                   schedule.EndTime = (DateTime)row["endTime"];
                   schedule.CreateTime = (DateTime)row["createTime"];
                   schedule.IfPrivate = Convert.ToInt32(row["ifPrivate"]);
                   schedule.SchContent = Convert.ToString(row["schContent"]);
                   schedule.ScheduleId = Convert.ToInt32(row["scheduleId"]);
                   schedule.Title = Convert.ToString(row["title"]);
                   schedule.CreateUser = UserService.GetUserById(Convert.ToString(row["userId"]));
                   schedule.Meeting = MeetingService.GetMeetingById(Convert.ToInt32(row["meetingId"]));
                   ItSchedule.Add(schedule);

               }
               return ItSchedule;
           }
           catch (Exception ex)
           {
               Console.WriteLine(ex.Message);
               throw ex;
           }
       }

       /// <summary>
       /// 通过日程Id获得某个日程的信息
       /// </summary>
       /// <param name="id"></param>
       /// <returns></returns>
       public static Schedule GetScheduleById(int id)
       {
           string sql = "select * from Schedule where scheduleId="+id;
           return GetAllSchedulesBySql(sql)[0];
       }
       /// <summary>
       /// 添加日程信息
       /// </summary>
       /// <param name="schedule"></param>
       /// <returns></returns>
       public static int AddSchedule(Schedule schedule)
       {
           string sql = "insert into Schedule(Title,Address,MeetingId,BeginTime,EndTime,SchContent,CreateUser,CreateTime,ifPrivate) values(@Title,@Address,@MeetingId,@BeginTime,@EndTime,@SchContent,@CreateUser,@CreateTime,@ifPrivate);select @@identity";
           SqlParameter[] para = new SqlParameter[] 
           {
           new SqlParameter("@Title",schedule.Title),
           new SqlParameter("@Address",schedule.Address),
           new SqlParameter("@MeetingId",schedule.Meeting.MeetingId),
           new SqlParameter("@BeginTime",schedule.BeginTime),
           new SqlParameter("@EndTime",schedule.EndTime),
           new SqlParameter("@SchContent",schedule.SchContent),
           new SqlParameter("@CreateUser",schedule.CreateUser.UserId),
           new SqlParameter("@CreateTime",schedule.CreateTime),
           new SqlParameter("@ifPrivate",schedule.IfPrivate)
           };
           return Convert.ToInt32(DBHelper.GetScalar(sql,para));
       }
       /// <summary>
       /// 通过日程Id修改日程信息
       /// </summary>
       /// <param name="schedule"></param>
       /// <returns></returns>
       public static int ModifyScheduleById(Schedule schedule)
       {
           string sql = "update Schedule set Title=@Title,Address=@Address,MeetingId=@MeetingId,BeginTime=@BeginTime,EndTime=@EndTime,SchContent=@SchContent,CreateUser=@CreateUser,CreateTime=@CreateTime,ifPrivate=@ifPrivate where ScheduleId=@ScheduleId";
           SqlParameter[] para = new SqlParameter[] 
           {
           new SqlParameter("@Title",schedule.Title),
           new SqlParameter("@Address",schedule.Address),
           new SqlParameter("@MeetingId",schedule.Meeting.MeetingId),
           new SqlParameter("@BeginTime",schedule.BeginTime),
           new SqlParameter("@EndTime",schedule.EndTime),
           new SqlParameter("@SchContent",schedule.SchContent),
           new SqlParameter("@CreateUser",schedule.CreateUser.UserId),
           new SqlParameter("@CreateTime",schedule.CreateTime),
           new SqlParameter("@ifPrivate",schedule.IfPrivate),
           new SqlParameter("@ScheduleId",schedule.ScheduleId)
           };
           return DBHelper.ExecuteCommand(sql, para);
       }
       /// <summary>
       /// 通过日程Id删除日程信息
       /// </summary>
       /// <param name="id"></param>
       /// <returns></returns>
       public static int DeleteScheduleById(int id) 
       {
           string sql = "delete from Schedule where ScheduleId="+id;
           return DBHelper.ExecuteCommand(sql);
       }
   }
}
