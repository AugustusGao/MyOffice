using System;
using System.Collections.Generic;
using System.Text;
using MyOffice.DAL;
using MyOffice.Models;

namespace MyOffice.BLL
{
    public class ReadCommonMessageManager
    {
        /// <summary>
        /// ���
        /// </summary>
        /// <param name="readComment"></param>
        /// <returns></returns>
        public static ReadCommonMessage AddReadCommonMessage(ReadCommonMessage readComment)
        {
            return ReadCommonMessageService.AddReadCommonMessage(readComment);
        }

        /// <summary>
        /// ����Id��ѯ��Ϣ�Ķ���
        /// </summary>
        /// <param name="readId"></param>
        /// <returns></returns>
        public static ReadCommonMessage GetReadCommonMessageById(int readId)
        {
            return ReadCommonMessageService.GetReadCommonMessageById(readId);
        }

        /// <summary>
        /// ��ѯ��Ϣ�Ķ���
        /// </summary>
        /// <returns></returns>
        public static IList<ReadCommonMessage> GetAllReadCommonMessage()
        {
            return ReadCommonMessageService.GetAllReadCommonMessage();
        }

        /// <summary>
        /// ���¶���Ϣ
        /// </summary>
        /// <param name="messageId"></param>
        /// <param name="userId"></param>
        public static void UpdateReadCommonMessage(int messageId, string userId)
        {
            ReadCommonMessageService.UpdateReadCommonMessage(messageId, userId);
        }
    }
}
