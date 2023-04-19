using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domian;

namespace Application
{
   public interface IUserRepository
    {
        Task<bool> UpdateAsync(User user);
        Task<bool> ChangePasswordAsync(User user);
        Task<User?> GetByIdAsync(int id);
    }
}
