using System;
using System.Collections.Generic;
using System.Text;
using MyOffice.Models;
using System.Data.SqlClient;
using System.Data;

namespace MyOffice.DAL
{
    public class ManualSignService
    {
        public static ManualSign AddManualSign(ManualSign manualSign)
        {
            string sql = "insert into manualsign (userId,signtime,signdesc,signtag)values(@uId,@signTime,@signdesc,@signTag)";
            sql += ";select @@identity ";
            SqlParameter[] para = new SqlParameter[] {
            
            new SqlParameter("@uId",manualSign.User.UserId),
                new SqlParameter("@signTime",manualSign.SignTime),
                new SqlParameter("@signdesc",manualSign.SignDesc),
                new SqlParameter ("@signTag",manualSign.SignTag)
            };
            int newId = Convert.ToInt32(DBHelper.GetScalar(sql, para));
            return GetManualSignById(newId);

        }

        public static ManualSign GetManualSignById(int newId)
        {
            string sql = "select * from manualsign where signId=" + newId;
            string userId = "";
            SqlDataReader reader = DBHelper.GetReader(sql);
            if (reader.Read())
            {
                ManualSign m = new ManualSign();
                m.SignId = Convert.ToInt32(reader["signId"]);
                m.SignTag = Convert.ToInt32(reader["signTag"]);
                m.SignTime = Convert.ToDateTime(reader["signTime"]);
                m.SignDesc = Convert.ToString(reader["signDesc"]);
                userId = Convert.ToString(reader["userId"]);
                reader.Close();
                m.User = UserService.GetUserById(userId);
                return m;
            }
            else
            {
                reader.Close();

                return null;
            }
        }
        public IList<ManualSign> GetAllManualSigns()
        {
            string sql = " select * from manualsign ";
            return GetManualSignBySql(sql);
        }

        public static  IList<ManualSign> GetManualSignBySql(string sql)
        {
            IList<ManualSign> list = new List<ManualSign>();
            DataTable table = DBHelper.GetDataSet(sql);
            foreach (DataRow row in table.Rows)
            {
                ManualSign m = new ManualSign();
                m.SignId = Convert.ToInt32(row["signId"]);
                m.SignTag = Convert.ToInt32(row["signTag"]);
                m.SignTime = Convert.ToDateTime(row["signTime"]);
                m.SignDesc = Convert.ToString(row["signDesc"]);
                m.User = UserService.GetUserById(Convert.ToString(row["userId"]));
                list.Add(m);
            }
            return list;
        }

  
        public static void DeleteManualSignBySignId(int signId)
        {
            string sql = "DELETE ManualSign WHERE SignId = @SignId";

            try
            {
                SqlParameter[] para = new SqlParameter[]
				{
					new SqlParameter("@SignId", signId)
				};

                DBHelper.ExecuteCommand(sql, para);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                throw e;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sign">true:表示是否已签到 false：表示是否已签退</param>
        /// <returns> 0：已签到 1：表示已签退</returns>
        public static int GetManualSignState(bool sign, string userId)
        {
            string sql = "select count(SignId) from ManualSign where 1=1 ";
            if (sign)
            {
                sql += " and SignTime between '" + string.Format("{0:yyyy-MM-dd 0:00:00}", DateTime.Today) + "' and '" + string.Format("{0:yyyy-MM-dd 23:59:59}", DateTime.Today) + "' and SignTag=0 and UserId='" + userId + "'";
            }
            else
            {
                sql += " and SignTime between '" + string.Format("{0:yyyy-MM-dd 0:00:00}", DateTime.Today) + "' and '" + string.Format("{0:yyyy-MM-dd 23:59:59}", DateTime.Today) + "' and SignTag=1 and UserId='" + userId + "'";
            }
            int count = int.Parse(DBHelper.GetScalar(sql).ToString());

            return count;
        }
        public static void ModifyManualSign(ManualSign manualSign)
        {
            string sql =
                "UPDATE ManualSign " +
                "SET " +
                    "UserId = @UserId, " + //FK
                    "SignTime = @SignTime, " +
                    "SignDesc = @SignDesc, " +
                    "SignTag = @SignTag " +
                "WHERE SignId = @SignId";


            try
            {
                SqlParameter[] para = new SqlParameter[]
				{
					new SqlParameter("@SignId", manualSign.SignId),
					new SqlParameter("@UserId", manualSign.User.UserId), //FK
					new SqlParameter("@SignTime", manualSign.SignTime),
					new SqlParameter("@SignDesc", manualSign.SignDesc),
					new SqlParameter("@SignTag", manualSign.SignTag)
				};

                DBHelper.ExecuteCommand(sql, para);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                throw e;
            }

        }
    }
}
