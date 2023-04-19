using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domian
{
    [Table("ShoppingMethod")]
    public class ShoppingMethod
    {
        public int Id { get; set; }
        [MinLength(3),MaxLength(100)]
        public string Name { get; set; }
        public decimal Price { get; set; }




        //relation with Order
        public IEnumerable<Order>? Orders { get; set; }
        //private ShoppingMethod():this(null!,0)
        //{
           
        //}
        public ShoppingMethod(string name, decimal price)
        {
            
            Name = name;
            Price = price;
            Orders = new List<Order>();
        }

        public ShoppingMethod() : this(null!, 0)
        {
           
        }
    }
}
