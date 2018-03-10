
using System;
using System.Collections.Generic;
using System.Text;

namespace MyOffice.Models
{
	
	[Serializable()]
	public class LoginLog
	{
	
		private int loginId; 
		private User user=new User(); 
		private DateTime loginTime;
        private DateTime exitTime;
		private int ifSuccess;
		private string loginUserIp = String.Empty;
		private string loginDesc = String.Empty;

		
		
		public LoginLog() { }


        public LoginLog(User user,DateTime loginTime,DateTime exitTime,int ifSuccess,string loginUserIp,string loginDesc) {
            this.user = user;
            this.loginTime = loginTime;
            this.exitTime = exitTime;
            this.ifSuccess = ifSuccess;
            this.loginUserIp = loginUserIp;
            this.loginDesc = loginDesc; 
        }
		
		public int LoginId
		{
			get { return this.loginId; }
			set { this.loginId = value; }
		}



        public DateTime ExitTime
        {
            get { return exitTime; }
            set { exitTime = value; }
        }
		
		public User User
		{
			get { return this.user; }
			set { this.user = value; }
		}		
		
		
		
		
		public DateTime LoginTime
		{
			get { return this.loginTime; }
			set { this.loginTime = value; }
		}		
		
		
		public int IfSuccess
		{
			get { return this.ifSuccess; }
			set { this.ifSuccess = value; }
		}		
		
		
		public string LoginUserIp
		{
			get { return this.loginUserIp; }
			set { this.loginUserIp = value; }
		}		
		
		
		public string LoginDesc
		{
			get { return this.loginDesc; }
			set { this.loginDesc = value; }
		}		
		
	}
}
