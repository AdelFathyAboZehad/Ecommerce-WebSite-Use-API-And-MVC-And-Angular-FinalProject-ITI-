using Domian;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domian
{
    [Table("WishList")]
    public class WishList
    {

        public int Id { get; set; }
        public Product Product { get; set; }
        public User User { get; set; }
        public WishList(Product product, User user)
        {
            Product = product;
            User = user;

        }
        public WishList() : this(null!, null!)
        {
        }
    }
}
