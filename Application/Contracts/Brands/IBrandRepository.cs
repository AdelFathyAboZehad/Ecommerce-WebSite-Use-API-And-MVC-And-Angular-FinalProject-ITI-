using Domian;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Contracts
{
    public interface IBrandRepository : IRepository<Brand, int>
    {
        Task<IEnumerable<Brand>> FilterByAsync(string? filter = null , int? id=null);
    }
}
