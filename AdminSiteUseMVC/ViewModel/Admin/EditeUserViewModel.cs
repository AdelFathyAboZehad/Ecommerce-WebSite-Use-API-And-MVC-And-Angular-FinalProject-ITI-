using System.ComponentModel.DataAnnotations;

namespace AdminSiteUseMVC.ViewModel.Admin
{
    public class EditeUserViewModel
    {

        public int Id { get; set; }
        [ MinLength(3), MaxLength(100) ,Display(Name ="First Name")]
        public string? FirstName { get; set; }
        [ MinLength(3), MaxLength(100), Display(Name = "Last Name")]
        public string? LastName { get; set; }
        [ MinLength(3), MaxLength(100), Display(Name = "UserName")]
        public string? UserName { get; set; }
        [DataType(DataType.EmailAddress), RegularExpression(@"^[^@\s]+@[^@\s]+\.(com|net|org|gov)$"), Display(Name = "Email")]
        public string? Email { get; set; }

        [Display(Name = "Role")]
        public List<int>? RoleId { get; set; }

        public EditeUserViewModel() { }

        public EditeUserViewModel(int id,string firstName, string lastName, string userName, string email)
        {
            Id= id;
            FirstName = firstName;
            LastName = lastName;
            UserName = userName;
            Email = email;
        }
    }
}
