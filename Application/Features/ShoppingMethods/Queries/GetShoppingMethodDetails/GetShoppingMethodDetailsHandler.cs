using Application.Contracts;
using Application.Contracts.ShoppingMethods;
using Dtos.shoppingMethods;
using MediatR;

namespace Application.Features.ShoppingMethods.Queries.GetShoppingMethodDetails
{
    public class GetShoppingMethodDetailsHandler:IRequestHandler<GetShoppingMethodDetailsQuery, ShopingMethodMinimalDTO >
    {
        private readonly IShoppingMethod _shoppingMethodRepository;

        public GetShoppingMethodDetailsHandler(IShoppingMethod shoppingMethodRepository)
        {
            _shoppingMethodRepository = shoppingMethodRepository;
        }

        public async Task<ShopingMethodMinimalDTO> Handle(GetShoppingMethodDetailsQuery request, CancellationToken cancellationToken)
        {
            var shopingMethod = await _shoppingMethodRepository.GetDetailsAsync(request.Id);
            if (shopingMethod != null)
            {
                return new ShopingMethodMinimalDTO(shopingMethod.Id, shopingMethod.Name, shopingMethod.Price);

            }
            else
            {
                throw new Exception("Not Found A Category");
            }

        }
    }
}
