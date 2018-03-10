
using System;
using System.Collections.Generic;
using System.Text;

namespace MyOffice.Models
{
	
	[Serializable()]
	public class RoleRight
	{
	
		private int roleRightId; 
		private Role role=new Role(); 
		private SysFun node=new SysFun(); 

		
		
		public RoleRight() { }
		
		
	
		
		public int RoleRightId
		{
			get { return this.roleRightId; }
			set { this.roleRightId = value; }
		}
		
		
	
		
		public Role Role
		{
			get { return this.role; }
			set { this.role = value; }
		}		
		
		
		public SysFun Node
		{
			get { return this.node; }
			set { this.node = value; }
		}		
		
		
		
	}
}
