using Dtos.Addresses;
using Dtos.shoppingMethod;
using Dtos.Users;

namespace Dtos.Order
{
    public class OrderMinimalDTO2
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public decimal Total { get; set; }
        public string? Status { get; set; }
    

    }
}
