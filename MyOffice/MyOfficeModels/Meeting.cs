
using System;
using System.Collections.Generic;
using System.Text;

namespace MyOffice.Models
{
	
	[Serializable()]
	public class Meeting
	{
	
		private int meetingId; 
		private string meetingName = String.Empty;

		
		
		public Meeting() { }
		
		
	
		
		public int MeetingId
		{
			get { return this.meetingId; }
			set { this.meetingId = value; }
		}
		
		
		
		
		
		public string MeetingName
		{
			get { return this.meetingName; }
			set { this.meetingName = value; }
		}		
		
	}
}
