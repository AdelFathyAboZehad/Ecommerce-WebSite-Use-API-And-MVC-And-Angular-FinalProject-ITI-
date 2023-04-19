using Application.Contracts.ShoppingMethods;
using DbContextL;
using Domian;

namespace InfraStructure.ShoppingMethods
{
    public class ShoppingMethodRepository : Repository<ShoppingMethod, int>, IShoppingMethod
    {
        public ShoppingMethodRepository(Context context) : base(context)
        {
        }

    }
}
