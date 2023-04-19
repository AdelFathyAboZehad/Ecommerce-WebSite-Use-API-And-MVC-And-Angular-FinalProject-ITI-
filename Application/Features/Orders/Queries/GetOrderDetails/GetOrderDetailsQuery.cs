using Dtos.Order;
using MediatR;

namespace Application.Features.Orders.Queries.GetOrderDetails
{
    public class GetOrderDetailsQuery : IRequest<OrderDetailsDTO>
    {
        public int OrderId { get; set; }
    }
}
