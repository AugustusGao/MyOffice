
using System;
using System.Collections.Generic;
using System.Text;

namespace MyOffice.Models
{
	
	[Serializable()]
	public class MyNote
	{
	
		private int noteId; 
		private User createUser=new User (); 
		private string noteTitle = String.Empty;
		private string noteContent = String.Empty;
		private DateTime createTime;

		
		
		public MyNote() { }
		
		
	
		
		public int NoteId
		{
			get { return this.noteId; }
			set { this.noteId = value; }
		}
		
		
	
		
		public User CreateUser
		{
			get { return this.createUser; }
			set { this.createUser = value; }
		}		
		
		
		
		
		public string NoteTitle
		{
			get { return this.noteTitle; }
			set { this.noteTitle = value; }
		}		
		
		
		public string NoteContent
		{
			get { return this.noteContent; }
			set { this.noteContent = value; }
		}		
		
		
		public DateTime CreateTime
		{
			get { return this.createTime; }
			set { this.createTime = value; }
		}		
		
	}
}
