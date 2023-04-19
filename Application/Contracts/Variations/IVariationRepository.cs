using Domian;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Contracts.Variations
{
    public interface IVariationRepository : IRepository<Variation, int>
    {
        Task<IEnumerable<Variation>> FilterByAsync(string? filter = null);
    }
}
