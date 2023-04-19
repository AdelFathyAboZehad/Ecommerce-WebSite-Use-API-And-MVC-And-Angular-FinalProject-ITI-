using Dtos.Variation;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Variations.Queries.GetVariationsDetails
{
    public class GetVariationsDetailsQuery : IRequest<VariationLargeDto>
    {
        public int ID { get; set; }
        public GetVariationsDetailsQuery(int id)
        {
            ID = id;
        }
    }
}
