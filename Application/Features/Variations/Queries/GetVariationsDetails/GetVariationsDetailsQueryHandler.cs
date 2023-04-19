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

namespace Application.Features.Variations.Queries.GetVariationsDetails
{
    public class GetVariationsDetailsQueryHandler : IRequestHandler<GetVariationsDetailsQuery, VariationLargeDto>
    {
        private readonly IVariationRepository _variationRepository;

        public GetVariationsDetailsQueryHandler(IVariationRepository variationRepository)
        {
            _variationRepository = variationRepository;
        }
        public async Task<VariationLargeDto> Handle(GetVariationsDetailsQuery request, CancellationToken cancellationToken)
        {
            var Variation = await _variationRepository.GetDetailsAsync(request.ID);

            if (Variation == null)
            {
                throw new Exception($"NO Variation with This Id {request.ID}");
            }

            else
            {
                VariationLargeDto variat = new VariationLargeDto
                {
                    Id = Variation.Id,
                    Name = Variation.Name,

                };




                foreach (var item in Variation.VariationOptions)
                {
                    variat.VariationOptions.Add(item.Value);
                }
                return variat;

            }
        }
    }
}
