
using System;
using System.Collections.Generic;
using System.Text;

namespace MyOffice.Models
{
	
	[Serializable()]
	public class Message
	{
	
		private int messageId; 
		private MessageType type=new MessageType (); 
		private User fromUser=new User (); 
		private string title = String.Empty;
		private string content = String.Empty;
		private DateTime beginTime;
		private DateTime endTime;
		private int ifPublish;
		private DateTime recordTime;
        private int ifDelete;
        private int ifDeleteTo;

		
		public Message() { }
		
		        public int IfDeleteTo
        {
            get { return ifDeleteTo; }
            set { ifDeleteTo = value; }
        }
	    public int IfDelete
        {
            get { return ifDelete; }
            set { ifDelete = value; }
        }
		
		public int MessageId
		{
			get { return this.messageId; }
			set { this.messageId = value; }
		}
		
		public MessageType Type
		{
			get { return this.type; }
			set { this.type = value; }
		}		
		
		
		public User FromUser
		{
			get { return this.fromUser; }
			set { this.fromUser = value; }
		}		
		
		
		
		
		public string Title
		{
			get { return this.title; }
			set { this.title = value; }
		}		
		
		
		public string Content
		{
			get { return this.content; }
			set { this.content = value; }
		}		
		
		
		public DateTime BeginTime
		{
			get { return this.beginTime; }
			set { this.beginTime = value; }
		}		
		
		
		public DateTime EndTime
		{
			get { return this.endTime; }
			set { this.endTime = value; }
		}		
		
		
		public int IfPublish
		{
			get { return this.ifPublish; }
			set { this.ifPublish = value; }
		}		
		
		
		public DateTime RecordTime
		{
			get { return this.recordTime; }
			set { this.recordTime = value; }
		}		
		
	}
}
