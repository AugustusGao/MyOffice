
using System;
using System.Collections.Generic;
using System.Text;

namespace MyOffice.Models
{
	
	[Serializable()]
	public class MessageToUser
	{
	
		private int id; 
		private Message message=new Message ();
        private User toUser=new User ();


		private int ifRead;

		
		
		public MessageToUser() { }
		
		
	
		public User ToUser
        {
            get { return toUser; }
            set { toUser = value; }
        }
		public int Id
		{
			get { return this.id; }
			set { this.id = value; }
		}
		
		
	
		
		public Message Message
		{
			get { return this.message; }
			set { this.message = value; }
		}		
		
		
		
		
		public int IfRead
		{
			get { return this.ifRead; }
			set { this.ifRead = value; }
		}		
		
	}
}
