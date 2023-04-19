using Domian;
using MediatR;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Users.Commands.UpdateUsersPassword
{
    public class UpdateUsersPasswordCommandQueryHandler : IRequestHandler<UpdateUsersPasswordCommandQuery, IdentityResult>
    {
        private readonly IUserRepository _userRepository;
        private readonly UserManager<User> _userManager;

        public UpdateUsersPasswordCommandQueryHandler(IUserRepository userRepository, UserManager<User> userManager)
        {
            _userRepository = userRepository;
            _userManager = userManager;
        }
        public async Task<IdentityResult> Handle(UpdateUsersPasswordCommandQuery request, CancellationToken cancellationToken)
        {

            var user = await _userManager.FindByNameAsync(request.UserName);
            if (user != null)
            {
                return await _userManager.ChangePasswordAsync(user, request.CurrentPassword, request.NewPassword);
            }
            return IdentityResult.Failed();






        }
    }
}
