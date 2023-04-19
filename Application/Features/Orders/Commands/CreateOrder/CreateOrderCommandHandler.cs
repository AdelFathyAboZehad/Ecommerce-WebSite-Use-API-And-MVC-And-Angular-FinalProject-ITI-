using Application.Contracts;
using Application.Contracts.Addresses;
using Application.Contracts.OrderDetailss;
using Application.Contracts.Orders;
using Application.Contracts.ShoppingMethods;
using Domian;
using Dtos.Order;
using Dtos.OrderDetails;
using Dtos.shoppingMethod;
using MediatR;

namespace Application.Features.Orders.Commands.CreateOrder
{
    public class CreateOrderCommandHandler : IRequestHandler<CreateOrderCommand, OrderMinimalDTO>
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IProductRepository _productRepository;
        private readonly IOrderDetailsRepository _orderDetailsRepository;
        private readonly IUserRepository _userRepository;
        private readonly IShoppingMethod _shoppingMethod;
        private readonly IAddressRepository _addressRepository;

        public CreateOrderCommandHandler(
            IOrderRepository orderRepository,
            IShoppingMethod shoppingMethod, 
            IAddressRepository addressRepository,
            IProductRepository productRepository,
            IOrderDetailsRepository orderDetailsRepository,
            IUserRepository userRepository
            )
        {
            _orderRepository = orderRepository;
            _productRepository = productRepository;
            _orderDetailsRepository = orderDetailsRepository;
            _userRepository = userRepository;
            _shoppingMethod = shoppingMethod;
            _addressRepository = addressRepository;
        }
        public async Task<OrderMinimalDTO> Handle(CreateOrderCommand request, CancellationToken cancellationToken)
        {
            var shoppingMethod = await _shoppingMethod.GetDetailsAsync(request.shoppingmethodId);
            var address = await _addressRepository.GetDetailsAsync(request.addressId);
            var user = await _userRepository.GetByIdAsync(request.userId);
            Order or = new Order
            {
                Status="pending",
                Total = request.total,
                Date = DateTime.Now,
                Address = address,
                ShoppingMethod = shoppingMethod,
            };

            var myorder = await _orderRepository.CreateAsync(or);

             List<OrderDetails> orderDetails = new List<OrderDetails>();
            var x = request.ItemsOfProductListCart; 
            int x1 = 0;
            foreach (var item in request.ItemsOfProductListCart)
            {

                var product = await _productRepository.GetDetailsAsync(item.ProductId);
                //var product = await _productRepository.Get

                var orderDetailsTemp =new OrderDetails
                {
                    Order=myorder,
                    Product=product,
                    Price=item.Price,
                    Quantity=item.Quantity,
                };
                await _orderDetailsRepository.CreateAsync(orderDetailsTemp);

                orderDetails.Add(orderDetailsTemp);
            }
            myorder.OrderDetails = orderDetails;
            await _orderRepository.UpdateAsync(myorder);

            return new OrderMinimalDTO {
                Id = myorder.Id,
                Date = myorder.Date,
                Total = myorder.Total,
                Status = "Pending",
                Address = new Dtos.Addresses.AddressMinimalDTO
                {
                    AddressAR1 = myorder.Address.AddressAR1,
                    AddressAR2 = myorder.Address.AddressAR2,
                    AddressEN1 = myorder.Address.AddressEN1,
                    AddressEN2 = myorder.Address.AddressEN2,
                    City = myorder.Address.City,
                    Region = myorder.Address.Region,
                    Country = myorder.Address.Country,
                    PostCode = myorder.Address.PostCode,
                    StreetNumber = myorder.Address.StreetNumber,
                    UnitNumber = myorder.Address.UnitNumber,
                    Id = myorder.Address.Id
                },
                User = new Dtos.Users.UserMinimalDto
                {
                    FirstName = user.Fname,
                    LastName = user.Fname,
                    UserName= user.UserName
                },
                ShoppingMethod= new ShopingMethodMinimalDTO()
                {
                    Id =  shoppingMethod.Id,
                    Name = shoppingMethod.Name,
                    Price=shoppingMethod.Price
                }

            };
        }
    }
}
