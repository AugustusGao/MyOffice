using System;
using System.Collections.Generic;
using System.Text;
using MyOffice.Models;
using System.Data.SqlClient;
using System.Data;

namespace MyOffice.DAL
{
    public class FileTypeService
    {
        private static IList<FileType> GetFileTypeBySql(string sql)
        {
            IList<FileType> lists = new List<FileType>();
            DataTable table = DBHelper.GetDataSet(sql);
            foreach (DataRow row in table.Rows)
            {


                FileType fileType = new FileType();
                fileType.FileTypeId = Convert.ToInt32(row["FileTypeId"]);
                fileType.FileTypeName = Convert.ToString(row["fileTypeName"]);
                fileType.FileTypeImage = Convert.ToString(row["fileTypeImage"]);
                fileType.FileTypeSuffix = Convert.ToString(row["fileTypeSuffix"]);
                lists.Add(fileType);
            }

            return lists;
        }

        private static IList<FileType> GetFileTypeBySql(string sql, params SqlParameter[] parameters)
        {
            IList<FileType> lists = new List<FileType>();
            DataTable table = DBHelper.GetDataSet(sql,parameters);
            foreach (DataRow row in table.Rows)
            {


                FileType fileType = new FileType();
                fileType.FileTypeId = Convert.ToInt32(row["FileTypeId"]);
                fileType.FileTypeName = Convert.ToString(row["fileTypeName"]);
                fileType.FileTypeImage = Convert.ToString(row["fileTypeImage"]);
                fileType.FileTypeSuffix = Convert.ToString(row["fileTypeSuffix"]);
                lists.Add(fileType);
            }

            return lists;
        }

        /// <summary>
        /// 根据主键查找对象
        /// </summary>
        /// <param name="fileTypeId"></param>
        /// <returns></returns>
        public static FileType GetFileTypeById(int fileTypeId)
        {
            string sql = "select * from fileTypeInfo where fileTypeId=@fileTypeId";
            SqlParameter[] parameters ={ new SqlParameter("@fileTypeId", fileTypeId) };
            return GetFileTypeBySql(sql, parameters)[0];
        }


        public static IList<FileType> GetAllFileType() {
            string sql = "select * from fileTypeInfo ";
            return GetFileTypeBySql(sql);
        }


    }
}
