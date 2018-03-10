using System;
using System.Collections.Generic;
using System.Text;
using MyOffice.DAL;
using MyOffice.Models;

namespace MyOffice.BLL
{
    public class UserStateManager
    {

        /// <summary>
        /// ����UserStateId���Ҷ���
        /// </summary>
        /// <param name="roleId"></param>
        /// <returns></returns>
        public static UserState GetUserStateById(int userStateId)
        {
            return UserStateService.GetUserStateById(userStateId);
        }

        /// <summary>
       /// ��ѯ�����û�״̬
       /// </summary>
       /// <returns></returns>
        public static IList<UserState> GetAllUserState()
        {
            return UserStateService.GetAllUserState();
        }
    }
}
