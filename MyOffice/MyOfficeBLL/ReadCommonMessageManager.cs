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
        /// 添加
        /// </summary>
        /// <param name="readComment"></param>
        /// <returns></returns>
        public static ReadCommonMessage AddReadCommonMessage(ReadCommonMessage readComment)
        {
            return ReadCommonMessageService.AddReadCommonMessage(readComment);
        }

        /// <summary>
        /// 根据Id查询消息阅读人
        /// </summary>
        /// <param name="readId"></param>
        /// <returns></returns>
        public static ReadCommonMessage GetReadCommonMessageById(int readId)
        {
            return ReadCommonMessageService.GetReadCommonMessageById(readId);
        }

        /// <summary>
        /// 查询消息阅读人
        /// </summary>
        /// <returns></returns>
        public static IList<ReadCommonMessage> GetAllReadCommonMessage()
        {
            return ReadCommonMessageService.GetAllReadCommonMessage();
        }

        /// <summary>
        /// 更新读信息
        /// </summary>
        /// <param name="messageId"></param>
        /// <param name="userId"></param>
        public static void UpdateReadCommonMessage(int messageId, string userId)
        {
            ReadCommonMessageService.UpdateReadCommonMessage(messageId, userId);
        }
    }
}
