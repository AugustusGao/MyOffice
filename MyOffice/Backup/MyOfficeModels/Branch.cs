
using System;
using System.Collections.Generic;
using System.Text;

namespace MyOffice.Models
{
	
	[Serializable()]
	public class Branch
	{
	
		private int branchId; 
		private string branchName = String.Empty;
		private string branchShortName = String.Empty;

		
		
		public Branch() { }
		
		
	
		
		public int BranchId
		{
			get { return this.branchId; }
			set { this.branchId = value; }
		}
		
		
		
		
		
		public string BranchName
		{
			get { return this.branchName; }
			set { this.branchName = value; }
		}		
		
		
		public string BranchShortName
		{
			get { return this.branchShortName; }
			set { this.branchShortName = value; }
		}		
		
	}
}
