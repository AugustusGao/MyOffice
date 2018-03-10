using System;
using System.Collections.Generic;
using System.Text;
using MyOffice.Models;
using System.Data.SqlClient;
using System.Data;

namespace MyOffice.DAL
{
    public class MessageTypeService
    {
        /// <summary>
        /// 根据MessageTypeID查询消息类型
        /// </summary>
        /// <param name="typeId">类型ID</param>
        /// <returns></returns>
        public static MessageType GetMessageTypeById(int typeId)
        {
            string sql="select * from MessageType where MessageTypeId="+typeId;
            using (SqlDataReader reader = DBHelper.GetReader(sql))
            {
                if (reader.Read())
                {
                    MessageType type = new MessageType();
                    type.MessageTypeId = (int)reader["MessageTypeId"];
                    type.MessageTypeName = (string)reader["MessageTypeName"];
                    type.MessageDesc = (string)reader["MessageDesc"];
                    reader.Close();
                    return type;
                }
                else
                {
                    reader.Close();
                    return null;
                }
            }
        }
        /// <summary>
        /// 查询所有消息类型
        /// </summary>
        /// <returns></returns>
        public static IList<MessageType> GetAllMessageType()
        {
            string sql = "select * from MessageType";
            return GetMessageTypeBySql(sql);
        }

        public static IList<MessageType> GetMessageTypeBySql(string sql)
        {
            IList<MessageType> list = new List<MessageType>();
            try
            {
                DataTable dt = DBHelper.GetDataSet(sql);
                foreach (DataRow row in dt.Rows)
                {
                    MessageType type = new MessageType();
                    type.MessageTypeId = (int)row["MessageTypeId"];
                    type.MessageTypeName=(string)row["MessageTypeName"];
                    type.MessageDesc = (string)row["MessageDesc"];
                    list.Add(type);
                }
                return list;
            }
            catch (Exception ex)
            {
                throw new ApplicationException(ex.Message);
            }
        }
    }
}
