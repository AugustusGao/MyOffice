using System;
using System.Collections.Generic;
using System.Text;
using MyOffice.Models;
using MyOffice.DAL;

namespace MyOffice.BLL
{
  public  class UserManager
    {
        /// <summary>
       /// 根据主键查找对象
       /// </summary>
       /// <param name="userId"></param>
       /// <returns></returns>
      public static User GetUserById(string  userId) {
          return UserService.GetUserById(userId);
      }
      /// <summary>
      /// 根据部门ID查找对象集合
      /// </summary>
      /// <param name="departId"></param>
      /// <returns></returns>
      public static IList<User> GetUseryDepartId(int departId)
      {
          return UserService.GetUseryDepartId(departId);
      }

        /// <summary>
       /// 查询所有用户信息
       /// </summary>
       /// <returns></returns>
      public static IList<User> GetAllUsers()
      {
          return UserService.GetAllUsers();
      }


       /// <summary>
       /// 根据用户名查询用户信息
       /// </summary>
       /// <param name="userName">用户名</param>
       /// <returns></returns>
      public static User GetUserByUserName(string userName)
      {
          return UserService.GetUserByUserName(userName);
      }
    
        /// <summary>
        /// 添加用户信息
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
      public static User AddUsers(User user)
      {
          return UserService.AddUsers(user);
      }

       /// <summary>
        /// 修改用户
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
      public static int UpdateUser(User user)
      {
          return UserService.UpdateUser(user);
      }

      /// <summary>
        /// 删除用户
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
      public static int DeleteUserById(string userId)
      {
          return UserService.DeleteUserById(userId);
      }
      /// <summary>
      /// 判断用户ID是否存在
      /// </summary>
      /// <param name="userId"></param>
      /// <returns></returns>
      public static bool UserNameExists(string userId)
      {
          User user = UserService.GetUserById(userId);
          if (user != null)
          {
              return true;
          }
          else
          {
              return false;
          }
      }
      /// <summary>
      /// 注册用户
      /// </summary>
      /// <param name="user"></param>
      /// <returns></returns>
      public static bool Register(User user)
      {
          if (UserNameExists(user.UserId))
          {
              return false;
          }
          else
          {
              UserService.AddUsers(user);
              return true;
          }
      }


      public static bool Login(string userName, string password, out User validUser)
      {
          User user = UserService.GetUserById(userName);
          if (user == null)
          {
              //用户名不存在 
              validUser = null;
              return false;
          }

          if (user.Password == password)
          {
              validUser = user;
              return true;
          }
          else
          {
              //密码错误
              validUser = null;
              return false;
          }
      }
      public static string[] GetNameByKeywords(string keyword, int displaycount)
      { return UserService.GetNameByKeywords(keyword, displaycount); }

      /// <summary>
      /// 根据条件查询用户信息
      /// </summary>
      /// <param name="branchId">机构ID</param>
      /// <param name="departId">部门ID</param>
      /// <param name="userId">用户Id</param>
      /// <param name="userName">用户名</param>
      /// <returns></returns>
      public static IList<User> SearchUserByItem(string  branchId, string departId, string userId, string userName)
      {
          return UserService.SearchUserByItem(branchId, departId, userId, userName);
      }
      /// <summary>
        /// 根据用户名模糊查询
        /// </summary>
        /// <param name="userName"></param>
        /// <returns></returns>
      public static IList<User> GetAllUserByUserName(string userName)
      {
          return UserService.GetAllUserByUserName(userName);
      }
  }
}
