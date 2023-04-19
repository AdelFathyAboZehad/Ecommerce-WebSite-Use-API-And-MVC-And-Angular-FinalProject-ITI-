using Application.Contracts;
using MediatR;
using Dtos.Category;
using Dtos.Product;
using Application.Features.Products.Queries.GetAllProducts;

namespace Application.Features.Products.Queries.GetAllProducts
{
    public class FilterProductsQueryHandler:IRequestHandler<FilterProductsQuery, IEnumerable<ProductMinimalDTO>>
    {
        private readonly IProductRepository _productRepository;

        public FilterProductsQueryHandler(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }
        public async Task<IEnumerable<ProductMinimalDTO>> Handle(FilterProductsQuery request, CancellationToken cancellationToken)
        {
            //  var product = (await _productRepository.GetAllAsync());

            //if (product != null)
            //{
            //    foreach (var item in product)
            //    {
           
                    return (await _productRepository.FilterByAsync(request.filter, request.price, request.Toprice, request.Isavailable, request.HasDiscount ,request.categoryId,request.brandId))
                          .Select(c => new ProductMinimalDTO()
                          { Id = c.Id, NameEN = c.NameEN, NameAR = c.NameAR,
                              DescriptionEN = c.DescriptionEN, DescriptionAR= c.DescriptionAR,
                              Price = c.Price, Quantity = c.Quantity,  DiscountPercentage = c.DiscountPercentage,
                              Images = c.Images.Where(a => a.Product.Id == c.Id).Select(l => l.ImageURL).ToList() });
            //    } //
            //}
            // return null;
        }


    }
}
