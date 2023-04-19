using System.ComponentModel.DataAnnotations.Schema;

namespace Domian
{

    [Table("OrderDetails")]
    public class OrderDetails
    {
     
        public int Id { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }

        //relation with Order
        public Order Order { get; set; }
        ////relation with UserReviews
        //public virtual ICollection<UserReview> UserReviews { get; set; }

        //relation with Product
        public Product Product { get; set; }


        public OrderDetails(decimal price, int quantity, Order order, Product product)
        {
            Price = price;
            Quantity = quantity;
            Order = order;
            Product = product;
        }
        public OrderDetails():this(0,0,null!,null!)
        {
            
        }




    }

}
