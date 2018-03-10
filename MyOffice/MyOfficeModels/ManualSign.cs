
using System;
using System.Collections.Generic;
using System.Text;

namespace MyOffice.Models
{
	
	[Serializable()]
	public class ManualSign
	{
	
		private int signId; 
		private User user=new User();
		private DateTime signTime;
		private string signDesc = String.Empty;
		private int signTag;

        public ManualSign() { }
        public ManualSign(User user,int late,int earlyOut,int truancy,double signRate)
        {
            this.user=user;
            this.late=late;
            this.earlyOut=earlyOut;
            this.truancy=truancy;
            this.signRate=signRate;
        }

        //统计信息
        private int late = 0;

        public int Late
        {
            get { return late; }
            set { late = value; }
        }
        private int earlyOut = 0;

        public int EarlyOut
        {
            get { return earlyOut; }
            set { earlyOut = value; }
        }
        private int truancy = 0;

        public int Truancy
        {
            get { return truancy; }
            set { truancy = value; }
        }
        private double signRate = 0.00;

        public double SignRate
        {
            get { return signRate; }
            set { signRate = value; }
        }
		
		
		public int SignId
		{
			get { return this.signId; }
			set { this.signId = value; }
		}
		
		
	    
		
		public User User
		{
			get { return this.user; }
			set { this.user = value; }
		}		
		
		
		
		
		public DateTime SignTime
		{
			get { return this.signTime; }
			set { this.signTime = value; }
		}		
		
		
		public string SignDesc
		{
			get { return this.signDesc; }
			set { this.signDesc = value; }
		}		
		
		
		public int SignTag
		{
			get { return this.signTag; }
			set { this.signTag = value; }
		}		
		
	}
}
