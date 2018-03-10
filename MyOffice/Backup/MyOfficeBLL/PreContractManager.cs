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
      /// ��ȡ����ԤԼ�˵���Ϣ
      /// </summary>
      /// <returns></returns>
      public static IList<PreContract> GetAllPreContracts() 
      {
          return PreContractService.GetAllPreContracts();
      }
      /// <summary>
      /// ���ԤԼ��
      /// </summary>
      /// <param name="preContract"></param>
      /// <returns></returns>
      public static int AddPreContract(PreContract preContract)
      {
          return PreContractService.AddPreContract(preContract);
      }

      /// <summary>
      /// ɾ��ԤԼ��
      /// </summary>
      /// <param name="id"></param>
      /// <returns></returns>
      public static int DeletePreContractById(int id) 
      {
          return PreContractService.DeletePreContractById(id);
      }

      /// <summary>
      /// ͨ���ճ�Id�������ԤԼ�˵���Ϣ
      /// </summary>
      /// <param name="scheduleId"></param>
      /// <returns></returns>
      public static IList<PreContract> GetPreContractByScheduleId(int scheduleId) 
      {
          return PreContractService.GetPreContractByScheduleId(scheduleId);
      }
    }
}
