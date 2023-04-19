using Domian;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdminSiteUseMVC.ViewModel.Admin
{
    public class RegistrationModel
    {


        [Required, MinLength(3), MaxLength(100)]
        public string FirstName { get; set; }
        [Required, MinLength(3), MaxLength(100)]
        public string LastName { get; set; }
        [Required, MinLength(3), MaxLength(100)]
        public string UserName { get; set; }
        [Required(ErrorMessage = "The Email Required"),DataType(DataType.EmailAddress), RegularExpression(@"^[^@\s]+@[^@\s]+\.(com|net|org|gov)$", ErrorMessage = "Invalid Email")]
        public string Email { get; set; }
        [Required(ErrorMessage = "The Password Required"), DataType(DataType.Password, ErrorMessage = "Invalid Password Datatype"), RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[#$^+=!*()@%&]).{8,}$", ErrorMessage = "Invalid Password")]
        public string Password { get; set; }
        [Required(ErrorMessage = "The ConfirmPassword  Must Match The Password"), DataType(DataType.Password)]//, RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[#$^+=!*()@%&]).{8,}$", ErrorMessage = "The ConfirmPassword  Must Match The Password")]
        [Compare("Password")]
        public string ConfirmPassword { get; set; }
        public RegistrationModel(string firstName, string lastName, string userName, string email, string password)
        {
            FirstName = firstName;
            LastName = lastName;
            UserName = userName;
            Email = email;
            Password = password;
        }

        public RegistrationModel()
        {

        }
    }


    public static class RegistrationModelExtensions
    {
        public static User ToModel(this RegistrationModel registrationModel)
        {
            return new User
            {
                Fname = registrationModel.FirstName,
                Lname = registrationModel.LastName,
                UserName = registrationModel.UserName,
                Email = registrationModel.Email
            };
        }
    }
}

