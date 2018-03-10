
using System;
using System.Collections.Generic;
using System.Text;

namespace MyOffice.Models
{
	
	[Serializable()]
	public class MessageType
	{
	
		private int messageTypeId; 
		private string messageTypeName = String.Empty;
		private string messageDesc = String.Empty;

		
		
		public MessageType() { }
		
		
	
		
		public int MessageTypeId
		{
			get { return this.messageTypeId; }
			set { this.messageTypeId = value; }
		}
		
		
		
		
		
		public string MessageTypeName
		{
			get { return this.messageTypeName; }
			set { this.messageTypeName = value; }
		}		
		
		
		public string MessageDesc
		{
			get { return this.messageDesc; }
			set { this.messageDesc = value; }
		}		
		
	}
}
