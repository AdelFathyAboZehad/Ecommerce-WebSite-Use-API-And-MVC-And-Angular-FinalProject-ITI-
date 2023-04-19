using Application.Contracts;
using Dtos.Brand;
using Dtos.Product;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Brands.Queries.GetBrandDetails
{
    public class GetBrandDetailsQueryHandler : IRequestHandler<GetBrandDetailsQuery, BrandLargeDto>
    {
        private readonly IBrandRepository _brandRepository;
        private readonly IProductRepository _productRepository;

        public GetBrandDetailsQueryHandler(IBrandRepository brandRepository,IProductRepository productRepository)
        {
            _brandRepository = brandRepository;
            _productRepository = productRepository;
        }
        public async Task<BrandLargeDto> Handle(GetBrandDetailsQuery request, CancellationToken cancellationToken)
        {
            var brand = await _brandRepository.GetDetailsAsync(request.Id);

            if (brand == null)
            {
                throw new Exception($"NO brand with This Id {request.Id}");
            }

            else
            {
                BrandLargeDto p = new BrandLargeDto
                {
                    Id = brand.Id,
                    NameEN = brand.NameEN, 
                    NameAR = brand.NameAR
                   //productMinimalDTOs=brand.Products.Select()
                       
                };

                List<ProductMinimalDTO> productMinimal= new List<ProductMinimalDTO>();

              
                var x =  (await _productRepository.FilterByAsync())
                         .Select(c => new ProductMinimalDTO()
                         { Id = c.Id, NameEN = c.NameEN, NameAR=c.NameAR,
                             DescriptionEN = c.DescriptionEN, DescriptionAR=c.DescriptionAR,
                             Price = c.Price, Quantity = c.Quantity, DiscountPercentage=c.DiscountPercentage,
                             Images = c.Images.Where(a => a.Product.Id == c.Id).Select(l => l.ImageURL).ToList() }).ToList();


                foreach (var item in x)
                {
                    if (brand.Products.Where(a=>a.Id==item.Id && brand.Id==a.Brand.Id).Select(a=>a.Brand.Id==brand.Id).FirstOrDefault()) {
                        productMinimal.Add(item);
                    }
                }


                 p.productMinimalDTOs = productMinimal;
                //foreach (var item in brand.Products)
                //{
                //    p.Products.Add(item.Name);
                //    foreach (var i in item.Images) {
                //       
                //    }
                //    //p.Images=(item.Images.Where(a => a.Product.Id == item.Id).Select(l => l.ImageURL).FirstOrDefault());
                //};

                return p;

            }
        }
    }
}
