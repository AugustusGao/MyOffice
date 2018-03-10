using System;
using System.Collections.Generic;
using System.Text;
using MyOffice.DAL;
using MyOffice.Models;

namespace MyOffice.BLL
{
    public class MessageTypeManager
    {
        /// <summary>
        /// 根据MessageTypeID查询消息类型
        /// </summary>
        /// <param name="typeId">类型ID</param>
        /// <returns></returns>
        public static MessageType GetMessageTypeById(int typeId)
        {
            return MessageTypeService.GetMessageTypeById(typeId);
        }

        /// <summary>
        /// 查询所有消息类型
        /// </summary>
        /// <returns></returns>
        public static IList<MessageType> GetAllMessageType()
        {
            return MessageTypeService.GetAllMessageType() ;
        }
    }
}
