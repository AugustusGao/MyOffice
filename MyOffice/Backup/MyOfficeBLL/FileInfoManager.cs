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
       /// ���ݸ�ID���Ҷ���
       /// </summary>
       /// <param name="parentId"></param>
       /// <returns></returns>
        public static IList<FileInfo> GetFileByParentId(int parentId) {
            return FileInfoService.GetFileByParentId(parentId);
        }


          /// <summary>
       /// ǰ̨�ļ���������ʾ�ļ����а������ļ��򸽼���Ҫ
       /// ����FileInfo�����ļ��е�ID���ر��ļ��������������ļ���(FileInfo��)�򸽼�(Accessory��)��ID
       /// </summary>
       /// <param name="fileId"></param>
       /// <returns>���ص������е�һ��ֵΪ�ļ���(�򸽼�)���ڵı�ı���,�ڶ���ֵΪ����ID</returns>
        public static IList<string[]> GetFileIdAndAccessoryIdByFileId(int fileId) {
            return FileInfoService.GetFileIdAndAccessoryIdByFileId(fileId);
        }


        /// <summary>
        /// �����������Ҷ���
        /// </summary>
        /// <param name="fileId"></param>
        /// <returns></returns>
        public static FileInfo GetFileByFileId(int fileId)
        {
            return FileInfoService.GetFileByFileId(fileId);
        }


        /// <summary>
        /// ���ݸ�ID���������ļ��ж���
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
       /// �޸��ļ�  ���޸��ļ�·��
       /// </summary>
       /// <param name="file"></param>
       /// <returns></returns>
        public static int UpdateFile(FileInfo file) {
            return FileInfoService.UpdateFile(file);
        }


        /// <summary>
       ///  �޸��ļ�  �����޸��ļ�·��
       /// </summary>
       /// <param name="file"></param>
       /// <returns></returns>
        public static int UpdateFileAndFilePath(FileInfo file) {
            return FileInfoService.UpdateFileAndFilePath(file);
        }


        /// <summary>
        /// �޸��ļ�Ŀ¼
        /// </summary>
        /// <param name="file"></param>
        /// <returns></returns>
        public static int MoveFile(FileInfo file)
        {
            return FileInfoService.UpdateParentId(file);
        }
         /// <summary>
       /// �����ļ�����ѯ
       /// </summary>
       /// <param name="file"></param>
       /// <returns></returns>
        public static IList<FileInfo> GetFileInfoByFileName(string fileName,string createUser,string beginTime,string endTime)
        {
            return FileInfoService.GetFileInfoByFileName(fileName,createUser,beginTime,endTime);
        }

        /// <summary>
        /// ������з��ڻ���վ�е��ļ�
        /// </summary>
        /// <returns></returns>
        public static IList<FileInfo> GetAllDelFileInfo()
        {
            return FileInfoService.GetAllDelFileInfo();
        }


        /// <summary>
        /// ����ɾ���ļ���ԭ
        /// </summary>
        /// <param name="fileId"></param>
        /// <returns></returns>
        public static int revert_IfDelete_ByFileId(int fileId)
        {
            return FileInfoService.revert_IfDelete_ByFileId(fileId);
        }

        /// <summary>
        ///�ݹ� ��ô��ļ��е�������Ŀ¼��ID����������Ŀ¼��
        /// </summary>
        /// <param name="lists">��ID����˼�����</param>
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
        /// ��������ɾ������
        /// </summary>
        /// <param name="fileId"></param>
        /// <returns></returns>
        public static int DelFileById(int fileId)
        {
            return FileInfoService.DelFileById(fileId);
        }

        /// <summary>
        /// ������������վ
        /// </summary>
        /// <param name="fileId"></param>
        /// <returns></returns>
        public static int update_IfDelete_ByFileId(int fileId)
        {
            return FileInfoService.update_IfDelete_ByFileId(fileId);
        }
    }
}
