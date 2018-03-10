using System;
using System.Collections.Generic;
using System.Text;
using MyOffice.DAL;
using MyOffice.Models;

namespace MyOffice.BLL
{
   public class OperateLogManager
    {
           /// <summary>
       /// 通过时间段查询操作日志的信息
       /// </summary>
       /// <param name="beginTime"></param>
       /// <param name="endTime"></param>
       /// <returns></returns>
       public static IList<OperateLog> GetAllOperateLogsByTime(string beginTime, string endTime)
       {
           return OperateLogService.GetAllOperateLogsByTime(beginTime, endTime);
       }
         /// <summary>
       /// 通过Id删除操作日志的信息
       /// </summary>
       /// <param name="id"></param>
       /// <returns></returns>
       public static int DeleteOperateLogById(int id)
       {
           return OperateLogService.DeleteOperateLogById(id);
       }
    }
}
