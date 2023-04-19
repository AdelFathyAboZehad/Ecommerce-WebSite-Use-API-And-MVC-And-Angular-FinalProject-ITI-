using MediatR;

namespace Application.Features.ShoppingMethods.Commands.UpdateShoppingMethod
{
    public class UpdateShoppingMethodCommand : IRequest<bool>
    {
        public int Id { get; set; }

        public string? Name { get; set; }
        public double? Price { get; set; }
        public UpdateShoppingMethodCommand(string name, double price)
        {
            // Id = id;
            Name = name;
            Price = price;
        }
    }
}
