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
        /// 根据UserStateId查找对象
        /// </summary>
        /// <param name="roleId"></param>
        /// <returns></returns>
        public static UserState GetUserStateById(int userStateId)
        {
            return UserStateService.GetUserStateById(userStateId);
        }

        /// <summary>
       /// 查询所有用户状态
       /// </summary>
       /// <returns></returns>
        public static IList<UserState> GetAllUserState()
        {
            return UserStateService.GetAllUserState();
        }
    }
}
