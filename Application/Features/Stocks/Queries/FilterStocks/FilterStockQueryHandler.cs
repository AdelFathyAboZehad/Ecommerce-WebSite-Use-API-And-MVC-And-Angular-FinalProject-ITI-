using Application.Contracts;
using Application.Features.Brands.Queries.FilterBrands;
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
    public class FilterStockQueryHandler : IRequestHandler<FilterStockQuery, IEnumerable<StockMinimalDto>>
    {
        private readonly IStockRepository _stockRepository;

        public FilterStockQueryHandler(IStockRepository stockRepository )
        {
            _stockRepository = stockRepository;
        }
        public async Task<IEnumerable<StockMinimalDto>> Handle(FilterStockQuery request, CancellationToken cancellationToken)
        {
            return (await _stockRepository.FilterByAsync(request.filter , request.address))
               .Select(a => new StockMinimalDto() { Id = a.Id, Name = a.Name , Address = a.Address });
        }
    }
}
