using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using MyOffice.Models;
using System.Data;
using System.Data.SqlClient;

namespace MyOffice.DAL
{
    public class UserService
    {

        private static IList<User> GetUserBySql(string sql)
        {
            IList<User> lists = new List<User>();
            DataTable table = DBHelper.GetDataSet(sql);
            foreach (DataRow row in table.Rows)
            {
                User user = new User();
                user.UserId = Convert.ToString(row["UserId"]);
                user.UserName = Convert.ToString(row["UserName"]);
                user.Password = Convert.ToString(row["Password"]);
                user.DepartId = Convert.ToInt32(row["DepartId"]);
                user.DepartName = Convert.ToString(row["DepartName"]);
                user.BranchId = Convert.ToInt32(row["BranchId"]);
                user.BranchName = Convert.ToString(row["BranchName"]);
                user.Gender = Convert.ToInt32(row["Gender"]);
                //外键对象
                int roleId = Convert.ToInt32(row["RoleId"]);
                user.Role = RoleService.GetRoleById(roleId);

                int userStateId = Convert.ToInt32(row["userStateId"]);
                user.UserState = UserStateService.GetUserStateById(userStateId);

                lists.Add(user);

            }
            return lists;
        }

        private static IList<User> GetUserBySql(string sql, params SqlParameter[] parameters)
        {
            IList<User> lists = new List<User>();
            try
            {
                DataTable table = DBHelper.GetDataSet(sql, parameters);
                foreach (DataRow row in table.Rows)
                {
                    User user = new User();
                    user.UserId = Convert.ToString(row["UserId"]);
                    user.UserName = Convert.ToString(row["UserName"]);
                    user.Password = Convert.ToString(row["Password"]);
                    user.DepartId = Convert.ToInt32(row["DepartId"]);
                    user.DepartName = Convert.ToString(row["DepartName"]);
                    user.BranchId = Convert.ToInt32(row["BranchId"]);
                    user.BranchName = Convert.ToString(row["BranchName"]);
                    user.Gender = Convert.ToInt32(row["Gender"]);
                    //外键对象
                    int roleId = Convert.ToInt32(row["RoleId"]);
                    user.Role = RoleService.GetRoleById(roleId);

                    int userStateId = Convert.ToInt32(row["userStateId"]);
                    user.UserState = UserStateService.GetUserStateById(userStateId);

                    lists.Add(user);

                }
                return lists;
            }
            catch (Exception ex) 
            {
                throw ex;
            }
        }

        /// <summary>
        /// 根据消息Id获得发送对象
        /// </summary>
        /// <param name="messageId"></param>
        /// <returns></returns>
        public static IList<User> GetReceiveUsersByMessageId(int messageId)
        {
            string sql = "select b.* from MessageToUser a,viewBranchDepartUsers b  where a.ToUserId=b.UserId and a.MessageId=" + messageId + " ";
            return GetUserBySql(sql);
        }

        /// <summary>
        /// 根据主键查找对象
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public static User GetUserById(string userId)
        {
            
            string sql = "select * from viewBranchDepartUsers where userId=@uId";
            SqlParameter[] parameters ={ new SqlParameter("@uId", userId) };
            SqlDataReader reader = DBHelper.GetReader(sql,parameters);
            if (reader.Read())
            {
                User user = new User();
                user.UserId = Convert.ToString(reader["UserId"]);
                user.UserName = Convert.ToString(reader["UserName"]);
                user.Password = Convert.ToString(reader["Password"]);
                user.DepartId = Convert.ToInt32(reader["DepartId"]);
                user.DepartName = Convert.ToString(reader["DepartName"]);
                user.BranchId = Convert.ToInt32(reader["BranchId"]);
                user.BranchName = Convert.ToString(reader["BranchName"]);
                user.Gender = Convert.ToInt32(reader["Gender"]);
                //外键对象
                int roleId = Convert.ToInt32(reader["RoleId"]);
                int userStateId = Convert.ToInt32(reader["userStateId"]);
                reader.Close();
                user.Role = RoleService.GetRoleById(roleId);
                user.UserState = UserStateService.GetUserStateById(userStateId);
                return user;
            }
            else
            {
                reader.Close();
                return null;
            }
            //return GetUserBySql(sql, parameters)[0];
        }

