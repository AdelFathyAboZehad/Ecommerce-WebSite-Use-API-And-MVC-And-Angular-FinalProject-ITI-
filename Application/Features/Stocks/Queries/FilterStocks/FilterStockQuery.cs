using Dtos.Brand;
using Dtos.Stock;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Stocks.Queries.FilterStocks
{
    public class FilterStockQuery : IRequest<IEnumerable<StockMinimalDto>>
    {
        public string? filter { get; set; }
        public string? address { get; set;}
    }
}
