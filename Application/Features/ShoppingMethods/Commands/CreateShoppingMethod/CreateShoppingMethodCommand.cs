 
using Dtos.shoppingMethods;
using MediatR;

namespace Application.Features.ShoppingMethods.Commands.CreateShoppingMethod
{
    public class CreateShoppingMethodCommand:IRequest<ShopingMethodMinimalDTO>
    {
        //public int Id { get; set; }

        public string Name { get; set; }
        public decimal Price { get; set; }
        public CreateShoppingMethodCommand(string name, decimal price)
        {
           // Id = id;
            Name = name;
            Price = price;
        }
    }
}
