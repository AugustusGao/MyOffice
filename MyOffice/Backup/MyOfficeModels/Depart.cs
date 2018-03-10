
using System;
using System.Collections.Generic;
using System.Text;

namespace MyOffice.Models
{
	
	[Serializable()]
	public class Depart
	{
	
		private int departId; 
		private Branch branch=new Branch (); 
		private User principalUser=new User (); 
		private string departName = String.Empty;
		private long connectTelNo;
		private long connectMobileTelNo;
		private long faxes;

		
		
		public Depart() { }
		
		
	
		
		public int DepartId
		{
			get { return this.departId; }
			set { this.departId = value; }
		}
		
		
	
		
		public Branch Branch
		{
			get { return this.branch; }
			set { this.branch = value; }
		}		
		
		
		public User PrincipalUser
		{
			get { return this.principalUser; }
			set { this.principalUser = value; }
		}		
		
		
		
		
		public string DepartName
		{
			get { return this.departName; }
			set { this.departName = value; }
		}		
		
		
		public long ConnectTelNo
		{
			get { return this.connectTelNo; }
			set { this.connectTelNo = value; }
		}		
		
		
		public long ConnectMobileTelNo
		{
			get { return this.connectMobileTelNo; }
			set { this.connectMobileTelNo = value; }
		}		
		
		
		public long Faxes
		{
			get { return this.faxes; }
			set { this.faxes = value; }
		}		
		
	}
}
