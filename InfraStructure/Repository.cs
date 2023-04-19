using Application.Contracts;
using DbContextL;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace InfraStructure
{
    public class Repository<TEntity, TId> : IRepository<TEntity, TId> where TEntity : class
    {
        
        protected readonly Context _context;
        protected readonly DbSet<TEntity> _dbset;

        public Repository(Context context)
        {
            _context = context;
            _dbset = _context.Set<TEntity>();
        }
        public virtual async Task<TEntity?> GetDetailsAsync(TId id)
        {
            var re = await _dbset.FindAsync(id);
            return re;
        }

        public async Task<TEntity> CreateAsync(TEntity item)
        {
            var Item = (await _dbset.AddAsync(item)).Entity;
            _context.SaveChanges();
            return Item;
        }
        public Task<bool> UpdateAsync(TEntity item)
        {
            var entity = _dbset.Update(item);
            _context.SaveChanges();
            if (entity != null)
            {
                return Task.FromResult(true);
            }
            else
            {
                return Task.FromResult(false);
            }
        }
        public async Task<bool> DeleteAsync(TId id)
        {
            var item = await GetDetailsAsync(id);
            if (item != null)
            {
                _dbset.Remove(item);
                _context.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }

        }

        public  async Task< IEnumerable<TEntity>> GetAllAsync()
        {
            return await Task.FromResult(_dbset);
            //if (_dbset != null)
            //{
            //    return await Task.FromResult(_dbset);
                
            //}
            //else
            //{
            //    throw new Exception("not valid");
            //}
        }
    }
}
