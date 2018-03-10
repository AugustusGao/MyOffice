using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Collections;
using System.Data.SqlClient;
using System.Text;
    /// <summary>
    /// SqlHelper数据库操作方法
    /// </summary>
    public abstract class SqlHelper
    {
        public static readonly string ConStrUrl = ConfigurationManager.ConnectionStrings["SQLURL"].ConnectionString;

        // Hashtable to store cached parameters
        private static Hashtable parmCache = Hashtable.Synchronized(new Hashtable());

        /// <summary>
        /// 执行增删改（无事务）
        /// </summary>
        /// <remarks>
        /// 例如:  
        ///  int result = ExecuteNonQuery(connString, CommandType.StoredProcedure, "PublishOrders", new SqlParameter("@prodid", 24));
        /// </remarks>
        /// <param name="connectionString">连接字符串</param>
        /// <param name="commandType">命令类型(stored procedure, text, etc.)</param>
        /// <param name="commandText">存储过程名 或 T-SQL 命令</param>
        /// <param name="commandParameters">命令参数</param>
        /// <returns>返回执行影响的行数</returns>
        public static int ExecuteNonQuery(string connectionString, CommandType cmdType, string cmdText, params SqlParameter[] commandParameters)
        {

            SqlCommand cmd = new SqlCommand();

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                PrepareCommand(cmd, conn, null, cmdType, cmdText, commandParameters);
                int val = cmd.ExecuteNonQuery();
                cmd.Parameters.Clear();
                return val;
            }
        }

        /// <summary>
        /// 执行增删改（无事务）
        /// </summary>
        /// <remarks>
        /// 例如:  
        ///  int result = ExecuteNonQuery(connString, CommandType.StoredProcedure, "PublishOrders", new SqlParameter("@prodid", 24));
        /// </remarks>
        /// <param name="conn">连接对象</param>
        /// <param name="commandType">命令类型 (stored procedure, text, etc.)</param>
        /// <param name="commandText">存储过程名称 或 T-SQL 命令</param>
        /// <param name="commandParameters">命令参数</param>
        /// <returns>返回影响的行数</returns>
        public static int ExecuteNonQuery(SqlConnection connection, CommandType cmdType, string cmdText, params SqlParameter[] commandParameters)
        {

            SqlCommand cmd = new SqlCommand();

            PrepareCommand(cmd, connection, null, cmdType, cmdText, commandParameters);
            int val = cmd.ExecuteNonQuery();
            cmd.Parameters.Clear();
            return val;
        }

        /// <summary>
        /// 执行增删改（有事务）
        /// </summary>
        /// <remarks>
        /// 例如:  
        ///  int result = ExecuteNonQuery(connString, CommandType.StoredProcedure, "PublishOrders", new SqlParameter("@prodid", 24));
        /// </remarks>
        /// <param name="trans">事务对象</param>
        /// <param name="commandType">命令类型(stored procedure, text, etc.)</param>
        /// <param name="commandText">存储过程名称 或 T-SQL 命令</param>
        /// <param name="commandParameters">命令参数数组</param>
        /// <returns>返回影响的行数</returns>
        public static int ExecuteNonQuery(SqlTransaction trans, CommandType cmdType, string cmdText, params SqlParameter[] commandParameters)
        {
            SqlCommand cmd = new SqlCommand();
            PrepareCommand(cmd, trans.Connection, trans, cmdType, cmdText, commandParameters);
            int val = cmd.ExecuteNonQuery();
            cmd.Parameters.Clear();
            return val;
        }

        /// <summary>
        /// 执行查询返回SqlDataReader结果集
        /// </summary>
        /// <remarks>
        /// 例如:  
        ///  SqlDataReader r = ExecuteReader(connString, CommandType.StoredProcedure, "PublishOrders", new SqlParameter("@prodid", 24));
        /// </remarks>
        /// <param name="connectionString">连接字符串</param>
        /// <param name="commandType">命令类型(stored procedure, text, etc.)</param>
        /// <param name="commandText">存储过程名称 或 T-SQL 命令</param>
        /// <param name="commandParameters">命令参数数组</param>
        /// <returns>返回SqlDataReader结果集</returns>
        public static SqlDataReader ExecuteReader(string connectionString, CommandType cmdType, string cmdText, params SqlParameter[] commandParameters)
        {
            SqlCommand cmd = new SqlCommand();
            SqlConnection conn = new SqlConnection(connectionString);

            //当出现异常时关闭连接对象，无异常时当SqlDataReader关闭时，则同时关闭连接
            try
            {
                PrepareCommand(cmd, conn, null, cmdType, cmdText, commandParameters);
                SqlDataReader rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                cmd.Parameters.Clear();
                return rdr;
            }
            catch
            {
                conn.Close();
                throw;
            }
        }

        /// <summary>
        /// 执行查询，并返回查询所返回的结果集的第一行第一列，忽略其他列或行
        /// </summary>
        /// <remarks>
        /// 例如:  
        ///  Object obj = ExecuteScalar(connString, CommandType.StoredProcedure, "PublishOrders", new SqlParameter("@prodid", 24));
        /// </remarks>
        /// <param name="connectionString">连接字符串</param>
        /// <param name="commandType">命令类型 (stored procedure, text, etc.)</param>
        /// <param name="commandText">存储过程名称 或 T-SQL 命令</param>
        /// <param name="commandParameters">命令参数数组/param>
        /// <returns>返回Object对象</returns>
        public static object ExecuteScalar(string connectionString, CommandType cmdType, string cmdText, params SqlParameter[] commandParameters)
        {
            SqlCommand cmd = new SqlCommand();

            using (SqlConnection connection = new SqlConnection(connectionString)) 
           {
                
                PrepareCommand(cmd, connection, null, cmdType, cmdText, commandParameters);
                object val = cmd.ExecuteScalar();
                cmd.Parameters.Clear();
                return val;
            }
        }

        /// <summary>
        /// 执行查询，并返回查询所返回的结果集的第一行第一列，忽略其他列或行
        /// </summary>
        /// <remarks>
        /// 例如:  
        ///  Object obj = ExecuteScalar(connString, CommandType.StoredProcedure, "PublishOrders", new SqlParameter("@prodid", 24));
        /// </remarks>
        /// <param name="conn">an existing database connection</param>
        /// <param name="commandType">命令类型 (stored procedure, text, etc.)</param>
        /// <param name="commandText">存储过程名 或 T-SQL 命令</param>
        /// <param name="commandParameters">命令参数数组</param>
        /// <returns>返回object对象</returns>
        public static object ExecuteScalar(SqlConnection connection, CommandType cmdType, string cmdText, params SqlParameter[] commandParameters)
        {

            SqlCommand cmd = new SqlCommand();
              
            PrepareCommand(cmd, connection, null, cmdType, cmdText, commandParameters);
            object val = cmd.ExecuteScalar();
            cmd.Parameters.Clear();
            return val;
        }
      
        /// <summary>
        /// 执行查询，并返回查询所返回的结果集的第一行第一列，忽略其他列或行（执行事务）
        /// </summary>
        /// <remarks>
        /// 例如:  
        ///  Object obj =ExecuteScalar(事务,命令状态,命令文本,参数数组)
        /// </remarks>
        /// <param name="trans">事务对象</param>
        /// <param name="commandType">命令类型 (stored procedure, text, etc.)</param>
        /// <param name="commandText">存储过程名 或 T-SQL 命令</param>
        /// <param name="commandParameters">命令参数数组</param>
        /// <returns>返回object对象</returns>
        public static object ExecuteScalar(SqlTransaction trans, CommandType cmdType, string cmdText, params SqlParameter[] commandParameters)
        {

            SqlCommand cmd = new SqlCommand();

            PrepareCommand(cmd,trans.Connection, trans, cmdType, cmdText, commandParameters);
            object val = cmd.ExecuteScalar();
            cmd.Parameters.Clear();
            return val;
        }

        /// <summary>
        /// 返回DataTable内存表
        /// </summary>
        /// <param name="connectionString">连接字符串</param>
        /// <param name="cmdType">命令类型</param>
        /// <param name="cmdText">命令文本</param>
        /// <param name="commandParameters">命令参数数组</param>
        /// <returns>返回内存表</returns>
        public static DataTable GetDataTable(string connectionString, CommandType cmdType, string cmdText, params SqlParameter[] commandParameters)
        {

            SqlCommand cmd = new SqlCommand();
            DataSet ds = new DataSet();
            using(SqlConnection connection=new SqlConnection(connectionString)){

            PrepareCommand(cmd, connection, null, cmdType, cmdText, commandParameters);
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            adapter.Fill(ds);
            cmd.Parameters.Clear();
            return ds.Tables[0];
            }
        }

        /// <summary>
        /// 返回DataTable内存表
        /// </summary>
        /// <param name="connection">连接对象</param>
        /// <param name="cmdType">命令类型</param>
        /// <param name="cmdText">命令文本</param>
        /// <param name="commandParameters">命令参数数组</param>
        /// <returns></returns>
        public static DataTable GetDataTable(SqlConnection connection, CommandType cmdType, string cmdText, params SqlParameter[] commandParameters)
        {

            SqlCommand cmd = new SqlCommand();
            DataSet ds = new DataSet();
            PrepareCommand(cmd, connection, null, cmdType, cmdText, commandParameters);
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            adapter.Fill(ds);
            cmd.Parameters.Clear();
            return ds.Tables[0];
        }

        /// <summary>
        /// 添加参数数组到缓存
        /// </summary>
        /// <param name="cacheKey">参数键</param>
        /// <param name="cmdParms">命令参数数组</param>
        public static void CacheParameters(string cacheKey, params SqlParameter[] commandParameters)
        {
            parmCache[cacheKey] = commandParameters;
        }

        /// <summary>
        /// 获得Cache参数数组
        /// </summary>
        /// <param name="cacheKey">循环cacheKey</param>
        /// <returns>Cached SqlParamters 数组</returns>
        public static SqlParameter[] GetCachedParameters(string cacheKey)
        {
            SqlParameter[] cachedParms = (SqlParameter[])parmCache[cacheKey];

            if (cachedParms == null)
                return null;

            SqlParameter[] clonedParms = new SqlParameter[cachedParms.Length];

            for (int i = 0, j = cachedParms.Length; i < j; i++)
                clonedParms[i] = (SqlParameter)((ICloneable)cachedParms[i]).Clone();

            return clonedParms;
        }

        /// <summary>
        /// 预处理命令
        /// </summary>
        /// <param name="cmd">SqlCommand 对象</param>
        /// <param name="conn">SqlConnection 对象</param>
        /// <param name="trans">SqlTransaction 对象</param>
        /// <param name="cmdType">命令类型 例如: stored procedure or text</param>
        /// <param name="cmdText">命令文本, e.g. Select * from Products</param>
        /// <param name="cmdParms">命令参数</param>
        private static void PrepareCommand(SqlCommand cmd, SqlConnection conn, SqlTransaction trans, CommandType cmdType, string cmdText, SqlParameter[] cmdParms)
        {

            if (conn.State != ConnectionState.Open)
                conn.Open();

            cmd.Connection = conn;
            cmd.CommandText = cmdText;

            if (trans != null)
                cmd.Transaction = trans;

            cmd.CommandType = cmdType;

            if (cmdParms != null)
            {
             if(cmdParms.Length>0) cmd.Parameters.AddRange(cmdParms);
            }
        }

        //级联删除
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

