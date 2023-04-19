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
    public class StockRepository : Repository<Stock, int>, IStockRepository
    {

        public StockRepository(Context context) : base(context) { }

        public async Task<IEnumerable<Stock>> FilterByAsync(string? filter = null, string? address = null)
        {
            return  _context.Stocks.Where(a => filter == null ? true : a.Name.ToLower().Contains(filter.ToLower()) || (a.Address == null ? false : a.Address.ToLower().Contains(address.ToLower()))) ;
        }


        public override async Task<Stock?> GetDetailsAsync(int id)
        {
            return  _context.Stocks.Where(a => a.Id == id).Include(a => a.Products).FirstOrDefault();
        }


      
    }
}
