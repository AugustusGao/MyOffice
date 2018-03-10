using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using MyOffice.Models;
using System.Data;
using System.Data.SqlClient;

namespace MyOffice.DAL
{
   public  class FileInfoService
    {
       private static IList<FileInfo> GetFileBySql(string sql)
       {
           IList<FileInfo> lists = new List<FileInfo>();
           DataTable table = DBHelper.GetDataSet(sql);
           foreach (DataRow  row in table.Rows)
           {
               FileInfo fileInfo = new FileInfo();
               fileInfo.FileId = Convert.ToInt32(row["fileId"]);
               fileInfo.FileName = Convert.ToString(row["fileName"]);
               fileInfo.Remark = Convert.ToString(row["remark"]);
               fileInfo.CreateDate = Convert.ToDateTime(row["createDate"]);
               fileInfo.ParentId = Convert.ToInt32(row["parentId"]);
               fileInfo.FilePath = Convert.ToString(row["filePath"]);
               fileInfo.IfDelete = Convert.ToInt32(row["ifDelete"]);
               //�������
               fileInfo.FileOwner = UserService.GetUserById(row["fileOwner"].ToString());
               fileInfo.FileType = FileTypeService.GetFileTypeById(Convert.ToInt32(row["FileType"]));
               lists.Add(fileInfo);
           }
           return lists;
       }

       private static IList<FileInfo> GetFileBySql(string sql,params SqlParameter [] parameters)
       {
           IList<FileInfo> lists = new List<FileInfo>();
           DataTable table = DBHelper.GetDataSet(sql,parameters);
           foreach (DataRow row in table.Rows)
           {
               FileInfo fileInfo = new FileInfo();
               fileInfo.FileId = Convert.ToInt32(row["fileId"]);
               fileInfo.FileName = Convert.ToString(row["fileName"]);
               fileInfo.Remark = Convert.ToString(row["remark"]);
               fileInfo.CreateDate = Convert.ToDateTime(row["createDate"]);
               fileInfo.ParentId = Convert.ToInt32(row["parentId"]);
               fileInfo.FilePath = Convert.ToString(row["filePath"]);
               fileInfo.IfDelete = Convert.ToInt32(row["ifDelete"]);
               //�������
               fileInfo.FileOwner = UserService.GetUserById(row["fileOwner"].ToString());
               fileInfo.FileType = FileTypeService.GetFileTypeById(Convert.ToInt32(row["FileType"]));
               lists.Add(fileInfo);
           }
           return lists;
       }


       /// <summary>
       /// ���ݸ�ID�������ж���
       /// </summary>
       /// <param name="parentId"></param>
       /// <returns></returns>
       public static IList<FileInfo> GetFileByParentId(int parentId) {
           string sql = "select * from fileInfo where parentId=@parentId and ifDelete=0 order by createDate desc";
           SqlParameter[] parameters ={ new SqlParameter("@parentId", parentId) };
           return GetFileBySql(sql,parameters);
       }


       /// <summary>
       /// ���ݸ�ID���������ļ��ж���
       /// </summary>
       /// <param name="parentId"></param>
       /// <returns></returns>
       public static IList<FileInfo> GetFolderByParentId(int parentId)
       {
           string sql = "select * from fileInfo where parentId=@parentId and FileType=1 order by createDate desc";
           SqlParameter[] parameters ={ new SqlParameter("@parentId", parentId) };
           return GetFileBySql(sql, parameters);
       }


       /// <summary>
       /// ǰ̨�ļ���������ʾ�ļ����а������ļ��򸽼���Ҫ
       /// ����FileInfo�����ļ��е�ID���ر��ļ��������������ļ���(FileInfo��)�򸽼�(Accessory��)��ID
       /// </summary>
       /// <param name="fileId"></param>
       /// <returns>���ص������е�һ��ֵΪ�ļ���(�򸽼�)���ڵı�ı���,�ڶ���ֵΪ����ID</returns>
       public static IList<string[]> GetFileIdAndAccessoryIdByFileId(int fileId) {
           string sql = "(select  'AccessoryFile' as TableName,accessoryId as id,createDate  from AccessoryFile  where fileId=@FileId  ) union (select 'FileInfo' as TableName,fileId  as id ,createDate  from fileInfo where parentId=@FileId )order by createDate asc";
           SqlParameter[] parameters ={ new SqlParameter("@FileId", fileId) };
           SqlDataReader read = DBHelper.GetReader(sql,parameters);
           IList<string[]> lists = new List<string[]>();
           while (read.Read())
           {
               string[] values ={Convert.ToString(read["TableName"]),Convert.ToString(read["id"])};
           }
           read.Close();
           return lists;
       }


       /// <summary>
       /// �����������Ҷ���
       /// </summary>
       /// <param name="fileId"></param>
       /// <returns></returns>
       public static FileInfo GetFileByFileId(int fileId)
       {
           try
           {
               string sql = "select * from fileInfo where fileId=@fileId";
               SqlParameter[] parameters ={ new SqlParameter("@fileId", fileId) };
               return GetFileBySql(sql, parameters)[0];
           }
           catch (Exception)
           {

               return null;
           }
       }


