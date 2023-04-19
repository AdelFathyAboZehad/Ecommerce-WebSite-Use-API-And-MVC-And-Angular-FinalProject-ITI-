using Application.Contracts;
using Application.Contracts.Variations;
using Dtos.Brand;
using Dtos.Variation;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Variations.Queries.FilterVariations
{
    public class FilterVariationsQueryHandler : IRequestHandler<FilterVariationsQuery, IEnumerable<VariationMinimalDto>>
    {
        private readonly IVariationRepository _variationRepository;

        public FilterVariationsQueryHandler(IVariationRepository variationRepository)
        {
            _variationRepository = variationRepository;
        }
        public async Task<IEnumerable<VariationMinimalDto>> Handle(FilterVariationsQuery request, CancellationToken cancellationToken)
        {
            return (await _variationRepository.FilterByAsync(request.filter))
                .Select(V => new VariationMinimalDto() { Id = V.Id, Name = V.Name });
        }
    }
}
