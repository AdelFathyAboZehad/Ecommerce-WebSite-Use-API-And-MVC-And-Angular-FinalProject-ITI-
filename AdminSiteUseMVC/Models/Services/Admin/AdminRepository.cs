using AdminSiteUseMVC.Models.IRepository.Admin;
using DbContextL;
using Domian;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace AdminSiteUseMVC.Models.Services.Admin
{
    public class AdminRepository:IAdminRepository
    {

        private readonly Context _context;
        private readonly UserManager<User> _userManager;
        private readonly RoleManager<Role> _roleManager;

        public AdminRepository(Context context, UserManager<User> userManager,RoleManager<Role> roleManager)
        {
            _context = context;
            _userManager = userManager;
            _roleManager = roleManager;
        }

        public async Task<IEnumerable<User>> GetAllAsync()
        {
            return await _userManager.Users.ToListAsync();

        }

        public async Task<User?> GetByIdAsync(int id)
        {
            var user = await _userManager.FindByIdAsync(id.ToString());
            return user;
        }
        public async Task<User?> GetByDetailsAsync(int id)
        {
            var user = await _context.Users.Include(u=>u.UserAddresses).ThenInclude(d=>d.Address).FirstOrDefaultAsync(ur=>ur.Id==id);
            return user;
        }
        public async Task<bool> UpdateAsync(User user)
        {
         var resualt = _context.Update(user);
            await _context.SaveChangesAsync();

            if (resualt != null)
            {
                return true;
            }else
            {
                return false;
            }
        }
        public async Task<bool> DeleteAsync(int id)
        {
            var user = await GetByIdAsync(id);
            if (user != null)
            {
                _context.Remove(user);
                _context.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }
        }
        public async Task<List<string>> GetAllRoleAsync(int id)
        {
         var user= await GetByIdAsync(id).ConfigureAwait(false);
            var roles = await _userManager.GetRolesAsync(user);
           return roles.ToList();
           
        }
    }
}
