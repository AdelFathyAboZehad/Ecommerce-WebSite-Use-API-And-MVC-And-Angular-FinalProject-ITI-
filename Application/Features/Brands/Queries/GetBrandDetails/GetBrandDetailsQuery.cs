using Dtos.Brand;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Brands.Queries.GetBrandDetails
{
    public class GetBrandDetailsQuery : IRequest<BrandLargeDto>
    {
        public int Id { get; set; }
        public GetBrandDetailsQuery(int id)
        {
            Id = id;
        }
    }
}
