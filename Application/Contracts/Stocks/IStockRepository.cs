using Domian;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Contracts
{
    public interface IStockRepository : IRepository<Stock,int>
    {
        Task<IEnumerable<Stock>> FilterByAsync(string? filter = null,string? address=null);
    }
}
