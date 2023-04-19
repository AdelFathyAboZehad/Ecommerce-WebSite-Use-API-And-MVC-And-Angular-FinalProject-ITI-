using Application.Contracts;
using DbContextL;
using Domian;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfraStructure
{
    public class CategoryRepository : Repository<Category,int>,ICategoryRepository
    {


        public CategoryRepository(Context context) :base(context)
        {
    
        }
   

        public async Task<IEnumerable<Category>> FilterByAsync(string? filter = null, int? parentCatId = null)
        {
            return _context.Categories
              .Where(a => filter == null ? true : (a.NameEN.ToLower().Contains(filter.ToLower()) || a.NameAR.Contains(filter)))
              .Where(a => parentCatId == null ? true : a.Parentcategory.Id == parentCatId);
        }
        public override async Task<Category?> GetDetailsAsync(int id)
        {
             return _context.Categories.Include(a => a.Products).ThenInclude(x => x.Images).FirstOrDefault(a => a.Id == id);
        }

    }
}
