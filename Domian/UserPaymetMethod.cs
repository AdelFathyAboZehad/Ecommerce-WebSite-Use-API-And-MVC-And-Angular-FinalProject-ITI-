using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domian
{
    [Table("UserPaymetMethod")]
    public class UserPaymetMethod
    {

        public int Id { get; set; }

        [MinLength(10), MaxLength(200)]
        public string Provider { get; set; }
        [MinLength(14), MaxLength(50)]
        public string AccountNumber { get; set; }
        public DateTime ExpritDate { get; set; }
        public bool? IsDefault { get; set; }

        //relation with Order
        public IEnumerable<Order> Orders { get; set; }

        //relation with User

        public User User { get; set; }

        public UserPaymetMethod(string provider, string accountNumber, DateTime expritDate, User user, bool? isDefault = null)
        {
            Provider = provider;
            AccountNumber = accountNumber;
            ExpritDate = expritDate;
            IsDefault = isDefault;
            User = user;
            Orders = new List<Order>();

        }
        public UserPaymetMethod() : this(null!, null!, DateTime.Now, null!)
        {

        }
    }
}
