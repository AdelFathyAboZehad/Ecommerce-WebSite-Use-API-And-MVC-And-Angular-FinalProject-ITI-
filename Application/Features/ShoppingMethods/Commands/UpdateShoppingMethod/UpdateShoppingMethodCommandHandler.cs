using Application.Contracts;
using Application.Contracts.ShoppingMethods;
using MediatR;

namespace Application.Features.ShoppingMethods.Commands.UpdateShoppingMethod
{
    public class UpdateShoppingMethodCommandHandler : IRequestHandler<UpdateShoppingMethodCommand, bool>
    {
        private readonly IShoppingMethod _shoppingMethodRepository;

        public UpdateShoppingMethodCommandHandler(IShoppingMethod shoppingMethodRepository)
        {
            _shoppingMethodRepository = shoppingMethodRepository;
        }
        public async Task<bool> Handle(UpdateShoppingMethodCommand request, CancellationToken cancellationToken)
        {

            var shoppingMethod = await _shoppingMethodRepository.GetDetailsAsync(request.Id);
           if(shoppingMethod == null)
            {
                return false;
            }
           else
            {
                if (request.Price != null)
                {
                    shoppingMethod.Price = (decimal)request.Price;
                }
                if (request.Name != null)
                {
                    shoppingMethod.Name = request.Name;
                }
                return await _shoppingMethodRepository.UpdateAsync(shoppingMethod);

            }
        }
    }
}
