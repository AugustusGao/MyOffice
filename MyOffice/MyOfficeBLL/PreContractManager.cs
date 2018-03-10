using System;
using System.Collections.Generic;
using System.Text;
using MyOffice.DAL;
using MyOffice.Models;

namespace MyOffice.BLL
{
  public class PreContractManager
    {
      /// <summary>
      /// 获取所有预约人的信息
      /// </summary>
      /// <returns></returns>
      public static IList<PreContract> GetAllPreContracts() 
      {
          return PreContractService.GetAllPreContracts();
      }
      /// <summary>
      /// 添加预约人
      /// </summary>
      /// <param name="preContract"></param>
      /// <returns></returns>
      public static int AddPreContract(PreContract preContract)
      {
          return PreContractService.AddPreContract(preContract);
      }

      /// <summary>
      /// 删除预约人
      /// </summary>
      /// <param name="id"></param>
      /// <returns></returns>
      public static int DeletePreContractById(int id) 
      {
          return PreContractService.DeletePreContractById(id);
      }

      /// <summary>
      /// 通过日程Id获得所有预约人的信息
      /// </summary>
      /// <param name="scheduleId"></param>
      /// <returns></returns>
      public static IList<PreContract> GetPreContractByScheduleId(int scheduleId) 
      {
          return PreContractService.GetPreContractByScheduleId(scheduleId);
      }
    }
}
