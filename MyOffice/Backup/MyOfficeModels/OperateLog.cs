
using System;
using System.Collections.Generic;
using System.Text;

namespace MyOffice.Models
{
	
	[Serializable()]
	public class OperateLog
	{
	
		private int operateId; 
		private User user=new User(); 
		private string operateName = String.Empty;
		private string objectId = String.Empty;
		private string operateDesc = String.Empty;
		private DateTime operateTime;

		
		
		public OperateLog() { }

        public OperateLog(User user,string operateName,string objectId,string operateDesc,DateTime operateTime) {
            this.user = user;
            this.operateName = operateName;
            this.objectId = objectId;
            this.operateDesc = operateDesc;
            this.operateTime = operateTime;
        
        }
	
		
		public int OperateId
		{
			get { return this.operateId; }
			set { this.operateId = value; }
		}
		
		
	
		
		public User User
		{
			get { return this.user; }
			set { this.user = value; }
		}		
		
		
		
		
		public string OperateName
		{
			get { return this.operateName; }
			set { this.operateName = value; }
		}		
		
		
		public string ObjectId
		{
			get { return this.objectId; }
			set { this.objectId = value; }
		}		
		
		
		public string OperateDesc
		{
			get { return this.operateDesc; }
			set { this.operateDesc = value; }
		}		
		
		
		public DateTime OperateTime
		{
			get { return this.operateTime; }
			set { this.operateTime = value; }
		}		
		
	}
}
