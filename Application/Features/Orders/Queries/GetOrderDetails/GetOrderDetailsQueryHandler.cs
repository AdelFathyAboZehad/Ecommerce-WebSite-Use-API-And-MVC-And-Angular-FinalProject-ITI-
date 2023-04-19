using Application.Contracts.Orders;
using Dtos.Addresses;
using Dtos.Order;
using Dtos.Product;
using MediatR;

namespace Application.Features.Orders.Queries.GetOrderDetails
{
    public class GetOrderDetailsQueryHandler : IRequestHandler<GetOrderDetailsQuery, OrderDetailsDTO>
    {
        private readonly IOrderRepository _orderRepository;

        public GetOrderDetailsQueryHandler(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }
        public async Task<OrderDetailsDTO> Handle(GetOrderDetailsQuery request, CancellationToken cancellationToken)
        {
            var order = await _orderRepository.GetDetailsAsync(request.OrderId);
            if (order == null)
            {
                throw new Exception("Not Found this Order");
            }
            else
            {

                return new OrderDetailsDTO
                {
                    Id = order.Id,
                    Date = order.Date,
                    Status = order.Status,
                    Total = order.Total,
                    Address = new AddressMinimalDTO
                    {
                        Id = order.Address.Id,
                        UnitNumber = order.Address.UnitNumber,
                        StreetNumber = order.Address.StreetNumber,
                        AddressEN1 = order.Address.AddressEN1,
                        AddressAR1 = order.Address.AddressAR1,
                        AddressEN2 = order.Address.AddressEN2,
                        AddressAR2 = order.Address.AddressAR2,
                        City = order.Address.City,
                        Country = order.Address.Country,
                        PostCode = order.Address.PostCode,
                        Region = order.Address.Region


                    },
                    Products = order.OrderDetails.Select(x => new ProductMinimalDTO
                    {
                        Id = x.Product.Id,
                        NameEN = x.Product.NameEN,
                        DescriptionEN = x.Product.DescriptionEN,
                        DescriptionAR = x.Product.DescriptionAR,
                        DiscountPercentage = x.Product.DiscountPercentage,
                        NameAR = x.Product.NameAR,
                        Price = x.Product.Price,
                        Quantity = x.Product.Quantity,
                        Images = x.Product.Images.Select(i => i.ImageURL).ToList()
                    })

                };
            }

        }
    }
}
