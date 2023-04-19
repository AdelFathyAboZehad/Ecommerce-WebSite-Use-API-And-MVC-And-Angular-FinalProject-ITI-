using AdminSiteUseMVC.Models.Services.GeneralRepositories;
using DbContextL;
using Domian;

namespace AdminSiteUseMVC.Models.Services.Brands
{
    public class BrandRepository : GeneralRepository<Brand, int>
    {
        public BrandRepository(Context context) : base(context)
        {
        }
    }
}
