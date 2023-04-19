using MediatR;

namespace Application.Features.ShoppingMethods.Commands.DeleteShoppingMethod
{
    public class DeleteShoppingMethodCommand : IRequest<bool>
    {
        public int id { get; set; }
        
    }
}
