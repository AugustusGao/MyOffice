using System;
using System.Collections.Generic;
using System.Text;
using MyOffice.DAL;
using MyOffice.Models;

namespace MyOffice.BLL
{
  public  class LoginLogManager
    {
            /// <summary>
       /// ͨ��ʱ��β�ѯ���еĵ�¼��־��Ϣ
       /// </summary>
       /// <param name="beginTime"></param>
       /// <param name="endTime"></param>
       /// <returns></returns>
      public static IList<LoginLog> GetAllLoginLogsByTime(string beginTime, string endTime)
      {
          return LoginLogService.GetAllLoginLogsByTime(beginTime, endTime);
      }
          /// <summary>
       /// ͨ��Idɾ����½��־��Ϣ
       /// </summary>
       /// <param name="id"></param>
       /// <returns></returns>
      public static int DeleteLoginLogById(int id)
      {
          return LoginLogService.DeleteLoginLogById(id);
      }
    }
}
