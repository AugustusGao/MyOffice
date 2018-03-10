
using System;
using System.Collections.Generic;
using System.Text;

namespace MyOffice.Models
{
	
	[Serializable()]
	public class User:IEquatable<User>
	{
	
		private string userId; 
		private Role role=new Role (); 
		private UserState userState=new UserState (); 
		private string userName = String.Empty;
		private string password = String.Empty;
		private int departId;
		private int gender;
        private int loginId;

        private string departName;

        public string DepartName
        {
            get { return departName; }
            set { departName = value; }
        }

      

        private int branchId;

        public int BranchId
        {
            get { return branchId; }
            set { branchId = value; }
        }

        private string branchName;

        public string BranchName
        {
            get { return branchName; }
            set { branchName = value; }
        }
		
		
		public User() { }
		
		
	        public int LoginId
        {
            get { return loginId; }
            set { loginId = value; }
        }
		
		public string UserId
		{
			get { return this.userId; }
			set { this.userId = value; }
		}
		
		
	
		
		public Role Role
		{
			get { return this.role; }
			set { this.role = value; }
		}		
		
		
		public UserState UserState
		{
			get { return this.userState; }
			set { this.userState = value; }
		}		
		
		
		
		
		public string UserName
		{
			get { return this.userName; }
			set { this.userName = value; }
		}		
		
		
		public string Password
		{
			get { return this.password; }
			set { this.password = value; }
		}


        public int DepartId
		{
			get { return this.departId; }
			set { this.departId = value; }
		}		
		
		
		public int Gender
		{
			get { return this.gender; }
			set { this.gender = value; }
		}


        #region IEquatable<User> ≥…‘±

        public bool Equals(User other)
        {
           if(this.userId.Equals(other.userId))
            return true;
          else
            return false;
        }

        #endregion
    }
}
