using AdminSiteUseMVC.Models.Services.GeneralRepositories;
using DbContextL;
using Domian;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography;

namespace AdminSiteUseMVC.Models.Services.Products
{
    public class ProductRepository : GeneralRepository<Product, long>
    {
        public ProductRepository(Context context) : base(context)
        {
        }

        public  async Task<Product?> GetByIdAllDetailsAsync(long id)
        {
            return await(
                _context.Products
                .Include(p=>p.Images)
                .Include(p=>p.Categories)
                .Include(p=>p.Stock)
                .Include(p=>p.Brand)
                .FirstAsync(p=>p.Id==id));
        }
        public async Task<IEnumerable<Product>> GetAllProductsWithImagesAsync()
        {
            return await Task.FromResult<IEnumerable<Product>>( 
                _context.Products
                .Include(p => p.Images)) ;
        }
        
    }
}
