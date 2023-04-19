 
using Dtos.shoppingMethods;
using MediatR;

namespace Application.Features.ShoppingMethods.Queries.GetShoppingMethodDetails
{
    public class GetShoppingMethodDetailsQuery : IRequest<ShopingMethodMinimalDTO>
    {


        public int Id { get; set; }


    }
}
