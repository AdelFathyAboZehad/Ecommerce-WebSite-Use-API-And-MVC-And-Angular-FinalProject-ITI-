using Dtos.Stock;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Stocks.Queries.GetStockDetails
{
    public class GetStockDetailsQuery : IRequest<StockLargeDto>
    {
        public int Id { get; set; }
        public GetStockDetailsQuery(int id)
        {
            Id = id;
        }
    }
}
