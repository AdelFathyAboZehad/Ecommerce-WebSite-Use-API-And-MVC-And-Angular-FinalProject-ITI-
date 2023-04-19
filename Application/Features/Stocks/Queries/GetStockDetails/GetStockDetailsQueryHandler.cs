using Application.Contracts;
using Dtos.Brand;
using Dtos.Stock;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Stocks.Queries.GetStockDetails
{
    public class GetStockDetailsQueryHandler : IRequestHandler<GetStockDetailsQuery, StockLargeDto>
    {
        private readonly IStockRepository _stockRepository;

        public GetStockDetailsQueryHandler(IStockRepository stockRepository)
        {
            _stockRepository = stockRepository;
        }
        public async Task<StockLargeDto> Handle(GetStockDetailsQuery request, CancellationToken cancellationToken)
        {
            var stock = await _stockRepository.GetDetailsAsync(request.Id);

            if (stock == null)
            {
                throw new Exception($"NO stock with This Id {request.Id}");
            }

            else
            {
                StockLargeDto stoc = new StockLargeDto
                {
                    Id = stock.Id,
                    Name = stock.Name,
                    Address = stock.Address

                };




                foreach (var item in stock.Products)
                {
                    //stoc.Products.Add(item.Name);
                }
                return stoc;

            }
        }
    }
}
