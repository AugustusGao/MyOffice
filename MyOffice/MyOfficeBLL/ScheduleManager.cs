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
        /// ���ݲ��ź�ʱ���������ʱ���ѯ�ճ���Ϣ
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
       /// ͨ���ճ�Id���ĳ���ճ̵���Ϣ
       /// </summary>
       /// <param name="id"></param>
       /// <returns></returns>
       public static Schedule GetScheduleById(int id) 
       {
           return ScheduleService.GetScheduleById(id);
       }
       /// <summary>
       /// ����ճ���Ϣ
       /// </summary>
       /// <param name="schedule"></param>
       /// <returns></returns>
       public static int AddSchedule(Schedule schedule) 
       {
           return ScheduleService.AddSchedule(schedule);
       }
       /// <summary>
       /// ͨ���ճ�Id�޸��ճ���Ϣ
       /// </summary>
       /// <param name="schedule"></param>
       /// <returns></returns>
       public static int ModifyScheduleById(Schedule schedule) 
       {
           return ScheduleService.ModifyScheduleById(schedule);
       }
       /// <summary>
       /// ͨ���ճ�Idɾ���ճ���Ϣ
       /// </summary>
       /// <param name="id"></param>
       /// <returns></returns>
       public static int DeleteScheduleById(int id) 
       {
           return ScheduleService.DeleteScheduleById(id);
       }

       /// <summary>
       /// ���ݲ��ź�ʱ���������ʱ���ѯĳ��ʱ��ε��ճ���Ϣ
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
