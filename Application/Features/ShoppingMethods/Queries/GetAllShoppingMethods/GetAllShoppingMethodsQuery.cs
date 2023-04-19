using Dtos.shoppingMethods;
using MediatR;

namespace Application.Features.ShoppingMethods.Queries.GetAllShoppingMethods
{
    public class GetAllShoppingMethodsQuery:IRequest<IEnumerable<ShopingMethodMinimalDTO>>
    {

    }
}
