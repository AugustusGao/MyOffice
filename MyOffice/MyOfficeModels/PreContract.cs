
using System;
using System.Collections.Generic;
using System.Text;
namespace MyOffice.Models
{
	
	[Serializable()]
	public class PreContract
	{
	
		private int preContractId; 
		private Schedule schedule=new Schedule(); 
		private string userId = String.Empty;

		
		
		public PreContract() { }
		
		
	
		
		public int PreContractId
		{
			get { return this.preContractId; }
			set { this.preContractId = value; }
		}
		
		
	
		
		public Schedule Schedule
		{
			get { return this.schedule; }
			set { this.schedule = value; }
		}		
		
		
		
		
		public string UserId
		{
			get { return this.userId; }
			set { this.userId = value; }
		}		
		
	}
}
