using System;
using System.Collections.Generic;
using System.Text;
using MyOffice.Models;
using System.Data.SqlClient;
using System.Data;

namespace MyOffice.DAL
{
    public class MessageToUserService
    {
        /// <summary>
        /// ������ϢId��ѯ��Ϣ���Ͷ������Ϣ
        /// </summary>
        /// <param name="messageId"></param>
        /// <returns></returns>
        public static MessageToUser GetMessageToUserByMessageId(int messageId)
        {
            string sql = "select * from MessageToUser where MessageId=" + messageId;
            try
            {
                SqlDataReader reader = DBHelper.GetReader(sql);
                if (reader.Read())
                {
                    MessageToUser item = new MessageToUser();
                    item.Id = (int)reader["Id"];
                    item.IfRead = (int)reader["IfRead"];
                    int msgId = (int)reader["MessageId"];
                    string userId = (string)reader["ToUserId"];
                    reader.Close();
                    item.Message = MessageService.GetMessageById(msgId);
                    item.ToUser = UserService.GetUserById(userId);
                    return item;

                }
                else
                {
                    reader.Close();
                    return null;
                }
            }
            catch (Exception ex)
            {
                throw new ApplicationException(ex.Message);
            }
        }
        /// <summary>
        /// ������ϢId��÷��Ͷ��������
        /// </summary>
        /// <param name="messageId"></param>
        /// <returns></returns>
        public static int GetReceiveUserTypeByMessageId(int messageId)
        {
            string sql = "select Count(*) MessageToUser where messageId=" + messageId;
            int count = Convert.ToInt32(DBHelper.GetScalar(sql));
            if (count > 0)
            {
                //��ѯ���Ͷ���
                string sql2 = "select ToUserId from MessageToUser where messageId=" + messageId;
                string result = DBHelper.ReturnStringScalar(sql2);
                if (result.Equals("0"))
                {
                    return 0;
                }
                else
                {
                    return 1;
                }
            }
            else
            {
                return count;
            }
        }

        /// <summary>
        /// ������ϢID���û�ID��ѯ��Ϣ���Ͷ�����Ϣ
        /// </summary>
        /// <param name="messageId"></param>
        /// <returns></returns>
        public static MessageToUser GetMessageToUserByMessageIdandUserId(string userId,int messageId)
        {
            string sql = "select * from MessageToUser where MessageId="+messageId+" and ToUserId='"+userId+"'";
            sql+=" union select * from MessageToUser where MessageId="+messageId+" and ToUserId='0'";
            using(DataTable dt=DBHelper.GetDataSet(sql))
            {
                MessageToUser item = new MessageToUser();
                foreach(DataRow row in dt.Rows)
                {
                   
                    item.Id=(int)row["Id"];
                    item.IfRead=(int)row["IfRead"];
                    item.Message=MessageService.GetMessageById(messageId);
                    item.ToUser=UserService.GetUserById(userId);
                }
                return item;
            }
        }
        /// <summary>
        /// ������ϢId��ѯ��Ϣ���Ͷ���������Ϣ
        /// </summary>
        /// <param name="messageId"></param>
        /// <returns></returns>
       public static IList<MessageToUser> GetAllMessageToUserByMessageId(int messageId)
       {
           string sql="select * from MessageToUser where MessageId="+messageId;
           return GetMessageToUserBySql(sql); 
       }

        private static IList<MessageToUser> GetMessageToUserBySql(string sql)
        {
            IList<MessageToUser> list = new List<MessageToUser>();
            using (DataTable dt = DBHelper.GetDataSet(sql))
            {
                foreach (DataRow row in dt.Rows)
                {
                    MessageToUser item = new MessageToUser();
                    item.Id=(int)row["Id"];
                    item.IfRead=(int)row["IfRead"];
                    item.Message = MessageService.GetMessageById((int)row["MessageId"]);
                    item.ToUser = UserService.GetUserById((string)row["ToUserId"]);
                    list.Add(item);
                }
                return list;
            }
        }
        /// <summary>
        /// ���
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public static bool AddMessageToUser(MessageToUser item)
        {
            string sql = "insert into MessageToUser(MessageId,ToUserId,IfRead) values(@MessageId,@ToUserId,@IfRead)";
            sql+=" ;select @@Identity";
            SqlParameter[] para = new SqlParameter[]
            {
                new SqlParameter("@MessageId",item.Message.MessageId),
                new SqlParameter("@ToUserId",item.ToUser.UserId),
                new SqlParameter("@IfRead",item.IfRead)
            };
            int id = Convert.ToInt32(DBHelper.GetScalar(sql, para));
            if (id > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// �޸���Ϣ
        /// </summary>
        /// <param name="messageId"></param>
        /// <param name="toUserId"></param>
        /// <param name="IfRead"></param>
        /// <returns></returns>
        public static int UpdateMessageToUser(MessageToUser item)
        {
            string sql = "update MessageToUser set messageId=@messageId,ToUserId=@ToUserId,IfRead=@IfRead where Id=@Id";
            SqlParameter[] para = new SqlParameter[]
            {
                new SqlParameter("@messageId",item.Message.MessageId),
                new SqlParameter("@ToUserId",item.ToUser.UserId),
                new SqlParameter("@IfRead",item.IfRead),
                new SqlParameter("@Id",item.Id)
            };
            return DBHelper.ExecuteCommand(sql, para);
        }
        /// <summary>
        /// �ռ�����ʾ��Ϣ
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public static IList<MessageToUser> SearchMessageToUser(User user)
        {
            string sql = "select * from Message m,MessageToUser mu where m.MessageId=mu.MessageId and ToUserId in('" +
                user.UserId + "','0') and IfDeleteTo=0 and IfDelete =0 and IfPublish=1 ";
            return GetMessageToUserBySql(sql);
        }
    }
}
