using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domian
{
    [Table("Stock")]
    public class Stock
    {


        public int Id { get; set; }
        [MinLength(3), MaxLength(200)]
        public string Name { get; set; }
        public string Address { get; set; }
        public IEnumerable<Product> Products { get; set; }
        public Stock(string brandName, string stockAddress)
        {
            Name = brandName;
            Address = stockAddress;
            Products = new List<Product>(); ;

        }
        public Stock() : this(null!, null!) { }
        //public bool AddProduct(Product product)
        //{

        //    var checkProductName = Products.FirstOrDefault(a => a.Name == product.Name);
        //    if (checkProductName != null)
        //    {
        //        return false;
        //    }
        //    else
        //    {
        //        _products.Add(product);
        //        return true;
        //    }
        //}
    }
}
