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
    public class FilterVariationsQuery : IRequest<IEnumerable<VariationMinimalDto>>
    {
        public string? filter { get; set; }
    }
    
}
