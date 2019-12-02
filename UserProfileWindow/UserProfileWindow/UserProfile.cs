using System;
using System.Collections.Generic;
using System.Text;

namespace UserProfileWindow
{
	public class UserProfile
	{
		public Guid Id { get; set; }
		public string ImagePath { get; set; }
		public string FirstName { get; set; }
		public string LastName { get; set; }
		public string Address { get; set; }
	}
}
