

using System;
using System.Collections.Generic;
using System.Text;

namespace MyOffice.Models
{
	
	[Serializable()]
	public class ReadCommonMessage
	{
	
		private int readId; 
		private Message message=new Message (); 
		private User user=new User (); 

		
		
		public ReadCommonMessage() { }
		
		
	
		
		public int ReadId
		{
			get { return this.readId; }
			set { this.readId = value; }
		}
		
		
	
		
		public Message Message
		{
			get { return this.message; }
			set { this.message = value; }
		}		
		
		
		public User User
		{
			get { return this.user; }
			set { this.user = value; }
		}		
		
		
		
	}
}
