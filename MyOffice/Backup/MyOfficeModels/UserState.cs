
using System;
using System.Collections.Generic;
using System.Text;

namespace MyOffice.Models
{
	
	[Serializable()]
	public class UserState
	{
	
		private int userStateId; 
		private string userStateName = String.Empty;

		
		
		public UserState() { }
		
		
	
		
		public int UserStateId
		{
			get { return this.userStateId; }
			set { this.userStateId = value; }
		}
		
		
		
		
		
		public string UserStateName
		{
			get { return this.userStateName; }
			set { this.userStateName = value; }
		}		
		
	}
}
