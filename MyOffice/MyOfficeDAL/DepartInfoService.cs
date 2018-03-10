using System;
using System.Collections.Generic;
using System.Text;
using MyOffice.Models;
using System.Data.SqlClient;
using System.Data;

namespace MyOffice.DAL
{
    public class DepartInfoService
    {
        /// <summary>
        /// 添加部门信息
        /// </summary>
        /// <param name="depart"></param>
        /// <returns></returns>
        public static Depart AddDepart(Depart depart)
        {
            string sql = "insert into DepartInfo(DepartName,PrincipalUser,ConnectTelNo,ConnectMobileTelNo,Faxes,BranchId) values(@DepartName,@PrincipalUser,@ConnectTelNo,@ConnectMobileNo,@Faxes,@BranchId)";
            sql += " ;select @@Identity";
            SqlParameter[] para = new SqlParameter[]
            {
                new SqlParameter("@DepartName",depart.DepartName),
                new SqlParameter("@PrincipalUser",depart.PrincipalUser.UserId),
                new SqlParameter("@ConnectMobileNo",depart.ConnectMobileTelNo),
                new SqlParameter("@ConnectTelNo",depart.ConnectTelNo),
                new SqlParameter("@Faxes",depart.Faxes),
                new SqlParameter("@BranchId",depart.Branch.BranchId)
            };
            int departId =Convert.ToInt32( DBHelper.GetScalar(sql,para));
            return GetDepartGetById(departId);
        }
        /// <summary>
        /// 根据部门Id查询部门信息
        /// </summary>
        /// <param name="departId"></param>
        /// <returns></returns>
        public static Depart GetDepartGetById(int departId)
        {
            string sql = "select * from DepartInfo where DepartId="+departId;
            using (SqlDataReader reader = DBHelper.GetReader(sql))
            {
                if (reader.Read())
                {
                    Depart depart = new Depart();
                    depart.DepartId=(int)reader["DepartId"];
                    depart.DepartName = (string)reader["DepartName"];
                    string PrincipalUser = (string)reader["PrincipalUser"];
                    depart.ConnectTelNo = (long)reader["ConnectTelNo"];
                    depart.ConnectMobileTelNo = (long)reader["ConnectMobileTelNo"];
                    depart.Faxes=(long)reader["Faxes"];
                    int branchId=(int)reader["BranchId"];
                    reader.Close();
                    depart.Branch = BranchService.GetBranchById(branchId);
                    depart.PrincipalUser = UserService.GetUserById(PrincipalUser);
                    return depart;
                }
                else
                {
                    reader.Close();
                    return null;
                }
            }
        }
        /// <summary>
        /// 查询所有部门信息
        /// </summary>
        /// <returns></returns>
        public static IList<Depart> GetAllDepart()
        {
            string sql = "select * from DepartInfo";
            return GetAllDepartBySql(sql);
        }

        private static IList<Depart> GetAllDepartBySql(string sql)
        {
            IList<Depart> list = new List<Depart>();
            using (DataTable dt = DBHelper.GetDataSet(sql))
            {
                foreach (DataRow row in dt.Rows)
                { 
                    Depart depart = new Depart();
                    depart.DepartId=(int)row["DepartId"];
                    depart.DepartName = (string)row["DepartName"];
                    depart.ConnectTelNo = (long)row["ConnectTelNo"];
                    depart.ConnectMobileTelNo = (long)row["ConnectMobileTelNo"];
                    depart.Faxes = (long)row["Faxes"];
                    depart.PrincipalUser = UserService.GetUserById(row["PrincipalUser"].ToString());
                    depart.Branch = BranchService.GetBranchById(Convert.ToInt32(row["BranchId"]));
                    list.Add(depart);
                }
                return list;
            }
        }

        private static IList<Depart> GetAllDepart(string sql, params SqlParameter[] parameters)
        {
            IList<Depart> list = new List<Depart>();
            using (DataTable dt = DBHelper.GetDataSet(sql, parameters))
            {
                foreach (DataRow row in dt.Rows)
                {
                    Depart depart = new Depart();
                    depart.DepartId = (int)row["DepartId"];
                    depart.DepartName = (string)row["DepartName"];
                    depart.ConnectTelNo = (long)row["ConnectTelNo"];
                    depart.ConnectMobileTelNo = (long)row["ConnectMobileTelNo"];
                    depart.Faxes = (long)row["Faxes"];
                    depart.PrincipalUser = UserService.GetUserById(row["PrincipalUser"].ToString());
                    depart.Branch = BranchService.GetBranchById(Convert.ToInt32(row["BranchId"]));
                    list.Add(depart);
                }
                return list;
            }
        }
        /// <summary>
        /// 修改部门信息
        /// </summary>
        /// <param name="depart"></param>
        /// <returns></returns>
        public static int UpdateDepart(Depart depart)
        {
            string sql = "update DepartInfo set DepartName=@DepartName,ConnectTelNo=@ConnectTelNo,ConnectMobileTelNo=@ConnectMobileTelNo,Faxes=@Faxes,PrincipalUser=@PrincipalUser,BranchId=@BranchId where DepartId=@DepartId";
            SqlParameter[] para = new SqlParameter[] 
            {
                new SqlParameter("@DepartName",depart.DepartName),
                new SqlParameter("@ConnectTelNo",depart.ConnectTelNo),
                new SqlParameter("@ConnectMobileTelNo",depart.ConnectMobileTelNo),
                new SqlParameter("@Faxes",depart.Faxes),
                new SqlParameter("@PrincipalUser",depart.PrincipalUser.UserId),
                new SqlParameter("@BranchId",depart.Branch.BranchId),
                new SqlParameter("@DepartId",depart.DepartId)
            };
            return DBHelper.ExecuteCommand(sql,para);
        }
        /// <summary>
        /// 删除部门信息
        /// </summary>
        /// <param name="departId"></param>
        /// <returns></returns>
        public static int DeleteDepart(int departId)
        {
            try
            {
                string sql = "Delete from DepartInfo where DepartId=" + departId;
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
            //            new SqlParameter("@DepartId",departId)
            //        };
            //        string sql = DBHelper.DeleteStringBuilder(new string[] { "UserInfo", "DepartInfo" }, new string[] { "DepartId", "DepartId" }, "@DepartId").ToString();
            //        return DBHelper.ExecuteCommand(sql,para);
            //    }
            //    catch (Exception ex)
            //    {
            //        throw ex;
            //    }
            //    conn.Close();
            //}
        }



        /// <summary>
        /// 根据机构ID查找对象集合
        /// </summary>
        /// <param name="branchId">部门ID</param>
        /// <returns></returns>
        public static IList<Depart> GetDeparByBranchId(int branchId)
        {
            string sql = "select * from DepartInfo where BranchId=@BranchId ";
            SqlParameter[] parameters ={ new SqlParameter("@BranchId", branchId) };
            return GetAllDepart(sql, parameters);
        }
    }
}
