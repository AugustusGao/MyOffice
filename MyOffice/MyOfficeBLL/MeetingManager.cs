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
        /// ͨ������Id��ѯ������Ϣ
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
       public static Meeting GetMeetingById(int id) 
       {
           return MeetingService.GetMeetingById(id);
       }
       /// <summary>
       /// ��ѯ���л�����Ϣ
       /// </summary>
       /// <returns></returns>
       public static IList<Meeting> GetAllMeetings() 
       {
           return MeetingService.GetAllMeetings();
       }
    }
}
