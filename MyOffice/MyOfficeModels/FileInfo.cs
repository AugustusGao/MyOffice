
using System;
using System.Collections.Generic;
using System.Text;

namespace MyOffice.Models
{
	
	[Serializable()]
	public class FileInfo
	{
	
		private int fileId; 
		private FileType fileType=new FileType(); 
		private User fileOwner=new User(); 
		private string fileName = String.Empty;
		private string remark = String.Empty;
		private DateTime createDate;
		private int parentId;
		private string filePath = String.Empty;
		private int ifDelete;

		
		
		public FileInfo() { }
		
		
	
		
		public int FileId
		{
			get { return this.fileId; }
			set { this.fileId = value; }
		}
		
		
	
		
		public FileType FileType
		{
			get { return this.fileType; }
			set { this.fileType = value; }
		}		
		
		
		public User FileOwner
		{
			get { return this.fileOwner; }
			set { this.fileOwner = value; }
		}		
		
		
		
		
		public string FileName
		{
			get { return this.fileName; }
			set { this.fileName = value; }
		}		
		
		
		public string Remark
		{
			get { return this.remark; }
			set { this.remark = value; }
		}		
		
		
		public DateTime CreateDate
		{
			get { return this.createDate; }
			set { this.createDate = value; }
		}		
		
		
		public int ParentId
		{
			get { return this.parentId; }
			set { this.parentId = value; }
		}		
		
		
		public string FilePath
		{
			get { return this.filePath; }
			set { this.filePath = value; }
		}		
		
		
		public int IfDelete
		{
			get { return this.ifDelete; }
			set { this.ifDelete = value; }
		}		
		
        public bool  Equals(FileInfo other)
        {
            if (this.fileId == other.fileId)
            {
                return true;
            }
            else {
                return false;
            }
        }


}
}
