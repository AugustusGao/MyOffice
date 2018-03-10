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
        /// ���ҵ�ǰ��¼�û������б�ǩ����Ϣ
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
       public static IList<MyNote> GetAllMyNotes(string userId) 
       {
           return MyNoteService.GetAllMyNotes(userId);
       }
       /// <summary>
       /// ������ǩ
       /// </summary>
       /// <param name="myNote"></param>
       /// <returns></returns>
       public static int AddMyNote(MyNote myNote) 
       {
           return MyNoteService.AddMyNote(myNote);
       }
       /// <summary>
       /// ���ݱ�ǩIdɾ����ǩ
       /// </summary>
       /// <param name="id"></param>
       /// <returns></returns>
       public static int DeleteMyNoteById(int id) 
       {
           return MyNoteService.DeleteMyNoteById(id);
       }

       /// <summary>
       /// ͨ����ǩId��øñ�ǩ����Ϣ
       /// </summary>
       /// <param name="id"></param>
       /// <returns></returns>
       public static MyNote GetMyNoteById(int id) 
       {
           return MyNoteService.GetMyNoteById(id);
       }
       /// <summary>
       /// ͨ����ǩId�޸ı�ǩ����Ϣ
       /// </summary>
       /// <param name="myNote"></param>
       /// <returns></returns>
       public static int ModifyMyNoteById(MyNote myNote) 
       {
           return MyNoteService.ModifyMyNoteById(myNote);
       }
    }
}
