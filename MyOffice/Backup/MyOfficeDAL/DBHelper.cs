using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;

namespace MyOffice.DAL
{
    public static class DBHelper
    {
        public static readonly string connectionString = ConfigurationManager.ConnectionStrings["connStr"].ConnectionString;
        private static SqlConnection connection;
        public static SqlConnection Connection
        {
            get 
            {
               
                if (connection == null)
                {
                    connection = new SqlConnection(connectionString);
                    connection.Open();
                }
                else if (connection.State == System.Data.ConnectionState.Closed)
                {
                    connection.Open();
                }
                else if (connection.State == System.Data.ConnectionState.Broken)
                {
                    connection.Close();
                    connection.Open();
                }
                return connection;
            }
        }

        public static int ExecuteCommand(params SqlParameter[] values)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = Connection;
            cmd.CommandText = "Pro_UpdateBooksCatagory";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddRange(values);
            int result = cmd.ExecuteNonQuery();
            return result;
        }

        public static int ExecuteCommand(string safeSql)
        {
            SqlCommand cmd = new SqlCommand(safeSql, Connection);
            int result = cmd.ExecuteNonQuery();
            return result;
        }

        public static int ExecuteCommand(string sql, params SqlParameter[] values)
        {
            SqlCommand cmd = new SqlCommand(sql, Connection);
            cmd.Parameters.AddRange(values);
            return cmd.ExecuteNonQuery();
        }

        public static Object GetScalar(string safeSql)
        {
            SqlCommand cmd = new SqlCommand(safeSql, Connection);
            object result = cmd.ExecuteScalar();
            return result;
        }

       

        public static Object GetScalar(string sql, params SqlParameter[] values)
        {
            SqlCommand cmd = new SqlCommand(sql, Connection);
            cmd.Parameters.AddRange(values);
            object result = cmd.ExecuteScalar();
            return result;
        }

        public static SqlDataReader GetReader(string safeSql)
        {
            SqlCommand cmd = new SqlCommand(safeSql, Connection);
            SqlDataReader reader = cmd.ExecuteReader();
            return reader;
        }

        public static SqlDataReader GetReader(string sql, params SqlParameter[] values)
        {
            SqlCommand cmd = new SqlCommand(sql, Connection);
            cmd.Parameters.AddRange(values);
            SqlDataReader reader = cmd.ExecuteReader();
            return reader;
        }

        public static DataTable GetDataSet(string safeSql)
        {
            DataSet ds = new DataSet();
            SqlCommand cmd = new SqlCommand(safeSql, Connection);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(ds);
            return ds.Tables[0];
        }

        public static DataTable GetDataSet(string sql, params SqlParameter[] values)
        {
            DataSet ds = new DataSet();
            SqlCommand cmd = new SqlCommand(sql, Connection);
            cmd.Parameters.AddRange(values);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(ds);
            return ds.Tables[0];
        }
        /// <summary>
        /// 查询用户发送用户对象
        /// </summary>
        /// <param name="safeSql"></param>
        /// <returns></returns>
        public static string ReturnStringScalar(string safeSql)
        {
            SqlCommand cmd = new SqlCommand(safeSql, Connection);
            try
            {
                string result = cmd.ExecuteScalar().ToString();
                return result;
            }
            catch (Exception ex)
            {
                throw new ApplicationException(ex.Message);
                return "0";
            }
            connection.Close();
        }

        /// <summary>
        /// 级联删除
        /// </summary>
        /// <param name="table"></param>
        /// <param name="field"></param>
        /// <param name="key"></param>
        /// <returns></returns>
        public static StringBuilder DeleteStringBuilder(string[] table, string[] field, string key)
        {
            StringBuilder sb = new StringBuilder();
            string[] tableName = table;
            string[] fieldName = field;

            for (int i = 0; i < tableName.Length; i++)
            {
                sb.Append("DELETE " + tableName[i] + " WHERE " + fieldName[i] + " = " + key + " ; ");
            }
            return sb;
        }

    }

}
