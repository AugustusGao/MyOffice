
using System;
using System.Collections.Generic;
using System.Text;

namespace MyOffice.Models
{
	
	[Serializable()]
	public class Role
	{
	
		private int roleId; 
		private string roleName = String.Empty;
		private string roleDesc = String.Empty;

		
		
		public Role() { }


        public Role(int roleId,string roleName,string roleDesc) {
            this.roleId = roleId;
            this.roleName = roleName;
            this.roleDesc = roleDesc;
        }
		
		public int RoleId
		{
			get { return this.roleId; }
			set { this.roleId = value; }
		}
		
		
		
		
		
		public string RoleName
		{
			get { return this.roleName; }
			set { this.roleName = value; }
		}		
		
		
		public string RoleDesc
		{
			get { return this.roleDesc; }
			set { this.roleDesc = value; }
		}		
		
	}
}
