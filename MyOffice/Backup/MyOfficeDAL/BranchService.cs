using System;
using System.Collections.Generic;
using System.Text;
using MyOffice.Models;
using System.Data;
using System.Data.SqlClient;

namespace MyOffice.DAL
{
    public class BranchService
    {
        /// <summary>
        /// 添加机构
        /// </summary>
        /// <param name="branch"></param>
        /// <returns></returns>
        public static Branch AddBranch(Branch branch)
        {
            string sql = "insert into BranchInfo(BranchName,BranchShortName) values(@BranchName,@BranchShortName)";
            sql += " ;Select @@Identity";
            SqlParameter[] para = new SqlParameter[]
            {
                new SqlParameter("@BranchName",branch.BranchName),
                new SqlParameter("@BranchShortName",branch.BranchShortName)
            };
            int branchId = Convert.ToInt32(DBHelper.GetScalar(sql,para));
            return GetBranchById(branchId);
        }
        /// <summary>
        /// 根据BrachId查机构信息
        /// </summary>
        /// <param name="branchId"></param>
        /// <returns></returns>
        public static Branch GetBranchById(int branchId)
        {
            string sql = "select * from BranchInfo where BranchId=" + branchId;
            SqlDataReader reader= DBHelper.GetReader(sql);
            if (reader.Read())
            {
                Branch branch = new Branch();
                branch.BranchId = (int)reader["BranchId"];
                branch.BranchName=(string)reader["BranchName"];
                branch.BranchShortName = (string)reader["BranchShortName"];
                reader.Close();
                return branch;
                
            }
            else
            {
                reader.Close();
                return null;
            }
        }
        /// <summary>
        /// 查询所有信息
        /// </summary>
        /// <returns></returns>
        public static IList<Branch> GetAllBranch()
        {
            string sql = "select * from BranchInfo order by BranchId desc";
            return GetAllBranchBySql(sql);
        }

        /// <summary>
        /// 根据SQL查所有信息（无参）
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        public static IList<Branch> GetAllBranchBySql(string sql)
        {
            IList<Branch> list = new List<Branch>();
            using (DataTable dt = DBHelper.GetDataSet(sql))
            {
                foreach (DataRow row in dt.Rows)
                {
                    Branch branch = new Branch();
                    branch.BranchId=(int)row["BranchId"];
                    branch.BranchName = (string)row["BranchName"];
                    branch.BranchShortName = (string)row["BranchShortName"];
                    list.Add(branch);
                }
                return list;
            }
        }
        /// <summary>
        /// 根据SQL查所有信息（有参）
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="para"></param>
        /// <returns></returns>
        public static IList<Branch> GetAllBranchBySql(string sql,SqlParameter para)
        {
            IList<Branch> list = new List<Branch>();
            using (DataTable dt = DBHelper.GetDataSet(sql,para))
            {
                foreach (DataRow row in dt.Rows)
                {
                    Branch branch = new Branch();
                    branch.BranchId = (int)row["BranchId"];
                    branch.BranchName = (string)row["BranchName"];
                    branch.BranchShortName = (string)row["BranchShortName"];
                    list.Add(branch);
                }
                return list;
            }
        }
        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="branchId"></param>
        /// <returns></returns>
        public static int DeleteBranchById(int branchId)
        {
            try
            {
                string sql = "Delete from BranchInfo where BranchID=" + branchId;
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
            //            new SqlParameter("@BranchId",branchId)
            //        };
            //        string sb=DBHelper.DeleteStringBuilder(new string[]{"DepartInfo","BranchInfo"},new string[]{"BranchId","BranchId"},"@BranchId").ToString();
            //        return DBHelper.ExecuteCommand(sb,para);
            //    }
            //    catch (Exception ex)
            //    { 
            //        throw ex;
            //    }
            //    conn.Close();
            //}
        }
        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="branch"></param>
        /// <returns></returns>
        public static int UpdateBranch(Branch branch) {
            string sql = "update BranchInfo set BranchName=@BranchName,BranchShortName=@BranchShortName where BranchId=@BranchId";
            SqlParameter[] para = new SqlParameter[]
            {
                new SqlParameter("@BranchName",branch.BranchName),
                new SqlParameter("@BranchShortName",branch.BranchShortName),
                new SqlParameter("@BranchId",branch.BranchId)
            };
            return DBHelper.ExecuteCommand(sql,para);
        }
    }
}
