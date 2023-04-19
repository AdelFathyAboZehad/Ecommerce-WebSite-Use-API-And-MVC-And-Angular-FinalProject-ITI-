using Application.Contracts;
using Application.Contracts.ShoppingMethods;
using Domian;
using Dtos.shoppingMethods;
using MediatR;


namespace Application.Features.ShoppingMethods.Commands.CreateShoppingMethod
{
    public class CreateShoppingMethodCommandHandler : IRequestHandler<CreateShoppingMethodCommand, ShopingMethodMinimalDTO>
    {
        private readonly IShoppingMethod _shoppingMethodRepository;

        public CreateShoppingMethodCommandHandler(IShoppingMethod shoppingMethodRepository)
        {
            _shoppingMethodRepository = shoppingMethodRepository;
        }
        public async Task<ShopingMethodMinimalDTO> Handle(CreateShoppingMethodCommand request, CancellationToken cancellationToken)
        {
            User user = new User();

            ShoppingMethod shoppingMethod = new ShoppingMethod(request.Name, (decimal)request.Price);
            await _shoppingMethodRepository.CreateAsync(shoppingMethod);


            if (shoppingMethod != null)
            {
                return new ShopingMethodMinimalDTO(shoppingMethod.Id, shoppingMethod.Name, shoppingMethod.Price);
            }
            else
            {
                throw new Exception("can not create a shopingmethod");
            }
        }
    }
}
