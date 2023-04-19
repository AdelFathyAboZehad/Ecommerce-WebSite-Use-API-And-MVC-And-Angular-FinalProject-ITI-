using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dtos.Users
{
	public class LoginModel
	{
		

		public string Email { get; set; }
		public string Password { get; set; }
		public LoginModel(string email, string password)
		{
			Email = email;
			Password = password;
		}
		public LoginModel()
		{

		}
	}
}
