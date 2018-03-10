using System;
using System.Collections.Generic;
using System.Text;
using MyOffice.Models;
using System.Data.SqlClient;
using System.Data;

namespace MyOffice.DAL
{
    public class MessageService
    {
        /// <summary>
        /// 添加消息
        /// </summary>
        /// <param name="message"></param>
        /// <returns></returns>
        public static int AddMessage(Message message)
        {
            string sqlStr =
                "INSERT INTO [MyOffice].[dbo].[Message]"
                + " ([Title],[Content],[Type],[BeginTime],[EndTime],[FromUserId],[IfPublish],[RecordTime],[IfDeleteTo],[IfDelete])"
                + " VALUES (@Title,@Content ,@Type,@BeginTime,@EndTime"
                + ",@FromUserId,@IfPublish,@RecordTime,@IfDeleteTo,@IfDelete)";
            sqlStr += " ;select @@Identity";
            SqlParameter[] para = new SqlParameter[]
            {
                new SqlParameter("@Title",message.Title),
                new SqlParameter("@Content",message.Content),
                new SqlParameter("@Type",message.Type.MessageTypeId),
                new SqlParameter("@BeginTime",message.BeginTime),
                new SqlParameter("@EndTime",message.EndTime),
                new SqlParameter("@FromUserId",message.FromUser.UserId),
                new SqlParameter("@IfPublish",message.IfPublish),
                new SqlParameter("@IfDeleteTo",message.IfDeleteTo),
                new SqlParameter("@IfDelete",message.IfDelete),
                new SqlParameter("@RecordTime",message.RecordTime)
            };
            int messageId = Convert.ToInt32(DBHelper.GetScalar(sqlStr, para));
            return messageId;
        }
        /// <summary>
        /// 根据ID查询消息
        /// </summary>
        /// <param name="message"></param>
        /// <returns></returns>
        public static Message GetMessageById(int messageId)
        {
            int typeId = 0;
            string sql = "select * from Message where MessageId=" + messageId;
            using (SqlDataReader reader = DBHelper.GetReader(sql))
            {
                if (reader.Read())
                {
                    Message message = new Message();
                    message.MessageId = (int)reader["MessageId"];
                    message.Title = (string)reader["Title"];
                    message.Content = (string)reader["Content"];
                    typeId = (int)reader["Type"];  //再找MessageTypeService的根据Id 找MessageType
                    message.BeginTime = (DateTime)reader["BeginTime"];
                    message.EndTime = (DateTime)reader["EndTime"];
                    message.RecordTime = (DateTime)reader["RecordTime"];
                    message.IfPublish = (int)reader["IfPublish"];
                    message.IfDelete = (int)reader["IfDelete"];
                    message.IfDeleteTo = (int)reader["IfDeleteTo"];
                    string userId = (string)reader["FromUserId"];
                    reader.Close();
                    message.FromUser = UserService.GetUserById(userId);
                    message.Type = MessageTypeService.GetMessageTypeById(typeId);
                    return message;
                }
                else
                {
                    reader.Close();
                    return null;
                }
            }
        }
        /// <summary>
        /// 查询所有消息
        /// </summary>
        /// <returns></returns>
        public static IList<Message> GetAllMessage()
        {
            string sql = "select * from Message";
            return GetMessageBySql(sql);
        }

        /// <summary>
        /// 根据条件查询所有信息
        /// </summary>
        /// <param name="begin"></param>
        /// <param name="end"></param>
        /// <param name="user"></param>
        /// <returns></returns>
        public static IList<Message> GetMessageByDate(string begin, string end, User user)
        {
            string sql = "select distinct * from Message where ((IfdeleteTo=0 and IfDelete =0) or  (IfdeleteTo in (0,2) and IfDelete =0))";
            if (begin != null && !begin.Equals("") && end != null && !end.Equals(""))
            {
                if (user.Role.RoleId == 2)
                {
                    //系统管理员
                    sql += " and RecordTime between '" + begin + "' and '" + end + "'";
                }
                else
                {
                    //普通用户
                    sql += " and RecordTime between '" + begin
                        + "' and '" + end + "' and FromUserId='" + user.UserId + "'";
                }
            }
            else
            {
                if (user.Role.RoleId != 2)
                {
                    sql += " and FromUserId='" + user.UserId + "'"; //普通用户
                }
            }
            sql += " order by RecordTime desc";
            return GetMessageBySql(sql);
        }