       public static int AddFile(FileInfo file) {
           string sql = "INSERT INTO [MyOffice].[dbo].[FileInfo] ([FileName] ,[FileType] ,[Remark] ,[FileOwner],[CreateDate],[ParentId],[FilePath],[IfDelete])  VALUES(@FileName,@FileType,@Remark,@FileOwner,@CreateDate,@ParentId,@FilePath,@IfDelete)";
           SqlParameter[] parameters ={ new SqlParameter("@FileName", file.FileName), new SqlParameter("@FileType", file.FileType.FileTypeId), new SqlParameter("@Remark", file.Remark), new SqlParameter("@FileOwner", file.FileOwner.UserId), new SqlParameter("@CreateDate", file.CreateDate), new SqlParameter("@ParentId", file.ParentId), new SqlParameter("@FilePath", file.FilePath), new SqlParameter("@IfDelete",file.IfDelete) };
           return DBHelper.ExecuteCommand(sql,parameters);
       }

       /// <summary>
       /// �޸��ļ�  ���޸��ļ�·��
       /// </summary>
       /// <param name="file"></param>
       /// <returns></returns>
       public static int UpdateFile(FileInfo file) {
           string sql = "update fileInfo set FileName=@FileName,FileType=@FileType,Remark=@Remark where FileId=@FileId";
           SqlParameter[] parameters ={ new SqlParameter("@FileName", file.FileName), new SqlParameter("@FileType", file.FileType.FileTypeId), new SqlParameter("@Remark", file.Remark), new SqlParameter("@FileId",file.FileId) };
           return DBHelper.ExecuteCommand(sql,parameters);
       }


       /// <summary>
       ///  �޸��ļ�  �����޸��ļ�·��
       /// </summary>
       /// <param name="file"></param>
       /// <returns></returns>
       public static int UpdateFileAndFilePath(FileInfo file) {
           string sql = "update fileInfo set FileName=@FileName,FileType=@FileType,Remark=@Remark,FilePath=@FilePath where FileId=@FileId";
           SqlParameter[] parameters ={ new SqlParameter("@FileName", file.FileName), new SqlParameter("@FileType", file.FileType.FileTypeId), new SqlParameter("@Remark", file.Remark), new SqlParameter("@FilePath",file.FilePath), new SqlParameter("@FileId", file.FileId) };
           return DBHelper.ExecuteCommand(sql, parameters);
       }

       /// <summary>
       /// �޸��ļ��ĸ�ID ��FilePath(�޸��ļ�Ŀ¼ʱʹ��)
       /// </summary>
       /// <param name="file"></param>
       /// <returns></returns>
       public static int UpdateParentId(FileInfo file) {
           string sql = "update fileInfo set parentId=@parentId , filePath=@filePath where fileId=@fileId";
           SqlParameter[] parameters ={ new SqlParameter("@parentId", file.ParentId), new SqlParameter("@filePath",file.FilePath), new SqlParameter("@fileId", file.FileId) };
           return DBHelper.ExecuteCommand(sql,parameters);
       }
       /// <summary>
       /// �����ļ�����ѯ
       /// </summary>
       /// <param name="file"></param>
       /// <returns></returns>
       public static IList<FileInfo> GetFileInfoByFileName(string fileName,string createUser,string beginTime,string endTime) 
       {
           string sql = "select * from fileInfo f,userInfo u where f.fileOwner=u.userId ";

               if (fileName != "")
               {
                   sql += " and fileName like  '" + fileName + "%'";
               }
            
               if (createUser != "")
               {
                   sql += "  and fileOwner like  '" + createUser + "%'";
               }
               if (beginTime != "" && beginTime != null && endTime != "" && endTime != null) 
               {
                   sql += " and  createDate  between '"+string.Format("{0:yyyy-MM-dd 00:00:00}",DateTime.Parse(beginTime))+"' and  '"+string.Format("{0:yyyy-MM-dd 23:59:59}",DateTime.Parse(endTime))+"'";
               }
               sql += " order by fileType asc";
          
           return GetFileBySql(sql);
       }

       /// <summary>
       /// ������з��ڻ���վ�е��ļ�
       /// </summary>
       /// <returns></returns>
       public static IList<FileInfo> GetAllDelFileInfo() {
           string sql = "select * from fileInfo where ifDelete=1";
           return GetFileBySql(sql);
       }


       /// <summary>
       /// ����ɾ���Ķ���ԭ
       /// </summary>
       /// <param name="fileId"></param>
       /// <returns></returns>
       public static int revert_IfDelete_ByFileId(int fileId) {
           string sql = "update fileInfo set IfDelete=0 where fileId=@fileId";
           SqlParameter[] parameters ={new SqlParameter ("@fileId",fileId) };
           return DBHelper.ExecuteCommand(sql,parameters);
       }

       /// <summary>
       /// ������������վ
       /// </summary>
       /// <param name="fileId"></param>
       /// <returns></returns>
       public static int update_IfDelete_ByFileId(int fileId) {
           string sql = "update fileInfo set IfDelete=1 where fileId=@fileId";
           SqlParameter[] parameters ={ new SqlParameter("@fileId", fileId) };
           return DBHelper.ExecuteCommand(sql, parameters);
       }

       /// <summary>
       /// ��������ɾ������
       /// </summary>
       /// <param name="fileId"></param>
       /// <returns></returns>
       public static int DelFileById(int fileId) {
           string sql = "delete from fileInfo where fileId=@fileId";
           SqlParameter[] parameters ={ new SqlParameter("@fileId", fileId) };
           return DBHelper.ExecuteCommand(sql,parameters);
       }
    }
}
