using System;
using System.Collections.Generic;
using System.Text;
using MyOffice.Models;
using System.Data;
using System.Data.SqlClient;
using System.Collections;

namespace MyOffice.DAL
{
    public class RoleService
    {
        private static IList<Role> GetRoleBySql(string sql)
        {
            IList<Role> lists = new List<Role>();
            DataTable table = DBHelper.GetDataSet(sql);
            foreach (DataRow row in table.Rows)
            {
                Role role = new Role();
                role.RoleId = Convert.ToInt32(row["roleId"]);
                role.RoleName = Convert.ToString(row["roleName"]);
                role.RoleDesc = Convert.ToString(row["roleDesc"]);
                lists.Add(role);
            }
            return lists;
        }


        private static IList<Role> GetRoleBySql(string sql,params SqlParameter [] parameter)
        {
            IList<Role> lists = new List<Role>();
            DataTable table = DBHelper.GetDataSet(sql,parameter);
            foreach (DataRow row in table.Rows)
            {
                Role role = new Role();
                role.RoleId = Convert.ToInt32(row["roleId"]);
                role.RoleName = Convert.ToString(row["roleName"]);
                role.RoleDesc = Convert.ToString(row["roleDesc"]);
                lists.Add(role);
            }
            return lists;
        }

        /// <summary>
        /// 根据roleId查找对象
        /// </summary>
        /// <param name="roleId"></param>
        /// <returns></returns>
        public static Role GetRoleById(int roleId) {
            string sql = "select * from roleInfo where roleId=@roleId";
            SqlParameter[] parameters ={new SqlParameter("@roleid",roleId) };
            return GetRoleBySql(sql, parameters)[0];
        }
        /// <summary>
        /// 查询所有角色(不包括管理员)
        /// </summary>
        /// <returns></returns>
        public static IList<Role> GetAllRole()
        {
            string sql = "select * from RoleInfo where roleId!=2";
            return GetRoleBySql(sql);
        }
        /// <summary>
        /// 查询所有
        /// </summary>
        /// <returns></returns>
        public static IList<Role> GetAllRoleInfo()
        {
            string sql = "select * from RoleInfo";
            return GetRoleBySql(sql);
        }
    }
}
