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
       /// 通过时间段查询所有的登录日志信息
       /// </summary>
       /// <param name="beginTime"></param>
       /// <param name="endTime"></param>
       /// <returns></returns>
      public static IList<LoginLog> GetAllLoginLogsByTime(string beginTime, string endTime)
      {
          return LoginLogService.GetAllLoginLogsByTime(beginTime, endTime);
      }
          /// <summary>
       /// 通过Id删除登陆日志信息
       /// </summary>
       /// <param name="id"></param>
       /// <returns></returns>
      public static int DeleteLoginLogById(int id)
      {
          return LoginLogService.DeleteLoginLogById(id);
      }
    }
}
