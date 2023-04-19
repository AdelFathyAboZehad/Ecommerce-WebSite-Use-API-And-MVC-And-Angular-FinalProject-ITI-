using Domian;

namespace Dtos.OrderDetails
{
    public class OrderDetialsMinimalDTO
    {
        public int Id { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
        public int OrderID { get; set; }
        public long ProductId { get; set; }
    }
}