        /// <summary>
        /// 根据部门ID查找对象集合
        /// </summary>
        /// <param name="departId">部门ID</param>
        /// <returns></returns>
        public static IList<User> GetUseryDepartId(int departId)
        {
            string sql = "select * from viewBranchDepartUsers where departId=@departId";
            SqlParameter[] parameters ={ new SqlParameter("@departId", departId) };
            return GetUserBySql(sql, parameters);
        }
        /// <summary>
        /// 查询所有用户信息
        /// </summary>
        /// <returns></returns>
        public static IList<User> GetAllUsers()
        {
            string sql = "select * from viewBranchDepartUsers";
            return GetUserBySql(sql);
        }
        /// <summary>
        /// 根据用户名查询用户信息
        /// </summary>
        /// <param name="userName">用户名</param>
        /// <returns></returns>
        public static User GetUserByUserName(string userName)
        {
            string sql = "select * from viewBranchDepartUsers where UserName='" + userName + "'";
            return GetUserBySql(sql)[0];

        }

        /// <summary>
        /// 添加用户信息
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public static User AddUsers(User user)
        {
            string sql = "insert into UserInfo(UserId,UserName,Password,DepartId,Gender,RoleId,UserStateId) values(@UserId,@UserName,@Password,@DepartId,@Gender,@RoleId,@UserStateId)";
            sql += " ;select UserId from UserInfo where UserId=@uid";
            SqlParameter[] para = new SqlParameter[]
           {
               new SqlParameter("@UserId",user.UserId),
               new SqlParameter("@UserName",user.UserName),
               new SqlParameter("@Password",user.Password),
               new SqlParameter("@DepartId",user.DepartId),
               new SqlParameter("@Gender",user.Gender),
               new SqlParameter("@RoleId",user.Role.RoleId),
               new SqlParameter("@UserStateId",user.UserState.UserStateId),
               new SqlParameter("@uid",user.UserId),
           };
            try
            {
                string userId = Convert.ToString(DBHelper.GetScalar(sql, para));
                return GetUserById(userId);
            }
            catch (Exception ex)
            {
                throw ex;
            }
           
          
        }
        /// <summary>
        /// 修改用户
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public static int UpdateUser(User user)
        {
            string sql = "update UserInfo set UserName=@UserName,Password=@Password,DepartId=@DepartId,Gender=@Gender, " +
                "RoleId=@RoleId,UserStateId=@UserStateId where UserId=@UserId";
            SqlParameter[] para = new SqlParameter[]
           {
            new SqlParameter("@UserName",user.UserName),
                new SqlParameter("@Password",user.Password),
               new SqlParameter("@DepartId",user.DepartId),
               new SqlParameter("@Gender",user.Gender),
               new SqlParameter("@RoleId",user.Role.RoleId),
               new SqlParameter("@UserStateId",user.UserState.UserStateId),
               new SqlParameter("@UserId",user.UserId)
           };
            return DBHelper.ExecuteCommand(sql, para);
        }
        /// <summary>
        /// 删除用户
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public static int DeleteUserById(string userId)
        {
            try
            {
                string sql = "Delete from UserInfo where UserId='" + userId + "'";
                return DBHelper.ExecuteCommand(sql);
            }
            catch (Exception ex)
            {
                throw new ApplicationException(ex.Message);
            }
            //using (SqlConnection conn = new SqlConnection(DBHelper.connectionString))
            //{
            //    conn.Open();
            //    try
            //    {
            //        SqlParameter[] para = new SqlParameter[]
            //        {
            //            new SqlParameter("@UserId",userId)
            //        };
            //        string sql = DBHelper.DeleteStringBuilder(new string[]{"OperateLog","LoginLog","ManualSign", "Schedule",
            //            "Message", "FileInfo", "DepartInfo", "MyNote","UserInfo"}, 
            //            new string[] { "UserId", "UserId", "UserId", "CreateUser", "FromUserId", "FileOwner", "PrincipalUser", 
            //                "CreateUser", "UserId" }, "@UserId").ToString();
            //        return DBHelper.ExecuteCommand(sql, para);
            //    }
            //    catch (Exception ex)
            //    {
            //        throw ex;
            //    }
            //    conn.Close();
            //}
        }
        /// <summary>
        /// 自动不全
        /// </summary>
        /// <param name="keyword"></param>
        /// <param name="displaycount"></param>
        /// <returns></returns>
        public static string[] GetNameByKeywords(string keyword, int displaycount)
        {

            List<string> results = new List<string>(displaycount);

            string sql = "select top " + displaycount + " * from viewBranchDepartUsers where UserName like '" + keyword + "%' order by UserName desc";
            IList<User> users = GetUserBySql(sql);

            foreach (User item in users)
            {
                results.Add(item.UserName);
            }

            return results.ToArray();
        }
        /// <summary>
        /// 根据条件查询用户信息
        /// </summary>
        /// <param name="branchId">机构ID</param>
        /// <param name="departId">部门ID</param>
        /// <param name="userId">用户Id</param>
        /// <param name="userName">用户名</param>
        /// <returns></returns>
        public static IList<User> SearchUserByItem(string branchId, string departId, string userId, string userName)
        {
            string sql = "select * from viewBranchDepartUsers where 1=1";
            if (userId != null && !userId.Equals(""))
            {
                sql += " and userId='"+userId+"'";
            }
            if (userName != null && !userName.Equals(""))
            {
                sql += " and userName like '" + userName + "'";
            }
            if (!branchId.Equals("") && branchId != null)
            {
                sql += " and branchId='" + branchId + "'";
            }
            if (!branchId.Equals("") && branchId != null && !departId.Equals("") && departId != null)
            {
                sql += " and branchId='" + branchId + "' and departId='" + departId + "'";
            }
            if (!branchId.Equals("") && branchId != null && userId != null && !userId.Equals(""))
            {
                sql += " and branchId='" + branchId + "' and userId='" + userId + "'";
            }
            if (!branchId.Equals("") && branchId != null && userName != null && !userName.Equals(""))
            {
                sql += " and branchId='" + branchId + "' and userName like '" + userName + "'";
            }
            if (!branchId.Equals("") && branchId != null && !departId.Equals("") && departId != null && userId != null && !userId.Equals(""))
            {
                sql += " and branchId='" + branchId + "' and departId='" + departId + "' and userId='" + userId + "'";
            }
            if (!branchId.Equals("") && branchId != null && !departId.Equals("") && departId != null && userName != null && !userName.Equals(""))
            {
                sql += " and branchId='" + branchId + "' and departId='" + departId + "' and userName like '" + userName + "'";
            }
            if (userName != null && !userName.Equals("") && userId != null && !userId.Equals(""))
            {
                sql += " and userName like '" + userName + "' and userId='" + userId + "'";
            }
            if (!branchId.Equals("") && branchId != null && !departId.Equals("") && departId != null && userName != null && !userName.Equals("") && !userId.Equals("") && userId != null)
            {
                sql += " and branchId='" + branchId + "' and departId='" + departId + "' and userId='" + userId + "' and userName like '" + userName + "'";
            }
            return GetUserBySql(sql);
        }

        /// <summary>
        /// 根据用户名模糊查询
        /// </summary>
        /// <param name="userName"></param>
        /// <returns></returns>
        public static IList<User> GetAllUserByUserName(string userName)
        {
            string sql = "select * from viewBranchDepartUsers where UserName like '" + userName + "%'";
            return GetUserBySql(sql);
        }
    }
}
