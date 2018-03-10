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
        /// 根据主键Id查找对象
        /// </summary>
        /// <param name="nodeId"></param>
        /// <returns></returns>
        public static SysFun GetSysFunById(int nodeId) {
            return SysFunService.GetSysFunById(nodeId);
        }

         /// <summary>
        /// 根据用户Id查找权限
        /// </summary>
        /// <param name="uid"></param>
        /// <returns></returns>
        public static IList<SysFun> GetParentNodeByUID(string uid) {
            int roleId = UserManager.GetUserById(uid).Role.RoleId;
            return SysFunService.GetParentNodeByRoleId(roleId);
        }


        /// <summary>
        /// 根据用户Id和父节点Id查找权限子节点
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
        /// 根据角色Id和父节点Id查找权限子节点
        /// </summary>
        /// <param name="roleId"></param>
        /// <param name="parentNodeId"></param>
        /// <returns></returns>
        public static IList<SysFun> GetNodeByParentIdAndRoleId(int roleId, int parentNodeId)
        {
            return SysFunService.GetNodeByParentIdAndRoleId(roleId, parentNodeId);
        }


        /// <summary>
        /// 根据父节点Id查找子节点集合
        /// </summary>
        /// <param name="parentNodeId"></param>
        /// <returns></returns>
        public static IList<SysFun> GetNodeByParentId(int parentNodeId)
        {
            return SysFunService.GetNodeByParentId(parentNodeId);
        }


        /// <summary>
        /// 获得此父节点下子节点的数量
        /// </summary>
        /// <param name="parentNodeId"></param>
        /// <returns></returns>
        public static int GetCountByParentId(int parentNodeId)
        {
            return SysFunService.GetCountByParentId(parentNodeId);
        }

        /// <summary>
        /// 菜单排序中上移节点
        /// </summary>
        /// <param name="nodeId">被移动的节点ID</param>
        /// <returns>是否成功</returns>
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
        /// 交换两个对象的displayOrder值
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
        /// 菜单排序中下移节点
        /// </summary>
        /// <param name="nodeId">被移动的节点ID</param>
        /// <returns>是否成功</returns>
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
        /// 根据角色Id查找权限主节点
        /// </summary>
        /// <param name="roleId"></param>
        /// <returns></returns>
        public static IList<SysFun> GetParentNodeByRoleId(int roleId)
        {
            return SysFunService.GetParentNodeByRoleId(roleId);
        }

        /// <summary>
        /// 查找所有父节点
        /// </summary>
        /// <returns></returns>
        public static IList<SysFun> GetAllParentSys()
        {
            return SysFunService.GetAllParentSys();
        }

       
    }
}
