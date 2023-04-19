using Dtos.Account;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Users.Queries.GetUserDetails
{
    public class UserDetailsQueryHandler : IRequestHandler<UserDetailsQuery, userDetailsDto>
    {
        private readonly IUserRepository _userRepository;

        public UserDetailsQueryHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public async Task<userDetailsDto> Handle(UserDetailsQuery request, CancellationToken cancellationToken)
        {
            var user = await _userRepository.GetByIdAsync(request.id);
            return new userDetailsDto {Id=user.Id,Email=user.Email,
                UserName=user.UserName,FirstName=user.Fname, LastName= user.Lname };
        }
    }
}
