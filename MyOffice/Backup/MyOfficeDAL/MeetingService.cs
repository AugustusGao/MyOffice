using System;
using System.Collections.Generic;
using System.Text;
using MyOffice.Models;
using System.Data;
using System.Data.SqlClient;

namespace MyOffice.DAL
{
   public class MeetingService
    {
       /// <summary>
       /// 通过sql语句查询所有会议信息
       /// </summary>
       /// <param name="sql"></param>
       /// <returns></returns>
       private static IList<Meeting> GetAllMeetingsBySql(string sql) 
       {
           IList<Meeting> ltMeeting = new List<Meeting>();
           try 
           {
               DataTable dt = DBHelper.GetDataSet(sql);
               foreach (DataRow row in dt.Rows) 
               {
                   Meeting meeting = new Meeting();
                   meeting.MeetingId = Convert.ToInt32(row["meetingId"]);
                   meeting.MeetingName = Convert.ToString(row["meetingName"]);
                   ltMeeting.Add(meeting);
               }
               return ltMeeting;
           }
           catch (Exception ex) 
           {
               Console.WriteLine(ex.Message);
               throw ex;
           }
       }
       /// <summary>
       /// 通过sql语句和参数查询所有会议信息
       /// </summary>
       /// <param name="sql"></param>
       /// <param name="values"></param>
       /// <returns></returns>
       private static IList<Meeting> GetAllMeetingsBySql(string sql,params SqlParameter [] values)
       {
           IList<Meeting> ltMeeting = new List<Meeting>();
           try
           {
               DataTable dt = DBHelper.GetDataSet(sql,values);
               foreach (DataRow row in dt.Rows)
               {
                   Meeting meeting = new Meeting();
                   meeting.MeetingId = Convert.ToInt32(row["meetingId"]);
                   meeting.MeetingName = Convert.ToString(row["meetingName"]);
                   ltMeeting.Add(meeting);
               }
               return ltMeeting;
           }
           catch (Exception ex)
           {
               Console.WriteLine(ex.Message);
               throw ex;
           }
       }
       /// <summary>
       /// 查询所有会议信息
       /// </summary>
       /// <returns></returns>
       public static IList<Meeting> GetAllMeetings() 
       {
           string sql = "select * from MeetingInfo";
           return GetAllMeetingsBySql(sql);
       }

       /// <summary>
       /// 通过会议Id查询会议信息
       /// </summary>
       /// <param name="id"></param>
       /// <returns></returns>
       public static Meeting GetMeetingById(int id)
       {
           string sql = "select * from MeetingInfo where MeetingId="+id;
           SqlDataReader dr = DBHelper.GetReader(sql);
           if (dr.Read())
           {
               Meeting meeting = new Meeting();
               meeting.MeetingId = Convert.ToInt32(dr["meetingId"]);
               meeting.MeetingName = Convert.ToString(dr["meetingName"]);
               dr.Close();
               return meeting;
           }
           else 
           {
               dr.Close();
               return null;
           }
         
       }
   }
}
