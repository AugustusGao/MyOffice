
using System;
using System.Collections.Generic;
using System.Text;

namespace MyOffice.Models
{
	
	[Serializable()]
	public class Schedule
	{
	
		private int scheduleId; 
		private Meeting meeting=new Meeting(); 
		private User createUser=new User(); 
		private string title = String.Empty;
		private string address = String.Empty;
		private DateTime beginTime;
		private DateTime endTime;
		private string schContent = String.Empty;
		private DateTime createTime;
		private int ifPrivate;
		
		public Schedule() {
        
            
        }
		
		public int ScheduleId
		{
			get { return this.scheduleId; }
			set { this.scheduleId = value; }
		}
		
		public Meeting Meeting
		{
			get { return this.meeting; }
			set { this.meeting = value; }
		}		
		
		
		public User CreateUser
		{
			get { return this.createUser; }
			set { this.createUser = value; }
		}		
		
		
		
		
		public string Title
		{
			get { return this.title; }
			set { this.title = value; }
		}		
		
		
		public string Address
		{
			get { return this.address; }
			set { this.address = value; }
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
		
		
		public string SchContent
		{
			get { return this.schContent; }
			set { this.schContent = value; }
		}		
		
		
		public DateTime CreateTime
		{
			get { return this.createTime; }
			set { this.createTime = value; }
		}		
		
		
		public int IfPrivate
		{
			get { return this.ifPrivate; }
			set { this.ifPrivate = value; }
		}
    }
}
