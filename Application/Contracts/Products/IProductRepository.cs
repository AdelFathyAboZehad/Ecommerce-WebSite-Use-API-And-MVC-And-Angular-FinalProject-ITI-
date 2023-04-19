using Application.Contracts;
using Domian;

namespace Application.Contracts
{
    public interface IProductRepository : IRepository<Product, long>
    {
        Task<IEnumerable<Product>> FilterByAsync(string? filter = null, int? fromPrice = null, int? toPric = null, bool? IsAvailable = null, bool? hasDiscount = null, int? categoryId = null,int? brandId = null);

    }
}
