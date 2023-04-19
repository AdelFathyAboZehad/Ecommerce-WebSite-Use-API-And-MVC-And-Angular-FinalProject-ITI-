using System.ComponentModel.DataAnnotations;

namespace AdminSiteUseMVC.ViewModel.Admin
{
    public class ChangePasswordViewModel
    {
       

        [Required, DataType(DataType.Password), Display(Name ="Current password")]
        public string CurrentPassword { get; set; }
       [Required, DataType(DataType.Password), Display(Name ="New password")]
        public string NewPassword { get; set; }
       [Required, DataType(DataType.Password), Display(Name = "Confirm new password")]
        [Compare("NewPassword", ErrorMessage = "Confirm new password does not match")]
        public string ConfirmNewPassword { get; set; }
        public bool IsSuccess { get; set; }
        public ChangePasswordViewModel() 
        { 
        }
        public ChangePasswordViewModel(string currentPassword, string newPassword, string confirmNewPassword)
        {
            CurrentPassword = currentPassword;
            NewPassword = newPassword;
            ConfirmNewPassword = confirmNewPassword;
        }
    }
}
