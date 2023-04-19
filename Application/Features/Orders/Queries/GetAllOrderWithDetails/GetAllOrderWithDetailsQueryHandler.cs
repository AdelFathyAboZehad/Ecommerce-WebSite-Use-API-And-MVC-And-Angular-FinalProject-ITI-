using Application.Contracts.Orders;
using Domian;
using Dtos.Addresses;
using Dtos.Order;
using Dtos.Product;
using MediatR;
using System.Linq;
using System.Security.Cryptography.X509Certificates;

namespace Application.Features.Orders.Queries.GetAllOrderWithDetails
{
    public class GetAllOrderWithDetailsQueryHandler : IRequestHandler<GetAllOrderWithDetailsQuery, IEnumerable<OrderDetailsDTO>>
    {
        private readonly IOrderRepository _orderRepository;

        public GetAllOrderWithDetailsQueryHandler(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }
        public async Task<IEnumerable<OrderDetailsDTO>> Handle(GetAllOrderWithDetailsQuery request, CancellationToken cancellationToken)
        {
            var user = await _orderRepository.GetAllOrderWithDetails(request.userid);
           
            if (user == null)
            {
                throw new Exception("Not Found this Order");
            }
            else
            {

                List<OrderDetailsDTO> lo = new List<OrderDetailsDTO>();
                var orders = user.UserAddresses.Select(a => new
                {
                    order=a.Address.Orders.Select(x=>new OrderDetailsDTO
                    {
                        Id = x.Id,
                        Date = x.Date,
                        Status = x.Status,
                        Total = x.Total,
                        Address = new AddressMinimalDTO
                        {
                            Id = x.Address.Id,
                            UnitNumber = x.Address.UnitNumber,
                            StreetNumber = x.Address.StreetNumber,
                            AddressEN1 = x.Address.AddressEN1,
                            AddressAR1 = x.Address.AddressAR1,
                            AddressEN2 = x.Address.AddressEN2,
                            AddressAR2 = x.Address.AddressAR2,
                            City = x.Address.City,
                            Country = x.Address.Country,
                            PostCode = x.Address.PostCode,
                            Region = x.Address.Region


                        },
                        Products = x.OrderDetails.Select(p => new ProductMinimalDTO
                        {
                            Id = p.Product.Id,
                            NameEN = p.Product.NameEN,
                            DescriptionEN = p.Product.DescriptionEN,
                            DescriptionAR = p.Product.DescriptionAR,
                            DiscountPercentage =p.Product.DiscountPercentage,
                            NameAR =p.Product.NameAR,
                            Price = p.Product.Price,
                            Quantity = p.Product.Quantity,
                            Images =p.Product.Images.Select(i => i.ImageURL).ToList()
                        })
                    })
                });

                foreach(var item in orders)
                {
                    foreach (var item1 in item.order)
                    {
                    lo.Add(new OrderDetailsDTO
                    {
                        Id = item1.Id,
                        Date = item1.Date,
                        Status = item1.Status,
                        Total = item1.Total,
                        Address = new AddressMinimalDTO
                        {
                            Id = item1.Address.Id,
                            UnitNumber = item1.Address.UnitNumber,
                            StreetNumber = item1.Address.StreetNumber,
                            AddressEN1 = item1.Address.AddressEN1,
                            AddressAR1 = item1.Address.AddressAR1,
                            AddressEN2 = item1.Address.AddressEN2,
                            AddressAR2 = item1.Address.AddressAR2,
                            City = item1.Address.City,
                            Country = item1.Address.Country,
                            PostCode = item1.Address.PostCode,
                            Region = item1.Address.Region


                        },
                        Products = item1.Products
                    });

                    }
                }
                
                return lo;
            }

        }
    }
}
