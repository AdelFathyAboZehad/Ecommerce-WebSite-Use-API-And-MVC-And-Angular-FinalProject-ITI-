using Microsoft.Build.Framework;
using System.ComponentModel.DataAnnotations;

namespace AdminSiteUseMVC.ViewModel.Admin
{
    public class UserDetailsViewModel
    {

        public int Id { get; set; }
        [Display(Name ="First Name")]
        public string FirstName { get; set; }
        [Display(Name ="Last Name")]
        public string LastName { get; set; }
        [Display(Name ="UserName")]
        public string UserName { get; set; }
        [Display(Name ="Email")]
        public string Email { get; set; }
        [Display(Name = "Address")]
        public int AddressId { get; set; }
        [Display(Name = "Role")]

        public int RoleId { get; set; }
        public UserDetailsViewModel() { }
        public UserDetailsViewModel(int id,string firstName, string lastName, string userName, string email)
        {
            Id= id;
            FirstName = firstName;
            LastName = lastName;
            UserName = userName;
            Email = email;
        }
    }
}
