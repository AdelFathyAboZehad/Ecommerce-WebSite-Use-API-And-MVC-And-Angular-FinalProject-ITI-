using Dtos.Brand;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Brands.Queries.FilterBrands
{
    public class FilterBrandQuery :IRequest<IEnumerable<BrandMinimalDto>>
    {
        public string? filter { get; set; }
        public int? id { get; set; }
     }
}
