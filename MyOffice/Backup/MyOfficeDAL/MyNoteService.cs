using System;
using System.Collections.Generic;
using System.Text;
using MyOffice.Models;
using System.Data;
using System.Data.SqlClient;

namespace MyOffice.DAL
{
   public class MyNoteService
    {
        /// <summary>
        /// 新增便签
       /// </summary>
       /// <param name="myNote"></param>
       /// <returns></returns>
       public static int AddMyNote(MyNote myNote)
       {
           string sql = "insert into MyNote(NoteTitle,NoteContent,CreateTime,CreateUser) values(@NoteTitle,@NoteContent,@CreateTime,@CreateUser);select @@identity";
           SqlParameter[] para = new SqlParameter[] 
           {
           new SqlParameter("@NoteTitle",myNote.NoteTitle),             
           new SqlParameter("@NoteContent",myNote.NoteContent),        
           new SqlParameter("@CreateTime",myNote.CreateTime),    
           new SqlParameter("@CreateUser",myNote.CreateUser.UserId),
           };
           return DBHelper.ExecuteCommand(sql,para);
       }

       /// <summary>
       /// 根据便签Id删除便签
       /// </summary>
       /// <param name="id"></param>
       /// <returns></returns>
       public static int DeleteMyNoteById(int id)
       {
           string sql = "delete from MyNote where NoteId="+id;
           return DBHelper.ExecuteCommand(sql);
       }

       /// <summary>
       /// 通过便签Id修改便签的信息
       /// </summary>
       /// <param name="myNote"></param>
       /// <returns></returns>
       public static int ModifyMyNoteById(MyNote myNote) 
       {
           string sql = "update MyNote set NoteTitle=@NoteTitle,NoteContent=@NoteContent where NoteId=@NoteId";
           SqlParameter[] para = new SqlParameter[] 
           {
           new SqlParameter("@NoteTitle",myNote.NoteTitle),             
           new SqlParameter("@NoteContent",myNote.NoteContent), 
           new SqlParameter("@NoteId",myNote.NoteId)
           };
           return DBHelper.ExecuteCommand(sql,para);
       }

       /// <summary>
       /// 通过便签Id获得该便签的信息
       /// </summary>
       /// <param name="id"></param>
       /// <returns></returns>
       public static MyNote GetMyNoteById(int id)
       {
           string sql = "select * from MyNote where NoteId="+id;
           return GetAllMyNotesBySql(sql)[0];
       }

       /// <summary>
       /// 查找当前登录用户的所有便签的信息
       /// </summary>
       /// <param name="userId"></param>
       /// <returns></returns>
       public static IList<MyNote> GetAllMyNotes(string userId) 
       {
           string sql = "select * from MyNote where CreateUser='"+userId+"'";
           return GetAllMyNotesBySql(sql);
       }
       /// <summary>
       /// 通过sql语句查询所有日程信息
       /// </summary>
       /// <param name="sql"></param>
       /// <returns></returns>
       private static IList<MyNote> GetAllMyNotesBySql(string sql)
       {
           IList<MyNote> ltMyNote = new List<MyNote>();
           try {
               DataTable dt = DBHelper.GetDataSet(sql);
               foreach (DataRow row in dt.Rows) 
               {
                   MyNote myNote = new MyNote();
                   myNote.CreateTime = (DateTime)row["createTime"];
                   myNote.CreateUser = UserService.GetUserById(Convert.ToString(row["createUser"]));
                   myNote.NoteContent = Convert.ToString(row["noteContent"]);
                   myNote.NoteId = Convert.ToInt32(row["noteId"]);
                   myNote.NoteTitle = Convert.ToString(row["noteTitle"]);
                   ltMyNote.Add(myNote);
               }
               return ltMyNote;
           }
           catch (Exception ex) 
           {
               Console.WriteLine(ex.Message);
               throw ex;
           }
       }
       /// <summary>
       /// 通过sql语句和参数查询所有日程信息
       /// </summary>
       /// <param name="sql"></param>
       /// <param name="values"></param>
       /// <returns></returns>
       private static IList<MyNote> GetAllMyNotesBySql(string sql,params SqlParameter [] values)
       {
           IList<MyNote> ltMyNote = new List<MyNote>();
           try
           {
               DataTable dt = DBHelper.GetDataSet(sql,values);
               foreach (DataRow row in dt.Rows)
               {
                   MyNote myNote = new MyNote();
                   myNote.CreateTime = (DateTime)row["createTime"];
                   myNote.CreateUser = UserService.GetUserById(Convert.ToString(row["createUser"]));
                   myNote.NoteContent = Convert.ToString(row["noteContent"]);
                   myNote.NoteId = Convert.ToInt32(row["noteId"]);
                   myNote.NoteTitle = Convert.ToString(row["noteTitle"]);
                   ltMyNote.Add(myNote);
               }
               return ltMyNote;
           }
           catch (Exception ex)
           {
               Console.WriteLine(ex.Message);
               throw ex;
           }
       }
    }
}
