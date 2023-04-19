using AdminSiteUseMVC.Models.IRepository.IGeneralRepositories;
using DbContextL;
using Microsoft.EntityFrameworkCore;

namespace AdminSiteUseMVC.Models.Services.GeneralRepositories
{
    public class GeneralRepository<TEntity,TId> : IGereralRepository<TEntity, TId> where TEntity : class
    {
        protected readonly Context _context;
        private readonly DbSet<TEntity> _dbSet;
        public GeneralRepository(Context context)
        {
            _context = context;
            _dbSet = _context.Set<TEntity>();
        }
        public async Task<IEnumerable<TEntity>> GetAllAsync()
        {
            return  (IEnumerable<TEntity>) _dbSet;

        }

        public async Task<TEntity?> GetByIdAsync(TId id)
        {
            return await _dbSet.FindAsync(id);
        }

        public async Task<TEntity> CreatAsync(TEntity item)
        {
            var data = (await _dbSet.AddAsync(item)).Entity;
            await _context.SaveChangesAsync();
            return data;
        }

        public async Task<bool> DeleteAsync(TId id)
        {
            var item = await _dbSet.FindAsync(id);
            if (item != null)
            {
                _dbSet.Remove(item);
                await _context.SaveChangesAsync();
                return true;
            }
            else
            {
                return false;
            }
        }

        public async Task<bool> UpdateAsync(TEntity item)
        {
            var entity = _dbSet.Update(item);
            if (entity != null)
            {
                await _context.SaveChangesAsync();
                return true;
            }
            else
            {
                return false;
            }
        }

    }
}
