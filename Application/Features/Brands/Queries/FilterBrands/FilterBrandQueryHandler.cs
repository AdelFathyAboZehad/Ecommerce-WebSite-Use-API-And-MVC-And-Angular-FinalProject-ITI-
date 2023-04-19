using Application.Contracts;
using Dtos.Brand;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Brands.Queries.FilterBrands
{
    public class FilterBrandQueryHandler : IRequestHandler<FilterBrandQuery, IEnumerable<BrandMinimalDto>>
    {
        private readonly IBrandRepository _brandRepository;

        public FilterBrandQueryHandler( IBrandRepository brandRepository)
        {
            _brandRepository = brandRepository;
        }
        public async Task<IEnumerable<BrandMinimalDto>> Handle(FilterBrandQuery request, CancellationToken cancellationToken)
        {
            return (await _brandRepository.FilterByAsync(request.filter))
                .Select(brand => new BrandMinimalDto() { Id = brand.Id, NameEN = brand.NameEN ,NameAR = brand.NameAR});
        }
    }
}
