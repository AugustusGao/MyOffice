using System;
using System.Collections.Generic;
using System.Text;
using MyOffice.Models;
using System.Data.SqlClient;
using System.Data;

namespace MyOffice.DAL
{
    public class ReadCommonMessageService
    {
        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="readComment"></param>
        /// <returns></returns>
        public static ReadCommonMessage AddReadCommonMessage(ReadCommonMessage readComment)
        {
            string sql = "insert into ReadCommonMessage(MessageId,UserId) values(@MessageId,@UserId)";
            sql += " ;Select @@Identity";
            SqlParameter[] para = new SqlParameter[]
            {
                new SqlParameter("@MessageId",readComment.Message.MessageId),
                new SqlParameter("@UserId",readComment.User.UserId)
            };
            int readId = Convert.ToInt32(DBHelper.GetScalar(sql,para));
            return GetReadCommonMessageById(readId);
        }
        /// <summary>
        /// 更新读信息
        /// </summary>
        /// <param name="messageId"></param>
        /// <param name="userId"></param>
        public static void UpdateReadCommonMessage(int messageId, string userId)
        {
            IList<MessageToUser> msgToUser = 
                MessageToUserService.GetAllMessageToUserByMessageId(messageId);
            if (msgToUser != null && msgToUser.Count > 0)
            {
                foreach (MessageToUser item in msgToUser)
                {
                    if (item.Message.IfPublish == 1)
                    {
                        if (item.ToUser != null)
                        {
                            if (item.ToUser.UserId.Equals("0"))
                            {
                                ReadCommonMessage readCM = SearchReadMUserId(-1, messageId, userId)[0];
                                if (readCM == null)
                                {
                                    //添加公共消息
                                    ReadCommonMessage rcm = new ReadCommonMessage();
                                    rcm.Message = item.Message;
                                    rcm.User.UserId = userId;
                                    AddReadCommonMessage(rcm);
                                }
                            }
                            else
                            {
                                if (item.IfRead == 0 && item.ToUser.UserId.Equals(userId))
                                {
                                    item.IfRead = 1;
                                    MessageToUserService.UpdateMessageToUser(item);
                                }
                            }
                        }
                    }
                }
            }
        }
        /// <summary>
        /// 根据条件查询阅读信息
        /// </summary>
        /// <param name="readId"></param>
        /// <param name="messageId"></param>
        /// <param name="userId"></param>
        /// <returns></returns>
        public static IList<ReadCommonMessage> SearchReadMUserId(int readId, int messageId, string userId)
        {
            string sql = "select * from ReadCommonMessage where 1=1";
            if (readId >= 0)
                sql += " and readId=" + readId + " ";
            if (messageId >= 0)
                sql += " and messageId='" + messageId + "'";
            if (userId != null && !userId.Equals(""))
                sql += " and userId='" + userId + "' ";
            return GetReadCommonMessageBySql(sql);
        }
        /// <summary>
        /// 根据Id查询消息阅读人
        /// </summary>
        /// <param name="readId"></param>
        /// <returns></returns>
        public static ReadCommonMessage GetReadCommonMessageById(int readId)
        {
            string sql = "select * from ReadCommonMessage where ReadId="+readId;
            using (SqlDataReader reader = DBHelper.GetReader(sql))
            {
                if (reader.Read())
                {
                    ReadCommonMessage item = new ReadCommonMessage();
                    item.ReadId = (int)reader["ReadId"];
                    string userId = (string)reader["UserId"];
                    int messageId = (int)reader["MessageId"];
                    reader.Close();
                    item.User = UserService.GetUserById(userId);
                    item.Message = MessageService.GetMessageById(messageId);
                    return item;
                }
                else
                {
                    reader.Close();
                    return null;
                }
            }
        }
        
        /// <summary>
        /// 查询消息阅读人
        /// </summary>
        /// <returns></returns>
        public static IList<ReadCommonMessage> GetAllReadCommonMessage()
        {
            string sql = "select * from ReadCommonMessage";
            return GetReadCommonMessageBySql(sql);
        }

        private static IList<ReadCommonMessage> GetReadCommonMessageBySql(string sql)
        {
            IList<ReadCommonMessage> list = new List<ReadCommonMessage>();
            try
            {
                DataTable dt = DBHelper.GetDataSet(sql);
                foreach (DataRow row in dt.Rows)
                {
                    ReadCommonMessage item = new ReadCommonMessage();
                    item.ReadId=(int)row["ReadId"];
                    item.User = UserService.GetUserById((string)row["UserId"]);
                    item.Message = MessageService.GetMessageById((int)row["MessageId"]);
                    list.Add(item);
                }
                return list;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return null;
        }
    }
}
