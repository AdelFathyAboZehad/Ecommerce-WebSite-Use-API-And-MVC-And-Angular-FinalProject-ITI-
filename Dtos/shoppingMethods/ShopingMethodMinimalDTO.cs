using System.ComponentModel.DataAnnotations;

namespace Dtos.shoppingMethods
{
    public class ShopingMethodMinimalDTO
    {
       

        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        //public List<int> OrderIds { get; set; } = new List<int>();
        public ShopingMethodMinimalDTO(int id, string name, decimal price)
        {
            Id = id;
            Name = name;
            Price = price;
        }
        public ShopingMethodMinimalDTO()
        {

        }

    }
}
