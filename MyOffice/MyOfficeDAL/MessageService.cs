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
        /// �����Ϣ
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
        /// ����ID��ѯ��Ϣ
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
                    typeId = (int)reader["Type"];  //����MessageTypeService�ĸ���Id ��MessageType
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
        /// ��ѯ������Ϣ
        /// </summary>
        /// <returns></returns>
        public static IList<Message> GetAllMessage()
        {
            string sql = "select * from Message";
            return GetMessageBySql(sql);
        }

        /// <summary>
        /// ����������ѯ������Ϣ
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
                    //ϵͳ����Ա
                    sql += " and RecordTime between '" + begin + "' and '" + end + "'";
                }
                else
                {
                    //��ͨ�û�
                    sql += " and RecordTime between '" + begin
                        + "' and '" + end + "' and FromUserId='" + user.UserId + "'";
                }
            }
            else
            {
                if (user.Role.RoleId != 2)
                {
                    sql += " and FromUserId='" + user.UserId + "'"; //��ͨ�û�
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
        /// �޸���Ϣ
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
        /// ��ɾ����Ϣ
        /// </summary>
        /// <param name="messageId">��ϢID</param>
        /// <param name="sign">true��������ɾ�� false���ռ���ɾ��</param>
        public static void UpdateDeleteMessage(int messageId, bool sign)
        {
            //��Ϣɾ��״̬ 0 ���� 1 ��ɾ�� 2 ���壨������Ϣ��
            if (messageId > 0)
            {
                Message message = GetMessageById(messageId);
                if (message != null)
                {
                    //δ������Ϣ���ݸ壩������״̬Ϊ0��
                    if (message.IfPublish != 1)
                    {
                        #region  ɾ���ݸ壨ɾ��״̬�޸�Ϊ1��
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
                        //�ѷ�������Ϣ����Ϣ״̬Ϊ1��
                        #region  ɾ���ѷ��� ɾ���ռ�
                        //�����������״ֵ̬Ϊ0��Ϊ2�����2��Ϊ1
                        //������Ϣ(��������ϵͳ�����ʼ���Ч�ڽ����Զ�ɾ��)
                        if (message.IfDeleteTo == message.IfDelete && message.IfDelete == 2)
                        {
                            message.IfDelete = 1;
                            message.IfDeleteTo = 1;
                        }

                        //�ǹ�����Ϣ
                        if (sign)//��ʾ����ɾ��
                        {
                            if (message.IfDelete == 0) message.IfDelete = 2;
                        }
                        else
                        {//�ռ�ɾ
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
        /// ����ʼ���Ϣ������
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public static BoxMessageCount GetNumber(User user)
        {
            BoxMessageCount msgCount = new BoxMessageCount();
            int inbox = 0, sum = 0, count = 0, cread = 0, send = 0;
            try
            {
                //�յ��ķǹ�����Ϣ��Ŀ
                string sql1 = "select count(a.MessageId) from Message a,MessageToUser b  " +
                    "where a.MessageId=b.MessageId and  b.ToUserId='" + user.UserId +
                    "' and a.IfPublish='1' and IfDelete=IfDeleteTo and IfDelete='0'";
                inbox = int.Parse(DBHelper.GetScalar(sql1).ToString());

                //δ���ǹ�����Ϣ
                string sql2 = "select count(a.MessageId) from Message a,MessageToUser b  " +
                    "where a.MessageId=b.MessageId and  b.ToUserId='" + user.UserId +
                    "' and a.IfPublish='1' and IfRead='0' and IfDelete=IfDeleteTo and IfDelete='0'";
                sum = int.Parse(DBHelper.GetScalar(sql2).ToString());

                //���й�����Ϣ
                string sql3 = "select count(a.MessageId) from Message a,MessageToUser b " +
                    "where b.MessageId=a.MessageId and b.ToUserId='0'and  a.IfPublish='1'and " +
                    "IfDelete=IfDeleteTo and IfDelete='0' ";
                count = int.Parse(DBHelper.GetScalar(sql3).ToString());
                //�Ѷ�������Ϣ
                string sql4 = "select count(a.MessageId) from ReadCommonMessage a,Message b,MessageToUser c where " +
                    "a.MessageId=c.MessageId and c.MessageId =b.MessageId and c.ToUserId='0' and  b.IfPublish='1' " +
                    "and IfDelete=IfDeleteTo and IfDelete='0' and c.IfRead='1'";
                cread = int.Parse(DBHelper.GetScalar(sql4).ToString());
                //�ѷ�����Ŀ
                string sql5 = "select count(MessageId) from Message where FromUserId='" + user.UserId +
                    "' and IfPublish='1'and IfDelete=IfDeleteTo and IfDelete='0'  ";
                send = int.Parse(DBHelper.GetScalar(sql5).ToString());
                //�ݸ���
                string sql6 = "select count(MessageId) from Message where FromUserId='" + user.UserId +
                    "' and IfPublish='0' and IfDelete=IfDeleteTo and IfDelete='0'";
                msgCount.DraftTotal = int.Parse(DBHelper.GetScalar(sql6).ToString());
                //��ɾ��
                string sql7 = "select count(MessageId) from Message where FromUserId='" + user.UserId +
                    "' and (IfDelete in(1,2) or IfDeleteTo in(1,2)) ";
                msgCount.GarbageTotal = int.Parse(DBHelper.GetScalar(sql7).ToString());
            }
            catch (Exception ex)
            {
                throw new ApplicationException(ex.Message);
            }
            //�õ�����δ����
            sum += count - cread;
            msgCount.ItNotRead = sum;
            //���ļ���
            msgCount.InboxTotal = inbox + count;
            //�ѷ���
            msgCount.SendedTotal = send;

            return msgCount;
        }

        /// <summary>
        /// ��ѯ����/�ݸ�/ɾ����Ϣ
        /// </summary>
        /// <param name="user"></param>
        /// <param name="ifPublish"></param>
        /// <param name="ifDelete">ɾ��</param>
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
                    //�ݸ�
                    if ((ifPublish == 0 && ifDelete == 0))
                    {
                        sql += " and IfPublish='" + ifPublish + "' and IfDelete='" + ifDelete + "'";
                    }
                    //����
                    if ((ifPublish == 1 && ifDelete == 0 && ifDeleteTo == 0))
                    {
                        sql += " and IfPublish='" + ifPublish + "' and IfDelete='" + ifDelete + "' and ifDeleteTo='" + ifDeleteTo + "'";
                    }

                    //ɾ��
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
        /// ����ɾ��
        /// </summary>
        /// <param name="messageId"></param>
        /// <returns></returns>
        public static int DeleteMessage(int messageId)
        {
            string sql = "Delete from Message where MessageId='" + messageId + "'";
            return DBHelper.ExecuteCommand(sql);
        }

        /// <summary>
        /// ������ʼ���
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
                    //˽����Ϣ
                    string sqlPrivate = "select count(m.MessageId) from Message m,MessageToUser mu where m.MessageId=mu.MessageId and EndTime>=getdate() and IfRead=0 and IfPublish=1 and (IfDeleteTo=0 and IfDelete in(0,2)) and ToUserId='" + user.UserId + "'";
                    //������Ϣ
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



