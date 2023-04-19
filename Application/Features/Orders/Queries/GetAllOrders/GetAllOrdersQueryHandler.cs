using Application.Contracts.Orders;
using Dtos.Order;
using MediatR;

namespace Application.Features.Orders.Queries.GetAllOrders
{
    public class GetAllOrdersQueryHandler : IRequestHandler<GetAllOrdersQuery, IEnumerable<OrderMinimalDTO2>>
    {
        private readonly IOrderRepository _orderRepository;

        public GetAllOrdersQueryHandler(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }
        public async Task<IEnumerable<OrderMinimalDTO2>> Handle(GetAllOrdersQuery request, CancellationToken cancellationToken)
        {
           // var v = (await _orderRepository.GetAllAsync()).Where(a => a.Address.UserAddresses.Select(a => a.User.Id == request.userid).FirstOrDefault());
            var v = await _orderRepository.GetAllOrdersForAUserAsync(request.userid);


            return v.Select(a => new OrderMinimalDTO2
            {
                Id = a.Id,
                Status = a.Status,
                Date = a.Date,
                Total = a.Total,
            });
        }
    }
}
