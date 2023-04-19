using System.ComponentModel.DataAnnotations;

namespace AdminSiteUseMVC.ViewModel.Admin
{
    public class AddRoleModel
    {
        [Display(Name = "User ID")]
        public int UserId { get; set; }
        [Display(Name = "Role Name")]
        public string RoleName { get; set; }
        public AddRoleModel(int userId, string roleName)
        {
            UserId = userId;
            RoleName = roleName;
        }
    }
}
