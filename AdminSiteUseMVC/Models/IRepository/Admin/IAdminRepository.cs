using AdminSiteUseMVC.ViewModel.Admin;
using Domian;

namespace AdminSiteUseMVC.Models.IRepository.Admin
{
    public interface IAdminRepository
    {
        Task<IEnumerable<User>> GetAllAsync();
        Task<User?> GetByIdAsync(int id);
        Task<bool> UpdateAsync(User user);
        Task<bool> DeleteAsync(int id);
        Task<User?> GetByDetailsAsync(int id);
        Task<List<string>> GetAllRoleAsync(int id);
    }
}
