using System;
using System.Collections.Generic;
using System.Text;
using MyOffice.Models;
using MyOffice.DAL;

namespace MyOffice.BLL
{
   public class ScheduleManager
    {
       /// <summary>
        /// 根据部门和时间或姓名和时间查询日程信息
       /// </summary>
       /// <param name="beginTime"></param>
       /// <param name="departId"></param>
       /// <param name="userName"></param>
       /// <param name="ifPrivate"></param>
       /// <returns></returns>
       public static IList<Schedule> SearchSchedule(string beginTime, int departId, string userName, bool ifPrivate) 
       {
           return ScheduleService.SearchSchedule(beginTime,departId,userName,ifPrivate);
       }
       /// <summary>
       /// 通过日程Id获得某个日程的信息
       /// </summary>
       /// <param name="id"></param>
       /// <returns></returns>
       public static Schedule GetScheduleById(int id) 
       {
           return ScheduleService.GetScheduleById(id);
       }
       /// <summary>
       /// 添加日程信息
       /// </summary>
       /// <param name="schedule"></param>
       /// <returns></returns>
       public static int AddSchedule(Schedule schedule) 
       {
           return ScheduleService.AddSchedule(schedule);
       }
       /// <summary>
       /// 通过日程Id修改日程信息
       /// </summary>
       /// <param name="schedule"></param>
       /// <returns></returns>
       public static int ModifyScheduleById(Schedule schedule) 
       {
           return ScheduleService.ModifyScheduleById(schedule);
       }
       /// <summary>
       /// 通过日程Id删除日程信息
       /// </summary>
       /// <param name="id"></param>
       /// <returns></returns>
       public static int DeleteScheduleById(int id) 
       {
           return ScheduleService.DeleteScheduleById(id);
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
           return ScheduleService.GetAllSchedulesByTime(beginTime,endTime,departId,userName,ifPrivate);
       }
     
    }
}
