
using System;
using System.Collections.Generic;
using System.Text;

namespace MyOffice.Models
{
	
	[Serializable()]
	public class WorkTime
	{
	
		private int workTimeId; 
		private string onDutyTime = String.Empty;
		private string offDutyTime = String.Empty;

		
		
		public WorkTime() { }
		
		
	
		
		public int WorkTimeId
		{
			get { return this.workTimeId; }
			set { this.workTimeId = value; }
		}
		
		
		
		
		
		public string OnDutyTime
		{
			get { return this.onDutyTime; }
			set { this.onDutyTime = value; }
		}		
		
		
		public string OffDutyTime
		{
			get { return this.offDutyTime; }
			set { this.offDutyTime = value; }
		}		
		
	}
}
