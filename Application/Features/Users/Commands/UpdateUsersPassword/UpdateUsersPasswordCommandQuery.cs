using MediatR;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Users.Commands.UpdateUsersPassword
{
    public class UpdateUsersPasswordCommandQuery : IRequest<IdentityResult>
    {


        [Required(ErrorMessage = "UserName Is Required")]
        public string UserName { get; set; }
        [Required, DataType(DataType.Password), Display(Name = "Current password")]
        public string CurrentPassword { get; set; }
        [Required, DataType(DataType.Password), Display(Name = "New password")]
        public string NewPassword { get; set; }
        [Required, DataType(DataType.Password), Display(Name = "Confirm new password")]
        [Compare("NewPassword", ErrorMessage = "Confirm new password does not match")]
        public string ConfirmNewPassword { get; set; }
        public UpdateUsersPasswordCommandQuery()
        {

        }
        public UpdateUsersPasswordCommandQuery(string userName, string currentPassword, string newPassword, string confirmNewPassword)
        {
            UserName = userName;
            CurrentPassword = currentPassword;
            NewPassword = newPassword;
            ConfirmNewPassword = confirmNewPassword;
        }

    }
}
