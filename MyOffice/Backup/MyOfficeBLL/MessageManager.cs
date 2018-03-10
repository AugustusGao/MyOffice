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
        /// 添加消息
        /// </summary>
        /// <param name="message"></param>
        /// <returns></returns>
        public static int AddMessage(Message message)
        {
            return MessageService.AddMessage(message);
        }

        /// <summary>
        /// 根据ID查询消息
        /// </summary>
        /// <param name="message"></param>
        /// <returns></returns>
        public static Message GetMessageById(int messageId)
        {
            return MessageService.GetMessageById(messageId);
        }

        /// <summary>
        /// 查询所有消息
        /// </summary>
        /// <returns></returns>
        public static IList<Message> GetAllMessage()
        {
            return MessageService.GetAllMessage();
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
            return MessageService.GetMessageByDate(begin,end,user);
        }

        /// <summary>
        /// 修改消息
        /// </summary>
        /// <param name="message"></param>
        /// <returns></returns>
        public static int UpdateMessage(Message message)
        {
            return MessageService.UpdateMessage(message);
        }

        /// <summary>
        /// 假删除消息
        /// </summary>
        /// <param name="messageId">消息ID</param>
        /// <param name="sign">true：发件箱删除 false：收件箱删除</param>
        public static void UpdateDeleteMessage(int messageId, bool sign)
        {
            MessageService.UpdateDeleteMessage(messageId,sign);
        }
        /// <summary>
        /// 根据消息Id获得发送对象，并加载到列表中
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
        /// 获得邮件信息的数量
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public static BoxMessageCount GetNumber(User user)
        {
            return MessageService.GetNumber(user);
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
            return MessageService.SearchMessageByCondition(user, ifPublish, ifDelete, ifDeleteTo);
        }

        /// <summary>
        /// 彻底删除
        /// </summary>
        /// <param name="messageId"></param>
        /// <returns></returns>
        public static int DeleteMessage(int messageId)
        {
            return MessageService.DeleteMessage(messageId);
        }

        /// <summary>
        /// 获得新邮件数
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public static int GetNewMailInfo(User user)
        {
            return MessageService.GetNewMailInfo(user);
        }
    }
}
