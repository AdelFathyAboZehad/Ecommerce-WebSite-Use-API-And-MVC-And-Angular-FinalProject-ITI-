using Dtos.Order;
using Dtos.OrderDetails;
using MediatR;

namespace Application.Features.Orders.Commands.CreateOrder
{
    public class CreateOrderCommand : IRequest<OrderMinimalDTO>
    {
        public decimal total { get; set; }
        public int shoppingmethodId { get; set; }
        public int addressId { get; set; }
        public int userId { get; set; }
        public List<OrderDetailsCart>? ItemsOfProductListCart { get; set; }

    }
}
