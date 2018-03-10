
using System;
using System.Collections.Generic;
using System.Text;

namespace MyOffice.Models
{
	
	[Serializable()]
	public class FileType
	{
	
		private int fileTypeId; 
		private string fileTypeName = String.Empty;
		private string fileTypeImage = String.Empty;
		private string fileTypeSuffix = String.Empty;

		
		
		public FileType() { }
		
		
	
		
		public int FileTypeId
		{
			get { return this.fileTypeId; }
			set { this.fileTypeId = value; }
		}
		
		
		
		
		
		public string FileTypeName
		{
			get { return this.fileTypeName; }
			set { this.fileTypeName = value; }
		}		
		
		
		public string FileTypeImage
		{
			get { return this.fileTypeImage; }
			set { this.fileTypeImage = value; }
		}		
		
		
		public string FileTypeSuffix
		{
			get { return this.fileTypeSuffix; }
			set { this.fileTypeSuffix = value; }
		}		
		
	}
}
