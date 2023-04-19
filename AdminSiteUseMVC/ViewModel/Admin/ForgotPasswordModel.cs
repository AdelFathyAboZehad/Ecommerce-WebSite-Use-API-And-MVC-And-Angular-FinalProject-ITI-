using System.ComponentModel.DataAnnotations;

namespace AdminSiteUseMVC.ViewModel.Admin
{
    public class ForgotPasswordModel
    {
        [Required, Display(Name ="Registered Email Address"),DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        public bool EmailSent { get; set; }
    }
}
