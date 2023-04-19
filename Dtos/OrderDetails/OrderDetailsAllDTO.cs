using Dtos.Order;

namespace DtosDtos.OrderDetails
{
    public class OrderDetailsAllDTO
    {


        public int Id { get; set; }
        public double Price { get; set; }
        public int Quantity { get; set; }

        //relation with Order
        public virtual OrderMinimalDTO? Order { get; set; }


        public OrderDetailsAllDTO(int id, double price, int quantity, OrderMinimalDTO? order)
        {
            Id = id;
            Price = price;
            Quantity = quantity;
            Order = order;
        }
        ////relation with UserReviews
        //public virtual ICollection<UserReview> UserReviews { get; set; }
        //relation with Product
        // public virtual Product? Product { get; set; }
    }
}
