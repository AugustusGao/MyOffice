using System;
using System.Collections.Generic;
using System.Text;
using MyOffice.Models;
using System.Collections;
using System.Data;
using System.Data.SqlClient;

namespace MyOffice.DAL
{
    public class RoleRightService
    {
        private static IList<RoleRight> GetRoleRightBySql(string sql)
        {
            IList<RoleRight> lists = new List<RoleRight>();
            DataTable table = DBHelper.GetDataSet(sql);
            foreach (DataRow row in table.Rows)
            {
                RoleRight roleRight = new RoleRight();
                roleRight.RoleRightId = Convert.ToInt32(row["RoleRightId"]);
                //外键对象
                roleRight.Role = RoleService.GetRoleById(Convert.ToInt32(row["roleId"]));

                roleRight.Node = SysFunService.GetSysFunById(Convert.ToInt32(row["NodeId"]));

                lists.Add(roleRight);
            }
            return lists;
        }

        private static IList<RoleRight> GetRoleRightBySql(string sql,params SqlParameter[] parametsers)
        {
            IList<RoleRight> lists = new List<RoleRight>();
            DataTable table = DBHelper.GetDataSet(sql,parametsers);
            foreach (DataRow row in table.Rows)
            {
                RoleRight roleRight = new RoleRight();
                roleRight.RoleRightId = Convert.ToInt32(row["RoleRightId"]);
                //外键对象
                roleRight.Role = RoleService.GetRoleById(Convert.ToInt32(row["roleId"]));

                roleRight.Node = SysFunService.GetSysFunById(Convert.ToInt32(row["NodeId"]));

                lists.Add(roleRight);
            }
            return lists;
        }
       

        /// <summary>
        /// 根据RoleId查找对象集合
        /// </summary>
        /// <param name="roleId"></param>
        /// <returns></returns>
        public static IList<RoleRight> GetRoleRightByRoleId(int roleId)
        {
            string sql = "select * from roleRight where roleId=@roleId";
            SqlParameter[] parameters ={ new SqlParameter("@roleid", roleId) };
            return GetRoleRightBySql(sql, parameters);
        }


        public static int AddRight(int roleId,int nodeId) {
            string sql = "insert into roleRight(roleId,nodeId) values(@roleId,@nodeId)";
            SqlParameter[] parameters ={ new SqlParameter("@roleId",roleId),new SqlParameter("@nodeId",nodeId)};
            return DBHelper.ExecuteCommand(sql,parameters);
        }

        /// <summary>
        /// 删除此角色所有的权限
        /// </summary>
        /// <param name="roleId"></param>
        /// <returns></returns>
        public static int delRoleRightByRoleId(int roleId) {
            string sql = "delete from roleRight where roleId=@roleId";
            SqlParameter[] parameters ={ new SqlParameter("@roleId", roleId) };
            return DBHelper.ExecuteCommand(sql, parameters);
        }
    }
}
