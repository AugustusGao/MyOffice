using System;
using System.Collections.Generic;
using System.Text;
using MyOffice.DAL;
using MyOffice.Models;

namespace MyOffice.BLL
{
    public class DepartInfoManager
    {
        /// <summary>
        /// ��Ӳ�����Ϣ
        /// </summary>
        /// <param name="depart"></param>
        /// <returns></returns>
        public static Depart AddDepart(Depart depart)
        {
            return DepartInfoService.AddDepart(depart);
        }
    
        /// <summary>
        /// ���ݲ���ID��ѯ������Ϣ
        /// </summary>
        /// <param name="departId"></param>
        /// <returns></returns>
        public static Depart GetDepartGetById(int departId)
        {
            return DepartInfoService.GetDepartGetById(departId);
        }
        /// <summary>
        /// ��ѯ���в�����Ϣ
        /// </summary>
        /// <returns></returns>
        public static IList<Depart> GetAllDepart()
        {
            return DepartInfoService.GetAllDepart();
        }
        /// <summary>
        /// �޸Ĳ�����Ϣ
        /// </summary>
        /// <param name="depart"></param>
        /// <returns></returns>
        public static int UpdateDepart(Depart depart)
        {
            return DepartInfoService.UpdateDepart(depart);
        }
        /// <summary>
        /// ɾ��������Ϣ
        /// </summary>
        /// <param name="departId"></param>
        /// <returns></returns>
        public static int DeleteDepart(int departId)
        {
            return DepartInfoService.DeleteDepart(departId);
        }

        /// <summary>
        /// ���ݻ���ID���Ҷ��󼯺�
        /// </summary>
        /// <param name="branchId"></param>
        /// <returns></returns>
        public static IList<Depart> GetDeparByBranchId(int branchId)
        {
            return DepartInfoService.GetDeparByBranchId(branchId);
        }
    }
}
