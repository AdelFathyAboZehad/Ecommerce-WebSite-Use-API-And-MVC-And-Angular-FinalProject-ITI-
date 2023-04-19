using System.ComponentModel.DataAnnotations.Schema;

namespace Domian

{
    public enum MyStatus { Binding, InProgress, DeliveryWay, Delivered }
    [Table("Order")]
    public class Order
    {


        public int Id { get; set; }
        public DateTime Date { get; set; }
        public decimal Total { get; set; }
        public string? Status { get; set; }
        //relation with OrderDetails

        public IEnumerable<OrderDetails> OrderDetails { get; set; }

        //relation with User

        //public virtual User User { get; set; }
        //relation with UserPaymetMethod

        public UserPaymetMethod? UserPaymetMethod { get; set; }

        //relation with ShoppingMethod

        public ShoppingMethod ShoppingMethod { get; set; }

        //relation with Address
        public Address Address { get; set; }

        public Order(decimal total, string status, UserPaymetMethod? userPaymetMethod, ShoppingMethod shoppingMethod, Address address, DateTime date)
        {
            Total = total;
            Status = status;
            UserPaymetMethod = userPaymetMethod;
            ShoppingMethod = shoppingMethod;
            Address = address;
            Date = date;
            OrderDetails = new List<OrderDetails>();

        }

        public Order() : this(0, null!, null!, null!, null!, DateTime.Now)
        {


        }
        //public Order():this(0,null!, null!, null!, null!, null!, DateTime.Now)
        //{

        //}


    }
}
