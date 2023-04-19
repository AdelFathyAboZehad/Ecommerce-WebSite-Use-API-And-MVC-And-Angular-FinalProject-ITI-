using Dtos.Addresses;
using Dtos.shoppingMethod;
using Dtos.Users;

namespace Dtos.Order
{
    public class OrderMinimalDTO
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public decimal Total { get; set; }
        public string? Status { get; set; }
        public ShopingMethodMinimalDTO ShoppingMethod { get; set; }
        public AddressMinimalDTO Address { get; set; }
        public UserMinimalDto User { get; set; }

    }
}
