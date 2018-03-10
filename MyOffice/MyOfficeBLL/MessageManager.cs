using System;
using System.Collections.Generic;
using System.Text;
using MyOffice.Models;
using MyOffice.DAL;
using System.Web.UI.WebControls;

namespace MyOffice.BLL
{
    public class MessageManager
    {
        /// <summary>
        /// �����Ϣ
        /// </summary>
        /// <param name="message"></param>
        /// <returns></returns>
        public static int AddMessage(Message message)
        {
            return MessageService.AddMessage(message);
        }

        /// <summary>
        /// ����ID��ѯ��Ϣ
        /// </summary>
        /// <param name="message"></param>
        /// <returns></returns>
        public static Message GetMessageById(int messageId)
        {
            return MessageService.GetMessageById(messageId);
        }

        /// <summary>
        /// ��ѯ������Ϣ
        /// </summary>
        /// <returns></returns>
        public static IList<Message> GetAllMessage()
        {
            return MessageService.GetAllMessage();
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
            return MessageService.GetMessageByDate(begin,end,user);
        }

        /// <summary>
        /// �޸���Ϣ
        /// </summary>
        /// <param name="message"></param>
        /// <returns></returns>
        public static int UpdateMessage(Message message)
        {
            return MessageService.UpdateMessage(message);
        }

        /// <summary>
        /// ��ɾ����Ϣ
        /// </summary>
        /// <param name="messageId">��ϢID</param>
        /// <param name="sign">true��������ɾ�� false���ռ���ɾ��</param>
        public static void UpdateDeleteMessage(int messageId, bool sign)
        {
            MessageService.UpdateDeleteMessage(messageId,sign);
        }
        /// <summary>
        /// ������ϢId��÷��Ͷ��󣬲����ص��б���
        /// </summary>
        /// <param name="chklstUsers"></param>
        /// <param name="messageId"></param>
        public static void LoadReceiveUsersListByMessageId(CheckBoxList chklstUsers, int messageId)
        {
            IList<User> list = UserService.GetReceiveUsersByMessageId(messageId);
            chklstUsers.Items.Clear();
            foreach (User item in list)
            {
                ListItem li = new ListItem();
                li.Value = item.UserId;
                li.Text = item.UserName;
                li.Selected = true;
                chklstUsers.Items.Add(li);
            }
        }

        /// <summary>
        /// ����ʼ���Ϣ������
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public static BoxMessageCount GetNumber(User user)
        {
            return MessageService.GetNumber(user);
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
            return MessageService.SearchMessageByCondition(user, ifPublish, ifDelete, ifDeleteTo);
        }

        /// <summary>
        /// ����ɾ��
        /// </summary>
        /// <param name="messageId"></param>
        /// <returns></returns>
        public static int DeleteMessage(int messageId)
        {
            return MessageService.DeleteMessage(messageId);
        }

        /// <summary>
        /// ������ʼ���
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public static int GetNewMailInfo(User user)
        {
            return MessageService.GetNewMailInfo(user);
        }
    }
}
