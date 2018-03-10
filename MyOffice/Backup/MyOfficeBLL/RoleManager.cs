using System;
using System.Collections.Generic;
using System.Text;
using MyOffice.DAL;
using MyOffice.Models;

namespace MyOffice.BLL
{
   public class RoleManager
    {

         /// <summary>
        /// 根据roleId查找对象
        /// </summary>
        /// <param name="roleId"></param>
        /// <returns></returns>
       public static Role GetRoleById(int roleId) {
           return RoleService.GetRoleById(roleId);
       }

        /// <summary>
       /// 查询所有角色(不包括管理员)
        /// </summary>
        /// <returns></returns>
       public static IList<Role> GetAllRole()
       {
           return RoleService.GetAllRole();
       }
       /// <summary>
        /// 查询所有
        /// </summary>
        /// <returns></returns>
       public static IList<Role> GetAllRoleInfo()
       {
           return RoleService.GetAllRoleInfo();
       }

    }
}
