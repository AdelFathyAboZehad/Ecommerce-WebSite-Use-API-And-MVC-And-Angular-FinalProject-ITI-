using Application.Contracts;
using Domian;

namespace Application.Contracts
{

    public interface ICategoryRepository : IRepository<Category, int>
    {
       Task<IEnumerable<Category>> FilterByAsync(string? filter = null , int ? parentCatId=null);

       
    }
}
