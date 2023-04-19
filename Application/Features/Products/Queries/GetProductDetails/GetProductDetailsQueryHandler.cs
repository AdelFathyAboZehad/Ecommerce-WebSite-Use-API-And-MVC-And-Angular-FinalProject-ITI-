using Application.Contracts;
using MediatR;

using Dtos.Product;
using System.Diagnostics;
using System.Xml.Linq;
 

namespace Application.Features.Products.Queries.GetProductDetails
{
    public class GetProductDetailsQueryHandler : IRequestHandler<GetProductDetailsQuery, ProductLargeDto>
    {
        private readonly IProductRepository _productRepository;

        public GetProductDetailsQueryHandler(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }
        public async Task<ProductLargeDto> Handle(GetProductDetailsQuery request, CancellationToken cancellationToken)
        {
            var product =await _productRepository.GetDetailsAsync(request.Id);

            if (product == null)
            {
                throw new Exception($"NO Product with This Id {request.Id}");
            }

            else
            {
                ProductLargeDto p = new ProductLargeDto {
                Id = product.Id,
                NameEN = product.NameEN,
                NameAR = product.NameAR,
                DescriptionEN = product.DescriptionEN,
                DescriptionAR= product.DescriptionAR,
                DiscountPercentage= product.DiscountPercentage,
                Price = product.Price,
                Quantity = product.Quantity,
                BrandNameEN = product.Brand.NameEN,
                BrandNameAR = product.Brand.NameAR
            };
          

               
                
                foreach (var item in product.Categories)
                {
                    p.CategoriesNames.Add(item.NameEN);

                }
                foreach (var item in product.Images)
                {
                    p.Images.Add(item.ImageURL);
                }

                return p;
               
            }
        }

    }
}
