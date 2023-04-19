using System.ComponentModel.DataAnnotations;

namespace AdminSiteUseMVC.ViewModel.Admin
{
    public class LoginModel
    {
        [Required,MinLength(3),MaxLength(200) ]
        public string UserName { get; set; }
        [Required(ErrorMessage = "The Password Required"), DataType(DataType.Password, ErrorMessage = "Invalid Password Datatype"), RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[#$^+=!*()@%&]).{8,}$", ErrorMessage = "Invalid Password")]
        public string Password { get; set; }
        public bool RememberMe { get; set; }
        public LoginModel() { }
        public LoginModel(string username, string password)
        {
            UserName = username;
            Password = password;
        }
    }
}
