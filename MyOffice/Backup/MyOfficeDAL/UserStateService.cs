using System;
using System.Collections.Generic;
using System.Text;
using MyOffice.Models;
using System.Data;
using System.Data.SqlClient;

namespace MyOffice.DAL
{
   public class UserStateService
    {
       private static IList<UserState> GetUserStateBySql(string sql)
        {
            IList<UserState> lists = new List<UserState>();
            DataTable table = DBHelper.GetDataSet(sql);
            foreach (DataRow row in table.Rows)
            {
                UserState userState = new UserState();
                userState.UserStateId = Convert.ToInt32(row["userStateId"]);
                userState.UserStateName = Convert.ToString(row["UserStateName"]);
                lists.Add(userState);
            }
            return lists;
        }


       private static IList<UserState> GetUserStateBySql(string sql, params SqlParameter[] parameter)
        {
            IList<UserState> lists = new List<UserState>();
            DataTable table = DBHelper.GetDataSet(sql,parameter);
            foreach (DataRow row in table.Rows)
            {
                UserState userState = new UserState();
                userState.UserStateId = Convert.ToInt32(row["userStateId"]);
                userState.UserStateName = Convert.ToString(row["UserStateName"]);
                lists.Add(userState);
            }
            return lists;
        }

        /// <summary>
        /// 根据UserStateId查找对象
        /// </summary>
        /// <param name="roleId"></param>
        /// <returns></returns>
       public static UserState GetUserStateById(int userStateId)
        {
            string sql = "select * from UserState where UserStateId=@UserStateId";
            SqlParameter[] parameters ={ new SqlParameter("@UserStateId", userStateId) };
            return GetUserStateBySql(sql, parameters)[0];
        }
       /// <summary>
       /// 查询所有用户状态
       /// </summary>
       /// <returns></returns>
       public static IList<UserState> GetAllUserState()
       {
           string sql = "select * from UserState";
           return GetUserStateBySql(sql);
       }
    }
}
