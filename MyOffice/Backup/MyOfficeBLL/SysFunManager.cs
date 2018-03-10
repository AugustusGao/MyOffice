using System;
using System.Collections.Generic;
using System.Text;
using MyOffice.Models;
using MyOffice.DAL;

namespace MyOffice.BLL
{
    public class SysFunManager
    {
         /// <summary>
        /// ��������Id���Ҷ���
        /// </summary>
        /// <param name="nodeId"></param>
        /// <returns></returns>
        public static SysFun GetSysFunById(int nodeId) {
            return SysFunService.GetSysFunById(nodeId);
        }

         /// <summary>
        /// �����û�Id����Ȩ��
        /// </summary>
        /// <param name="uid"></param>
        /// <returns></returns>
        public static IList<SysFun> GetParentNodeByUID(string uid) {
            int roleId = UserManager.GetUserById(uid).Role.RoleId;
            return SysFunService.GetParentNodeByRoleId(roleId);
        }


        /// <summary>
        /// �����û�Id�͸��ڵ�Id����Ȩ���ӽڵ�
       /// </summary>
       /// <param name="roleId"></param>
       /// <param name="parentNodeId"></param>
       /// <returns></returns>
        public static IList<SysFun> GetNodeByParentIdAndUID(string uid, int parentNodeId)
        {
            int roleId = UserManager.GetUserById(uid).Role.RoleId;
            return SysFunService.GetNodeByParentIdAndRoleId(roleId,parentNodeId);
        }

        /// <summary>
        /// ���ݽ�ɫId�͸��ڵ�Id����Ȩ���ӽڵ�
        /// </summary>
        /// <param name="roleId"></param>
        /// <param name="parentNodeId"></param>
        /// <returns></returns>
        public static IList<SysFun> GetNodeByParentIdAndRoleId(int roleId, int parentNodeId)
        {
            return SysFunService.GetNodeByParentIdAndRoleId(roleId, parentNodeId);
        }


        /// <summary>
        /// ���ݸ��ڵ�Id�����ӽڵ㼯��
        /// </summary>
        /// <param name="parentNodeId"></param>
        /// <returns></returns>
        public static IList<SysFun> GetNodeByParentId(int parentNodeId)
        {
            return SysFunService.GetNodeByParentId(parentNodeId);
        }


        /// <summary>
        /// ��ô˸��ڵ����ӽڵ������
        /// </summary>
        /// <param name="parentNodeId"></param>
        /// <returns></returns>
        public static int GetCountByParentId(int parentNodeId)
        {
            return SysFunService.GetCountByParentId(parentNodeId);
        }

        /// <summary>
        /// �˵����������ƽڵ�
        /// </summary>
        /// <param name="nodeId">���ƶ��Ľڵ�ID</param>
        /// <returns>�Ƿ�ɹ�</returns>
        public static bool UpNode(int nodeId) {
            try
            {
                SysFun sys = SysFunService.GetSysFunById(nodeId);
                int row_Number = SysFunService.GetRow_NumberByNodeId(nodeId,sys.ParentNodeId);
                if (row_Number == 1)
                {
                    return false;
                }
                else
                {
                    int nodeIdUp = SysFunService.GetNodeIdByRow_Number(row_Number - 1,sys.ParentNodeId);
                    ChangeNode(nodeId, nodeIdUp);
                    return true;
                }
            }
            catch (Exception)
            {

                return false;
            }
        }

        /// <summary>
        /// �������������displayOrderֵ
        /// </summary>
        /// <param name="oldNodeId"></param>
        /// <param name="newNodeId"></param>
        private static void ChangeNode(int oldNodeId, int newNodeId)
        {
            SysFun oldSys = SysFunService.GetSysFunById(oldNodeId);
            SysFun newSys = SysFunService.GetSysFunById(newNodeId);
            SysFunService.UpdateSysFun(oldNodeId,newSys);
            SysFunService.UpdateSysFun(newNodeId,oldSys);
        }


        /// <summary>
        /// �˵����������ƽڵ�
        /// </summary>
        /// <param name="nodeId">���ƶ��Ľڵ�ID</param>
        /// <returns>�Ƿ�ɹ�</returns>
        public static bool DownNode(int nodeId) {
            try
            {
                SysFun sys = SysFunService.GetSysFunById(nodeId);
                int row_Number = SysFunService.GetRow_NumberByNodeId(nodeId, sys.ParentNodeId);
                if (row_Number == SysFunService.GetCountByParentId(sys.ParentNodeId))
                {
                    return false;
                }
                else
                {
                    int nodeIdDown = SysFunService.GetNodeIdByRow_Number(row_Number + 1, sys.ParentNodeId);
                    ChangeNode(nodeId, nodeIdDown);
                    return true;
                }
            }
            catch (Exception)
            {

                return false;
            }
        }

        /// <summary>
        /// ���ݽ�ɫId����Ȩ�����ڵ�
        /// </summary>
        /// <param name="roleId"></param>
        /// <returns></returns>
        public static IList<SysFun> GetParentNodeByRoleId(int roleId)
        {
            return SysFunService.GetParentNodeByRoleId(roleId);
        }

        /// <summary>
        /// �������и��ڵ�
        /// </summary>
        /// <returns></returns>
        public static IList<SysFun> GetAllParentSys()
        {
            return SysFunService.GetAllParentSys();
        }

       
    }
}
