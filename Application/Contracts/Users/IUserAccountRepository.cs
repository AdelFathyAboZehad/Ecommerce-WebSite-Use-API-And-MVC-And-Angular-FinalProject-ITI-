using Dtos.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Contracts.User
{
    public interface IUserAccountRepository
    {
        Task<AuthModel> Registration(RegistrationModel registrationModel);
        Task<AuthModel> Login(LoginModel loginModel);
        //Task<string> AddRoleAsync(AddRoleModel addRoleModel);
        void logout();
    }
}
