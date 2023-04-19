using Application.Contracts;
using DbContextL;
using Domian;
using Microsoft.EntityFrameworkCore;

namespace InfraStructure
{
    public class BrandRepository : Repository<Brand, int>, IBrandRepository
    {
        public BrandRepository(Context context) : base(context) { }

        public async Task<IEnumerable<Brand>> FilterByAsync(string? filter = null , int? id =null)
        {
            return _context.Brands.Where(a => filter == null ? true :( a.NameEN.ToLower().Contains(filter.ToLower()) || a.NameAR.Contains(filter)))
                .Where(a => id == null ? true : a.Id == id.Value);  
        }


        public override async Task<Brand?> GetDetailsAsync(int id)
        {
            return _context.Brands.Where(a => a.Id == id).Include(a => a.Products).ThenInclude(x=>x.Images).FirstOrDefault();
        }

    }
}
