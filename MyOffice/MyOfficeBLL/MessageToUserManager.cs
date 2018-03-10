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
        /// 根据消息Id查询消息发送对象的信息
        /// </summary>
        /// <param name="messageId"></param>
        /// <returns></returns>
        public static MessageToUser GetMessageToUserByMessageId(int messageId)
        {
            return MessageToUserService.GetMessageToUserByMessageId(messageId);
        }

        /// <summary>
        /// 根据消息Id查询消息发送对象所有信息
        /// </summary>
        /// <param name="messageId"></param>
        /// <returns></returns>
        public static IList<MessageToUser> GetAllMessageToUserByMessageId(int messageId)
        {
            return MessageToUserService.GetAllMessageToUserByMessageId(messageId);
        }

        /// <summary>
        /// 根据消息Id获得发送对象的种类
        /// </summary>
        /// <param name="messageId"></param>
        /// <returns></returns>
        public static int GetReceiveUserTypeByMessageId(int messageId)
        {
            return MessageToUserService.GetReceiveUserTypeByMessageId(messageId);
        }

        /// <summary>
        /// 添加消息的发送对象
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public static bool AddMessageToUser(MessageToUser item)
        {
            return MessageToUserService.AddMessageToUser(item);
        }
        /// <summary>
        /// 修改消息
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
        /// 收件箱显示信息
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public static IList<MessageToUser> SearchMessageToUser(User user)
        {
            return MessageToUserService.SearchMessageToUser(user);
        }
    }
}
