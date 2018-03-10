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
        /// ����roleId���Ҷ���
        /// </summary>
        /// <param name="roleId"></param>
        /// <returns></returns>
       public static Role GetRoleById(int roleId) {
           return RoleService.GetRoleById(roleId);
       }

        /// <summary>
       /// ��ѯ���н�ɫ(����������Ա)
        /// </summary>
        /// <returns></returns>
       public static IList<Role> GetAllRole()
       {
           return RoleService.GetAllRole();
       }
       /// <summary>
        /// ��ѯ����
        /// </summary>
        /// <returns></returns>
       public static IList<Role> GetAllRoleInfo()
       {
           return RoleService.GetAllRoleInfo();
       }

    }
}
