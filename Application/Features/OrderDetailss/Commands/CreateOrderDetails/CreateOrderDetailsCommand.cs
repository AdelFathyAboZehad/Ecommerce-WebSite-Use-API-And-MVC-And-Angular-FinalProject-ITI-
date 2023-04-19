using Dtos.OrderDetails;
using MediatR;

namespace Application.Features.OrderDetailss.Commands.CreateOrderDetails
{
    public class CreateOrderDetailsCommand: IRequest<OrderDetialsMinimalDTO>
    {
        public decimal Price { get; set; }
        public int Quantity { get; set; }
        public int OrderID { get; set; }
        public long ProductId { get; set; }
    }
}
