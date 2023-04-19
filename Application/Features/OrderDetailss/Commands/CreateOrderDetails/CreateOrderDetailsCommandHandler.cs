using Application.Contracts;
using Application.Contracts.OrderDetailss;
using Dtos.OrderDetails;
using MediatR;

namespace Application.Features.OrderDetailss.Commands.CreateOrderDetails
{
    public class CreateOrderDetailsCommandHandler : IRequestHandler<CreateOrderDetailsCommand, OrderDetialsMinimalDTO>
    {
        private readonly IOrderDetailsRepository _orderDetailsRepository;
        private readonly IProductRepository _productRepository;

        public CreateOrderDetailsCommandHandler(
            IOrderDetailsRepository orderDetailsRepository,
            IProductRepository productRepository)
        {
            _orderDetailsRepository = orderDetailsRepository;
            _productRepository = productRepository;
        }

        public Task<OrderDetialsMinimalDTO> Handle(CreateOrderDetailsCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
