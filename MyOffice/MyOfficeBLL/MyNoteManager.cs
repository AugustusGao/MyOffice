using System;
using System.Collections.Generic;
using System.Text;
using MyOffice.DAL;
using MyOffice.Models;

namespace MyOffice.BLL
{
   public class MyNoteManager
    {
        /// <summary>
        /// 查找当前登录用户的所有便签的信息
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
       public static IList<MyNote> GetAllMyNotes(string userId) 
       {
           return MyNoteService.GetAllMyNotes(userId);
       }
       /// <summary>
       /// 新增便签
       /// </summary>
       /// <param name="myNote"></param>
       /// <returns></returns>
       public static int AddMyNote(MyNote myNote) 
       {
           return MyNoteService.AddMyNote(myNote);
       }
       /// <summary>
       /// 根据便签Id删除便签
       /// </summary>
       /// <param name="id"></param>
       /// <returns></returns>
       public static int DeleteMyNoteById(int id) 
       {
           return MyNoteService.DeleteMyNoteById(id);
       }

       /// <summary>
       /// 通过便签Id获得该便签的信息
       /// </summary>
       /// <param name="id"></param>
       /// <returns></returns>
       public static MyNote GetMyNoteById(int id) 
       {
           return MyNoteService.GetMyNoteById(id);
       }
       /// <summary>
       /// 通过便签Id修改便签的信息
       /// </summary>
       /// <param name="myNote"></param>
       /// <returns></returns>
       public static int ModifyMyNoteById(MyNote myNote) 
       {
           return MyNoteService.ModifyMyNoteById(myNote);
       }
    }
}
