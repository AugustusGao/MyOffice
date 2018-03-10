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
        /// 添加部门信息
        /// </summary>
        /// <param name="depart"></param>
        /// <returns></returns>
        public static Depart AddDepart(Depart depart)
        {
            return DepartInfoService.AddDepart(depart);
        }
    
        /// <summary>
        /// 根据部门ID查询所有信息
        /// </summary>
        /// <param name="departId"></param>
        /// <returns></returns>
        public static Depart GetDepartGetById(int departId)
        {
            return DepartInfoService.GetDepartGetById(departId);
        }
        /// <summary>
        /// 查询所有部门信息
        /// </summary>
        /// <returns></returns>
        public static IList<Depart> GetAllDepart()
        {
            return DepartInfoService.GetAllDepart();
        }
        /// <summary>
        /// 修改部门信息
        /// </summary>
        /// <param name="depart"></param>
        /// <returns></returns>
        public static int UpdateDepart(Depart depart)
        {
            return DepartInfoService.UpdateDepart(depart);
        }
        /// <summary>
        /// 删除部门信息
        /// </summary>
        /// <param name="departId"></param>
        /// <returns></returns>
        public static int DeleteDepart(int departId)
        {
            return DepartInfoService.DeleteDepart(departId);
        }

        /// <summary>
        /// 根据机构ID查找对象集合
        /// </summary>
        /// <param name="branchId"></param>
        /// <returns></returns>
        public static IList<Depart> GetDeparByBranchId(int branchId)
        {
            return DepartInfoService.GetDeparByBranchId(branchId);
        }
    }
}
