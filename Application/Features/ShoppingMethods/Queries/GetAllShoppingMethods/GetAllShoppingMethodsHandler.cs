using Application.Contracts;
using Application.Contracts.ShoppingMethods;
using Dtos.shoppingMethods;
using MediatR;

namespace Application.Features.ShoppingMethods.Queries.GetAllShoppingMethods
{
    public class GetAllShoppingMethodsHandler : IRequestHandler<GetAllShoppingMethodsQuery, IEnumerable<ShopingMethodMinimalDTO>>
    {
        private readonly IShoppingMethod _shoppingMethodRepository;

        public GetAllShoppingMethodsHandler(IShoppingMethod shoppingMethodRepository)
        {
            _shoppingMethodRepository = shoppingMethodRepository;
        }

        public async Task<IEnumerable<ShopingMethodMinimalDTO>> Handle(GetAllShoppingMethodsQuery request, CancellationToken cancellationToken)
        {
            var Shiping = (await _shoppingMethodRepository.GetAllAsync()).Select(a => new ShopingMethodMinimalDTO(a.Id, a.Name, a.Price)).ToList();
            var x = 1;
            return Shiping;

        }
    }
}
