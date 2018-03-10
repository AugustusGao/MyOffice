using System;
using System.Collections.Generic;
using System.Text;
using MyOffice.DAL;
using MyOffice.Models;

namespace MyOffice.BLL
{
    public class FileTypeManager
    {

         /// <summary>
        /// �����������Ҷ���
        /// </summary>
        /// <param name="fileTypeId"></param>
        /// <returns></returns>
        public static FileType GetFileTypeById(int fileTypeId) {
            return FileTypeService.GetFileTypeById(fileTypeId);
        }



        public static IList<FileType> GetAllFileType()
        {
            return FileTypeService.GetAllFileType();
        }

    }
}
