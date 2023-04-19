using System.ComponentModel.DataAnnotations;

namespace Dtos.shoppingMethod
{
    public class ShopingMethodMinimalDTO
    {
       

        public int Id { get; set; }
       
        public string Name { get; set; }
        public decimal Price { get; set; }
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
