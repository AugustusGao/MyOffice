using System;
using System.Collections.Generic;
using System.Text;
using MyOffice.Models;
using MyOffice.DAL;
using System.Data.SqlClient;

namespace MyOffice.BLL
{
    public class MessageToUserManager
    {
        /// <summary>
        /// ������ϢId��ѯ��Ϣ���Ͷ������Ϣ
        /// </summary>
        /// <param name="messageId"></param>
        /// <returns></returns>
        public static MessageToUser GetMessageToUserByMessageId(int messageId)
        {
            return MessageToUserService.GetMessageToUserByMessageId(messageId);
        }

        /// <summary>
        /// ������ϢId��ѯ��Ϣ���Ͷ���������Ϣ
        /// </summary>
        /// <param name="messageId"></param>
        /// <returns></returns>
        public static IList<MessageToUser> GetAllMessageToUserByMessageId(int messageId)
        {
            return MessageToUserService.GetAllMessageToUserByMessageId(messageId);
        }

        /// <summary>
        /// ������ϢId��÷��Ͷ��������
        /// </summary>
        /// <param name="messageId"></param>
        /// <returns></returns>
        public static int GetReceiveUserTypeByMessageId(int messageId)
        {
            return MessageToUserService.GetReceiveUserTypeByMessageId(messageId);
        }

        /// <summary>
        /// �����Ϣ�ķ��Ͷ���
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public static bool AddMessageToUser(MessageToUser item)
        {
            return MessageToUserService.AddMessageToUser(item);
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
            return MessageToUserService.UpdateMessageToUser(item);
        }

         /// <summary>
        /// �ռ�����ʾ��Ϣ
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public static IList<MessageToUser> SearchMessageToUser(User user)
        {
            return MessageToUserService.SearchMessageToUser(user);
        }
    }
}
