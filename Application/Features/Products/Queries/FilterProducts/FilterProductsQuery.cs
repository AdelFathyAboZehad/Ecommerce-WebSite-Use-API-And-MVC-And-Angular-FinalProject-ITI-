using MediatR;
using Dtos.Product;

namespace Application.Features.Products.Queries.GetAllProducts
{
    public class FilterProductsQuery :IRequest<IEnumerable<ProductMinimalDTO>>
    {
        public string? filter { get; set; }
        public int? price { get; set; }
        public int? Toprice { get; set; }
        public bool? Isavailable { get; set; }
        public bool? HasDiscount { get; set; }
        public int? categoryId { get; set; }
        public int? brandId { get; set; }
       

    }
}
