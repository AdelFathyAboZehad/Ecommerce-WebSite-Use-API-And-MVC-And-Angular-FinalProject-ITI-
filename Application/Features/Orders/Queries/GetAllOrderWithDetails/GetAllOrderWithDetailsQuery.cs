using Dtos.Order;
using MediatR;

namespace Application.Features.Orders.Queries.GetAllOrderWithDetails
{
    public class GetAllOrderWithDetailsQuery:IRequest<IEnumerable<OrderDetailsDTO>>
    {
        public int userid { get; set; }

    }
}
