using Application;
using DbContextL;
using Domian;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfraStructure.Users
{
    public class Userrepository : IUserRepository
    {
        private readonly Context _context;
        private readonly UserManager<User> _userManager;

        public Userrepository(Context context,UserManager<User> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        public async Task<bool> UpdateAsync(User user)
        {
            var entity =await _userManager.UpdateAsync(user);//.Update(user);
          
            await _context.SaveChangesAsync();
            if (entity != null)
            {
                //return Task.FromResult(true);
                return true;
            }
            else
            {
                // return Task.FromResult(false);
                return false;
            }
        }

        public async Task<bool> ChangePasswordAsync(User user)
        {
            var entity = await _userManager.UpdateAsync(user);
           await _context.SaveChangesAsync();
            if (entity != null)
            {
                //return Task.FromResult(true);
                return true;
            }
            else
            {
                // return Task.FromResult(false);
                return false;
            }
        }

     
        public async Task<User?> GetByIdAsync(int id)
        {
            var user = await _userManager.Users.FirstOrDefaultAsync(x => x.Id == id);
            return user;
        }

    }
}

