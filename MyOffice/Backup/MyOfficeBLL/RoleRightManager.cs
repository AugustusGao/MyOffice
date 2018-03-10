using System;
using System.Collections.Generic;
using System.Text;
using MyOffice.DAL;
using MyOffice.Models;

namespace MyOffice.BLL
{
   public class RoleRightManager
    {
       /// <summary>
        /// 根据RoleId查找对象集合
        /// </summary>
        /// <param name="roleId"></param>
        /// <returns></returns>
       public static IList<RoleRight> GetRoleRightByRoleId(int roleId)
       {
           return RoleRightService.GetRoleRightByRoleId(roleId);
       }
       public static int AddRight(int roleId, int nodeId)
       {
           return RoleRightService.AddRight(roleId,nodeId);
       }


       /// <summary>
       /// 删除此角色所有的权限
       /// </summary>
       /// <param name="roleId"></param>
       /// <returns></returns>
       public static int delRoleRightByRoleId(int roleId)
       {
           return RoleRightService.delRoleRightByRoleId(roleId);
       }
    }
}
