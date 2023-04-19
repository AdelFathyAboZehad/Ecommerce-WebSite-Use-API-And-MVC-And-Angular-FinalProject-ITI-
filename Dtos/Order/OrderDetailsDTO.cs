using Dtos.Addresses;
using Dtos.Product;

namespace Dtos.Order
{
    public class OrderDetailsDTO
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public decimal Total { get; set; }
        public string? Status { get; set; }
        public  IEnumerable<ProductMinimalDTO>? Products { get; set; }
        public AddressMinimalDTO Address { get; set; }
    }
}
