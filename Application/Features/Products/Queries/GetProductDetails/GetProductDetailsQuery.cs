using MediatR;
using Dtos.Product;

namespace Application.Features.Products.Queries.GetProductDetails
{
    public class GetProductDetailsQuery:IRequest<ProductLargeDto>
    {
        public long Id { get; set; }
        public GetProductDetailsQuery(long id)
        {
            Id = id;

        }
    }
}
