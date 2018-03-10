using System;
using System.Collections.Generic;
using System.Text;
using MyOffice.Models;
using MyOffice.DAL;

namespace MyOffice.BLL
{
   public class MeetingManager
    {
        /// <summary>
        /// 通过会议Id查询会议信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
       public static Meeting GetMeetingById(int id) 
       {
           return MeetingService.GetMeetingById(id);
       }
       /// <summary>
       /// 查询所有会议信息
       /// </summary>
       /// <returns></returns>
       public static IList<Meeting> GetAllMeetings() 
       {
           return MeetingService.GetAllMeetings();
       }
    }
}
