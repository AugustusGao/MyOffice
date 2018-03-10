
using System;
using System.Collections.Generic;
using System.Text;
             
namespace MyOffice.Models
{
	
	[Serializable()]
	public class AccessoryFile
	{
	
		private int accessoryId; 
		private FileInfo file=new FileInfo(); 
		private string accessoryName = String.Empty;
		private int accessorySize;
		private int accessoryType;
		private DateTime createDate;
		private string accessoryPath = String.Empty;

		
		
		public AccessoryFile() { }
		
		
	
		
		public int AccessoryId
		{
			get { return this.accessoryId; }
			set { this.accessoryId = value; }
		}
		
		
	
		
		public FileInfo File
		{
			get { return this.file; }
			set { this.file = value; }
		}		
		
		
		
		
		public string AccessoryName
		{
			get { return this.accessoryName; }
			set { this.accessoryName = value; }
		}		
		
		
		public int AccessorySize
		{
			get { return this.accessorySize; }
			set { this.accessorySize = value; }
		}		
		
		
		public int AccessoryType
		{
			get { return this.accessoryType; }
			set { this.accessoryType = value; }
		}		
		
		
		public DateTime CreateDate
		{
			get { return this.createDate; }
			set { this.createDate = value; }
		}		
		
		
		public string AccessoryPath
		{
			get { return this.accessoryPath; }
			set { this.accessoryPath = value; }
		}		
		
	}
}
