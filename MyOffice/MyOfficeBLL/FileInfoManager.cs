using System;
using System.Collections.Generic;
using System.Text;
using MyOffice.DAL;
using MyOffice.Models;
using System.Collections;

namespace MyOffice.BLL
{
    public class FileInfoManager
    {
        
       /// <summary>
       /// 根据父ID查找对象
       /// </summary>
       /// <param name="parentId"></param>
       /// <returns></returns>
        public static IList<FileInfo> GetFileByParentId(int parentId) {
            return FileInfoService.GetFileByParentId(parentId);
        }


          /// <summary>
       /// 前台文件管理中显示文件夹中包含的文件或附件需要
       /// 根据FileInfo表中文件夹的ID返回本文件夹中所包含的文件夹(FileInfo表)或附件(Accessory表)的ID
       /// </summary>
       /// <param name="fileId"></param>
       /// <returns>返回的数组中第一个值为文件夹(或附件)所在的表的表名,第二个值为主键ID</returns>
        public static IList<string[]> GetFileIdAndAccessoryIdByFileId(int fileId) {
            return FileInfoService.GetFileIdAndAccessoryIdByFileId(fileId);
        }


        /// <summary>
        /// 根据主键查找对象
        /// </summary>
        /// <param name="fileId"></param>
        /// <returns></returns>
        public static FileInfo GetFileByFileId(int fileId)
        {
            return FileInfoService.GetFileByFileId(fileId);
        }


        /// <summary>
        /// 根据父ID查找所有文件夹对象
        /// </summary>
        /// <param name="parentId"></param>
        /// <returns></returns>
        public static IList<FileInfo> GetFolderByParentId(int parentId)
        {
            return FileInfoService.GetFolderByParentId(parentId);
        }

        public static int AddFile(FileInfo file)
        {
            return FileInfoService.AddFile(file);
        }


          /// <summary>
       /// 修改文件  不修改文件路径
       /// </summary>
       /// <param name="file"></param>
       /// <returns></returns>
        public static int UpdateFile(FileInfo file) {
            return FileInfoService.UpdateFile(file);
        }


        /// <summary>
       ///  修改文件  包括修改文件路径
       /// </summary>
       /// <param name="file"></param>
       /// <returns></returns>
        public static int UpdateFileAndFilePath(FileInfo file) {
            return FileInfoService.UpdateFileAndFilePath(file);
        }


        /// <summary>
        /// 修改文件目录
        /// </summary>
        /// <param name="file"></param>
        /// <returns></returns>
        public static int MoveFile(FileInfo file)
        {
            return FileInfoService.UpdateParentId(file);
        }
         /// <summary>
       /// 根据文件名查询
       /// </summary>
       /// <param name="file"></param>
       /// <returns></returns>
        public static IList<FileInfo> GetFileInfoByFileName(string fileName,string createUser,string beginTime,string endTime)
        {
            return FileInfoService.GetFileInfoByFileName(fileName,createUser,beginTime,endTime);
        }

        /// <summary>
        /// 获得所有放在回收站中的文件
        /// </summary>
        /// <returns></returns>
        public static IList<FileInfo> GetAllDelFileInfo()
        {
            return FileInfoService.GetAllDelFileInfo();
        }


        /// <summary>
        /// 将被删除文件还原
        /// </summary>
        /// <param name="fileId"></param>
        /// <returns></returns>
        public static int revert_IfDelete_ByFileId(int fileId)
        {
            return FileInfoService.revert_IfDelete_ByFileId(fileId);
        }

        /// <summary>
        ///递归 获得此文件夹的所有子目录的ID（包括子子目录）
        /// </summary>
        /// <param name="lists">将ID放入此集合中</param>
        /// <param name="fileId"></param>
        public static void GetAllChildByFileId( IList<int> lists, int fileId) {
            IList<FileInfo> fileLists = FileInfoService.GetFileByParentId(fileId);
            foreach (FileInfo file in fileLists)
            {
                lists.Add(file.FileId);
                GetAllChildByFileId(lists, file.FileId);
            }
        }


        /// <summary>
        /// 根据主键删除对象
        /// </summary>
        /// <param name="fileId"></param>
        /// <returns></returns>
        public static int DelFileById(int fileId)
        {
            return FileInfoService.DelFileById(fileId);
        }

        /// <summary>
        /// 将对象放入回收站
        /// </summary>
        /// <param name="fileId"></param>
        /// <returns></returns>
        public static int update_IfDelete_ByFileId(int fileId)
        {
            return FileInfoService.update_IfDelete_ByFileId(fileId);
        }
    }
}
