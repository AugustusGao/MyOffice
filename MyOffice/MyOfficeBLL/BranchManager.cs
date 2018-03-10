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
        /// ��ӻ�����Ϣ
        /// </summary>
        /// <param name="branch"></param>
        /// <returns></returns>
        public static Branch AddBranch(Branch branch)
        {
            return BranchService.AddBranch(branch);
        }
        /// <summary>
        /// ���ݻ���Id��ѯ��Ϣ
        /// </summary>
        /// <param name="branchId"></param>
        /// <returns></returns>
        public static Branch GetBranchById(int branchId)
        {
            return BranchService.GetBranchById(branchId);
        }
        /// <summary>
        /// ��ѯ���л�����Ϣ
        /// </summary>
        /// <returns></returns>
        public static IList<Branch> GetAllBranch()
        {
            return BranchService.GetAllBranch();
        
        }

        /// <summary>
        /// ɾ��������Ϣ
        /// </summary>
        /// <param name="branchId"></param>
        /// <returns></returns>
        public static int DeleteBranchById(int branchId)
        {
            return BranchService.DeleteBranchById(branchId);
        }
        /// <summary>
        /// �޸Ļ�����Ϣ
        /// </summary>
        /// <param name="branch"></param>
        /// <returns></returns>
        public static int UpdateBranch(Branch branch)
        {
            return BranchService.UpdateBranch(branch);
        }
    }
}
