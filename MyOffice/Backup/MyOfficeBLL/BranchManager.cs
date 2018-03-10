using System;
using System.Collections.Generic;
using System.Text;
using MyOffice.DAL;
using MyOffice.Models;

namespace MyOffice.BLL
{
    public class BranchManager
    {
        /// <summary>
        /// 添加机构信息
        /// </summary>
        /// <param name="branch"></param>
        /// <returns></returns>
        public static Branch AddBranch(Branch branch)
        {
            return BranchService.AddBranch(branch);
        }
        /// <summary>
        /// 根据机构Id查询信息
        /// </summary>
        /// <param name="branchId"></param>
        /// <returns></returns>
        public static Branch GetBranchById(int branchId)
        {
            return BranchService.GetBranchById(branchId);
        }
        /// <summary>
        /// 查询所有机构信息
        /// </summary>
        /// <returns></returns>
        public static IList<Branch> GetAllBranch()
        {
            return BranchService.GetAllBranch();
        
        }

        /// <summary>
        /// 删除机构信息
        /// </summary>
        /// <param name="branchId"></param>
        /// <returns></returns>
        public static int DeleteBranchById(int branchId)
        {
            return BranchService.DeleteBranchById(branchId);
        }
        /// <summary>
        /// 修改机构信息
        /// </summary>
        /// <param name="branch"></param>
        /// <returns></returns>
        public static int UpdateBranch(Branch branch)
        {
            return BranchService.UpdateBranch(branch);
        }
    }
}
