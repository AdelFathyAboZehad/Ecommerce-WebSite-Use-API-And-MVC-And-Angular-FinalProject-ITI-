using AdminSiteUseMVC.Models.Services.GeneralRepositories;
using DbContextL;
using Domian;

namespace AdminSiteUseMVC.Models.Services.Categories
{
    public class CategoryReopsitory : GeneralRepository<Category, int>
    {
        public CategoryReopsitory(Context context) : base(context)
        {
        }
    }
}
