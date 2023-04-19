using Application.Contracts;
using Application.Contracts.ShoppingMethods;
using MediatR;

namespace Application.Features.ShoppingMethods.Commands.DeleteShoppingMethod
{
    public class DeleteShoppingMethodCommandHandler : IRequestHandler<DeleteShoppingMethodCommand, bool>
    {
        private readonly IShoppingMethod _shoppingMethodRepository;

        public DeleteShoppingMethodCommandHandler(IShoppingMethod shoppingMethodRepository)
        {
            _shoppingMethodRepository = shoppingMethodRepository;
        }
        public async Task<bool> Handle(DeleteShoppingMethodCommand request, CancellationToken cancellationToken)
        {
            return (await _shoppingMethodRepository.DeleteAsync(request.id));
        }
    }
}
