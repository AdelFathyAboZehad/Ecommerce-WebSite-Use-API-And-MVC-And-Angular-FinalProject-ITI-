using AdminSiteUseMVC.Models.Services.GeneralRepositories;
using DbContextL;
using Domian;

namespace AdminSiteUseMVC.Models.Services.ShoppingMethods
{
    public class ShoppingMethodRepository : GeneralRepository<ShoppingMethod, int>
    {
        public ShoppingMethodRepository(Context context) : base(context)
        {
        }
    }
}
