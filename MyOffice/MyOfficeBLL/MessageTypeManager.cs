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
        /// ����MessageTypeID��ѯ��Ϣ����
        /// </summary>
        /// <param name="typeId">����ID</param>
        /// <returns></returns>
        public static MessageType GetMessageTypeById(int typeId)
        {
            return MessageTypeService.GetMessageTypeById(typeId);
        }

        /// <summary>
        /// ��ѯ������Ϣ����
        /// </summary>
        /// <returns></returns>
        public static IList<MessageType> GetAllMessageType()
        {
            return MessageTypeService.GetAllMessageType() ;
        }
    }
}
