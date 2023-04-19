using AdminSiteUseMVC.Models.Services.GeneralRepositories;
using DbContextL;
using Domian;

namespace AdminSiteUseMVC.Models.Services.Stocks
{
    public class StockRepository : GeneralRepository<Stock, int>
    {
        public StockRepository(Context context):base(context)
        {
            
        }
    }
}