        public static IList<Message> GetMessageBySql(string sql)
        {
            IList<Message> list = new List<Message>();
            try
            {
                using (DataTable dt = DBHelper.GetDataSet(sql))
                {
                    foreach (DataRow row in dt.Rows)
                    {
                        Message message = new Message();
                        message.MessageId = (int)row["MessageId"];
                        message.Title = (string)row["Title"];
                        message.Content = (string)row["Content"];
                        message.Type = MessageTypeService.GetMessageTypeById((int)row["Type"]);
                        message.BeginTime = (DateTime)row["BeginTime"];
                        message.EndTime = (DateTime)row["EndTime"];
                        message.RecordTime = (DateTime)row["RecordTime"];
                        message.IfPublish = (int)row["IfPublish"];
                        message.IfDelete = (int)row["IfDelete"];
                        message.IfDeleteTo = (int)row["IfDeleteTo"];
                        string userId = (string)row["FromUserId"];
                        message.FromUser = UserService.GetUserById(userId);
                        list.Add(message);
                    }
                    return list;
                }
            }
            catch (Exception ex)
            {
                throw new ApplicationException(ex.Message);
            }
        }
        /// <summary>
        /// 修改消息
        /// </summary>
        /// <param name="message"></param>
        /// <returns></returns>
        public static int UpdateMessage(Message message)
        {
            string sql = "update Message set Title=@Title,Content=@Content,Type=@Type,BeginTime=@BeginTime," +
                "EndTime=@EndTime,RecordTime=@RecordTime,IfPublish=@IfPublish,FromUserId=@FromUserId," +
                "IfDelete=@IfDelete,IfDeleteTo=@IfDeleteTo where MessageId=@MessageId";

            SqlParameter[] para = new SqlParameter[]
            {
                new SqlParameter("@Title",message.Title),
                new SqlParameter("@Content",message.Content),
                new SqlParameter("@Type",message.Type.MessageTypeId),
                new SqlParameter("@BeginTime",message.BeginTime),
                new SqlParameter("@EndTime",message.EndTime),
                new SqlParameter("@RecordTime",DateTime.Now),
                new SqlParameter("@IfPublish",message.IfPublish),
                new SqlParameter("@FromUserId",message.FromUser.UserId),
                new SqlParameter("@IfDelete",message.IfDelete),
                new SqlParameter("@IfDeleteTo",message.IfDeleteTo),
                new SqlParameter("@MessageId",message.MessageId)
            };
            return DBHelper.ExecuteCommand(sql, para);
        }
        /// <summary>
        /// 假删除消息
        /// </summary>
        /// <param name="messageId">消息ID</param>
        /// <param name="sign">true：发件箱删除 false：收件箱删除</param>
        public static void UpdateDeleteMessage(int messageId, bool sign)
        {
            //消息删除状态 0 正常 1 已删除 2 缓冲（隐藏消息）
            if (messageId > 0)
            {
                Message message = GetMessageById(messageId);
                if (message != null)
                {
                    //未发布消息（草稿）（发布状态为0）
                    if (message.IfPublish != 1)
                    {
                        #region  删除草稿（删除状态修改为1）
                        if (message.FromUser != null && !message.FromUser.Equals(""))
                        {
                            if (message.FromUser.UserId != null && !message.FromUser.UserId.Equals(""))
                            {
                                message.IfDelete = 1;
                            }
                        }
                        #endregion
                    }
                    else
                    {
                        //已发布的消息（消息状态为1）
                        #region  删除已发送 删除收件
                        //处理方案：如果状态值为0改为2如果是2改为1
                        //公共消息(处理方案有系统根据邮件有效期进行自动删除)
                        if (message.IfDeleteTo == message.IfDelete && message.IfDelete == 2)
                        {
                            message.IfDelete = 1;
                            message.IfDeleteTo = 1;
                        }

                        //非公共消息
                        if (sign)//表示发件删除
                        {
                            if (message.IfDelete == 0) message.IfDelete = 2;
                        }
                        else
                        {//收件删
                            if (message.IfDeleteTo == 0) message.IfDeleteTo = 2;
                        }
                    }
                    message.RecordTime = DateTime.Now;
                    int count = UpdateMessage(message);
                }
                        #endregion
            }
        }
        /// <summary>
        /// 获得邮件信息的数量
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public static BoxMessageCount GetNumber(User user)
        {
            BoxMessageCount msgCount = new BoxMessageCount();
            int inbox = 0, sum = 0, count = 0, cread = 0, send = 0;
            try
            {
                //收到的非公共信息数目
                string sql1 = "select count(a.MessageId) from Message a,MessageToUser b  " +
                    "where a.MessageId=b.MessageId and  b.ToUserId='" + user.UserId +
                    "' and a.IfPublish='1' and IfDelete=IfDeleteTo and IfDelete='0'";
                inbox = int.Parse(DBHelper.GetScalar(sql1).ToString());

                //未读非公共消息
                string sql2 = "select count(a.MessageId) from Message a,MessageToUser b  " +
                    "where a.MessageId=b.MessageId and  b.ToUserId='" + user.UserId +
                    "' and a.IfPublish='1' and IfRead='0' and IfDelete=IfDeleteTo and IfDelete='0'";
                sum = int.Parse(DBHelper.GetScalar(sql2).ToString());

                //所有公共消息
                string sql3 = "select count(a.MessageId) from Message a,MessageToUser b " +
                    "where b.MessageId=a.MessageId and b.ToUserId='0'and  a.IfPublish='1'and " +
                    "IfDelete=IfDeleteTo and IfDelete='0' ";
                count = int.Parse(DBHelper.GetScalar(sql3).ToString());
                //已读公共消息
                string sql4 = "select count(a.MessageId) from ReadCommonMessage a,Message b,MessageToUser c where " +
                    "a.MessageId=c.MessageId and c.MessageId =b.MessageId and c.ToUserId='0' and  b.IfPublish='1' " +
                    "and IfDelete=IfDeleteTo and IfDelete='0' and c.IfRead='1'";
                cread = int.Parse(DBHelper.GetScalar(sql4).ToString());
                //已发的数目
                string sql5 = "select count(MessageId) from Message where FromUserId='" + user.UserId +
                    "' and IfPublish='1'and IfDelete=IfDeleteTo and IfDelete='0'  ";
                send = int.Parse(DBHelper.GetScalar(sql5).ToString());
                //草稿数
                string sql6 = "select count(MessageId) from Message where FromUserId='" + user.UserId +
                    "' and IfPublish='0' and IfDelete=IfDeleteTo and IfDelete='0'";
                msgCount.DraftTotal = int.Parse(DBHelper.GetScalar(sql6).ToString());
                //已删除
                string sql7 = "select count(MessageId) from Message where FromUserId='" + user.UserId +
                    "' and (IfDelete in(1,2) or IfDeleteTo in(1,2)) ";
                msgCount.GarbageTotal = int.Parse(DBHelper.GetScalar(sql7).ToString());
            }
            catch (Exception ex)
            {
                throw new ApplicationException(ex.Message);
            }
            //得到所有未读的
            sum += count - cread;
            msgCount.ItNotRead = sum;
            //总文件数
            msgCount.InboxTotal = inbox + count;
            //已发送
            msgCount.SendedTotal = send;

            return msgCount;
        }

