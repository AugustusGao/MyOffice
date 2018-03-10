
using System;
using System.Collections.Generic;
using System.Text;

namespace MyOffice.Models
{
	
	[Serializable()]
	public class SysFun
	{
	
		private int nodeId; 
		private string displayName = String.Empty;
		private string nodeURL = String.Empty;
		private int displayOrder;
		private int parentNodeId;

		
		
		public SysFun() { }
		
		
	
		
		public int NodeId
		{
			get { return this.nodeId; }
			set { this.nodeId = value; }
		}
		
		
		
		
		
		public string DisplayName
		{
			get { return this.displayName; }
			set { this.displayName = value; }
		}		
		
		
		public string NodeURL
		{
			get { return this.nodeURL; }
			set { this.nodeURL = value; }
		}		
		
		
		public int DisplayOrder
		{
			get { return this.displayOrder; }
			set { this.displayOrder = value; }
		}		
		
		
		public int ParentNodeId
		{
			get { return this.parentNodeId; }
			set { this.parentNodeId = value; }
		}		
		
	}
}
