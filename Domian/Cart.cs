using System.ComponentModel.DataAnnotations.Schema;

namespace Domian
{
    [Table("Cart")]
    public class Cart
    {
       

        public int Id { get; set; }

        public int Quantity { get; set; }

        //relation with User

        public  User User { get; set; }

        //relation with Product
        public  Product Product { get; set; }
        public Cart( int quantity, User user, Product product)
        {
           
            Quantity = quantity;
            User = user;
            Product = product;
        }
        public Cart( ):this(0,null!,null!)
        {
            
           
          
        }

        //public Cart():this(0, 0, null!, null!)
        //{

        //}

    }
}