        /// <summary>
        /// 查询发件/草稿/删除信息
        /// </summary>
        /// <param name="user"></param>
        /// <param name="ifPublish"></param>
        /// <param name="ifDelete">删除</param>
        /// <param name="ifDeleteTo"></param>
        /// <returns></returns>
        public static IList<Message> SearchMessageByCondition(User user, int ifPublish, int ifDelete, int ifDeleteTo)
        {
            string sql = "";
            if (user != null)
            {
                if (user.UserId != null && !user.UserId.Equals(""))
                {
                    sql = "select distinct * from Message where FromUserId='" + user.UserId + "' ";
                    //草稿
                    if ((ifPublish == 0 && ifDelete == 0))
                    {
                        sql += " and IfPublish='" + ifPublish + "' and IfDelete='" + ifDelete + "'";
                    }
                    //发送
                    if ((ifPublish == 1 && ifDelete == 0 && ifDeleteTo == 0))
                    {
                        sql += " and IfPublish='" + ifPublish + "' and IfDelete='" + ifDelete + "' and ifDeleteTo='" + ifDeleteTo + "'";
                    }

                    //删除
                    if (ifDelete == -1 && ifDelete == -1 && ifPublish == -1)
                    {
                        sql += " and (IfDelete in(1,2) or IfDeleteTo in(1,2))";
                    }

                }
                return GetMessageBySql(sql);
            }
            return null;
        }
        /// <summary>
        /// 彻底删除
        /// </summary>
        /// <param name="messageId"></param>
        /// <returns></returns>
        public static int DeleteMessage(int messageId)
        {
            string sql = "Delete from Message where MessageId='" + messageId + "'";
            return DBHelper.ExecuteCommand(sql);
        }

        /// <summary>
        /// 获得新邮件数
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public static int GetNewMailInfo(User user)
        {
            int count = 0;
            if (user != null)
            {
                if (user.UserId != null && !user.UserId.Equals(""))
                {
                    //私人消息
                    string sqlPrivate = "select count(m.MessageId) from Message m,MessageToUser mu where m.MessageId=mu.MessageId and EndTime>=getdate() and IfRead=0 and IfPublish=1 and (IfDeleteTo=0 and IfDelete in(0,2)) and ToUserId='" + user.UserId + "'";
                    //公共消息
                    string sqlPublic = "select count(m.MessageId) from Message m,MessageToUser mu where m.MessageId=mu.MessageId  and EndTime>=getdate() and IfPublish=1   and ToUserId='0' and mu.MessageId not in" +
                        "(select distinct mu.MessageId from ReadCommonMessage rm,MessageToUser mu where rm.MessageId=mu.MessageId and ToUserId='0' and  UserId='" + user.UserId + "')";

                    object pi = DBHelper.GetScalar(sqlPrivate);
                    object pb = DBHelper.GetScalar(sqlPublic);
                    if (pi != null) count += int.Parse(pi.ToString());
                    if (pb != null) count += int.Parse(pb.ToString());
                }
            }
            return count;
        }
    }
}



